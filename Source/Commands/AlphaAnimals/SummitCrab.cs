using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class SummitCrab : ModdedRaid
    {
        public SummitCrab()
        {
            worker = new IncidentWorker_SummitCrab();
            worker.def = IncidentDef.Named("AA_IncidentSummitCrab");
        }
    }
}
