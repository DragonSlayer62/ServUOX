using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
    public class PvPWarnTeleporter : Teleporter
    {
        [Constructible]
        public PvPWarnTeleporter()
        {
        }

        public PvPWarnTeleporter(Serial serial)
            : base(serial)
        {
        }

        public override bool OnMoveOver(Mobile m)
        {
            if (m is PlayerMobile pm)
            {
                if (pm.DisabledPvpWarning)
                {
                    return base.OnMoveOver(m);
                }
                else if (!pm.HasGump(typeof(PvpWarningGump)))
                {
                    pm.SendGump(new PvpWarningGump(this));
                }
            }

            return true;
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

    public class PvpWarningGump : Gump
    {
        private readonly Teleporter m_Owner;

        public PvpWarningGump(Teleporter teleporter)
            : base(150, 50)
        {
            m_Owner = teleporter;

            AddPage(0);

            AddImage(0, 0, 0xE10);
            AddImageTiled(0, 14, 15, 200, 0xE13);
            AddImageTiled(380, 14, 14, 200, 0xE15);
            AddImage(0, 201, 0xE16);
            AddImageTiled(15, 201, 370, 16, 0xE17);
            AddImageTiled(15, 0, 370, 16, 0xE11);
            AddImage(380, 0, 0xE12);
            AddImage(380, 201, 0xE18);
            AddImageTiled(15, 15, 365, 190, 0xA40);

            AddHtmlLocalized(30, 20, 330, 20, 1060635, 0x4040FE, false, false); // <CENTER>WARNING</CENTER>
            AddHtmlLocalized(30, 50, 330, 60, 1113792, 0xFFFFFF, false, false); // You are about to enter a PvP area, where you can be attacked and stolen from by other players. Do you wish to proceed?

            AddHtmlLocalized(65, 125, 300, 25, 1113794, 0xFFFFFF, false, false); // Yes, I wish to proceed
            AddButton(30, 125, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0);

            AddHtmlLocalized(65, 150, 300, 25, 1113795, 0xFFFFFF, false, false); // Yes, and do not ask me again
            AddButton(30, 150, 0xFA5, 0xFA7, 2, GumpButtonType.Reply, 0);

            AddHtmlLocalized(65, 175, 300, 25, 1113793, 0xFFFFFF, false, false); // No, I do not wish to proceed
            AddButton(30, 175, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0);

            AddImageTiled(15, 14, 365, 1, 0x2393);
            AddImageTiled(380, 14, 1, 190, 0x2391);
            AddImageTiled(15, 205, 365, 1, 0x2393);
            AddImageTiled(15, 14, 1, 190, 0x2391);
            AddImageTiled(0, 0, 395, 1, 0x23C5);
            AddImageTiled(394, 0, 1, 217, 0x23C3);
            AddImageTiled(0, 216, 395, 1, 0x23C5);
            AddImageTiled(0, 0, 1, 217, 0x23C3);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (!(sender.Mobile is PlayerMobile pm))
            {
                return;
            }

            if (!pm.InRange(m_Owner.Location, 5))
            {
                return;
            }

            switch (info.ButtonID)
            {
                case 2: // Yes, and do not ask me again
                    {
                        pm.DisabledPvpWarning = true;
                        pm.SendLocalizedMessage(1113796); // You may use your avatar's context menu to re-enable the warning later.

                        goto case 1;
                    }
                case 1: // Yes, I wish to proceed
                    {
                        BaseCreature.TeleportPets(pm, m_Owner.PointDest, m_Owner.MapDest);
                        pm.MoveToWorld(m_Owner.PointDest, m_Owner.MapDest);

                        break;
                    }
                case 0: // No, I do not wish to proceed
                    {
                        break;
                    }
            }
        }
    }
}
