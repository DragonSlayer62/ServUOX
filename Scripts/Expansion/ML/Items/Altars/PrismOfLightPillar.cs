namespace Server.Items
{
    public class PrismOfLightPillar : Container
    {
        public override int LabelNumber => 1024643;  // pedestal

        private PrismOfLightAltar m_Altar;
        private int m_OrgHue;

        [CommandProperty(AccessLevel.GameMaster)]
        public PrismOfLightAltar Altar
        {
            get { return m_Altar; }
            set
            {
                m_Altar = value;

                if (!m_Altar.Pedestals.Contains(this))
                    m_Altar.Pedestals.Add(this);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int ID { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int OrgHue
        {
            get { return m_OrgHue; }
            set
            {
                m_OrgHue = value;
                Hue = m_OrgHue;
                InvalidateProperties();
            }
        }

        public PrismOfLightPillar(PrismOfLightAltar altar, int hue)
            : base(0x207D)
        {
            OrgHue = hue;
            Movable = false;

            m_Altar = altar;

            if (m_Altar != null)
            {
                ID = m_Altar.GetID();
                m_Altar.Pedestals.Add(this);
            }
        }

        public PrismOfLightPillar(Serial serial) : base(serial)
        {
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (m_Altar == null)
                return false;

            if (dropped.GetType() == m_Altar.Keys[ID])
            {
                if (m_Altar.OnDragDrop(from, dropped))
                {
                    Hue = 36;
                    return true;
                }
            }
            else
            {
                from.SendLocalizedMessage(1072682); // This is not the proper key.
            }

            return false;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version

            writer.Write(m_OrgHue);

            writer.Write(ID);
            writer.Write(m_Altar);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_OrgHue = reader.ReadInt();
                        goto case 0;
                    }
                case 0:
                    {
                        ID = reader.ReadInt();
                        m_Altar = reader.ReadItem() as PrismOfLightAltar;

                        break;
                    }

                default:
                    break;
            }

            if (version < 1)
            {
                if (m_OrgHue == 0)
                    m_OrgHue = Hue;

                if (!m_Altar.Pedestals.Contains(this))
                    m_Altar.Pedestals.Add(this);
            }
        }
    }
}
