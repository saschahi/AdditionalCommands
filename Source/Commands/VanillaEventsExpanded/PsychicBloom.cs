using AdditionalCommands.Helpers;
using RimWorld;
using VEE;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class PsychicBloom : MiscEvents
    {
        public PsychicBloom()
        {
            worker = new IncidentWorker_MakeGameConditionPurple();
            worker.def = IncidentDef.Named("VEE_PsychicBloom");
        }
    }
}
