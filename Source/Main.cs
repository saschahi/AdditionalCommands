using Verse;
using System;
using System.Collections.Generic;
using UnityEngine;

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
            if (ModExists("VanillaExpanded.VEE"))
            {
                LogMod("Vanilla Events Expanded");
                CurrentPatchedMods.Add("VanillaExpanded.VEE");
            }



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

    public class ExampleSettings : ModSettings
    {
        /// <summary>
        /// The three settings our mod has.
        /// </summary>
        //public bool exampleBool;
        //public float exampleFloat = 200f;
        //public List<Pawn> exampleListOfPawns = new List<Pawn>();

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref Main.trySkipEarliestDayCheck, "trySkipEarliestDayCheck");
            Scribe_Values.Look(ref Main.coinsperbit, "coinsPerBit");
            Scribe_Values.Look(ref Main.partymode, "partymode");
            Scribe_Values.Look(ref Main.partypercentage, "partyPercentage");
            Scribe_Values.Look(ref Main.bitstocoin, "bitstocoins");
            //Scribe_Values.Look(ref exampleFloat, "exampleFloat", 200f);
            //Scribe_Collections.Look(ref exampleListOfPawns, "exampleListOfPawns", LookMode.Reference);
            base.ExposeData();
        }
    }

    public class ExampleMod : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        ExampleSettings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public ExampleMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<ExampleSettings>();
        }
        
        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("Should we try to skip the 'Earliest day Possible' some Events try to enforce?", ref Main.trySkipEarliestDayCheck, "Note: This might break some Events, and might not always solve the cause of Event not possible!");
            listingStandard.Label("");
            listingStandard.CheckboxLabeled("Should People get rewarded Coins for gifting Bits?", ref Main.bitstocoin);
            listingStandard.Label("How many Coins should people get for 1 Bit?");
            listingStandard.Label(Main.coinsperbit.ToString());
            Main.coinsperbit = (int)listingStandard.Slider(Main.coinsperbit, 0, 100);
            listingStandard.Label("");
            listingStandard.CheckboxLabeled("Do you want to enable Bits Party Mode?", ref Main.partymode, "With this every active Viewer gets a (below configurable) Percentage of the Coins that the Gifter gets");
            listingStandard.Label("Bits Party Mode Percentage");
            listingStandard.Label(Main.partypercentage.ToString());
            Main.partypercentage = (int)listingStandard.Slider(Main.partypercentage, 0, 100);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {
            return "ToolkitAddon: More Stuff";
        }
    }
}
