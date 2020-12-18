using System;
using System.Collections.Generic;
using Library.Characters.Heroes;
using Library.Characters.Villains;

namespace Library
{
    public class HonorAndGlory
    {
        private static HonorAndGlory instance;
        public List<string> ArbolDeLosMilDias { get; }
        public int PiedraEterna { get; set; }
        public Dictionary<string,string> LibroDeLaSabiduria { get; set; }

        private HonorAndGlory()
        {
            ArbolDeLosMilDias = new List<string>();
            PiedraEterna = 0;
            LibroDeLaSabiduria = new Dictionary<string, string>();
        }

        public static HonorAndGlory GetInstance()
        {
            if (instance == null)
            {
                instance = new HonorAndGlory();
            }

            return instance;
        }

        public void VillainKilledHero(AbstractVillain villain, AbstractHero hero)
        {
            //TODO
        }
        
        public void HeroKilledVillain(AbstractHero hero, AbstractVillain villain)
        {
            //TODO
        }
        
        
    }
}