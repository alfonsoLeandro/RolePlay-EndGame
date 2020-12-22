namespace Library.Items
{
    /// <summary>
    /// Clase abstracta destinada a ser heredada por cualquier item de tipo mágico.
    /// </summary>
    public abstract class MagicItem : AbstractItem
    {
        
        /// <summary>
        /// Crea un nuevo item mágico y establece sus propiedades o estadísticas.
        /// </summary>
        /// <param name="defenseValue">Los puntos de defensa que agregará este item a el personaje que lo posea.</param>
        /// <param name="damageValue">Los puntos de ataque que agregará este item a el personaje que lo posea.</param>
        /// <param name="healthValue">Los puntos de salud que agregará este item a el personaje que lo posea.</param>
        public MagicItem(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }
        
    }
}