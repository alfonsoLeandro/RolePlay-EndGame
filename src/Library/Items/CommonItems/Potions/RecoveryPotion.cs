namespace Library.Items.CommonItems.Potions
{
    /// <summary>
    /// Clase que representa un tipo de item llamado RecoveryPotion.
    /// </summary>
    public class RecoveryPotion : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo RecoveryPotion.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public RecoveryPotion(int defenseValue, int healthValue) : base(defenseValue, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Recovery potion";
        }
    }
}