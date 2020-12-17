using System;

namespace Library.Items.ExceptionalItems
{
    public class SpellBook : AbstractItem
    {
        /// <summary>
        /// Genera un nuevo spell book, el mismo puede contener
        /// </summary>
        public SpellBook() : base(false, true, RandomStat(), RandomStat(), RandomStat())
        {
        }

        /// <summary>
        /// Genera una valor random entre -5 y 20 para utilizar en cada una de las estadísticas del spell book.
        /// </summary>
        /// <returns>Un valor entre -5 y 20</returns>
        private static int RandomStat()
        {
            return new Random().Next(20 + 6) - 5;
        }

        public override string ToString()
        {
            return "Spell book";
        }
    }
}