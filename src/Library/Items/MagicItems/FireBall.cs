namespace Library.Items.MagicItems
{
    public class FireBall : MagicItem
    {
        public FireBall(int damageValue) : base(0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Fire ball";
        }
        
        //Combinations: FireBall+Staff
        
        public CompoundMagicItem Combine(ForbiddenStaff staff)
        {
            return new CompoundMagicItem(this, staff, 
                "Fireball shooting forbidden staff");
        }
        
    }
}