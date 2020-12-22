namespace Library.Encounters
{
    /// <summary>
    /// Interfaz destinada a ser implementada en encuentros de cualquier tipo.
    /// </summary>
    /// <see cref="BattleEncounter"/>
    /// <see cref="ExchangeEncounter"/>
    public interface IEncounter
    {
        /// <summary>
        /// Ejecuta el encuentro.
        /// </summary>
        /// <returns>Depende del tipo de encuentro.</returns>
        bool RunEncounter();
    }
}