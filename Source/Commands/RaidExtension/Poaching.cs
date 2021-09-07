using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.RaidExtension;

namespace AdditionalCommands.Commands.RaidExtension
{
    public class Poaching : ModdedRaidWager
    {
        public Poaching()
        {
            worker = new IncidentWorkerPoaching();
            worker.def = IncidentDef.Named("SrPoaching");
        }
    }

}
