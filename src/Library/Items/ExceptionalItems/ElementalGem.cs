namespace Library.Items.ExceptionalItems
{
    /// <summary>
    /// Clase que representa un tipo de item excepcional llamado ElementalGem.
    /// La habilidad de este item es ser combinado con items de tipo <see cref="DarkSword"/>
    /// para resultar en otro DarkSword con estadísticas más poderosas.
    /// Cabe aclarar, una gema elemental por sí sola no añade ninguna estadística a ningún personaje.
    /// </summary>
    public class ElementalGem : NonMagicItem
    {
        /// <summary>
        /// Crea un nuevo ElementalGem.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public ElementalGem(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Elemental gem";
        }
    }
}