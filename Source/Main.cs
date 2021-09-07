using Verse;
using System;
using System.Collections.Generic;

namespace AdditionalCommands
{

    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main() 
        {
            Patcher.OnStartup();
            
        }
    }

    public static class Patcher
    {
        public static List<String> CurrentPatchedMods = new List<String>();
        public static void OnStartup()
        {
            LoadCurrentPatchedMods();
        }

        public static void LoadCurrentPatchedMods()
        {
            if (ModExists("SR.ModRimworld.FactionalWar"))
            {
                LogMod("[SR]Factional War");
                CurrentPatchedMods.Add("SR.ModRimworld.FactionalWar");
            }
            if (ModExists("SR.ModRimworld.RaidExtension"))
            {
                LogMod("[SR]Raid Extensions");
                CurrentPatchedMods.Add("SR.ModRimworld.RaidExtension");
            }
            if (ModExists("sarg.alphaanimals"))
            {
                LogMod("Alpha Animals");
                CurrentPatchedMods.Add("sarg.alphaanimals");
            }

            


        }

        public static void LogMod(string mod)
        {
            Log.Message("ToolkitAddon - More Stuff: Found Patchable Mod: " + mod);
        }

        public static bool ModExists(string mod)
        {
            return ModLister.GetActiveModWithIdentifier(mod) != null;
        }
    }
}
