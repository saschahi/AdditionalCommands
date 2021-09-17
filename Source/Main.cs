using HarmonyLib;
using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace AdditionalCommands
{

    [StaticConstructorOnStartup]
    public static class Main
    {
        public static bool trySkipEarliestDayCheck;
        public static int coinsperbit;
        public static int partypercentage;
        public static bool partymode;
        public static bool bitstocoin;
        public static int maxValueToCleanup = 500;

        static Main() 
        {
            InternalPatcher.OnStartup();
        }
    }

    public static class InternalPatcher
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
            if (ModExists("VanillaExpanded.VEE"))
            {
                LogMod("Vanilla Events Expanded");
                CurrentPatchedMods.Add("VanillaExpanded.VEE");
            }
            if (ModExists("com.yayo.meteor"))
            {
                LogMod("Yayo's Meteor");
                CurrentPatchedMods.Add("com.yayo.meteor");
            }
            /*if (ModExists("marvinkosh.sometimesraidsgowrong"))
            {
                LogMod("Sometimes Raids Go Wrong");
                CurrentPatchedMods.Add("marvinkosh.sometimesraidsgowrong");
            }*/
            

            var harmony = new Harmony("AdditionalCommands");
            harmony.PatchAll();
        }

        public static void LogMod(string mod)
        {
            Log.Message("[ToolkitAddon - More Stuff] Found Patchable Mod: " + mod);
        }

        public static bool ModExists(string mod)
        {
            return ModLister.GetActiveModWithIdentifier(mod) != null;
        }
    }

}

