using System;
using System.Collections.Generic;

namespace Library.Items.ExceptionalItems
{
    public class SpellBook : MagicItem
    {
        private List<Spell> Spells { get; } = new List<Spell>();

        public SpellBook() : this(new List<Spell>())
        {
        }
        
        public SpellBook(List<Spell> spells) : base(0, 0, 0)
        {
            foreach (var spell in spells)
            {
                this.DamageValue += spell.DamageValue;
                this.DefenseValue += spell.DefenseValue;
                this.HealthValue += spell.HealthValue;
                Spells.Add(spell);
            }
        }

        public override string ToString()
        {
            return "Spell book";
        }
 
        public SpellBook Combine(Spell spell)
        {
            var spells = this.Spells;
            spells.Add(spell);
            return new SpellBook(spells);
        }
    }
}