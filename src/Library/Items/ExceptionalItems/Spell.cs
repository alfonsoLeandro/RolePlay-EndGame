namespace Library.Items.ExceptionalItems
{
    public class Spell : MagicItem
    {
        public Spell(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Spell";
        }
    }
}