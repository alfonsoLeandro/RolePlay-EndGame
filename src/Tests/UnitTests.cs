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
using Library.Items.CommonItems.Potions;
using Library.Items.ExceptionalItems;
using Library.Items.MagicItems;

namespace Library.Tests
{
    /// <summary>
    /// Clase destinada a contener los tests de NUnit.
    /// Pido comprensión por parte de quien corrija estos tests ya que hay algunas cosas que pueden no estar
    /// hecha como fueron descritas en el punto número 5 de la tarea, y esto es porque realicé los tests antes
    /// de leer las recomendaciones de tests. A partir de la linea 283 realizo los tests que recomendaron en el
    /// punto numero 5, todos los anteriores son tests que encontré útiles.
    /// </summary>
    public class UnitTests
    {
    
        [SetUp]
        public void SetUp()
        {
            //Necesitado para que los Encounter no tiren NullPointerException
            RpCore.Initialize(new ConsoleEventLogger());
        }
        

        [TestCase]
        public void Character_is_dead()
        {
            Elf elf = new Elf(10, 10, 0);
            Dragon dragon = new Dragon(10, 10, 0);
            
            dragon.Attack(elf);
            
            Assert.IsFalse(elf.IsAlive());
        }

        [TestCase]
        public void Successful_exchange()
        {
            Dwarf dwarf = new Dwarf(9, 1, 0);
            Demon demon = new Demon(23,6547, 24);

            Sword sword = new Sword(999999999);
            
            dwarf.AddItem(sword);
            
            ExchangeEncounter encounter = new ExchangeEncounter(dwarf, demon, sword);
            
            Assert.IsTrue(encounter.RunEncounter());
        }    
        
