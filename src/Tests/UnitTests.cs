using System;
using NUnit.Framework;
using Library.Characters.Heroes;
using System.Collections.Generic;
using Library.Characters.Villains;
using Library.Encounters;
using Library.EventLogger;
using Library.Exceptions;
using Library.Items;
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
            SpellBook spellBook = new SpellBook(new List<Spell>());
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
            Wizard wizard = new Wizard(1,1,1,new List<AbstractItem>());

            try
            {
                wizard.AddItem(staff);
            }
            catch (CannotAddItemException e)
            {
                failed = true;
            }
            
            Assert.IsFalse(failed);
        }     
        
        [TestCase]
        public void Successful_item_combination()
        {
            Sword sword = new Sword(10);
            Shield shield = new Shield(10);

            var combined = shield.Combine(sword);

            Assert.IsTrue(combined.ToString().Equals("Shield and sword")
                          && combined.DamageValue.Equals(sword.DamageValue) 
                          && combined.DefenseValue.Equals(shield.DefenseValue));
        } 
        
        [TestCase]
        public void Successful_elemental_gem_added_to_dark_sword()
        {
            DarkSword darkSword = new DarkSword(new List<ElementalGem>());
            ElementalGem gem = new ElementalGem(10,10, 10);
            
            var combined = darkSword.Combine(gem);

            Assert.IsTrue(combined.ToString().Equals("Dark sword")
                          && combined.DamageValue.Equals(gem.DamageValue) 
                          && combined.DefenseValue.Equals(gem.DefenseValue)
                          && combined.HealthValue.Equals(gem.HealthValue));
        }

        [TestCase]
        public void Successfully_recognize_gem_and_dark_sword_and_combine_them()
        {
            DarkSword darkSword = new DarkSword(new List<ElementalGem>());
            ElementalGem gem = new ElementalGem(10,10,10);
            
            Knight knight = new Knight(10,10,10, new List<AbstractItem>(){darkSword, gem});
            
            Assert.IsTrue(knight.Damage.Equals(10+gem.DamageValue) 
                          && knight.Defense.Equals(10+gem.DefenseValue)
                          && knight.Hp.Equals(10+gem.HealthValue));
        }   
        
        [TestCase]
        public void Successfully_recognize_gem_and_dark_sword_and_combine_them_after_creation()
        {
            DarkSword darkSword = new DarkSword(new List<ElementalGem>());
            
            Knight knight = new Knight(10,10,10, new List<AbstractItem>(){darkSword});

            ElementalGem gem = new ElementalGem(10,10,10);
            
            knight.AddItem(gem);
            
            
            Assert.IsTrue(knight.Damage.Equals(10+gem.DamageValue) 
                          && knight.Defense.Equals(10+gem.DefenseValue)
                          && knight.Hp.Equals(10+gem.HealthValue));
        }   
        
        [TestCase]
        public void Successfully_recognize_spell_and_spell_book_and_combine_them()
        {
            SpellBook spellBook = new SpellBook(new List<Spell>());
            Spell spell = new Spell(10,10,10);
            
            Wizard wizard = new Wizard(10,10,10, new List<AbstractItem>(){spellBook, spell});
            
            Assert.IsTrue(wizard.Damage.Equals(10+spell.DamageValue) 
                          && wizard.Defense.Equals(10+spell.DefenseValue)
                          && wizard.Hp.Equals(10+spell.HealthValue));
        }
        
        [TestCase]
        public void Successfully_recognize_spell_and_spell_book_and_combine_them_after_creation()
        {
            SpellBook spellBook = new SpellBook(new List<Spell>());
            
            Wizard wizard = new Wizard(10,10,10, new List<AbstractItem>(){spellBook});
            
            Spell spell = new Spell(10,10,10);
            
            wizard.AddItem(spell);
            
            Assert.IsTrue(wizard.Damage.Equals(10+spell.DamageValue) 
                          && wizard.Defense.Equals(10+spell.DefenseValue)
                          && wizard.Hp.Equals(10+spell.HealthValue));
        }

        [TestCase]
        public void Ascleipo_staff_combined_is_non_magic()
        {
            bool failed = false;
            
            AscleipoStaff staff = new AscleipoStaff(10,10,10);
            FireBall fireBall = new FireBall(100);
            
            Knight knight = new Knight(10,0,0, new List<AbstractItem>());

            try
            {
                knight.AddItem(staff.Combine(fireBall));
            }
            catch (Exception e)
            {
                failed = true;
            }
            
            Assert.IsTrue(!failed && knight.Damage.Equals(110));
        }       
        
        [TestCase]
        public void Cannot_add_magic_compound_to_non_wizard_or_witch()
        {
            bool failed = false;
            
            FireBall fireBall = new FireBall(100);
            ForbiddenStaff staff = new ForbiddenStaff(10,10);
            
            
            Knight knight = new Knight(10,0,0, new List<AbstractItem>());

            try
            {
                knight.AddItem(fireBall.Combine(staff));
            }
            catch (Exception e)
            {
                failed = true;
            }
            
            Assert.IsTrue(failed && knight.Damage.Equals(0));
        }
        
   
        
    }
}