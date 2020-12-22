namespace Library.Items.CommonItems
{
    /// <summary>
    /// Clase que representa un tipo de item llamado Sword.
    /// </summary>
    public class Sword : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo Sword.
        /// </summary>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        public Sword(int damageValue) : base(0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Sword";
        }
        
        //Combinations: sword+sword, sword+shield, sword+sharp shield
        
        /// <summary>
        /// Combina este item con un <see cref="Sword"/> para crear un item
        /// compuesto no mágico.
        /// </summary>
        /// <param name="sword">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto no mágico formado por estos dos items.</returns>
        public CompoundNonMagicItem Combine(Sword sword)
        {
            return new CompoundNonMagicItem(this, sword,
                "Crossed swords");
        }    
        
        /// <summary>
        /// Combina este item con un <see cref="Shield"/> para crear un item
        /// compuesto no mágico.
        /// </summary>
        /// <param name="shield">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto no mágico formado por estos dos items.</returns>
        public CompoundNonMagicItem Combine(Shield shield)
        {
            return new CompoundNonMagicItem(this, shield,
                "Sword and shield");
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
                "Sword and sharp shield");
        }
    }
}