        [TestCase]
        public void UnSuccessful_exchange()
        {
            bool failed = false;
            Dwarf dwarf = new Dwarf(9, 1, 0);
            Demon demon = new Demon(23,6547, 24);
            
            //dwarf no tiene nigun item. El intercambio deberia fallar (devolver false.)
            //dwarf.AddItem(new Sword(999999999));
            
            ExchangeEncounter encounter = new ExchangeEncounter(dwarf, demon, new Shield(82387));
            
            try
            {
                encounter.RunEncounter();
            }
            catch (Exception e)
            {
                failed = true;
            }
                
            Assert.IsTrue(failed);
        }
        
        
        [TestCase]
        public void Villains_win_battle_encounter()
        {
            Dwarf dwarf = new Dwarf(9, 1, 0);
            Elf elf = new Elf(10, 3, 0);
            Wizard wizard = new Wizard(8, 4, 0);
            
            
            Demon demon = new Demon(23,6547, 24);
            Dragon dragon = new Dragon(10, 10, 0);
            Orc orc = new Orc(24, 4, 1);

            var heroes = new List<AbstractHero> {dwarf, elf, wizard};
            var villains = new List<AbstractVillain> {demon, dragon, orc};

            BattleEncounter encounter = new BattleEncounter(heroes, villains);
            
            Assert.IsFalse(encounter.RunEncounter());
        }    
        
        
        [TestCase]
        public void Heroes_win_battle_encounter()
        {
            Dwarf dwarf = new Dwarf(1000, 80, 0);
            Elf elf = new Elf(67060, 45, 0);
            Wizard wizard = new Wizard(9595, 54, 0);
            
            
            Demon demon = new Demon(23,1, 24);
            Dragon dragon = new Dragon(10, 10, 0);
            Orc orc = new Orc(24, 4, 1);

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
            Elf elf = new Elf(1,1,1);
        
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
            Wizard wizard = new Wizard(1,1,1);

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
            
            Knight knight = new Knight(10,0,0);

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
            
            
            Knight knight = new Knight(10,0,0);

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

        [TestCase]
        public void Damage_is_increased_when_adding_item()
        {
            Knight knight = new Knight(10,0,0);
            Sword sword = new Sword(10);
            
            int previous = knight.Damage;
            
            knight.AddItem(sword);
            
            Assert.IsTrue(previous == 0 && knight.Damage == sword.DamageValue);
        } 
        
        [TestCase]
        public void Defense_is_increased_when_adding_item()
        {
            Knight knight = new Knight(10,0,0);
            Shield shield = new Shield(10);
            
            int previous = knight.Defense;
            
            knight.AddItem(shield);
            
            Assert.IsTrue(previous == 0 && knight.Defense == shield.DefenseValue);
        }
        
        [TestCase]
        public void Damage_is_reduced_when_removing_item()
        {
            Knight knight = new Knight(10,0,0);
            Sword sword = new Sword(10);
            
            knight.AddItem(sword);
            
            int previous = knight.Damage;
            
            knight.RemoveItem(sword);
            
            Assert.IsTrue(previous == sword.DamageValue && knight.Damage == 0);
        } 
        
        [TestCase]
        public void Defense_is_reduced_when_removing_item()
        {
            Knight knight = new Knight(10,0,0);
            Shield shield = new Shield(10);

            knight.AddItem(shield);
            
            int previous = knight.Defense;
            
            knight.RemoveItem(shield);
            
            Assert.IsTrue(previous == shield.DefenseValue && knight.Defense == 0);
        }  
        
        [TestCase]
        public void Damage_is_total_of_items_added_when_creating()
        {
            Sword sword = new Sword(10);
            Sword anotherSword = new Sword(30);
            Knight knight = new Knight(10,0,0, new List<AbstractItem>(){sword, anotherSword});

            
            Assert.AreEqual(knight.Damage, sword.DamageValue+anotherSword.DamageValue);
        } 
        
        [TestCase]
        public void Defense_is_total_of_items_added_when_creating()
        {
            Shield shield = new Shield(540);
            Shield anotherShield = new Shield(75);
            Knight knight = new Knight(10,0,0, new List<AbstractItem>(){shield, anotherShield});

            
            Assert.AreEqual(knight.Defense, shield.DefenseValue+anotherShield.DefenseValue);
        }
        
        [TestCase]
        public void Removing_non_existent_item_fails()
        {
            bool failed = false;
            Shield shield = new Shield(9);
            Knight knight = new Knight(10,0,0);

            try
            {
                knight.RemoveItem(shield);
            }
            catch (Exception e)
            {
                failed = true;
            }
            
            Assert.IsTrue(failed);
        }
        
        //TEST 9: Cambié el modo en que funciona la defensa, para agregar un "toque" o "salt" y para que no funcione
        //de la misma manera que los puntos de vida. La defensa puede ser muy eficiente o muy poco eficiente de la siguiente manera:
        //cuando un personaje es atacado, se le resta: (el poder de ataque del atacante menos un numero pseudo random entre 0 y el
        //poder de defensa del personaje atacado). Snippet de este código:
        //hero.Hp = Math.Max(0, hero.Hp - Math.Max(0, this.Damage - new Random().Next(hero.Defense)));


        [TestCase]
        public void Hp_cannot_be_lower_than_0()
        {
            Elf elf = new Elf(10,10,10);
            Satan satan = new Satan(10,999999999,10);
            
            satan.Attack(elf);
            
            Assert.IsTrue(elf.Hp >= 0);
        }
        
        //TEST 11: Nuevamente el punto del test 9.

        [TestCase]
        public void Sharer_loses_an_item_and_shared_gains_one()
        {
            //Characters:
            Caronte caronte = new Caronte(10,10,10);
            Wizard wizard = new Wizard(10,10,10);
            
            //Items:
            var curingPotion = new CuringPotion(103);
            var shield = new Shield(1456);
            var sword = new Sword(993);
            var trident = new Trident(12081,120);
            
            //Adding items:
            caronte.AddItem(shield);
            
            wizard.AddItem(curingPotion);
            wizard.AddItem(sword);
            wizard.AddItem(trident);
            
            //Encounter
            ExchangeEncounter encounter = new ExchangeEncounter(wizard, caronte, curingPotion);

            //Saving previous item counts
            int previousCaronteItems = caronte.Items.Count;
            int previousWizardItems = wizard.Items.Count;
            
            //Running the encounter (assuming the encounter success)
            encounter.RunEncounter();
            
            Assert.IsTrue(caronte.Items.Count == previousCaronteItems+1 
                          && wizard.Items.Count == previousWizardItems-1
                          && caronte.Items.Contains(curingPotion)
                          && !wizard.Items.Contains(curingPotion));
        }

        [TestCase]
        public void Sharer_loses_every_item_traded()
        {
            var items = new List<AbstractItem>()
            {
                new Shield(1234),
                new Sword(65),
                new Trident(43,1293)
            };
            
            Wizard sharer = new Wizard(10,10,10, items);
            Dragon receiver = new Dragon(2534,2344,1423);

            int previousSharerItems = sharer.Items.Count;
            int previousReceiverItems = receiver.Items.Count;

            var encounter = new ExchangeEncounter(sharer, receiver, items);

            encounter.RunEncounter();
            
            Assert.IsTrue(previousSharerItems == items.Count
                          && previousReceiverItems == 0
                          && sharer.Items.Count == 0
                          && receiver.Items.Count == items.Count);
        }

        [TestCase]
        public void Exception_should_be_thrown_when_sharer_does_not_have_specific_item()
        {
            Elf sharer = new Elf(1, 1, 1);
            Wizard receiver = new Wizard(34,3,3);
            
            Sword item = new Sword(12);
            
            ExchangeEncounter encounter = new ExchangeEncounter(sharer, receiver, item);

            Assert.Throws<NoItemsToShareException>(() => encounter.RunEncounter());
        }
        
        
        [TestCase]
        public void Expected_battle_result_1()
        {
            Satan satan = new Satan(10,0,0);
            ShadowHunter shadowHunter = new ShadowHunter(1,10,10);
            
            BattleEncounter battleEncounter = new BattleEncounter(new List<AbstractHero>(){shadowHunter},
                new List<AbstractVillain>(){satan});

            
            Assert.IsTrue(battleEncounter.RunEncounter());
        }
        
        [TestCase]
        public void Expected_battle_result_2()
        {
            Satan satan = new Satan(10,9000,0);
            ShadowHunter shadowHunter = new ShadowHunter(1,10,10);
            
            BattleEncounter encounter = new BattleEncounter(new List<AbstractHero>(){shadowHunter},
                new List<AbstractVillain>(){satan});

            
            Assert.IsFalse(encounter.RunEncounter());
        }  
        
        
        [TestCase]
        public void Only_one_character_alive_after_battle_encounter_1()
        {
            Satan satan = new Satan(10,9000,0);
            Dragon dragon = new Dragon(56,52,34);
            Orc orc = new Orc(23, 34, 4);

            ShadowHunter shadowHunter = new ShadowHunter(1,10,10);
            Angel angel = new Angel(231,223,343);
            Archer archer = new Archer(2323,323,32);
            Knight knight = new Knight(23,3334,132);
            
            BattleEncounter encounter = new BattleEncounter(new List<AbstractHero>()
                {
                    shadowHunter,
                    angel,
                    archer,
                    knight
                },
                new List<AbstractVillain>()
                {
                    satan,
                    dragon,
                    orc
                });
            
            encounter.RunEncounter();

            int heroesAlive = 0;
            int villainsAlive = 0;
            foreach (var hero in encounter.Heroes)
            {
                if (hero.IsAlive()) heroesAlive++;
            }
            foreach (var villain in encounter.Villains)
            {
                if (villain.IsAlive()) villainsAlive++;
            }

            
            Assert.IsTrue(heroesAlive == 0 || villainsAlive == 0);
        }     
        
        [TestCase]
        public void Only_one_character_alive_after_battle_encounter_2()
        {
            Satan satan = new Satan(10,9000,0);
            ShadowHunter shadowHunter = new ShadowHunter(1,10,10);
            
            BattleEncounter encounter = new BattleEncounter(shadowHunter,satan);
            
            encounter.RunEncounter();

            int heroesAlive = 0;
            int villainsAlive = 0;
            foreach (var hero in encounter.Heroes)
            {
                if (hero.IsAlive()) heroesAlive++;
            }
            foreach (var villain in encounter.Villains)
            {
                if (villain.IsAlive()) villainsAlive++;
            }

            
            Assert.IsTrue((heroesAlive == 0 && villainsAlive == 1)
                          || (villainsAlive == 0 && heroesAlive == 1));
        }

        [TestCase]
        public void Libro_de_la_sabiduria_works_correctly()
        {
            Elf elf = new Elf(10,20,30);
            Satan satan = new Satan(100,100,100);
            Wizard wizard = new Wizard(1,1,1);
            
            satan.Attack(elf);
            
            Assert.IsTrue(!elf.IsAlive()
                          && Wizard.LibroDeLaSabiduria[satan.ToString()+$"({satan.Id})"].Contains(elf.ToString()));
        }
    }
}