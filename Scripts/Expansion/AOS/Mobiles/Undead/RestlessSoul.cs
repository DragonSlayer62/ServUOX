using System.Collections.Generic;
using Server.ContextMenus;
using Server.Engines.Quests;
using Server.Engines.Quests.Haven;

namespace Server.Mobiles
{
    [CorpseName("a ghostly corpse")]
    public class RestlessSoul : BaseCreature
    {
        [Constructible]
        public RestlessSoul()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            Name = "restless soul";
            Body = 0x3CA;
            Hue = 0x453;

            SetStr(26, 40);
            SetDex(26, 40);
            SetInt(26, 40);

            SetHits(16, 24);

            SetDamage(ResistType.Phys, 100, 0, 1, 10);

            SetResist(ResistType.Phys, 15, 25);
            SetResist(ResistType.Fire, 5, 15);
            SetResist(ResistType.Cold, 25, 40);
            SetResist(ResistType.Pois, 5, 10);
            SetResist(ResistType.Engy, 10, 20);

            SetSkill(SkillName.MagicResist, 20.1, 30.0);
            SetSkill(SkillName.Swords, 20.1, 30.0);
            SetSkill(SkillName.Tactics, 20.1, 30.0);
            SetSkill(SkillName.Wrestling, 20.1, 30.0);

            Fame = 500;
            Karma = -500;

            VirtualArmor = 6;
        }

        public RestlessSoul(Serial serial)
            : base(serial)
        {
        }

        public override bool AlwaysMurderer => true;
        public override bool AlwaysAttackable => true;
        public override bool BleedImmunity => true;
        public override int TreasureMapLevel => 2;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
        }

        public override void DisplayPaperdollTo(Mobile to)
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] is PaperdollEntry)
                    list.RemoveAt(i--);
            }
        }

        public override int GetIdleSound() { return 0x107; }
        public override int GetAngerSound() { return 0x1BF; }
        public override int GetDeathSound() { return 0xFD; }

        public override bool IsEnemy(Mobile m)
        {
            if (m is PlayerMobile player && Map == Map.Trammel && X >= 5199 && X <= 5271 && Y >= 1812 && Y <= 1865) // Schmendrick's cave
            {
                QuestSystem qs = player.Quest;

                if (qs is UzeraanTurmoilQuest && qs.IsObjectiveInProgress(typeof(FindSchmendrickObjective)))
                {
                    return false;
                }
            }

            return base.IsEnemy(m);
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