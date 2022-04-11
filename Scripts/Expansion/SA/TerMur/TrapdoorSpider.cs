using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a trapdoor spider corpse")]
    public class TrapdoorSpider : BaseCreature
    {
        public override bool CanStealth => true;

        [Constructible]
        public TrapdoorSpider()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a trapdoor spider";
            Body = 737;
            Hidden = true;

            SetStr(100, 104);
            SetDex(162, 165);
            SetInt(29, 50);

            SetHits(125, 144);

            SetDamage(15, 18);

            SetDamageType(ResistType.Physical, 20);
            SetDamageType(ResistType.Poison, 80);

            SetResist(ResistType.Physical, 0);
            SetResist(ResistType.Fire, 30, 35);
            SetResist(ResistType.Cold, 30, 35);
            SetResist(ResistType.Poison, 40, 45);
            SetResist(ResistType.Energy, 95, 100);

            SetSkill(SkillName.Anatomy, 2.0, 3.8);
            SetSkill(SkillName.MagicResist, 47.5, 57.9);
            SetSkill(SkillName.Poisoning, 70.5, 73.5);
            SetSkill(SkillName.Tactics, 73.3, 78.9);
            SetSkill(SkillName.Wrestling, 92.5, 94.6);
            SetSkill(SkillName.Hiding, 110.3, 119.9);
            SetSkill(SkillName.Stealth, 110.5, 119.6);
        }

        public TrapdoorSpider(Serial serial)
            : base(serial)
        {
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            RevealingAction();
            base.OnDamage(amount, from, willKill);
        }

        public override void OnDamagedBySpell(Mobile from)
        {
            RevealingAction();
            base.OnDamagedBySpell(from);
        }

        public override int TreasureMapLevel => 2;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
        }

        public override int GetIdleSound()
        {
            return 1605;
        }

        public override int GetAngerSound()
        {
            return 1602;
        }

        public override int GetHurtSound()
        {
            return 1604;
        }

        public override int GetDeathSound()
        {
            return 1603;
        }

        public override void OnThink()
        {

            if (!Alive || Deleted)
            {
                return;
            }

            if (!Hidden)
            {
                double chance = 0.05;

                if (Hits < 20)
                {
                    chance = 0.1;
                }

                if (Poisoned)
                {
                    chance = 0.01;
                }

                if (Utility.RandomDouble() < chance)
                {
                    HideSelf();
                }
                base.OnThink();
            }
        }

        private void HideSelf()
        {
            if (Core.TickCount >= NextSkillTime)
            {
                Effects.SendLocationParticles(
                    EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);

                PlaySound(0x22F);
                Hidden = true;

                UseSkill(SkillName.Stealth);
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            var version = reader.ReadInt();
        }
    }
}