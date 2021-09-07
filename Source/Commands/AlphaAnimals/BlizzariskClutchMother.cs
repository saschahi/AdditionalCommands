using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class BlizzariskClutchMother : ModdedRaid
    { 
        public BlizzariskClutchMother()
        {
            worker = new IncidentWorker_BlizzariskClutchMother();
            worker.def = IncidentDef.Named("AA_IncidentBlizzariskClutchMother");
        }
    }
}
