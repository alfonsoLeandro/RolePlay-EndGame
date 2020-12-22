using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Library.Encounters;

namespace Library.Scenarios
{
    /// <summary>
    /// Clase que representa varios encuentros de tipo batlla (<see cref="BattleEncounter"/>)
    /// ejecutados uno detrás del otro.
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// La lista de encuentros que se llevarán a cabo en este escenario.
        /// </summary>
        public List<BattleEncounter> Encounters { get; }

        
        /// <summary>
        /// Crea un nuevo escenario con una lista de encuentros de batalla dada.
        /// </summary>
        /// <param name="encounters">Los encuentros que se llevarán a cabo en este escenario.</param>
        public Scenario(List<BattleEncounter> encounters)
        {
            this.Encounters = encounters;
        }


        /// <summary>
        /// Inicia este escenario y ejecuta los encuentros de batalla de uno en uno de forma ordenada.
        /// </summary>
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


        /// <summary>
        /// Escribe una linea dada en el archivo de salida especificado en <see cref="RpCore"/>.
        /// </summary>
        /// <param name="line">La línea a escribir en el archivo.</param>
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