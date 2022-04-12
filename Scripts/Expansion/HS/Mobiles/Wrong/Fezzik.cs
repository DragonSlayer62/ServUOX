using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an ogre corpse")]
    public class Fezzik : BaseCreature
    {
        private DateTime m_StinkingCauldronTime;

        [Constructible]
        public Fezzik()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Fezzik";
            Title = "The Ogre Cook";
            Body = 1;
            BaseSoundID = 427;

            SetStr(1142, 1381);
            SetDex(73, 90);
            SetInt(52, 84);

            SetMana(0);

            SetDamage(25, 30);

            SetDamageType(ResistType.Phys, 100);

            SetResist(ResistType.Phys, 75, 80);
            SetResist(ResistType.Fire, 70, 75);
            SetResist(ResistType.Cold, 65, 75);
            SetResist(ResistType.Pois, 55, 65);
            SetResist(ResistType.Engy, 65, 75);

            SetSkill(SkillName.MagicResist, 133.3, 151.9);
            SetSkill(SkillName.Tactics, 120.3, 130.0);
            SetSkill(SkillName.Wrestling, 122.2, 128.9);
            SetSkill(SkillName.Anatomy, 10.0, 15.0);
            SetSkill(SkillName.DetectHidden, 90.0);
            SetSkill(SkillName.Parry, 95.0, 100.0);

            Fame = 3000;
            Karma = -3000;

            VirtualArmor = 52;

            PackItem(new Club());
        }

        public Fezzik(Serial serial)
            : base(serial)
        {
        }

        public override int Meat => 2;

        public override void AlterDamageScalarFrom(Mobile caster, ref double scalar)
        {
            if (0.5 >= Utility.RandomDouble())
                SpawnGreenGoo();
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);

            if (0.5 >= Utility.RandomDouble())
                SpawnGreenGoo();
        }

        public void SpawnGreenGoo()
        {
            if (m_StinkingCauldronTime <= DateTime.UtcNow)
            {
                new StinkingCauldron().MoveToWorld(Location, Map);

                m_StinkingCauldronTime = DateTime.UtcNow + TimeSpan.FromMinutes(2);
            }
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (0.1 > Utility.RandomDouble())
            {
                c.DropItem(new RecipeScroll(603));
            }
        }

        public override int TreasureMapLevel => 3;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager, 2);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}