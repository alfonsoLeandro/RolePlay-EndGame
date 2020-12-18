using System;
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
        private ILogger Logger { get; }
        
        
        public ExchangeEncounter(AbstractCharacter sharer, AbstractCharacter toShare)
        {
            Sharer = sharer;
            ToShare = toShare;
            Logger = RpCore.GetInstance().Logger;
        }

        
        public bool RunEncounter()
        {
            Logger.Log($"Un encuentro de intercambio a comenzado.");
            try
            {
                if(Sharer.Items.Count == 0) throw new NoItemsToShareException("El personaje que iba a compartir items no tiene ningun item en su posesión.");
                AbstractItem item = Sharer.Items[new Random().Next(Sharer.Items.Count)];
                Sharer.GiveItem(ToShare, item);
                Logger.Log($"{ToShare.ToString()} ha cedido un {item.ToString()} a {Sharer.ToString()}");
                return true;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
            Logger.Log("El intercambio ha fallado.");
            return false;

        }
    }
}