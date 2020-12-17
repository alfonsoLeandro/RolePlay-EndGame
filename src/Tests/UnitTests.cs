using System;
using NUnit.Framework;
using Library.Characters.Heroes;
using System.Collections.Generic;
using Library.Characters.Villains;
using Library.Encounters;
using Library.EventLogger;
using Library.Exceptions;
using Library.Items;
using Library.Items.Common_items;
using Library.Items.CommonItems;
using Library.Items.ExceptionalItems;
using Library.Items.MagicItems;

namespace Library.Tests
{
    public class UnitTests
    {
    
        [SetUp]
        public void SetUp()
        {
            RpCore.InitializeInstance(new ConsoleEventLogger());
        }
        

        [TestCase]
        public void Character_is_dead()
        {
            Elf elf = new Elf(10, 10, 0, new List<AbstractItem>());
            Dragon dragon = new Dragon(10, 10, 0, new List<AbstractItem>());
            
            dragon.Attack(elf);
            
            Assert.IsFalse(elf.IsAlive());
        }

        [TestCase]
        public void Successful_exchange()
        {
            Dwarf dwarf = new Dwarf(9, 1, 0, new List<AbstractItem>());
            Demon demon = new Demon(23,6547, 24, new List<AbstractItem>());
            
            dwarf.AddItem(new Sword(999999999));
            
            ExchangeEncounter encounter = new ExchangeEncounter(dwarf, demon);
            
            Assert.IsTrue(encounter.RunEncounter());
        }    
        
        [TestCase]
        public void UnSuccessful_exchange()
        {
            Dwarf dwarf = new Dwarf(9, 1, 0, new List<AbstractItem>());
            Demon demon = new Demon(23,6547, 24, new List<AbstractItem>());
            
            //dwarf no tiene nigun item. El intercambio deberia fallar (devolver false.)
            //dwarf.AddItem(new Sword(999999999));
            
            ExchangeEncounter encounter = new ExchangeEncounter(dwarf, demon);
            
            Assert.IsFalse(encounter.RunEncounter());
        }
        
        
        [TestCase]
        public void Villains_win_battle_encounter()
        {
            Dwarf dwarf = new Dwarf(9, 1, 0, new List<AbstractItem>());
            Elf elf = new Elf(10, 3, 0, new List<AbstractItem>());
            Wizard wizard = new Wizard(8, 4, 0, new List<AbstractItem>());
            
            
            Demon demon = new Demon(23,6547, 24, new List<AbstractItem>());
            Dragon dragon = new Dragon(10, 10, 0, new List<AbstractItem>());
            Orc orc = new Orc(24, 4, 1, new List<AbstractItem>());

            var heroes = new List<AbstractHero> {dwarf, elf, wizard};
            var villains = new List<AbstractVillain> {demon, dragon, orc};

            BattleEncounter encounter = new BattleEncounter(heroes, villains);
            
            Assert.IsFalse(encounter.RunEncounter());
        }    
        
        
        [TestCase]
        public void Heroes_win_battle_encounter()
        {
            Dwarf dwarf = new Dwarf(1000, 80, 0, new List<AbstractItem>());
            Elf elf = new Elf(67060, 45, 0, new List<AbstractItem>());
            Wizard wizard = new Wizard(9595, 54, 0, new List<AbstractItem>());
            
            
            Demon demon = new Demon(23,1, 24, new List<AbstractItem>());
            Dragon dragon = new Dragon(10, 10, 0, new List<AbstractItem>());
            Orc orc = new Orc(24, 4, 1, new List<AbstractItem>());

            var heroes = new List<AbstractHero> {dwarf, elf, wizard};
            var villains = new List<AbstractVillain> {demon, dragon, orc};

            BattleEncounter encounter = new BattleEncounter(heroes, villains);
            
            Assert.IsTrue(encounter.RunEncounter());
        }

        [TestCase]
        public void Cannot_add_magic_item_to_non_wizard_character()
        {
            bool failed = false;
            SpellBook spellBook = new SpellBook();
            Elf elf = new Elf(1,1,1,new List<AbstractItem>());

            try
            {
                elf.AddItem(spellBook);
            }
            catch (CannotAddItemException e)
            {
                failed = true;
            }
            
            Assert.IsTrue(failed);
        }  
        
        [TestCase]
        public void Can_add_magic_item_to_wizard()
        {
            bool failed = false;
            ForbiddenStaff staff = new ForbiddenStaff(70,90);
            Wizard elf = new Wizard(1,1,1,new List<AbstractItem>());

            try
            {
                elf.AddItem(staff);
            }
            catch (CannotAddItemException e)
            {
                failed = true;
            }
            
            Assert.IsFalse(failed);
        }
        
    }
}
