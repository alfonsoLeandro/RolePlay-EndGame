namespace Library.Items
{
    /// <summary>
    /// Clase abstracta destinada a ser heredada por cualquier item de tipo no mágico.
    /// La utilización de esta clase podría haber sido obviada y en su lugar utilizar simplemente
    /// <see cref="AbstractItem"/> pero decidí crear esta clase igualmente simplemente para
    /// dejar en claro cuales items son mágicos y cuales no.
    /// </summary>
    public abstract class NonMagicItem : AbstractItem
    {
        
        /// <summary>
        /// Crea un nuevo item no mágico y establece sus propiedades o estadísticas.
        /// </summary>
        /// <param name="defenseValue">Los puntos de defensa que agregará este item a el personaje que lo posea.</param>
        /// <param name="damageValue">Los puntos de ataque que agregará este item a el personaje que lo posea.</param>
        /// <param name="healthValue">Los puntos de salud que agregará este item a el personaje que lo posea.</param>
        public NonMagicItem(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }
    }
}