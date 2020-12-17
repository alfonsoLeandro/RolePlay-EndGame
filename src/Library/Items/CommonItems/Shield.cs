namespace Library.Items.Common_items
{
    public class Shield : AbstractItem
    {
        public Shield(int defenseValue) : base(false, false, defenseValue, 0, 0)
        {
        }

        public override string ToString()
        {
            return "Shield";
        }
    }
}