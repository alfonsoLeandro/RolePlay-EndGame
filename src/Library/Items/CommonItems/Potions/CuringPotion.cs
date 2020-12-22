namespace Library.Items.CommonItems.Potions
{
    /// <summary>
    /// Clase que representa un tipo de item llamado CuringPotion.
    /// </summary>
    public class CuringPotion : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo CuringPotion.
        /// </summary>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public CuringPotion(int healthValue) : base(0, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Curing potion";
        }
    }
}