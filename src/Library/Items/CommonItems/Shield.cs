namespace Library.Items.CommonItems
{
    /// <summary>
    /// Clase que representa un tipo de item llamado Shield.
    /// </summary>
    public class Shield : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo Shield.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        public Shield(int defenseValue) : base(defenseValue, 0, 0)
        {
        }

        public override string ToString()
        {
            return "Shield";
        }
        
        //Combinations: shield+sword, shield+trident
        
        /// <summary>
        /// Combina este item con un <see cref="Sword"/> para crear un item
        /// compuesto no mágico.
        /// </summary>
        /// <param name="sword">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto no mágico formado por estos dos items.</returns>
        public CompoundNonMagicItem Combine(Sword sword)
        {
            return new CompoundNonMagicItem(this, sword,
                "Shield and sword");
        }    
        
        /// <summary>
        /// Combina este item con un <see cref="Trident"/> para crear un item
        /// compuesto no mágico.
        /// </summary>
        /// <param name="trident">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto no mágico formado por estos dos items.</returns>
        public CompoundNonMagicItem Combine(Trident trident)
        {
            return new CompoundNonMagicItem(this, trident,
                "Shield and trident");
        }
    }
}