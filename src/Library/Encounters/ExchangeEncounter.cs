using System;
using System.Collections.Generic;
using Library.Characters;
using Library.EventLogger;
using Library.Exceptions;
using Library.Items;

namespace Library.Encounters
{
    public class ExchangeEncounter : IEncounter
    {
        private AbstractCharacter Sharer { get; }
        private AbstractCharacter ToShare { get; }
        private List<AbstractItem> Items { get; }
        private ILogger Logger { get; }
        
        
        public ExchangeEncounter(AbstractCharacter sharer, AbstractCharacter toShare, AbstractItem item)
            : this(sharer, toShare, new List<AbstractItem>(){item})
        {
        }    
        public ExchangeEncounter(AbstractCharacter sharer, AbstractCharacter toShare, List<AbstractItem> items)
        {
            Sharer = sharer;
            ToShare = toShare;
            Items = items;
            Logger = RpCore.Instance.Logger;
        }

        //Implementación previa.
        // public bool RunEncounter()
        // {
        //     Logger.Log($"Un encuentro de intercambio a comenzado.");
        //     try
        //     {
        //         if(!Sharer.IsAlive() || !ToShare.IsAlive()) throw new DeadCharactersCannotTradeException("Uno de los dos personajes que iba a participar en el encuentro de intercambio no se encuentra con vida.");
        //         if(Sharer.Items.Count == 0) throw new NoItemsToShareException("El personaje que iba a compartir items no tiene ningún item en su posesión.");
        //         AbstractItem item = Sharer.Items[new Random().Next(Sharer.Items.Count)];
        //         Sharer.GiveItem(ToShare, item);
        //         Logger.Log($"{ToShare.ToString()} ha cedido un {item.ToString()} a {Sharer.ToString()}");
        //         return true;
        //     }
        //     catch (Exception e)
        //     {
        //         Logger.Log(e.Message);
        //     }
        //     Logger.Log("El intercambio ha fallado.");
        //     return false;
        //
        // }    
        
        public bool RunEncounter()
        {
            Logger.Log($"Un encuentro de intercambio a comenzado.");
            if (!Sharer.IsAlive() || !ToShare.IsAlive())
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
                Sharer.GiveItem(ToShare, item);
                Logger.Log($"{ToShare.ToString()} ha cedido un {item.ToString()} a {Sharer.ToString()}");
            }

            Logger.Log("El intercambio ha terminado con éxito.");
            return true;
        }
    }
}