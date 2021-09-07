using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class DunealiskClutchMother : ModdedRaid
    {
        public DunealiskClutchMother()
        {
            worker = new IncidentWorker_DunealiskClutchMother();
            worker.def = IncidentDef.Named("AA_IncidentDunealiskClutchMother");
        }

    }
}
