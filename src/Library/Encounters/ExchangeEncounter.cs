using System;
using System.Collections.Generic;
using Library.Characters;
using Library.EventLogger;
using Library.Exceptions;
using Library.Items;

namespace Library.Encounters
{
    /// <summary>
    /// Encuentro de tipo intercambio entre dos personajes de cualquier tipo.
    /// En este encuentro, el primer personaje cede al menos un item dado a el segundo personaje.
    /// </summary>
    public class ExchangeEncounter : IEncounter
    {
        /// <summary>
        /// El personaje a ceder item/s.
        /// </summary>
        private AbstractCharacter Sharer { get; }
        /// <summary>
        /// El personaje que recibirá el/los items.
        /// </summary>
        private AbstractCharacter Receiver { get; }
        /// <summary>
        /// La lista de items a ceder.
        /// </summary>
        private List<AbstractItem> Items { get; }
        /// <summary>
        /// El <see cref="ILogger"/> obtenido desde <see cref="RpCore"/>.
        /// </summary>
        private ILogger Logger { get; }
        
        /// <summary>
        /// Constructor utilizado para intercambiar un único item.
        /// Se aplica el patrón creator ya que en este constructor se crea una nueva lista que contiene el único item.
        /// </summary>
        /// <param name="sharer">El personaje a ceder el item.</param>
        /// <param name="receiver">El personaje a recibir el item.</param>
        /// <param name="item">El item a intercambiar.</param>
        public ExchangeEncounter(AbstractCharacter sharer, AbstractCharacter receiver, AbstractItem item)
            : this(sharer, receiver, new List<AbstractItem>(){item})
        {
        }
        
        /// <summary>
        /// Crea un nuevo encuentro de intercambio entre dos personajes y una lista de items.
        /// </summary>
        /// <param name="sharer">El personaje a ceder los items.</param>
        /// <param name="receiver">El personaje a recibir los items.</param>
        /// <param name="items">Los items a intercambiar.</param>
        public ExchangeEncounter(AbstractCharacter sharer, AbstractCharacter receiver, List<AbstractItem> items)
        {
            Sharer = sharer;
            Receiver = receiver;
            Items = items;
            Logger = RpCore.Instance.Logger;
        }
        
        /// <summary>
        /// Ejecuta el intercambio entre ambos personajes.
        /// </summary>
        /// <returns>True si el intercambio culminó con éxito.</returns>
        /// <exception cref="DeadCharactersCannotTradeException">Arrojado cuando al menos uno de los dos personajes se encuentra sin vida.</exception>
        /// <exception cref="NoItemsToShareException">Arrojado cuando la lista de items del personaje a ceder el/los items se encuentra vacía.</exception>
        /// <exception cref="DoesNotContainItemException">Arrojado cuando el personaje a ceder el/los items no contiene al menos uno de los items.</exception>
        public bool RunEncounter()
        {
            Logger.Log($"Un encuentro de intercambio a comenzado.");
            if (!Sharer.IsAlive() || !Receiver.IsAlive())
                throw new DeadCharactersCannotTradeException(
                    "Uno de los dos personajes que iba a participar en el encuentro de intercambio no se encuentra con vida.");
            if (Sharer.Items.Count == 0)
                throw new NoItemsToShareException(
                    "El personaje que iba a ceder un item no contiene ningún item.");
                    
            
            foreach (var item in Items)
            {
                if (!Sharer.Items.Contains(item))
                    throw new DoesNotContainItemException(
                        "El personaje que iba a compartir items no contiene al menos uno de los items que iba a ceder.");
            } 
            
            foreach (var item in Items)
            {
                Sharer.GiveItem(Receiver, item);
                Logger.Log($"{Receiver.ToString()} ha cedido un {item.ToString()} a {Sharer.ToString()}");
            }

            Logger.Log("El intercambio ha terminado con éxito.");
            return true;
        }
    }
}