namespace Library.Items.CommonItems.Potions
{
    /// <summary>
    /// Clase que representa un tipo de item llamado ResistancePotion.
    /// </summary>
    public class ResistancePotion : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo ResistancePotion.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        public ResistancePotion(int defenseValue) : base(defenseValue, 0, 0)
        {
        }

        public override string ToString()
        {
            return "Resistance potion";
        }
    }
}