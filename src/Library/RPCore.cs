using Library.EventLogger;

namespace Library
{
    public class RpCore
    {
        public static RpCore Instance { get; set; }
        public ILogger Logger { get; }
        public string ResultsFile { get; set; }

        
        private RpCore(ILogger logger)
        {
            this.Logger = logger;
        }




        public static void Initialize(ILogger logger)
        {
            Instance = new RpCore(logger);
        }
        
        
    }
}