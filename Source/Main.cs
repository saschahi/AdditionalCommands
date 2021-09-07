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
                CurrentPatchedMods.Add("[SR]Factional War");
            }
            if (ModExists("SR.ModRimworld.RaidExtension"))
            {
                LogMod("[SR]Raid Extensions");
                CurrentPatchedMods.Add("[SR]Raid Extensions");
            }
            
            



        }

        public static void LogMod(string mod)
        {
            Log.Message("ToolkitAddon - More Stuff: Found Patchable Mod: " + mod);
        }

        public static bool ModExists(string mod)
        {
            return ModLister.GetModWithIdentifier(mod) != null;
        }
    }
}
