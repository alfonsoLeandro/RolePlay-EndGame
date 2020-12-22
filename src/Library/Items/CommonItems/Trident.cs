namespace Library.Items.CommonItems
{
    /// <summary>
    /// Clase que representa un tipo de item llamado Trident.
    /// </summary>
    public class Trident : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo Trident.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        public Trident(int defenseValue, int damageValue) : base(defenseValue, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Trident";
        }
        
          
        //Combinations: trident+shield, trident+sharp shield

        
        /// <summary>
        /// Combina este item con un <see cref="Shield"/> para crear un item
        /// compuesto no mágico.
        /// </summary>
        /// <param name="shield">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto no mágico formado por estos dos items.</returns>
        public CompoundNonMagicItem Combine(Shield shield)
        {
            return new CompoundNonMagicItem(this, shield,
                "Trident and shield");
        }    
                
        /// <summary>
        /// Combina este item con un <see cref="SharpShield"/> para crear un item
        /// compuesto no mágico.
        /// </summary>
        /// <param name="shield">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto no mágico formado por estos dos items.</returns>
        public CompoundNonMagicItem Combine(SharpShield shield)
        {
            return new CompoundNonMagicItem(this, shield,
                "Trident and sharp shield");
        }
    }
}