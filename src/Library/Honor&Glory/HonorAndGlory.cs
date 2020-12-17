using System;
using System.Collections.Generic;

namespace Library
{
    public class HonorAndGlory
    {
        private HonorAndGlory instance;
        public List<string> HeroesDefeated { get; }

        private HonorAndGlory()
        {
            HeroesDefeated = new List<string>();
        }

        public HonorAndGlory GetInstance()
        {
            if (instance == null)
            {
                instance = new HonorAndGlory();
            }

            return instance;
        }
    }
}