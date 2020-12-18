namespace Library.Items.MagicItems
{
    public class ForceField : MagicItem
    {
        public ForceField(int defenseValue,  int healthValue) : base(defenseValue, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Force field";
        }
    }
}