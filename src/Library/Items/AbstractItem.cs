

namespace Library.Items
{
    public abstract class AbstractItem
    {
        public int DefenseValue { get; protected set; }
        public int DamageValue { get; protected set; }
        public int HealthValue { get; protected set; }

        protected AbstractItem(int defenseValue, int damageValue, int healthValue)
        {
            this.DefenseValue = defenseValue;
            this.DamageValue = damageValue;
            this.HealthValue = healthValue;
        }

        public abstract override string ToString();
    }
}