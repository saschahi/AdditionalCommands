using AdditionalCommands.Helpers;
using RimWorld;
using VEE;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class SpaceBattle : MiscEvents
    {
        public SpaceBattle()
        {
            worker = new IncidentWorker_MakeGameConditionNoLetter();
            worker.def = IncidentDef.Named("VEE_SpaceBattle");
        }
    }
}
