namespace Library.Items.MagicItems
{
    public class Fireball : MagicItem
    {
        public Fireball(int damageValue) : base(0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Fire ball";
        }
    }
}