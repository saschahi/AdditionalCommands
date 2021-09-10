using AdditionalCommands.Helpers;
using RimWorld;
using VEE;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class PsychicRain : MiscEvents
    {
        public PsychicRain()
        {
            worker = new IncidentWorker_MakeGameConditionVEE();
            worker.def = IncidentDef.Named("VEE_PsychicRain");
        }
    }
}
