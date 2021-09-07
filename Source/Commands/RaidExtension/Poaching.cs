using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.RaidExtension;

namespace AdditionalCommands.RaidExtension
{
    public class Poaching : ModdedRaid
    {
        public Poaching()
        {
            worker = new IncidentWorkerPoaching();
            worker.def = IncidentDef.Named("SrPoaching");
            Category = IncidentCategoryDefOf.ThreatSmall;
        }
    }

}
