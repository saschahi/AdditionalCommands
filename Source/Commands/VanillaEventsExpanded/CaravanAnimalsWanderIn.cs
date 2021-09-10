using AdditionalCommands.Helpers;
using RimWorld;
using VEE.RegularEvents;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class CaravanAnimalsWanderIn : MiscEvents
    {
        public CaravanAnimalsWanderIn()
        {
            worker = new CaravanAnimalWI();
            worker.def = IncidentDef.Named("VEE_CaravanAnimalsWanderIn");
        }
    }
}
