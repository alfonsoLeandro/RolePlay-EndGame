using System;
using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Characters.Villains;
using Library.Exceptions;
using Library.Items;

namespace Library.Characters.Heroes
{
    public abstract class AbstractHero : AbstractCharacter, IObserver
    {
        public int PiedraEterna { get; protected set; }
        
        public AbstractHero(int hp, int damage, int defense) : this(hp, damage, defense, new List<AbstractItem>())
        {
        }
        
          public AbstractHero(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
          {
              PiedraEterna = 0;
              TorreDeLosCaidos.Instance.Subscribe(this);
          }
        
        
        public void Attack(AbstractVillain villain)
        {
            if(!this.IsAlive() || !villain.IsAlive()) throw new CannotAttackDeadException("Uno de los dos caracteres que iba a ser atacado estaba muerto.");
            villain.Hp = Math.Max(0, villain.Hp - Math.Max(0, this.Damage - villain.Defense));
            
            if (!villain.IsAlive())
            {
                TorreDeLosCaidos.Instance.Notify(this, villain);
            }
        }

        public virtual void Update(AbstractCharacter killer, AbstractCharacter killed)
        {
            if (killer.Equals(this))
            {
                PiedraEterna += 1;
            }
        }
    }
}