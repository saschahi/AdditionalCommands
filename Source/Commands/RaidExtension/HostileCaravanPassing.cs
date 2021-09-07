using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.RaidExtension;
using Verse;

namespace AdditionalCommands.Commands.RaidExtension
{
    class HostileCaravanPassing : MiscEvents
    {
        public HostileCaravanPassing()
        {
            worker = new IncidentWorkerHostileTraderCaravanPassing();
            worker.def = IncidentDef.Named("SrHositleCaravanPassing");
        }
    }

}
