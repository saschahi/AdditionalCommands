using AdditionalCommands.Helpers;
using RimWorld;
using VEE.RegularEvents;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class CropSprout : MiscEvents
    {
        public CropSprout()
        {
            worker = new VEE.RegularEvents.Cropsprout();
            worker.def = IncidentDef.Named("VEE_CropSprout");
        }
    }
}
