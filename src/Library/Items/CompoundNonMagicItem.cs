namespace Library.Items
{
    /// <summary>
    /// Clase que representa a un item producido por la combinación de dos items de tipo no mágico.
    /// </summary>
    /// <seealso cref="NonMagicItem"/>
    public class CompoundNonMagicItem : NonMagicItem
    {
        /// <summary>
        /// El nombre final de este item para ser utilizado en el método ToString()
        /// </summary>
        private readonly string itemName;
        
        /// <summary>
        /// Crea un nuevo item compuesto no mágico a partir de dos items.
        /// </summary>
        /// <param name="item1">El primer item.</param>
        /// <param name="item2">El segundo item.</param>
        /// <param name="itemName">El nombre de la combinación de estos dos items.</param>
        public CompoundNonMagicItem(AbstractItem item1, AbstractItem item2, string itemName) :
            this(item1.DefenseValue+item2.DefenseValue, 
                item1.DamageValue+item2.DamageValue, 
                item1.HealthValue+item2.HealthValue, 
                itemName)
        {
        }
        
        /// <summary>
        /// Crea un nuevo item compuesto no mágico a partir de las propiedades o estadísticas de dos o más items.
        /// </summary>
        /// <param name="defenseValue">Los puntos de defensa del item resultante.</param>
        /// <param name="damageValue">Los puntos de ataque del item resultante.</param>
        /// <param name="healthValue">Los puntos de salud del item resultante.</param>
        /// <param name="itemName">El nombre de la combinación de estos dos items.</param>
        public CompoundNonMagicItem(int defenseValue, int damageValue, int healthValue, string itemName) : base(defenseValue, damageValue, healthValue)
        {
            this.itemName = itemName;
        }

        public override string ToString()
        {
            return itemName;
        }
    }
}