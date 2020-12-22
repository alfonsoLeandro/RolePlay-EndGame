using System.Collections.Generic;
using System.IO;
using Library;
using Library.Characters.Heroes;
using Library.Characters.Villains;
using Library.Encounters;
using Library.EventLogger;
using Library.Items;
using Library.Items.CommonItems;
using Library.Items.CommonItems.Potions;
using Library.Items.ExceptionalItems;
using Library.Items.MagicItems;
using Library.Scenarios;

namespace RolePlay_EndGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            RpCore.Initialize(new ConsoleEventLogger(),
                Path.Combine("..","..","..","..","..","src","Program","results.csv"));


            
            //var scenariosData = new ProcessScenariosFile().Process();
            
            var scenariosData = new List<BattleEncounter>()
            {
                new BattleEncounter(new List<AbstractHero>()
                    {
                        new Angel(10,324,12,new List<AbstractItem>()
                        {
                            new Shield(30)
                        })
                    },
                    new List<AbstractVillain>(){
                        new Dragon(50,12,43, new List<AbstractItem>()
                        {
                            new Sword(30)
                        }),
                        new Caronte(50,21,12, new List<AbstractItem>()
                        {
                            new Shield(100)
                        })
                    }),
                new BattleEncounter(new List<AbstractHero>()
                    {
                        new Dwarf(10,324,12,new List<AbstractItem>()
                        {
                            new Shield(30)
                        }),
                        new Archer(50,523,1, new List<AbstractItem>()
                        {
                            new AscleipoStaff(40,30,40).Combine(new FireBall(100))
                        }),
                        new Knight(40,900,97, new List<AbstractItem>()
                        {
                            new DarkSword(),
                            new ElementalGem(30,40,0),
                            new ElementalGem(5,10,50)
                        })
                    },
                    new List<AbstractVillain>(){
                        new Cerberus(560,12,43, new List<AbstractItem>()
                        {
                            new CuringPotion(30),
                            new OPPotion(30, 50,1)
                        }),
                        new Satan(5660,21,12, new List<AbstractItem>()
                        {
                            new Shield(10)
                        }),
                        new Demon(600, 30,10, new List<AbstractItem>()
                        {
                            new Trident(100, 10),
                            new StrengthPotion(100)
                        })
                    }),
                new BattleEncounter(new List<AbstractHero>()
                    {
                        new Wizard(10,324,12,new List<AbstractItem>()
                        {
                            new FireBall(100),
                            new Spell(30,80,90),
                            new Spell(30,80,90),
                            new SpellBook()
                        })
                    },
                    new List<AbstractVillain>(){
                        new Witch(10,324,12,new List<AbstractItem>()
                        {
                            new FireBall(100),
                            new Spell(30,80,90),
                            new Spell(30,80,90),
                            new SpellBook()
                        })
                    }),
                 
            };
            Scenario scenario = new Scenario(scenariosData);

            scenario.StartScenario();
            RpCore.Instance.Logger.Log("Finished!");
            
        }
        
    }
}