using System.Collections.Generic;
using HarmonyLib;
using System.Reflection;
using SirRandoo.ToolkitUtils;
using SirRandoo.ToolkitUtils.Interfaces;

namespace AdditionalCommands
{
    [HarmonyPatch]
    public static class Patch
    {
        /// Here we tell Harmony the thing we want to patch.
        public static IEnumerable<MethodBase> TargetMethods()
        {
            // This asks Harmony to get the Execute method in Utils' BuyPawn class.
            yield return AccessTools.Method(typeof(SirRandoo.ToolkitUtils.Incidents.BuyPawn), "Execute");
            
        }

        /// Here we tell Harmony that the code in this method should run before Utils'.
        /// 
        /// The __instance parameter is special in that Harmony will pass the instance
        /// the class you're patching so that you can access public members of it.
        public static void Prefix(SirRandoo.ToolkitUtils.Incidents.BuyPawn __instance)
        {
            //Making sure to not clog up the Basket with lots of Stuff.
            if (!Basket.TryGetEggFor(__instance.Viewer.username, out IEasterEgg egg))
            {
                Basket.RegisterEggFor(__instance.Viewer.username, new AlphaEgg());
            }
            else if (!(egg is AlphaEgg))
            {
                Basket.RegisterEggFor(__instance.Viewer.username, new AlphaEgg());
            }
        }

        /// Here we tell Harmony that the code in this method should run after Utils'.
        public static void Postfix(SirRandoo.ToolkitUtils.Incidents.BuyPawn __instance)
        {
            // Here we check to see if the viewer has an easter egg assigned to them, and
            // if they do, we make sure we only remove it if it's our Mime egg.
            if (Basket.TryGetEggFor(__instance.Viewer.username, out IEasterEgg egg))
            {
                if (egg is AlphaEgg)
                {
                    //And this is later meant to remove the easteregg if it did activate successfully?
                    //Basket.UnregisterEggFor(__instance.Viewer.username)
                }

            }

        }
    }

}
