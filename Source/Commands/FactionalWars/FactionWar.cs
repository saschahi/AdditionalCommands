﻿using AdditionalCommands.Helpers;
using RimWorld;
using SR.ModRimWorld.FactionalWar;

namespace AdditionalCommands.Commands.FactionalWars
{
    public class FactionWar : ModdedRaidWager
    {
        public FactionWar()
        {
            worker = new IncidentWorkerFactionWar();
            worker.def = IncidentDef.Named("SrFactionWar");
        }
    }
}
