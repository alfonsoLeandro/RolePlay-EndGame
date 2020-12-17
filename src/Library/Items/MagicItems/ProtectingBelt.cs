namespace Library.Items.MagicItems
{
    public class ProtectingBelt : AbstractItem
    {
        public ProtectingBelt(int defenseValue, int healthValue) : base(false, true, defenseValue, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Protecting belt";
        }
    }
}