using AdditionalCommands.Helpers;
using RimWorld;
using VEE;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class GlobalWarming : MiscEvents
    {
        public GlobalWarming()
        {
            worker = new IncidentWorker_MakeGameConditionVEE();
            worker.def = IncidentDef.Named("VEE_GlobalWarming");
        }
    }
}
