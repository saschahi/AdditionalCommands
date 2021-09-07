using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class FungalHusk : ModdedRaid
    {
        public FungalHusk()
        {
            worker = new IncidentWorker_FungalHusk();
            worker.def = IncidentDef.Named("AA_IncidentFungalHusk");
        }
    }
}
