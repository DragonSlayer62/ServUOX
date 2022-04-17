using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an elf corpse")]
    public class ElfBrigand : BaseCreature
    {
        [Constructible]
        public ElfBrigand()
            : base(AIType.AI_Spellweaving, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Race = Race.Elf;

            if (Female = Utility.RandomBool())
            {
                Body = 606;
                Name = NameList.RandomName("Elf female");
            }
            else
            {
                Body = 605;
                Name = NameList.RandomName("Elf male");
            }

            Title = "the brigand";
            Hue = Race.RandomSkinHue();

            SetStr(86, 100);
            SetDex(81, 95);
            SetInt(61, 75);

            SetDamage(ResistType.Phys, 100, 0, 10, 23);

            SetResist(ResistType.Phys, 10, 15);
            SetResist(ResistType.Fire, 10, 15);
            SetResist(ResistType.Pois, 10, 15);
            SetResist(ResistType.Engy, 10, 15);

            SetSkill(SkillName.MagicResist, 25.0, 47.5);
            SetSkill(SkillName.Tactics, 65.0, 87.5);
            SetSkill(SkillName.Wrestling, 15.0, 37.5);
            SetSkill(SkillName.Spellweaving, 50.0, 75.0);
            SetSkill(SkillName.Focus, 50.0, 75.0);

            Fame = 1000;
            Karma = -1000;

            // outfit
            AddItem(new Shirt(Utility.RandomNeutralHue()));

            switch (Utility.Random(4))
            {
                case 0:
                    AddItem(new Sandals());
                    break;
                case 1:
                    AddItem(new Shoes());
                    break;
                case 2:
                    AddItem(new Boots());
                    break;
                case 3:
                    AddItem(new ThighBoots());
                    break;
                default:
                    AddItem(new ThighBoots());
                    break;
            }

            if (Female)
            {
                if (Utility.RandomBool())
                    AddItem(new Skirt(Utility.RandomNeutralHue()));
                else
                    AddItem(new Kilt(Utility.RandomNeutralHue()));
            }
            else
                AddItem(new ShortPants(Utility.RandomNeutralHue()));

            // hair, facial hair			
            HairItemID = Race.RandomHair(Female);
            HairHue = Race.RandomHairHue();

            // weapon, shield
            Item weapon = Loot.RandomWeapon();

            AddItem(weapon);

            if (weapon.Layer == Layer.OneHanded && Utility.RandomBool())
                AddItem(Loot.RandomShield());

            PackItem(Loot.PackGold(50, 100));
        }

        public ElfBrigand(Serial serial)
            : base(serial)
        {
        }

        public override bool AlwaysMurderer => true;
        public override bool DisplayFameTitle => false;

        public override void OnDeath(Container c)
        {
            if (Utility.RandomDouble() < 0.75)
                c.DropItem(new SeveredElfEars());

            base.OnDeath(c);
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
