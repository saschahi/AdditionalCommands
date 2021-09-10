using AdditionalCommands.Helpers;
using RimWorld;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class BattleAnimalsWanderIn : MiscEvents
    {
        public BattleAnimalsWanderIn()
        {
            worker = new VEE.RegularEvents.battleAnimal();
            worker.def = IncidentDef.Named("VEE_BattleAnimalsWanderIn");
        }
    }
}
