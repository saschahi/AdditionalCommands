using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.RaidExtension;

namespace AdditionalCommands.RaidExtension
{
    public class SRLogging : ModdedRaid
    {
        public SRLogging()
        {
            worker = new IncidentWorkerLogging();
            worker.def = IncidentDef.Named("SrLogging");
            Category = IncidentCategoryDefOf.ThreatSmall;
        }
    }

}
