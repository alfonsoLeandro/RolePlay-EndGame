namespace Library.Items.ExceptionalItems
{
    public class ElementalGem : AbstractItem
    {
        public ElementalGem(int defenseValue, int damageValue, int healthValue) : base(false, false, defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Elemental gem";
        }
    }
}