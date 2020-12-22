namespace Library.Items.CommonItems
{
    /// <summary>
    /// Clase que representa un tipo de item llamado SharpShield.
    /// </summary>
    public class SharpShield : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo SharpShield.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        public SharpShield(int defenseValue, int damageValue) : base(defenseValue, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Sharp shield";
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
                "Sharp shield and sword");
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
                "Sharp shield and trident");
        }


    }
}