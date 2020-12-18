using System;
using System.Collections.Generic;
using Library.Characters.Villains;
using Library.Exceptions;
using Library.Items;

namespace Library.Characters.Heroes
{
    public abstract class AbstractHero : AbstractCharacter
    {
        public AbstractHero(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
        }
        
        
        public void Attack(AbstractVillain villain)
        {
            if(!this.IsAlive() || !villain.IsAlive()) throw new CannotAttackDeadException("Uno de los dos caracteres que iba a ser atacado estaba muerto.");
            villain.Hp = Math.Max(0, villain.Hp - Math.Max(0, this.Damage - villain.Defense));
            
            if (!villain.IsAlive())
            {
                HonorAndGlory.GetInstance().HeroKilledVillain(this, villain);
            }
        }

    }
}