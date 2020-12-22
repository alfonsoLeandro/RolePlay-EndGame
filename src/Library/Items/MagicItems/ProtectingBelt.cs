namespace Library.Items.MagicItems
{
    /// <summary>
    /// Clase que representa un tipo de item mágico llamado ProtectingBelt.
    /// </summary>
    public class ProtectingBelt : MagicItem
    {
        /// <summary>
        /// Crea un nuevo ProtectingBelt.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public ProtectingBelt(int defenseValue, int healthValue) : base(defenseValue, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Protecting belt";
        }
    }
}