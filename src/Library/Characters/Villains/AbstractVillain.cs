using System;
using System.Collections.Generic;
using Library.CampoDeLosCaidos;
using Library.Characters.Heroes;
using Library.Exceptions;
using Library.Items;

namespace Library.Characters.Villains
{
    public abstract class AbstractVillain : AbstractCharacter, IObserver
    {
        public List<string> ArbolDeLosMilDias { get; }
        
        public AbstractVillain(int hp, int damage, int defense) : this(hp, damage, defense, new List<AbstractItem>())
        {
        }
        
        public AbstractVillain(int hp, int damage, int defense, List<AbstractItem> items) : base(hp, damage, defense, items)
        {
            ArbolDeLosMilDias = new List<string>();
            TorreDeLosCaidos.Instance.Subscribe(this);
        }

        public void Attack(AbstractHero hero)
        {
            if (!this.IsAlive() || !hero.IsAlive())
                throw new CannotAttackDeadException("Uno de los dos caracteres que iba a ser atacado estaba muerto.");
            hero.Hp = Math.Max(0, hero.Hp - Math.Max(0, this.Damage - new Random().Next(hero.Defense)));

            if (!hero.IsAlive())
            {
                TorreDeLosCaidos.Instance.Notify(this, hero);
            }
        }

        public virtual void Update(AbstractCharacter killer, AbstractCharacter killed)
        {
            if (killer.Equals(this))
            {
                ArbolDeLosMilDias.Add(killed.ToString());
            }
        }
    }
}