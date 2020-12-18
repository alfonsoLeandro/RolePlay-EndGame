using System.Collections.Generic;
using Library.Characters.Heroes;
using Library.Characters.Villains;
using Library.EventLogger;
using Library.Exceptions;

namespace Library.Encounters
{
    public class BattleEncounter : IEncounter
    {
        public List<AbstractHero> Heroes { get; }
        public List<AbstractVillain> Villains { get; }
        private ILogger Logger { get; }
        

        public BattleEncounter(AbstractHero hero, AbstractVillain villain)
        : this(new List<AbstractHero>(){hero}, new List<AbstractVillain>(){villain})
        {
        }
        
        public BattleEncounter(List<AbstractHero> heroes, List<AbstractVillain> villains)
        {
            Heroes = heroes;
            Villains = villains;
            Logger = RpCore.Instance.Logger;
        }



        public bool RunEncounter()
        {
            Logger.Log($"Un encuentro de combate ha comenzado. {Heroes.Count} heroes y {Villains.Count} villanos");

            if (Villains.Count == 0)
            {
                throw new NotEnoughParticipantsInBattleException("El encuentro ha terminado abruptamente ya que no hay suficientes villanos");
            }
            if (Heroes.Count == 0)
            {
                throw new NotEnoughParticipantsInBattleException("El encuentro ha terminado abruptamente ya que no hay suficientes heroes");
            }
            

            while (!AllHeroesDead() && !AllVillainsDead())
            {
                //Los enemigos atacan primero. Cada enemigo ataca únicamente a un héroe. Si hay un sólo héroe,
                //todos los enemigos atacan al mismo. Si hay más de un enemigo y más de un héroe, el primer enemigo
                //ataca al primer héroe, el segundo enemigo ataca al segundo héroe, y así sucesivamente. Si hay menos
                //héroes (N) que enemigos (M), el siguiente enemigo (N+1) ataca al primero héroe, el
                //siguiente enemigo (N+2) ataca al segundo héroe, y así sucesivamente.

                //Atacan los villanos:
                int j;
                for (int i = 0; i < Villains.Count; i++)
                {
                    if (AllHeroesDead()) break;
                    
                    var villain = Villains[i];
                    
                    if (!villain.IsAlive()) continue;
                    
                    j = i;
                    while (j >= Heroes.Count || !Heroes[j].IsAlive())
                    {
                        if (j == 0) j = Heroes.Count;
                        j--;
                    }

                    var hero = Heroes[j];
                    
                    villain.Attack(hero);
                    Logger.Log($"{villain.ToString()} ataca a {hero.ToString()}");
                    
                    if(!hero.IsAlive()) Logger.Log($"{hero.ToString()} ha muerto en manos de {villain.ToString()}");
                }
            
                //Luego, los héroes sobrevivientes atacan a los enemigos. Todos los héroes atacan
                //a cada uno de los enemigos 1 vez.
            
                //Atacan los heroes:
                foreach (var hero in Heroes)
                {
                    if (AllVillainsDead() || AllHeroesDead()) break;

                    if (!hero.IsAlive()) continue;
                    
                    
                    foreach (var villain in Villains)
                    {
                        if (!villain.IsAlive()) continue;
                        
                        hero.Attack(villain);
                        
                        Logger.Log($"{hero.ToString()} ataca a {villain.ToString()}");
                                
                        if (!villain.IsAlive())
                        {
                            Logger.Log($"{villain.ToString()} ha muerto en manos de {hero.ToString()}");
                            hero.Vp += villain.Vp + 2;
                            if (hero.Vp >= 5)
                            {
                                Logger.Log($"{hero.ToString()} se ha curado por tener {hero.Vp} VP");
                                hero.Vp = 0;
                                hero.Cure();
                            }
                        }
                                
                        
                    }
                    
                }
            }
            
            Logger.Log("El encuentro de combate ha terminado.");

            Logger.Log(AllVillainsDead() ? "Los heroes han ganado." : "Los villanos han ganado.");

            return AllVillainsDead();
            
        }
        
        
        

        private bool AllHeroesDead()
        {
            foreach (var hero in Heroes)
            {
                if (hero.IsAlive()) return false;
            }

            return true;
        } 
        
        private bool AllVillainsDead()
        {
            foreach (var villain in Villains)
            {
                if (villain.IsAlive()) return false;
            }

            return true;
        }


    }
}