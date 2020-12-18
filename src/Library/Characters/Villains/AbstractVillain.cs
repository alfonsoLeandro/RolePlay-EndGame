using System;
using System.Collections.Generic;
using Library.Characters.Heroes;
using Library.Exceptions;
using Library.Items;

namespace Library.Characters.Villains
{
    public abstract class AbstractVillain : AbstractCharacter
    {
        public AbstractVillain(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }

        public void Attack(AbstractHero hero)
        {
            if (!this.IsAlive() || !hero.IsAlive())
                throw new CannotAttackDeadException("Uno de los dos caracteres que iba a ser atacado estaba muerto.");
            hero.Hp = Math.Max(0, hero.Hp - Math.Max(0, this.Damage - new Random().Next(hero.Defense)));

            if (!hero.IsAlive())
            {
                HonorAndGlory.GetInstance().VillainKilledHero(this, hero);
            }
        }
        
    }
}