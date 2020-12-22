using System;
using System.Collections.Generic;

namespace Library.Items.ExceptionalItems
{
    /// <summary>
    /// Clase que representa un tipo de item excepcional mágico llamado SpellBook.
    /// La habilidad de este item es ser combinado con items de tipo <see cref="Spell"/>
    /// para resultar en otro SpellBook con estadísticas más poderosas.
    /// Cabe aclarar, un SpellBook sin spells no posee ninguna estadística.
    /// </summary>
    public class SpellBook : MagicItem
    {
        /// <summary>
        /// La lista de Spells de este SpellBook.
        /// </summary>
        private List<Spell> Spells { get; } = new List<Spell>();

        /// <summary>
        /// Crea un nuevo SpellBook sin Spells añadidos.
        /// En este constructor se aplica el patrón creator ya que se llama al segundo constructor
        /// con una nueva lista de Spells (vacía).
        /// </summary>
        public SpellBook() : this(new List<Spell>())
        {
        }
        
        /// <summary>
        /// Crea un nuevo SpellsBook con una lista de <see cref="Spells"/> dada.
        /// </summary>
        /// <param name="spells">La lista de Spells a agregar a esta SpellsBook.</param>
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
 
        /// <summary>
        /// Combina este SpellBook con un Spell.
        /// </summary>
        /// <param name="spell">El Spell a agregar a este SpellBook.</param>
        /// <returns>Una nueva SpellBook que contiene el nuevo Spell además de los Spells que ya contenía, si contenía alguno.</returns>
        public SpellBook Combine(Spell spell)
        {
            var spells = this.Spells;
            spells.Add(spell);
            return new SpellBook(spells);
        }
    }
}