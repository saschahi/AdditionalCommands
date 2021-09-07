using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class FeraliskClutchMother : ModdedRaid
    {
        public FeraliskClutchMother()
        {
            worker = new IncidentWorker_FeraliskClutchMother();
            worker.def = IncidentDef.Named("AA_IncidentFeraliskClutchMother");
        }
    }
}
