namespace Library.Items.CommonItems.Potions
{
    public class RecoveryPotion : AbstractItem
    {
        public RecoveryPotion(int defenseValue, int healthValue) : base(false, false, defenseValue, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Recovery potion";
        }
    }
}