using System;
using Server;

namespace Server.Mobiles
{
    [CorpseName("a najasaurus corpse")]
    public class Najasaurus : BaseCreature
    {
        public override bool AttacksFocus => !Controlled;

        [Constructible]
        public Najasaurus()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, .2, .4)
        {
            Name = "a najasaurus";
            Body = 1289;
            BaseSoundID = 219;

            SetStr(162, 346);
            SetDex(151, 218);
            SetInt(21, 40);

            SetDamage(13, 24);
            SetHits(737, 854);

            SetDamageType(ResistType.Phys, 50);
            SetDamageType(ResistType.Pois, 50);

            SetResist(ResistType.Phys, 45, 55);
            SetResist(ResistType.Fire, 50, 60);
            SetResist(ResistType.Cold, 45, 55);
            SetResist(ResistType.Pois, 100);
            SetResist(ResistType.Engy, 35, 45);

            SetSkill(SkillName.MagicResist, 150.0, 190.0);
            SetSkill(SkillName.Tactics, 80.0, 95.0);
            SetSkill(SkillName.Wrestling, 80.0, 100.0);
            SetSkill(SkillName.Poisoning, 90.0, 100.0);
            SetSkill(SkillName.DetectHidden, 45.0, 55.0);

            Fame = 17000;
            Karma = -17000;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 102.0;
        }

        public override Poison HitPoison => Poison.Lethal;
        public override Poison PoisonImmunity => Poison.Lethal;
        public override bool CanAngerOnTame => true;
        public override int TreasureMapLevel => 2;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
        }

        public Najasaurus(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (version == 0)
            {
                SetMagicalAbility(MagicalAbility.Poisoning);
            }
        }
    }
}
