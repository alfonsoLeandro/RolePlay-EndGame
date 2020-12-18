namespace Library.Items.ExceptionalItems
{
    public class ElementalGem : NonMagicItem
    {
        public ElementalGem(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Elemental gem";
        }
    }
}