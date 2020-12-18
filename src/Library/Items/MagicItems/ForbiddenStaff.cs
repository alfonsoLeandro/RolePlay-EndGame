namespace Library.Items.MagicItems
{
    public class ForbiddenStaff : MagicItem
    {
        public ForbiddenStaff(int damageValue, int healthValue) : base( 0, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Forbidden staff";
        }
        
        //Combinations: Staff+FireBall
        
        public CompoundMagicItem Combine(FireBall fireBall)
        {
            return new CompoundMagicItem(this, fireBall, 
                "Fireball shooting forbidden staff");
        }
    }
}