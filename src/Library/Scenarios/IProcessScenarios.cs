using System.Collections.Generic;
using Library.Encounters;

namespace Library.Scenarios
{
    public interface IProcessScenarios
    {
        List<BattleEncounter> Process();
    }
}