namespace Library.Items.ExceptionalItems
{
    public class DarkSword : AbstractItem
    {
        public DarkSword() : base(false, false, 0, 0, 0)
        {
        }

        public override string ToString()
        {
            return "Dark sword";
        }
    }
}