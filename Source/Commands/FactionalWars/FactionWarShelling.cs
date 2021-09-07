using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.FactionalWar;

namespace AdditionalCommands.FactionalWars
{
    public class FactionWarShelling : ModdedRaidWager
    {
        public FactionWarShelling()
        {
            worker = new IncidentWorkerFactionWarShellingSiteGenerate();
            worker.def = IncidentDef.Named("SrFactionWarShellingSiteGenerate");
        }
    }
}
