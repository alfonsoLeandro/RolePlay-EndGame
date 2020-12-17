namespace Library.Items.ExceptionalItems
{
    public class AscleipoStaff : AbstractItem
    {
        //TODO
        public AscleipoStaff(bool isCompound, bool isMagic, int defenseValue, int damageValue, int healthValue) : base(isCompound, isMagic, defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Ascleipo staff";
        }
    }
}