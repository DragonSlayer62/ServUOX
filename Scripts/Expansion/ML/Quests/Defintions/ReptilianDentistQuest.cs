using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class ReptilianDentistQuest : BaseQuest
    {
        public ReptilianDentistQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(CoilsFang), "Coil's Fang", 1));

            AddReward(new BaseReward(typeof(AlchemistCraftsmanSatchel), 1074282));
        }

        /* Reptilian Dentist */
        public override object Title => 1074280;
        /* I'm working on a striking necklace -- something really unique -- and I know just what I need to finish it up.  
        A huge fang!  Won't that catch the eye?  I would like to employ you to find me such an item, perhaps a snake would 
        make the ideal donor.  I'll make it worth your while, of course. */
        public override object Description => 1074710;
        /* I understand.  I don't like snakes much either.  They're so creepy. */
        public override object Refuse => 1074723;
        /* Those really big snakes like swamps, I've heard.  You might try the blighted grove. */
        public override object Uncomplete => 1074722;
        /* Do you have it?  *gasp* What a tooth!  Here … I must get right to work. */
        public override object Complete => 1074721;
        public override bool CanOffer()
        {
            return MondainsLegacy.BlightedGrove;
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
