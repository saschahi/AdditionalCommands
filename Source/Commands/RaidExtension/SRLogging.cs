using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.RaidExtension;

namespace AdditionalCommands.Commands.RaidExtension
{
    public class SRLogging : ModdedRaidWager
    {
        public SRLogging()
        {
            worker = new IncidentWorkerLogging();
            worker.def = IncidentDef.Named("SrLogging");
        }
    }

}
