using AdditionalCommands.Helpers;
using RimWorld;
using VEE.RegularEvents;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class AnimalPodCrash : MiscEvents
    {
        public AnimalPodCrash()
        {
            worker = new AnimalTransportPodCrash();
            worker.def = IncidentDef.Named("VEE_AnimalPodCrash");
        }
    }
}
