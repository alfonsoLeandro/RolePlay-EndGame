using System.Collections.Generic;
using Library.Encounters;

namespace Library.Scenarios
{
    /// <summary>
    /// Interfaz destinada a ser implementada por clases dedicadas a cargar listas
    /// de encuentros de batallas para ser utilizadas en la creación de escenarios.
    /// </summary>
    public interface IProcessScenarios
    {
        /// <summary>
        /// Procesa la información desde una fuente dada y devuelve la misma
        /// en el formato de lista de encuentros de batalla.
        /// </summary>
        /// <returns>Una lista de encuentros de batalla.</returns>
        List<BattleEncounter> Process();
    }
}