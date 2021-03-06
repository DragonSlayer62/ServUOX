using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a chaos dragoon corpse")]
    public class ChaosDragoon : BaseCreature
    {
        [Constructible]
        public ChaosDragoon()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.4)
        {
            Name = "a chaos dragoon";
            Body = 0x190;
            Hue = Utility.RandomSkinHue();

            SetStr(176, 225);
            SetDex(81, 95);
            SetInt(61, 85);

            SetHits(176, 225);

            SetDamage(24, 26);

            SetDamageType(ResistanceType.Physical, 25);
            SetDamageType(ResistanceType.Fire, 25);
            SetDamageType(ResistanceType.Cold, 25);
            SetDamageType(ResistanceType.Energy, 25);

            SetSkill(SkillName.Fencing, 77.6, 92.5);
            SetSkill(SkillName.Healing, 60.3, 90.0);
            SetSkill(SkillName.Macing, 77.6, 92.5);
            SetSkill(SkillName.Anatomy, 77.6, 87.5);
            SetSkill(SkillName.MagicResist, 77.6, 97.5);
            SetSkill(SkillName.Swords, 77.6, 92.5);
            SetSkill(SkillName.Tactics, 77.6, 87.5);

            Fame = 5000;
            Karma = -5000;

            CraftResource res = CraftResource.None;

            switch (Utility.Random(6))
            {
                case 0:
                    res = CraftResource.BlackScales;
                    break;
                case 1:
                    res = CraftResource.RedScales;
                    break;
                case 2:
                    res = CraftResource.BlueScales;
                    break;
                case 3:
                    res = CraftResource.YellowScales;
                    break;
                case 4:
                    res = CraftResource.GreenScales;
                    break;
                case 5:
                    res = CraftResource.WhiteScales;
                    break;
            }

            BaseWeapon melee = null;

            switch (Utility.Random(3))
            {
                case 0:
                    melee = new Kryss();
                    break;
                case 1:
                    melee = new Broadsword();
                    break;
                case 2:
                    melee = new Katana();
                    break;
            }

            AddItem(melee);

            DragonHelm helm = new DragonHelm();
            helm.Resource = res;
            AddItem(helm);

            DragonChest chest = new DragonChest();
            chest.Resource = res;
            AddItem(chest);

            DragonArms arms = new DragonArms();
            arms.Resource = res;
            AddItem(arms);

            DragonGloves gloves = new DragonGloves();
            gloves.Resource = res;
            AddItem(gloves);

            DragonLegs legs = new DragonLegs();
            legs.Resource = res;
            AddItem(legs);

            ChaosShield shield = new ChaosShield();
            AddItem(shield);

            AddItem(new Shirt());
            AddItem(new Boots());
            //AddItem(new Boots(0x455));
            //AddItem(new Shirt(Utility.RandomMetalHue()));

            int amount = Utility.RandomMinMax(1, 3);

            switch (res)
            {
                case CraftResource.BlackScales:
                    AddItem(new BlackScales(amount));
                    break;
                case CraftResource.RedScales:
                    AddItem(new RedScales(amount));
                    break;
                case CraftResource.BlueScales:
                    AddItem(new BlueScales(amount));
                    break;
                case CraftResource.YellowScales:
                    AddItem(new YellowScales(amount));
                    break;
                case CraftResource.GreenScales:
                    AddItem(new GreenScales(amount));
                    break;
                case CraftResource.WhiteScales:
                    AddItem(new WhiteScales(amount));
                    break;
            }

            new SwampDragon().Rider = this;

            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public ChaosDragoon(Serial serial)
            : base(serial)
        {
        }

        public override bool AutoDispel => true;
        public override bool BardImmunity => !Core.AOS;
        public override bool CanRummageCorpses => true;
        public override bool AlwaysMurderer => true;
        public override bool DisplayFameTitle => false;

        public override int GetIdleSound() { return 0x2CE; }
        public override int GetDeathSound() { return 0x2CC; }
        public override int GetHurtSound() { return 0x2D1; }
        public override int GetAttackSound() { return 0x2C8; }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
        }

        public override bool OnBeforeDeath()
        {
            IMount mount = Mount;

            if (mount != null)
                mount.Rider = null;

            return base.OnBeforeDeath();
        }

        public override void AlterMeleeDamageTo(Mobile to, ref int damage)
        {
            if (to is Dragon || to is WhiteWyrm || to is SwampDragon || to is Drake || to is Nightmare || to is Hiryu || to is LesserHiryu || to is Daemon)
                damage *= 3;
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
