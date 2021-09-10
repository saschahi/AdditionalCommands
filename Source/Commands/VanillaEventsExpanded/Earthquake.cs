using AdditionalCommands.Helpers;
using RimWorld;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class Earthquake : MiscEvents
    {
        public Earthquake()
        {
            worker = new VEE.RegularEvents.EarthQuake();
            worker.def = IncidentDef.Named("VEE_Earthquake");
        }
    }
}
