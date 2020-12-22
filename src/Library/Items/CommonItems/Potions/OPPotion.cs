namespace Library.Items.CommonItems.Potions
{
    /// <summary>
    /// Clase que representa un tipo de item llamado OPPotion.
    /// </summary>
    public class OPPotion : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo OPPotion.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public OPPotion(int defenseValue, int damageValue, int healthValue) : base(defenseValue*2, damageValue*2, healthValue*2)
        {
        }

        public override string ToString()
        {
            return "OP Potion";
        }
    }
}