using System.Collections.Generic;
using Library.Characters.Heroes;
using Library.Characters.Villains;

namespace Library.CampoDeLosCaidos
{
    public class TorreDeLosCaidos
    {
        private static TorreDeLosCaidos instance;
        public List<string> ArbolDeLosMilDias { get; }
        public int PiedraEterna { get; set; }
        public Dictionary<string,string> LibroDeLaSabiduria { get; set; }

        private TorreDeLosCaidos()
        {
            ArbolDeLosMilDias = new List<string>();
            PiedraEterna = 0;
            LibroDeLaSabiduria = new Dictionary<string, string>();
        }

        public static TorreDeLosCaidos GetInstance()
        {
            if (instance == null)
            {
                instance = new TorreDeLosCaidos();
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