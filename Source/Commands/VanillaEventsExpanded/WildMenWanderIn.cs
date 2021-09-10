using AdditionalCommands.Helpers;
using RimWorld;
using VEE.RegularEvents;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class WildMenWanderIn : MiscEvents
    {
        public WildMenWanderIn()
        {
            worker = new VEE.RegularEvents.WildMenWanderIn();
            worker.def = IncidentDef.Named("VEE_WildMenWanderIn");
        }
    }
}
