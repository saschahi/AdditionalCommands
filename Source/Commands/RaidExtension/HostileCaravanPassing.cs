using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.RaidExtension;

namespace AdditionalCommands.RaidExtension
{
    public class HostileCaravanPassing : HostileVisitor
    {
        public HostileCaravanPassing()
        {
            worker = new IncidentWorkerHositleTraderCaravanPassing();
            worker.def = IncidentDef.Named("SrHositleCaravanPassing");
            Category = IncidentCategoryDefOf.Misc;
        }
    }

}
