using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class CactipineDropPod : ModdedRaid
    {
        public CactipineDropPod()
        {
            worker = new IncidentWorker_CactipineDropPod();
            worker.def = IncidentDef.Named("AA_CactipineDropPod");
        }
    }
}
