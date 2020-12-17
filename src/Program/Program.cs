using System.Collections.Generic;
using Library;
using Library.Characters.Heroes;
using Library.Characters.Villains;
using Library.Encounters;
using Library.EventLogger;
using Library.Items;

namespace RolePlay_EndGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            RpCore.InitializeInstance(new ConsoleEventLogger());
            
            Dwarf dwarf = new Dwarf(9, 110, 0, new List<AbstractItem>());
            Elf elf = new Elf(10, 87, 0, new List<AbstractItem>());
            Wizard wizard = new Wizard(1000, 900, 0, new List<AbstractItem>());
            
            
            Demon demon = new Demon(23,6547, 24, new List<AbstractItem>());
            Dragon dragon = new Dragon(10, 10, 0, new List<AbstractItem>());
            Orc orc = new Orc(24, 4, 1, new List<AbstractItem>());

            var heroes = new List<AbstractHero> {dwarf, elf, wizard};
            var villains = new List<AbstractVillain> {demon, dragon, orc};

            BattleEncounter encounter = new BattleEncounter(heroes, villains);
            
            encounter.RunEncounter();
            
            
        }
    }
}
