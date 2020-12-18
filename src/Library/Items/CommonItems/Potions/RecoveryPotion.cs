namespace Library.Items.CommonItems.Potions
{
    public class RecoveryPotion : NonMagicItem
    {
        public RecoveryPotion(int defenseValue, int healthValue) : base(defenseValue, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Recovery potion";
        }
    }
}