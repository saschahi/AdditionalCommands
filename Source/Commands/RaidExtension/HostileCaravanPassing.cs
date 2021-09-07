using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.RaidExtension;
using Verse;

namespace AdditionalCommands.RaidExtension
{
    public class HostileCaravanPassing : HostileVisitor
    {
        public HostileCaravanPassing()
        {
            worker = new IncidentWorkerHostileTraderCaravanPassing();
            worker.def = IncidentDef.Named("SrHositleCaravanPassing");
            Category = IncidentCategoryDefOf.Misc;
        }
    }

}
