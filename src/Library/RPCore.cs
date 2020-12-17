using Library.EventLogger;

namespace Library
{
    public class RpCore
    {
        private static RpCore Instance { get; set; }
        public ILogger Logger { get; }

        
        private RpCore(ILogger logger)
        {
            this.Logger = logger;
        }

        
        
        
        public static void InitializeInstance(ILogger logger)
        {
            Instance = new RpCore(logger);
        }
        
        
        public static RpCore GetInstance()
        {
            return Instance;
        }
        
    }
}