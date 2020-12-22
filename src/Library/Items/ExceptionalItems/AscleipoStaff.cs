namespace Library.Items.ExceptionalItems
{
    /// <summary>
    /// Clase que representa un tipo de item excepcional llamado AscleipoStaff.
    /// La habilidad de este item es ser combinado con un item mágico para resultar en un item
    /// compuesto no mágico y asi ser portado por personajes no mágicos.
    /// </summary>
    public class AscleipoStaff : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo AscleipoStaff.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public AscleipoStaff(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Ascleipo staff";
        }
        
        //Combinations: staff+MAGIC
        
        /// <summary>
        /// Combina este item con cualquier <see cref="MagicItem"/> para crear un item
        /// compuesto no mágico.
        /// </summary>
        /// <param name="item">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto no mágico formado por estos dos items.</returns>
        public CompoundNonMagicItem Combine(MagicItem item)
        {
            return new CompoundNonMagicItem(this, item,
                "Ascleipo staff and "+item.ToString());
        }    
        
    }
}