namespace Library.Items.MagicItems
{
    /// <summary>
    /// Clase que representa un tipo de item mágico llamado ForbiddenStaff.
    /// </summary>
    public class ForbiddenStaff : MagicItem
    {
        /// <summary>
        /// Crea un nuevo ForbiddenStaff.
        /// </summary>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public ForbiddenStaff(int damageValue, int healthValue) : base( 0, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Forbidden staff";
        }
        
        //Combinations: Staff+FireBall
        
        /// <summary>
        /// Combina este item con un <see cref="FireBall"/> para crear un item
        /// compuesto mágico.
        /// </summary>
        /// <param name="fireBall">El item a combinar con este item.</param>
        /// <returns>Un nuevo item compuesto mágico formado por estos dos items.</returns>
        public CompoundMagicItem Combine(FireBall fireBall)
        {
            return new CompoundMagicItem(this, fireBall, 
                "Fireball shooting forbidden staff");
        }
    }
}