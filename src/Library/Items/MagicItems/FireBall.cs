namespace Library.Items.MagicItems
{
    /// <summary>
    /// Clase que representa un tipo de item mágico llamado Fireball.
    /// </summary>
    public class FireBall : MagicItem
    {
        /// <summary>
        /// Crea un nuevo Fireball.
        /// </summary>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        public FireBall(int damageValue) : base(0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Fire ball";
        }
        
        //Combinations: FireBall+Staff
        
        /// <summary>
        /// Combina este item con un <see cref="ForbiddenStaff"/> para crear un item
        /// compuesto mágico.
        /// </summary>
        /// <param name="staff">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto mágico formado por estos dos items.</returns>
        public CompoundMagicItem Combine(ForbiddenStaff staff)
        {
            return new CompoundMagicItem(this, staff, 
                "Fireball shooting forbidden staff");
        }
        
    }
}