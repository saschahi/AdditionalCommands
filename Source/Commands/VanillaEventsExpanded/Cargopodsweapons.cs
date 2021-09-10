using AdditionalCommands.Helpers;
using RimWorld;
using VEE.RegularEvents;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class Cargopodsweapons : MiscEvents
    {
        public Cargopodsweapons()
        {
            worker = new WeaponPod();
            worker.def = IncidentDef.Named("VEE_Cargopodsweapons");
        }
    }
}
