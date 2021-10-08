using System.Collections.Generic;
using ToolkitCore.Interfaces;
using ToolkitCore.Windows;
using UnityEngine;
using Verse;

namespace AdditionalCommands
{
    public class Settings : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        ExampleSettings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public Settings(ModContentPack content) : base(content)
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
            listingStandard.Label("What should be the Max Value of items we remove with the cleanup Command? (Default 500)");
            listingStandard.Label(Main.maxValueToCleanup.ToString());
            Main.maxValueToCleanup = (int)listingStandard.Slider(Main.maxValueToCleanup, 10, 2000);
            listingStandard.Label("");
            listingStandard.Label("How many Forbidden Items do there have to be to before the Cleanup button works? (Default 30)");
            listingStandard.Label(Main.mintoremove.ToString());
            Main.maxValueToCleanup = (int)listingStandard.Slider(Main.mintoremove, 1, 100);
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
            Scribe_Values.Look(ref Main.maxValueToCleanup, "maxValueToCleanup", 500);
            Scribe_Values.Look(ref Main.mintoremove, "mintoremove", 30);
            //Scribe_Values.Look(ref exampleFloat, "exampleFloat", 200f);
            //Scribe_Collections.Look(ref exampleListOfPawns, "exampleListOfPawns", LookMode.Reference);
            base.ExposeData();
        }
    }


    public class ToolkitMenu : IAddonMenu
    {
        List<FloatMenuOption> IAddonMenu.MenuOptions() => new List<FloatMenuOption>
        {
            new FloatMenuOption("Settings", delegate ()
            {
                Window_ModSettings window = new Window_ModSettings(LoadedModManager.GetMod<AdditionalCommands.Settings>());
                Find.WindowStack.TryRemove(window.GetType());
                Find.WindowStack.Add(window);
            }),
            new FloatMenuOption("Cleanup Forbidden Items", delegate()
            {
                AdditionalCommands.Commands.ClearCommand.RemoveForbidden("Streamer");
            })
        };
    }
}

