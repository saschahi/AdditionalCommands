using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using SometimesRaidsGoWrong;
using Verse;
using SirRandoo.ToolkitUtils.Incidents;
using RimWorld;

namespace AdditionalCommands.Patches.SometimesRaidsGoWrong
{
    //Lmao doesn't work

    /*
    [HarmonyPatch]
    public static class RaidPatch
    {
        public static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(typeof(WageredIncident), "Execute");
        }

        public static void Prefix(WageredIncident __instance, ref IncidentWorker ___worker)
        {
            Log.Message("Injected into Raid Successfully"); //Doesn't work

            
            if(InternalPatcher.CurrentPatchedMods.Contains("marvinkosh.sometimesraidsgowrong"))
            {
                if(___worker.GetType() == typeof (RimWorld.IncidentWorker_RaidEnemy))
                {
                    ___worker = new MarvsRandom_RaidEnemy();
                }
            }
        }

        
        public static void Postfix(WageredIncident __instance)
        {

        }
    }
    */
}
