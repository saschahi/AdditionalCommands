using AdditionalCommands.Helpers;
using RimWorld;
using VEE;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class IceAge : MiscEvents
    {
        public IceAge()
        {
            worker = new IncidentWorker_MakeGameConditionVEE();
            worker.def = IncidentDef.Named("VEE_IceAge");
        }
    }
}
