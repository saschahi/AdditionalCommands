using AdditionalCommands.Helpers;
using RimWorld;
using VEE.RegularEvents;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class Cargopodsapparel : MiscEvents
    {
        public Cargopodsapparel()
        {
            worker = new ApparelPod();
            worker.def = IncidentDef.Named("VEE_Cargopodsapparel");
        }
    }
}
