using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Library.Encounters;

namespace Library.Scenarios
{
    /// <summary>
    /// Implementación de <see cref="IProcessScenarios"/> utilizando un archivo como fuente
    /// de la información.
    /// </summary>
    public class ProcessScenariosFile : IProcessScenarios
    {
        public List<BattleEncounter> Process()
        {
            List<BattleEncounter> encounters = new List<BattleEncounter>();
            string fileName = Path.Combine("..", "..", "..", "scenarios.csv");
            StreamReader streamReader = null;
            

            //TODO: terminar
            
            try
            {
                streamReader = new StreamReader(fileName);
            }
            catch (Exception ignored)
            {
                RpCore.Instance.Logger.Log("Ha ocurrido un error al intentar procesar el archivo.");
                return new List<BattleEncounter>();
            }

            while (!streamReader.EndOfStream)
            {
                // Leer datos del archivo
                var line = streamReader.ReadLine();
                var values = line.Split(',');
                // List<string> aux = new List<string>();
                // foreach (var value in values)
                // {
                //     string s = value.Replace("\"", "");
                //     aux.Add(s);
                // }
                Console.WriteLine(line);
            }

            streamReader.Close();
                

            return encounters;
            
        }
    }
}