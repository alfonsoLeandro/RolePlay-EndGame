namespace Library.Items.MagicItems
{
    public class ProtectingBelt : MagicItem
    {
        public ProtectingBelt(int defenseValue, int healthValue) : base(defenseValue, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Protecting belt";
        }
    }
}