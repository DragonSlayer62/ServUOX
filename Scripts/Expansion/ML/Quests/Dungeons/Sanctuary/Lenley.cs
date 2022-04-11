using Server.Engines.Quests;
using Server.Regions;
using System;

namespace Server.Mobiles
{
    public class Lenley : BaseEscort
    {
        public override Type[] Quests => new Type[] { typeof(FreedomQuest) };

        public LenleyRegion _Region { get; set; }

        [Constructible]
        public Lenley()
            : base()
        {
            Name = "Lenley";
            Title = "the Snitch";
            Body = 0x2A;
            Hidden = true;
            CantWalk = true;

            SetStr(96, 120);
            SetDex(81, 100);
            SetInt(36, 60);

            SetHits(58, 72);

            SetDamage(4, 5);

            SetDamageType(ResistType.Physical, 100);

            SetResist(ResistType.Physical, 25, 30);
            SetResist(ResistType.Fire, 10, 20);
            SetResist(ResistType.Cold, 10, 20);
            SetResist(ResistType.Poison, 10, 20);
            SetResist(ResistType.Energy, 10, 20);

            SetSkill(SkillName.MagicResist, 35.1, 60.0);
            SetSkill(SkillName.Tactics, 50.1, 75.0);
            SetSkill(SkillName.Wrestling, 50.1, 75.0);
            SetSkill(SkillName.Hiding, 75.0);

            Fame = 1500;
            Karma = 1500;

            VirtualArmor = 28;
        }

        public Lenley(Serial serial)
            : base(serial)
        {
        }

        public override void RevealingAction()
        {
            if (_Region != null)
            {
                _Region.Unregister();
            }

            CantWalk = false;

            base.RevealingAction();
        }

        public override void OnDelete()
        {
            DeleteLenleyRegion();

            base.OnDelete();
        }

        public void DeleteLenleyRegion()
        {
            if (_Region != null)
            {
                _Region.Unregister();
            }
        }

        protected override void OnLocationChange(Point3D oldLocation)
        {
            if (Deleted)
            {
                return;
            }

            UpdateLenleyRegion();
        }

        protected override void OnMapChange(Map oldMap)
        {
            if (Deleted)
            {
                return;
            }

            UpdateLenleyRegion();
        }

        public void UpdateLenleyRegion()
        {
            if (Hidden)
            {
                DeleteLenleyRegion();

                if (!Deleted && Map != Map.Internal)
                {
                    _Region = new LenleyRegion(this);
                    _Region.Register();
                }
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (Hidden)
            {
                Timer.DelayCall(TimeSpan.Zero, new TimerCallback(UpdateLenleyRegion));
            }
        }
    }
}
