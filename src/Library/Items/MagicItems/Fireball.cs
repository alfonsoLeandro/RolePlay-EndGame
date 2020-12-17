namespace Library.Items.MagicItems
{
    public class Fireball : AbstractItem
    {
        public Fireball(int damageValue) : base(false, true, 0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Fire ball";
        }
    }
}