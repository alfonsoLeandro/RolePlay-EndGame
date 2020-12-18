namespace Library.Items.CommonItems.Potions
{
    public class ResistancePotion : NonMagicItem
    {
        public ResistancePotion(int defenseValue) : base(defenseValue, 0, 0)
        {
        }

        public override string ToString()
        {
            return "Resistance potion";
        }
    }
}