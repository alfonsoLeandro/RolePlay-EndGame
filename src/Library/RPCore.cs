using Library.EventLogger;

namespace Library
{
    /// <summary>
    /// Clase encargada de almacenar datos sensibles para el programa como el Logger (<see cref="ILogger"/>)
    /// y el path al archivo de salida de los escenarios.
    /// </summary>
    public class RpCore
    {
        /// <summary>
        /// La única instancia de esta clase.
        /// Se aplica el patrón Singleton.
        /// </summary>
        public static RpCore Instance { get; set; }
        /// <summary>
        /// El ILogger seleccionado.
        /// </summary>
        public ILogger Logger { get; }
        /// <summary>
        /// El path al archivo de salida para los resultados de escenarios.
        /// </summary>
        public string ResultsFile { get; set; }

        /// <summary>
        /// Constructor privado para favorecer la aplicación del patrón singleton.
        /// </summary>
        /// <param name="logger">El logger que se utilizará en el programa.</param>
        /// <param name="pathToResultsFile">El path al archivo de salida para los resultados de los escenarios.</param>
        private RpCore(ILogger logger, string pathToResultsFile)
        {
            this.Logger = logger;
            this.ResultsFile = pathToResultsFile;
        }


        
        /// <summary>
        /// Inicializa la única instancia de ésta clase.
        /// </summary>
        /// <param name="logger">El logger que se utilizará en el programa.</param>
        /// <param name="pathToResultsFile">El path al archivo de salida para los resultados de los escenarios.</param>
        public static void Initialize(ILogger logger, string pathToResultsFile)
        {
            if (Instance == null)
            {
                Instance = new RpCore(logger, pathToResultsFile);
            }
        }
        
        
    }
}