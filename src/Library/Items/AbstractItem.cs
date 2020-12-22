

namespace Library.Items
{
    /// <summary>
    /// Clase abstracta destinada a ser heredada por los tipos de items mágicos y no mágicos.
    /// </summary>
    /// <seealso cref="MagicItem"/>
    /// <seealso cref="NonMagicItem"/>
    public abstract class AbstractItem
    {
        /// <summary>
        /// Los puntos de defensa que agregará este item a el personaje que lo posea.
        /// </summary>
        public int DefenseValue { get; protected set; }
        /// <summary>
        /// Los puntos de ataque que agregará este item a el personaje que lo posea.
        /// </summary>
        public int DamageValue { get; protected set; }
        /// <summary>
        /// Los puntos de salud que agregará este item a el personaje que lo posea.
        /// </summary>
        public int HealthValue { get; protected set; }

        /// <summary>
        /// Crea un nuevo item y establece sus propiedades o estadísticas.
        /// </summary>
        /// <param name="defenseValue">Los puntos de defensa que agregará este item a el personaje que lo posea.</param>
        /// <param name="damageValue">Los puntos de ataque que agregará este item a el personaje que lo posea.</param>
        /// <param name="healthValue">Los puntos de salud que agregará este item a el personaje que lo posea.</param>
        protected AbstractItem(int defenseValue, int damageValue, int healthValue)
        {
            this.DefenseValue = defenseValue;
            this.DamageValue = damageValue;
            this.HealthValue = healthValue;
        }

        /// <summary>
        /// Obtiene el nombre de este item, utilizado generalmente para la combinación de items.
        /// </summary>
        /// <returns>El nombre de este item.</returns>
        public abstract override string ToString();
    }
}