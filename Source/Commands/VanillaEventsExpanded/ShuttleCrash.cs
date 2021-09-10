using AdditionalCommands.Helpers;
using RimWorld;
using VEE.RegularEvents;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class ShuttleCrash : MiscEvents
    {
        public ShuttleCrash()
        {
            worker = new VEE.RegularEvents.ShuttleCrash();
            worker.def = IncidentDef.Named("VEE_ShuttleCrash");
        }
    }
}
