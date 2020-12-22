namespace Library.Items.ExceptionalItems
{
    /// <summary>
    /// Clase que representa un tipo de item excepcional mágico llamado Spell.
    /// La habilidad de este item es ser combinado con items de tipo <see cref="SpellBook"/>
    /// para resultar en otro SpellBook con estadísticas más poderosas.
    /// Cabe aclarar, un spell por sí solo no añade ninguna estadística a ningún personaje.
    /// </summary>
    public class Spell : MagicItem
    {
        /// <summary>
        /// Crea un nuevo Spell.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="damageValue">La cantidad de puntos de ataque que agregará este item.</param>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public Spell(int defenseValue, int damageValue, int healthValue) : base(defenseValue, damageValue, healthValue)
        {
        }

        public override string ToString()
        {
            return "Spell";
        }
    }
}