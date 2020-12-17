namespace Library.Items.CommonItems.Potions
{
    public class ResistancePotion : AbstractItem
    {
        public ResistancePotion(int defenseValue) : base(false, false, defenseValue, 0, 0)
        {
        }

        public override string ToString()
        {
            return "Resistance potion";
        }
    }
}