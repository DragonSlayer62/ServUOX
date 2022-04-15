using System;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a solen queen corpse")]
    public class RedSolenQueen : BaseCreature, IRedSolen
    {
        private bool m_BurstSac;
        private static bool m_Laid;

        [Constructible]
        public RedSolenQueen()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a red solen queen";
            Body = 783;
            BaseSoundID = 959;

            SetStr(296, 320);
            SetDex(121, 145);
            SetInt(76, 100);

            SetHits(151, 162);

            SetDamage(ResistType.Phys, 70, 0, 10, 15);
            SetDamage(ResistType.Pois, 30);

            SetResist(ResistType.Phys, 30, 40);
            SetResist(ResistType.Fire, 30, 35);
            SetResist(ResistType.Cold, 25, 35);
            SetResist(ResistType.Pois, 35, 40);
            SetResist(ResistType.Engy, 25, 30);

            SetSkill(SkillName.MagicResist, 70.0);
            SetSkill(SkillName.Tactics, 90.0);
            SetSkill(SkillName.Wrestling, 90.0);

            Fame = 4500;
            Karma = -4500;

            VirtualArmor = 45;

            SolenHelper.PackPicnicBasket(this);

            PackItem(new ZoogiFungus((Utility.RandomDouble() > 0.05) ? 5 : 25));

            if (Utility.RandomDouble() < 0.05)
                PackItem(new BallOfSummoning());
        }

        public RedSolenQueen(Serial serial)
            : base(serial)
        {
        }

        public bool BurstSac => m_BurstSac;

        public override int GetAngerSound()
        {
            return 0x259;
        }

        public override int GetIdleSound()
        {
            return 0x259;
        }

        public override int GetAttackSound()
        {
            return 0x195;
        }

        public override int GetHurtSound()
        {
            return 0x250;
        }

        public override int GetDeathSound()
        {
            return 0x25B;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {

            if (attacker.Weapon is BaseRanged)
            {
                BeginAcidBreath();
            }
            else if (Map != null && attacker != this && m_Laid == false && 0.20 > Utility.RandomDouble()) //  if (m_Talked == false)
            {
                RSQEggSac sac = new RSQEggSac();

                sac.MoveToWorld(Location, Map);
                PlaySound(0x582);
                Say(1114445); // * * The solen queen summons her workers to her aid! * *
                m_Laid = true;
                EggSacTimer e = new EggSacTimer();
                e.Start();
            }

            base.OnGotMeleeAttack(attacker);
        }

        public override void OnDamagedBySpell(Mobile attacker)
        {
            base.OnDamagedBySpell(attacker);

            if (0.80 >= Utility.RandomDouble())
                BeginAcidBreath();
        }

        #region Acid Breath
        private DateTime m_NextAcidBreath;

        public void BeginAcidBreath()
        {
            if (!(Combatant is PlayerMobile m) || m.Deleted || !m.Alive || !Alive || m_NextAcidBreath > DateTime.Now || !CanBeHarmful(m))
                return;

            PlaySound(0x118);
            MovingEffect(m, 0x36D4, 1, 0, false, false, 0x3F, 0);

            TimeSpan delay = TimeSpan.FromSeconds(GetDistanceToSqrt(m) / 5.0);
            Timer.DelayCall<Mobile>(delay, new TimerStateCallback<Mobile>(EndAcidBreath), m);

            m_NextAcidBreath = DateTime.Now + TimeSpan.FromSeconds(5);
        }

        public void EndAcidBreath(Mobile m)
        {
            if (m == null || m.Deleted || !m.Alive || !Alive)
                return;

            if (0.2 >= Utility.RandomDouble())
                m.ApplyPoison(this, Poison.Greater);

            AOS.Damage(m, Utility.RandomMinMax(100, 120), 0, 0, 0, 100, 0);
        }
        #endregion

        private class EggSacTimer : Timer
        {
            public EggSacTimer()
                : base(TimeSpan.FromSeconds(10))
            {
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Laid = false;

            }
        }

        public override bool IsEnemy(Mobile m)
        {
            if (SolenHelper.CheckRedFriendship(m))
                return false;
            else
                return base.IsEnemy(m);
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            SolenHelper.OnRedDamage(from);

            if (!willKill)
            {
                if (!BurstSac)
                {
                    if (Hits < 50)
                    {
                        PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* The solen's acid sac is burst open! *");
                        m_BurstSac = true;
                    }
                }
                else if (from != null && from != this && InRange(from, 1))
                {
                    SpillAcid(from, 1);
                }
            }

            base.OnDamage(amount, from, willKill);
        }

        public override bool OnBeforeDeath()
        {
            SpillAcid(4);

            return base.OnBeforeDeath();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);
            writer.Write(m_BurstSac);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_BurstSac = reader.ReadBool();
                        break;
                    }
            }
        }
    }

    public class RSQEggSac : Item, ICarvable
    {
        private SpawnTimer m_Timer;

        public override string DefaultName => "egg sac";

        [Constructible]
        public RSQEggSac()
            : base(4316)
        {
            Movable = false;
            Hue = 350;

            m_Timer = new SpawnTimer(this);
            m_Timer.Start();
        }

        public bool Carve(Mobile from, Item item)
        {
            Effects.PlaySound(GetWorldLocation(), Map, 0x027);
            Effects.SendLocationEffect(GetWorldLocation(), Map, 0x3728, 10, 10, 0, 0);

            from.SendMessage("You destroy the egg sac.");
            Delete();
            m_Timer.Stop();

            return true;
        }

        public RSQEggSac(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadInt();

            m_Timer = new SpawnTimer(this);
            m_Timer.Start();
        }

        private class SpawnTimer : Timer
        {
            private readonly Item m_Item;

            public SpawnTimer(Item item)
                : base(TimeSpan.FromSeconds(Utility.RandomMinMax(5, 10)))
            {
                Priority = TimerPriority.FiftyMS;

                m_Item = item;
            }

            protected override void OnTick()
            {
                if (m_Item.Deleted)
                    return;

                Mobile spawn;

                switch (Utility.Random(2))
                {
                    case 0:
                        spawn = new RedSolenWarrior();
                        spawn.MoveToWorld(m_Item.Location, m_Item.Map);
                        m_Item.Delete();
                        break;
                    case 1:
                        spawn = new RedSolenWorker();
                        spawn.MoveToWorld(m_Item.Location, m_Item.Map);
                        m_Item.Delete();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
