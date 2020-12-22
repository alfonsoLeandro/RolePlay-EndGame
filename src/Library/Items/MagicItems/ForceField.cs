namespace Library.Items.MagicItems
{
    /// <summary>
    /// Clase que representa un tipo de item mágico llamado ForceField.
    /// </summary>
    public class ForceField : MagicItem
    {
        /// <summary>
        /// Crea un nuevo ForceField.
        /// </summary>
        /// <param name="defenseValue">La cantidad de puntos de defensa que agregará este item.</param>
        /// <param name="healthValue">La cantidad de puntos de salud que agregará este item.</param>
        public ForceField(int defenseValue,  int healthValue) : base(defenseValue, 0, healthValue)
        {
        }

        public override string ToString()
        {
            return "Force field";
        }
    }
}