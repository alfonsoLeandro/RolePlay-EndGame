namespace Library.Items.CommonItems.Potions
{
    /// <summary>
    /// Clase que representa un tipo de item llamado StrengthPotion.
    /// </summary>
    public class StrengthPotion : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo StrengthPotion.
        /// </summary>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        public StrengthPotion(int damageValue) : base(0, damageValue, 0)
        {
        }

        public override string ToString()
        {
            return "Strength potion";
        }
    }
}