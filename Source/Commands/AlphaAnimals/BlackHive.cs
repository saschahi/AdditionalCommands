using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class BlackHive : ModdedRaidWager
    {
        
        public BlackHive()
        {
            worker = new IncidentWorker_BlackHive();
            worker.def = IncidentDef.Named("AA_Incident_BlackHive");
            //Log.Warning("INFO FOR BLACKHIVE RAID: If you're confused looking for a reason why a blackhive raid didn't appear, that's because Alpha Animals is coded dumb and always tells me that it executed correctly even if the hardcoded 15 days grace period isn't over yet");
        }
    }
}
