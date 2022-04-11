using System;
using Server.Items;

namespace Server.Factions
{
    public class FactionSorceress : BaseFactionGuard
    {
        [Constructible]
        public FactionSorceress()
            : base("the sorceress")
        {
            GenerateBody(true, false);

            SetStr(126, 150);
            SetDex(61, 85);
            SetInt(126, 150);

            SetDamageType(ResistType.Physical, 100);

            SetResist(ResistType.Physical, 30, 50);
            SetResist(ResistType.Fire, 30, 50);
            SetResist(ResistType.Cold, 30, 50);
            SetResist(ResistType.Energy, 30, 50);
            SetResist(ResistType.Poison, 30, 50);

            VirtualArmor = 24;

            SetSkill(SkillName.Macing, 100.0, 110.0);
            SetSkill(SkillName.Wrestling, 100.0, 110.0);
            SetSkill(SkillName.Tactics, 100.0, 110.0);
            SetSkill(SkillName.MagicResist, 100.0, 110.0);
            SetSkill(SkillName.Healing, 100.0, 110.0);
            SetSkill(SkillName.Anatomy, 100.0, 110.0);

            SetSkill(SkillName.Magery, 100.0, 110.0);
            SetSkill(SkillName.EvalInt, 100.0, 110.0);
            SetSkill(SkillName.Meditation, 100.0, 110.0);

            AddItem(Immovable(Rehued(new WizardsHat(), 1325)));
            AddItem(Immovable(Rehued(new Sandals(), 1325)));
            AddItem(Immovable(Rehued(new LeatherGorget(), 1325)));
            AddItem(Immovable(Rehued(new LeatherGloves(), 1325)));
            AddItem(Immovable(Rehued(new LeatherLegs(), 1325)));
            AddItem(Immovable(Rehued(new Skirt(), 1325)));
            AddItem(Immovable(Rehued(new FemaleLeatherChest(), 1325)));
            AddItem(Newbied(Rehued(new QuarterStaff(), 1310)));

            PackItem(new Bandage(Utility.RandomMinMax(30, 40)));
            PackStrongPotions(6, 12);
        }

        public FactionSorceress(Serial serial)
            : base(serial)
        {
        }

        public override GuardAI GuardAI => GuardAI.Magic | GuardAI.Bless | GuardAI.Curse;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}