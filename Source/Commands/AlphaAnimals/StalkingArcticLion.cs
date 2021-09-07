using RimWorld;
using AlphaBehavioursAndEvents;
using AdditionalCommands.Helpers;
using Verse;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class StalkingArcticLion : ModdedRaid
    {
        public StalkingArcticLion()
        {
            worker = new IncidentWorker_StalkingArcticLion();
            worker.def = IncidentDef.Named("AA_IncidentStalkingArcticLion");
        }
    }
}
