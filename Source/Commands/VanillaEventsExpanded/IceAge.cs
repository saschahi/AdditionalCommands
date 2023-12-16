using AdditionalCommands.Helpers;
using RimWorld;
using VEE;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class IceAge : MiscEvents
    {
        public IceAge()
        {
            worker = new VEE.IncidentWorker_MakeGameConditionPurple();
            worker.def = IncidentDef.Named("VEE_IceAge");
        }
    }
}
