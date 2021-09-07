using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.FactionalWar;

namespace AdditionalCommands.Commands.FactionalWars
{
    public class FactionWarContention : ModdedRaidWager
    {
        public FactionWarContention()
        {
            worker = new IncidentWorkerFactionWarContentionSiteGenerate();
            worker.def = IncidentDef.Named("SrFactionWarContentionSiteGenerate");
        }
    }
}
