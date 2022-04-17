using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    [TypeAlias("Server.Mobiles.Yamadon")]
    [CorpseName("a yamandon corpse")]
    public class Yamandon : BaseCreature
    {
        [Constructible]
        public Yamandon()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a yamandon";
            Body = 249;

            SetStr(786, 930);
            SetDex(251, 365);
            SetInt(101, 115);

            SetHits(1601, 1800);

            SetDamage(ResistType.Phys, 70, 0, 19, 35);
            SetDamage(ResistType.Pois, 20);
            SetDamage(ResistType.Engy, 10);

            SetResist(ResistType.Phys, 65, 85);
            SetResist(ResistType.Fire, 70, 90);
            SetResist(ResistType.Cold, 50, 70);
            SetResist(ResistType.Pois, 50, 70);
            SetResist(ResistType.Engy, 50, 70);

            SetSkill(SkillName.Anatomy, 115.1, 130.0);
            SetSkill(SkillName.MagicResist, 117.6, 132.5);
            SetSkill(SkillName.Poisoning, 120.1, 140.0);
            SetSkill(SkillName.Tactics, 117.1, 132.0);
            SetSkill(SkillName.Wrestling, 112.6, 132.5);

            Fame = 22000;
            Karma = -22000;

            if (Utility.RandomDouble() < .50)
                PackItem(Engines.Plants.Seed.RandomBonsaiSeed());

            PackItem(new Eggs(2));

            SetWeaponAbility(WeaponAbility.DoubleStrike);
        }

        public Yamandon(Serial serial)
            : base(serial)
        {
        }

        public override bool ReacquireOnMovement => true;
        public override Poison PoisonImmunity => Poison.Lethal;
        public override Poison HitPoison => Utility.RandomBool() ? Poison.Deadly : Poison.Lethal;
        public override int TreasureMapLevel => 5;
        public override int Hides => 20;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich);
            AddLoot(LootPack.FilthyRich, 2);
            AddLoot(LootPack.Gems, 6);
        }

        public override void OnDamagedBySpell(Mobile attacker)
        {
            base.OnDamagedBySpell(attacker);
            DoCounter(attacker);
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);
            DoCounter(attacker);
        }

        public override int GetAttackSound() => 1260;

        public override int GetAngerSound() => 1262;

        public override int GetDeathSound() => 1259; //Other Death sound is 1258... One for Yamadon, one for Serado?

        public override int GetHurtSound() => 1263;

        public override int GetIdleSound() => 1261;

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            _ = reader.ReadInt();
        }

        private void DoCounter(Mobile attacker)
        {
            if (Map == null)
                return;

            if (attacker is BaseCreature creature && creature.BardProvoked)
                return;

            if (0.2 > Utility.RandomDouble())
            {
                /* Counterattack with Hit Poison Area
                * 20-25 damage, unresistable
                * Lethal poison, 100% of the time
                * Particle effect: Type: "2" From: "0x4061A107" To: "0x0" ItemId: "0x36BD" ItemIdName: "explosion" FromLocation: "(296 615, 17)" ToLocation: "(296 615, 17)" Speed: "1" Duration: "10" FixedDirection: "True" Explode: "False" Hue: "0xA6" RenderMode: "0x0" Effect: "0x1F78" ExplodeEffect: "0x1" ExplodeSound: "0x0" Serial: "0x4061A107" Layer: "255" Unknown: "0x0"
                * Doesn't work on provoked monsters
                */
                Mobile target = null;

                if (attacker is BaseCreature creature1)
                {
                    Mobile m = creature1.GetMaster();

                    if (m != null)
                        target = m;
                }

                if (target == null || !target.InRange(this, 18))
                    target = attacker;

                Animate(10, 4, 1, true, false, 0);

                ArrayList targets = new ArrayList();
                IPooledEnumerable eable = target.GetMobilesInRange(8);

                foreach (Mobile m in eable)
                {
                    if (m == this || !CanBeHarmful(m))
                        continue;

                    if (m is BaseCreature creature2 && (creature2.Controlled || creature2.Summoned || creature2.Team != Team))
                        targets.Add(m);
                    else if (m.Player && m.Alive)
                        targets.Add(m);
                }
                eable.Free();

                for (int i = 0; i < targets.Count; ++i)
                {
                    Mobile m = (Mobile)targets[i];

                    DoHarmful(m);

                    AOS.Damage(m, this, Utility.RandomMinMax(20, 25), true, 0, 0, 0, 100, 0);

                    m.FixedParticles(0x36BD, 1, 10, 0x1F78, 0xA6, 0, (EffectLayer)255);
                    m.ApplyPoison(this, Poison.Lethal);
                }
            }
        }
    }
}
