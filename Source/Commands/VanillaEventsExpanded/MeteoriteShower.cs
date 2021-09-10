using AdditionalCommands.Helpers;
using RimWorld;
using VEE;
using VEE.RegularEvents;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class MeteoriteShower : MiscEvents
    {
        public MeteoriteShower()
        {
            worker = new VEE.RegularEvents.MeteoriteShower();
            worker.def = IncidentDef.Named("VEE_MeteoriteShower");
        }
    }
}
