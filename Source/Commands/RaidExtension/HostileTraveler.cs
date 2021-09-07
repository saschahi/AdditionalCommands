using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.RaidExtension;

namespace AdditionalCommands.Commands.RaidExtension
{
    class HostileTraveler : MiscEvents
    {
        public HostileTraveler()
        {
            worker = new IncidentWorkerHostileTraveler();
            worker.def = IncidentDef.Named("SrHositleTraveler");
        }
    }

}
