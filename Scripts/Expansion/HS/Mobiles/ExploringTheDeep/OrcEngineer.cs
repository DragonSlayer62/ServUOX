using System;
using Server.Items;
using Server.Engines.Quests;
using System.Collections.Generic;
using System.Linq;

namespace Server.Mobiles
{
    [CorpseName("an orcish corpse")]
    public class OrcEngineer : Orc
    {
        public static List<OrcEngineer> Instances { get; set; }

        [Constructible]
        public OrcEngineer()
            : base()
        {
            Title = "the Orcish Engineer";

            SetStr(500, 510);
            SetDex(200, 210);
            SetInt(200, 210);

            SetHits(3500, 3700);

            SetDamage(8, 14);

            SetDamageType(ResistType.Phys, 100);

            SetResist(ResistType.Phys, 65, 70);
            SetResist(ResistType.Fire, 65, 70);
            SetResist(ResistType.Cold, 65, 70);
            SetResist(ResistType.Pois, 60);
            SetResist(ResistType.Engy, 65, 70);

            SetSkill(SkillName.Parry, 100.0, 110.0);
            SetSkill(SkillName.MagicResist, 70.0, 80.0);
            SetSkill(SkillName.Tactics, 110.0, 120.0);
            SetSkill(SkillName.Wrestling, 120.0, 130.0);
            SetSkill(SkillName.DetectHidden, 100.0, 110.0);

            Fame = 1500;
            Karma = -1500;

            if (Instances == null)
                Instances = new List<OrcEngineer>();

            Instances.Add(this);

            Timer SelfDeleteTimer = new InternalSelfDeleteTimer(this);
            SelfDeleteTimer.Start();
        }

        public static OrcEngineer Spawn(Point3D platLoc, Map platMap)
        {
            if (Instances != null && Instances.Count > 0)
                return null;

            OrcEngineer creature = new OrcEngineer();
            creature.Home = platLoc;
            creature.RangeHome = 4;
            creature.MoveToWorld(platLoc, platMap);

            return creature;
        }

        public class InternalSelfDeleteTimer : Timer
        {
            private OrcEngineer Mare;

            public InternalSelfDeleteTimer(Mobile p) : base(TimeSpan.FromMinutes(10))
            {
                Priority = TimerPriority.FiveSeconds;
                Mare = ((OrcEngineer)p);
            }
            protected override void OnTick()
            {
                if (Mare.Map != Map.Internal)
                {
                    Mare.Delete();
                    Stop();
                }
            }
        }

        public override void OnDeath(Container c)
        {
            List<DamageStore> rights = GetLootingRights();

            foreach (Mobile m in rights.Select(x => x.m_Mobile).Distinct())
            {
                if (m is PlayerMobile)
                {
                    PlayerMobile pm = m as PlayerMobile;

                    if (pm.ExploringTheDeepQuest == ExploringTheDeepQuestChain.CollectTheComponent)
                    {
                        Item item = new OrcishSchematics();

                        if (m.Backpack == null || !m.Backpack.TryDropItem(m, item, false))
                        {
                            m.BankBox.DropItem(item);
                        }

                        m.SendLocalizedMessage(1154489); // You received a Quest Item!
                    }
                }
            }

            if (Instances != null && Instances.Contains(this))
                Instances.Remove(this);

            base.OnDeath(c);
        }

        public override void OnAfterDelete()
        {
            Instances.Remove(this);

            base.OnAfterDelete();
        }

        public OrcEngineer(Serial serial)
            : base(serial)
        {
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

            Instances = new List<OrcEngineer>();
            Instances.Add(this);

            Timer SelfDeleteTimer = new InternalSelfDeleteTimer(this);
            SelfDeleteTimer.Start();
        }
    }
}
