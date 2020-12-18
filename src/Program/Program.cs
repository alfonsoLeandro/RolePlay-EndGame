using System.Collections.Generic;
using Library;
using Library.Characters.Heroes;
using Library.EventLogger;
using Library.Items;
using Library.Items.ExceptionalItems;
using Library.Items.MagicItems;

namespace RolePlay_EndGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            RpCore.InitializeInstance(new ConsoleEventLogger());
        }
    }
}
