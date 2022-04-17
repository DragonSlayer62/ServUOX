using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    [CorpseName("a Putrefier corpse")]
    public class Putrefier : Balron
    {
        [Constructible]
        public Putrefier()
        {
            Name = "Putrefier";
            Hue = 63;

            SetStr(1057, 1400);
            SetDex(232, 560);
            SetInt(201, 440);

            SetHits(3010, 4092);

            SetDamage(ResistType.Phys, 50, 0, 27, 34);
            SetDamage(ResistType.Fire, 0);
            SetDamage(ResistType.Pois, 50);
            SetDamage(ResistType.Engy, 0);

            SetResist(ResistType.Phys, 65, 80);
            SetResist(ResistType.Fire, 65, 80);
            SetResist(ResistType.Cold, 50, 60);
            SetResist(ResistType.Pois, 100);
            SetResist(ResistType.Engy, 40, 50);

            SetSkill(SkillName.Wrestling, 111.2, 128.0);
            SetSkill(SkillName.Tactics, 115.2, 125.2);
            SetSkill(SkillName.MagicResist, 143.4, 170.0);
            SetSkill(SkillName.Anatomy, 44.6, 67.0);
            SetSkill(SkillName.Magery, 117.6, 118.8);
            SetSkill(SkillName.EvalInt, 113.0, 128.8);
            SetSkill(SkillName.Meditation, 41.4, 85.0);
            SetSkill(SkillName.Poisoning, 45.0, 50.0);

            Fame = 24000;
            Karma = -24000;

            VirtualArmor = 30;
        }

        public Putrefier(Serial serial)
            : base(serial)
        {
        }

        public override void OnDeath(Container CorpseLoot)
        {
            for (int i = 0; i < Utility.RandomMinMax(0, 2); i++)
            {
                CorpseLoot.DropItem(Loot.RandomScroll(0, Loot.ArcanistScrollTypes.Length, SpellbookType.Arcanist));
            }

            CorpseLoot.DropItem(new SpleenOfThePutrefier());

            if (Utility.RandomDouble() < 0.6)
                CorpseLoot.DropItem(new ParrotItem());

            if (Paragon.ChestChance > Utility.RandomDouble())
                CorpseLoot.DropItem(new ParagonChest(Name, 5));

            base.OnDeath(CorpseLoot);
        }

        public override bool GivesMLMinorArtifact => true;
        public override Poison HitPoison => Poison.Deadly;// Becomes Lethal with Paragon bonus
        
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

        private void DoCounter(Mobile attacker)
        {
            if (Map == null || (attacker is BaseCreature creature && creature.BardProvoked))
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

                if (target == null || !target.InRange(this, 25))
                    target = attacker;

                Animate(10, 4, 1, true, false, 0);

                List<Mobile> targets = new List<Mobile>();
                IPooledEnumerable eable = target.GetMobilesInRange(8);

                foreach (Mobile m in eable)
                {
                    if (m == this || !CanBeHarmful(m))
                        continue;

                    if (m is BaseCreature creature2 && (creature2.Controlled || creature2.Summoned || creature2.Team != Team))
                        targets.Add(m);
                    else if (m.Player)
                        targets.Add(m);
                }
                eable.Free();

                for (int i = 0; i < targets.Count; ++i)
                {
                    Mobile m = targets[i];

                    DoHarmful(m);

                    AOS.Damage(m, this, Utility.RandomMinMax(20, 25), true, 0, 0, 0, 100, 0);

                    m.FixedParticles(0x36BD, 1, 10, 0x1F78, 0xA6, 0, (EffectLayer)255);
                    m.ApplyPoison(this, Poison.Lethal);
                }

                targets.Clear();
                targets.TrimExcess();
            }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 3);
            AddLoot(LootPack.MedScrolls, 2);
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
        }
    }
}
