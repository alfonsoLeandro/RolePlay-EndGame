﻿using Library;
using Library.EventLogger;

namespace RolePlay_EndGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            RpCore.Initialize(new ConsoleEventLogger());
        }
    }
}
