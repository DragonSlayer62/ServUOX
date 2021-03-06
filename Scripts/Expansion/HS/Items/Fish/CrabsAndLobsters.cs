using Server;
using System;
using Server.Targeting;
using Server.Misc;

namespace Server.Items
{
    public class BaseCrabAndLobster : BaseHighseasFish
    {
        public override Item GetCarved => null;
        public override int GetCarvedAmount => 1;
        public override double DefaultWeight => 2.0;

        public BaseCrabAndLobster(int itemID) : base(itemID)
        {
        }

        public BaseCrabAndLobster(Serial serial) : base(serial) { }

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

    public class RareCrabAndLobster : BaseCrabAndLobster
    {
        private Mobile m_CaughtBy;
        private DateTime m_DateCaught;

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Fisher { get { return m_CaughtBy; } set { m_CaughtBy = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime DateCaught { get { return m_DateCaught; } set { m_DateCaught = value; } }

        public RareCrabAndLobster(int itemID)
            : base(itemID)
        {
        }

        public RareCrabAndLobster(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
            writer.Write(m_CaughtBy);
            writer.Write(m_DateCaught);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_CaughtBy = reader.ReadMobile();
            m_DateCaught = reader.ReadDateTime();
        }
    }

    public class Crab : BaseCrabAndLobster
    {
        public override int LabelNumber => 1096489;

        [Constructible]
        public Crab()
            : base(BaseHighseasFish.GetCrabID())
        {
        }

        public Crab(Serial serial) : base(serial) { }

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

    public class Lobster : BaseCrabAndLobster
    {
        public override int LabelNumber => 1096491;

        [Constructible]
        public Lobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
        }

        public Lobster(Serial serial) : base(serial) { }

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

    public class AppleCrab : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116378;

        [Constructible]
        public AppleCrab() : base(BaseHighseasFish.GetCrabID())
        {
        }

        public AppleCrab(Serial serial) : base(serial) { }

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

    public class BlueCrab : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116374;

        [Constructible]
        public BlueCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
        }

        public BlueCrab(Serial serial) : base(serial) { }

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

    public class DungeonessCrab : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116373;

        [Constructible]
        public DungeonessCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
        }

        public DungeonessCrab(Serial serial) : base(serial) { }

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

    public class KingCrab : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116375;

        [Constructible]
        public KingCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
        }

        public KingCrab(Serial serial) : base(serial) { }

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

    public class RockCrab : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116376;

        [Constructible]
        public RockCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
        }

        public RockCrab(Serial serial) : base(serial) { }

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

    public class SnowCrab : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116377;

        [Constructible]
        public SnowCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
        }

        public SnowCrab(Serial serial) : base(serial) { }

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

    public class StoneCrab : RareCrabAndLobster
    {
        public override int LabelNumber => 1116334;
        public override Item GetCarved => new StoneCrabMeat();

        [Constructible]
        public StoneCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
            Hue = FishInfo.GetFishHue(typeof(StoneCrab));
        }

        public StoneCrab(Serial serial) : base(serial) { }

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

    public class SpiderCrab : RareCrabAndLobster
    {
        public override int LabelNumber => 1116336;
        public override Item GetCarved => new SpiderCrabMeat();

        [Constructible]
        public SpiderCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
            Hue = FishInfo.GetFishHue(typeof(SpiderCrab));
        }

        public SpiderCrab(Serial serial) : base(serial) { }

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

    public class TunnelCrab : RareCrabAndLobster
    {
        public override int LabelNumber => 1116372;

        [Constructible]
        public TunnelCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
            Hue = FishInfo.GetFishHue(typeof(TunnelCrab));
        }

        public TunnelCrab(Serial serial) : base(serial) { }

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

    public class VoidCrab : RareCrabAndLobster
    {
        public override int LabelNumber => 1116368;

        [Constructible]
        public VoidCrab()
            : base(BaseHighseasFish.GetCrabID())
        {
            Hue = FishInfo.GetFishHue(typeof(VoidCrab));
        }
        public VoidCrab(Serial serial) : base(serial) { }

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

    public class CrustyLobster : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116383;

        [Constructible]
        public CrustyLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
        }

        public CrustyLobster(Serial serial) : base(serial) { }

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

    public class FredLobster : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116382;

        [Constructible]
        public FredLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
        }

        public FredLobster(Serial serial) : base(serial) { }

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

    public class HummerLobster : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116381;

        [Constructible]
        public HummerLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
        }

        public HummerLobster(Serial serial) : base(serial) { }

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

    public class RockLobster : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116380;

        [Constructible]
        public RockLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
        }

        public RockLobster(Serial serial) : base(serial) { }

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

    public class ShovelNoseLobster : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116384;

        [Constructible]
        public ShovelNoseLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
        }

        public ShovelNoseLobster(Serial serial) : base(serial) { }

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

    public class SpineyLobster : BaseCrabAndLobster
    {
        public override int LabelNumber => 1116379;

        [Constructible]
        public SpineyLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
        }

        public SpineyLobster(Serial serial) : base(serial) { }

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

    public class BlueLobster : RareCrabAndLobster
    {
        public override int LabelNumber => 1116366;
        public override Item GetCarved => new BlueLobsterMeat();

        [Constructible]
        public BlueLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
            Hue = FishInfo.GetFishHue(typeof(BlueLobster));
        }

        public BlueLobster(Serial serial) : base(serial) { }

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

    public class BloodLobster : RareCrabAndLobster
    {
        public override int LabelNumber => 1116370;

        [Constructible]
        public BloodLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
            Hue = FishInfo.GetFishHue(typeof(BloodLobster));
        }

        public BloodLobster(Serial serial) : base(serial) { }

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

    public class DreadLobster : RareCrabAndLobster
    {
        public override int LabelNumber => 1116371;

        [Constructible]
        public DreadLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
            Hue = FishInfo.GetFishHue(typeof(DreadLobster));
        }

        public DreadLobster(Serial serial) : base(serial) { }

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

    public class VoidLobster : RareCrabAndLobster
    {
        public override int LabelNumber => 1116369;

        [Constructible]
        public VoidLobster()
            : base(BaseHighseasFish.GetLobsterID())
        {
            Hue = FishInfo.GetFishHue(typeof(VoidLobster));
        }

        public VoidLobster(Serial serial) : base(serial) { }

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

    public class StoneCrabMeat : Item
    {
        public override int LabelNumber => 1116317;

        [Constructible]
        public StoneCrabMeat() : base(4159)
        {
            Hue = FishInfo.GetFishHue(typeof(StoneCrab));
        }

        public StoneCrabMeat(Serial serial) : base(serial) { }

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

    public class SpiderCrabMeat : Item
    {
        public override int LabelNumber => 1116320;

        [Constructible]
        public SpiderCrabMeat()
            : base(4159)
        {
            Hue = FishInfo.GetFishHue(typeof(SpiderCrab));
        }

        public SpiderCrabMeat(Serial serial) : base(serial) { }

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

    public class BlueLobsterMeat : Item
    {
        public override int LabelNumber => 1116318;

        [Constructible]
        public BlueLobsterMeat()
            : base(4159)
        {
            Hue = FishInfo.GetFishHue(typeof(BlueLobster));
        }

        public BlueLobsterMeat(Serial serial) : base(serial) { }

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