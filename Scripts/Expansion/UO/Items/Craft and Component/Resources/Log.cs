
namespace Server.Items
{
    [Flipable(0x1BDD, 0x1BE0)]
    public class BaseLog : Item, ICommodity, IAxe, IResource
    {
        private CraftResource m_Resource;

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource
        {
            get => m_Resource;
            set { m_Resource = value; InvalidateProperties(); }
        }

        TextDefinition ICommodity.Description => LabelNumber;
        //TextDefinition ICommodity.Description => CraftResources.IsStandard(m_Resource) ? LabelNumber : 1075062 + ((int)m_Resource - (int)CraftResource.RegularWood);

        bool ICommodity.IsDeedable => true;

        [Constructible]
        public BaseLog() : this(1)
        {
        }

        [Constructible]
        public BaseLog(int amount) : this(CraftResource.RegularWood, amount)
        {
        }

        [Constructible]
        public BaseLog(CraftResource resource)
            : this(resource, 1)
        {
        }

        [Constructible]
        public BaseLog(CraftResource resource, int amount)
            : base(0x1BDD)
        {
            Stackable = true;
            Weight = 2.0;
            Amount = amount;
            m_Resource = resource;
            Hue = CraftResources.GetHue(resource);
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (!CraftResources.IsStandard(m_Resource))
            {
                int num = CraftResources.GetLocalizationNumber(m_Resource);

                if (num > 0)
                {
                    list.Add(num);
                }
                else
                {
                    list.Add(CraftResources.GetName(m_Resource));
                }
            }
        }
        public BaseLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(2);
            writer.Write((int)m_Resource);
        }

        public static bool UpdatingBaseLogClass;

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (version == 1)
            {
                UpdatingBaseLogClass = true;
            }

            m_Resource = (CraftResource)reader.ReadInt();

            if (version == 0)
            {
                m_Resource = CraftResource.RegularWood;
            }
        }

        public virtual bool TryCreateBoards(Mobile from, double skill, Item item)
        {
            if (Deleted || !from.CanSee(this))
            {
                item.Delete();
                return false;
            }
            if (from.Skills.Carpentry.Value < skill && from.Skills.Lumberjacking.Value < skill)
            {
                item.Delete();
                from.SendLocalizedMessage(1072652); // You cannot work this strange and unusual wood.
                return false;
            }

            if (HasSocket<Caddellite>())
            {
                item.AttachSocket(new Caddellite());
            }

            base.ScissorHelper(from, item, 1, false);
            return true;
        }

        public virtual bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 0, new Board()))
            {
                return false;
            }

            return true;
        }
    }

    public class Log : BaseLog
    {
        [Constructible]
        public Log()
            : this(1)
        {
        }

        [Constructible]
        public Log(int amount)
            : base(CraftResource.RegularWood, amount)
        {
        }

        public Log(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            if (UpdatingBaseLogClass)
            {
                return; // don't deserialize anything on update
            }

            _ = reader.ReadInt();
        }

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 0, new Board()))
            {
                return false;
            }

            return true;
        }
    }
}
