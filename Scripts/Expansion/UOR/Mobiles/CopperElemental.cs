using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an ore elemental corpse")]
    public class CopperElemental : BaseCreature
    {
        [Constructible]
        public CopperElemental()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a copper elemental";
            Body = 109;
            BaseSoundID = 268;

            SetStr(226, 255);
            SetDex(126, 145);
            SetInt(71, 92);

            SetHits(136, 153);

            SetDamage(9, 16);

            SetDamageType(ResistType.Phys, 100);

            SetResist(ResistType.Phys, 30, 40);
            SetResist(ResistType.Fire, 30, 40);
            SetResist(ResistType.Cold, 30, 40);
            SetResist(ResistType.Pois, 20, 30);
            SetResist(ResistType.Engy, 10, 20);

            SetSkill(SkillName.MagicResist, 50.1, 95.0);
            SetSkill(SkillName.Tactics, 60.1, 100.0);
            SetSkill(SkillName.Wrestling, 60.1, 100.0);

            Fame = 4800;
            Karma = -4800;

            VirtualArmor = 26;
        }

        public CopperElemental(Serial serial)
            : base(serial)
        {
        }

        public override bool AutoDispel => true;
        public override bool BleedImmunity => true;
        public override int TreasureMapLevel => 1;

        public override void OnDeath(Container CorpseLoot)
        {
            CorpseLoot.DropItem(new CopperOre(25));
            //ore.ItemID = 0x19B9;
            base.OnDeath(CorpseLoot);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
            AddLoot(LootPack.Gems, 2);
        }

        public override void CheckReflect(Mobile caster, ref bool reflect)
        {
            reflect = true; // Every spell is reflected back to the caster
        }

        public override void AlterMeleeDamageFrom(Mobile from, ref int damage)
        {
            AOS.Damage(from, this, damage / 2, 0, 0, 0, 0, 0, 0, 100);
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
