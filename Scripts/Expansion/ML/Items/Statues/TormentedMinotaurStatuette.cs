using System;

namespace Server.Items
{
    public class TormentedMinotaurStatuette : BaseStatuette
    {
        private static readonly int[] m_Sounds = new int[]
        {
            0x597, 0x598, 0x599, 0x59A, 0x59B, 0x59C, 0x59D
        };
        [Constructible]
        public TormentedMinotaurStatuette()
            : base(0x2D88)
        {
            Name = "Tormented Minotaur Statuette";
            Weight = 1.0;
        }

        public TormentedMinotaurStatuette(Serial serial)
            : base(serial)
        {
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (TurnedOn && IsLockedDown && (!m.Hidden || m.IsPlayer()) && Utility.InRange(m.Location, Location, 2) && !Utility.InRange(oldLocation, Location, 2))
                Effects.PlaySound(Location, Map, m_Sounds[Utility.Random(m_Sounds.Length)]);

            base.OnMovement(m, oldLocation);
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
        }
    }
}