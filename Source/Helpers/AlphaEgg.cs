using SirRandoo.ToolkitUtils.Utils;
using TwitchToolkit;
using TwitchToolkit.Incidents;
using Verse;

namespace AdditionalCommands
{
    public class AlphaEgg : EasterEgg
    {
        public override float Chance => 0.06f;
        public override bool IsPossible(StoreIncident incident, Viewer viewer)
        {
            if(incident == SirRandoo.ToolkitUtils.IncidentDefOf.BuyPawn)
            {
                if(InternalPatcher.CurrentPatchedMods.Contains("sarg.alphaanimals"))
                {
                    return true;
                }
                // Is there an easy way to check here if another race has been chosen already?
            }
            return false;
        }

        public override void Execute(Viewer viewer, Pawn pawn)
        {
            if (pawn.kindDef == RimWorld.PawnKindDefOf.Colonist)
            {
                pawn.health.AddHediff(HediffDef.Named("AA_MimeHediff"), null, null, null);
            }
        }
    }



}
