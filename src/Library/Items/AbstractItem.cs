using Library.Exceptions;
using Library.Items.ExceptionalItems;

namespace Library.Items
{
    public abstract class AbstractItem
    {
        private bool IsCompound { get; }
        public bool IsMagic { get; }
        public int DefenseValue { get; }
        public int DamageValue { get; }
        public int HealthValue { get; }

        protected AbstractItem(bool isCompound, bool isMagic, int defenseValue, int damageValue, int healthValue)
        {
            this.IsCompound = isCompound;
            this.IsMagic = isMagic;
            this.DefenseValue = defenseValue;
            this.DamageValue = damageValue;
            this.HealthValue = healthValue;
        }

        
        public CompoundItem Combine(AbstractItem anotherItem)
        {
            if(this.IsCompound || anotherItem.IsCompound) throw new CannotCombineCompoundsException("Un item compuesto no se puede combinar con otro item.");
            
            //Rompo con polimorfismo para comprobar que alguno de los items sea la Ascleipo Staff
            //para así devolver un item que no sea mágico (siguiendo lo que pide la conigna).
            //Podria tambien hacer un override de este metodo en la clase de Ascleipo Staff pero
            //no tomaría en cuenta que pasa cuando un item que no es Ascleipo Staff se combina con la
            //Ascleipo Staff
            if (GetType() == typeof(AscleipoStaff) || anotherItem.GetType() == typeof(AscleipoStaff))
            {
                return new CompoundItem(false,
                    this.DefenseValue + anotherItem.DefenseValue,
                    this.DamageValue + anotherItem.DamageValue,
                    this.HealthValue + anotherItem.HealthValue,
                    $"{this.ToString()} and {anotherItem.ToString()}");
            }
            return new CompoundItem(this, anotherItem, $"{this.ToString()} and {anotherItem.ToString()}");
        }

        public abstract override string ToString();
    }
}