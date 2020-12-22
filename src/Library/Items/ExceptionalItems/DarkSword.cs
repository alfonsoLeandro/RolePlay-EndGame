using System.Collections.Generic;

namespace Library.Items.ExceptionalItems
{
    /// <summary>
    /// Clase que representa un tipo de item excepcional llamado DarkSword.
    /// La habilidad de este item es ser combinado con items de tipo <see cref="ElementalGem"/>
    /// para resultar en otro DarkSword con estadísticas más poderosas.
    /// Cabe aclarar, un DarkSword sin gemas elementales no posee ninguna estadística.
    /// </summary>
    public class DarkSword : AbstractItem
    {
        /// <summary>
        /// La lista de gemas elementales de este DarkSword.
        /// </summary>
        private List<ElementalGem> Gems { get; } = new List<ElementalGem>();

        /// <summary>
        /// Crea un nuevo DarkSword sin gemas elementales añadidas.
        /// En este constructor se aplica el patrón creator ya que se llama al segundo constructor
        /// con una nueva lista de gemas (vacía).
        /// </summary>
        public DarkSword() : this(new List<ElementalGem>())
        {
        }
        
        /// <summary>
        /// Crea una nueva DarkSword con una lista de <see cref="ElementalGem"/> dada.
        /// </summary>
        /// <param name="gems">La lista de gemas a agregar a esta DarkSword.</param>
        public DarkSword(List<ElementalGem> gems) : base(0, 0, 0)
        {
            foreach (var gem in gems)
            {
                this.DamageValue += gem.DamageValue;
                this.DefenseValue += gem.DefenseValue;
                this.HealthValue += gem.HealthValue;
                Gems.Add(gem);
            }
        }

        public override string ToString()
        {
            return "Dark sword";
        }

        /// <summary>
        /// Combina esta DarkSword con una gema.
        /// </summary>
        /// <param name="gem">La gema a agregar a esta DarkSword.</param>
        /// <returns>Una nueva DarkSword que contiene la nueva gema además de las gemas que ya contenía, si contenía alguna.</returns>
        public DarkSword Combine(ElementalGem gem)
        {
            var gems = this.Gems;
            gems.Add(gem);
            return new DarkSword(gems);
        }
        
    }
}