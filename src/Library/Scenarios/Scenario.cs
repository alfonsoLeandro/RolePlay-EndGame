using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Library.Encounters;

namespace Library.Scenarios
{
    public class Scenario
    {
        public List<BattleEncounter> Encounters { get; }

        public Scenario(List<BattleEncounter> encounters)
        {
            this.Encounters = encounters;
        }


        public void StartScenario()
        {
            WriteToFile("Escenario:");
            foreach (var encounter in Encounters)
            {
                try
                {
                    if (encounter.RunEncounter())
                    {
                        WriteToFile("Heroes won!");
                    }
                    else
                    {
                        WriteToFile("Villains won!");
                    }
                }
                catch (Exception ignored)
                {
                    WriteToFile("Encounter failed");
                }
                
                Thread.Sleep(500);
            }
        }


        private void WriteToFile(string line)
        {
            if (!File.Exists(RpCore.Instance.ResultsFile))
            {
                using (StreamWriter sw = File.CreateText(RpCore.Instance.ResultsFile))
                {
                    sw.WriteLine(line);
                }
            }
        }
        
    }
}