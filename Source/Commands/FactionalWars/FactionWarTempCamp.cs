﻿using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.FactionalWar;

namespace AdditionalCommands.Commands.FactionalWars
{
    public class FactionWarTempCamp : ModdedRaidWager
    {
        public FactionWarTempCamp()
        {
            worker = new IncidentWorkerFactionWarTempCampSiteGenerate();
            worker.def = IncidentDef.Named("SrFactionWarTempCampSiteGenerate");
        }
    }
}
