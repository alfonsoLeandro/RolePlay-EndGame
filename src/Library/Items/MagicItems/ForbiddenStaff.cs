namespace Library.Items.MagicItems
{
    public class ForbiddenStaff : AbstractItem
    {
        public ForbiddenStaff(int damageValue, int healthValue) : base(false, true, 0, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Forbidden staff";
        }
    }
}