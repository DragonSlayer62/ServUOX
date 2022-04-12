namespace Server.Mobiles
{
    [CorpseName("a clan ribbon courtier corpse")]
    public class ClanRC : BaseCreature
    {
        //public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }
        [Constructible]
        public ClanRC()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Clan Ribbon Courtier";
            Body = 42;
            Hue = 2207;
            BaseSoundID = 437;

            SetStr(231);
            SetDex(252);
            SetInt(125);

            SetHits(2054, 2100);

            SetDamage(7, 14);

            SetDamageType(ResistType.Phys, 100);

            SetResist(ResistType.Phys, 40);
            SetResist(ResistType.Fire, 10, 12);
            SetResist(ResistType.Cold, 15, 20);
            SetResist(ResistType.Pois, 10, 12);
            SetResist(ResistType.Engy, 10, 12);

            SetSkill(SkillName.MagicResist, 113.5, 115.0);
            SetSkill(SkillName.Tactics, 65.1, 70.0);
            SetSkill(SkillName.Wrestling, 50.5, 55.0);

            Fame = 1500;
            Karma = -1500;

            VirtualArmor = 48;
        }

        public ClanRC(Serial serial)
            : base(serial)
        {
        }

        public override bool CanRummageCorpses => true;
        public override int Hides => 8;
        public override HideType HideType => HideType.Spined;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.Average);
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
