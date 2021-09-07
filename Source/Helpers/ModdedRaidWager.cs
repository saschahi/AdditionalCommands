using Verse;
using TwitchToolkit.Store;
using RimWorld;
using TwitchToolkit;
using ToolkitCore;
using TwitchToolkit.IncidentHelpers;

namespace AdditionalCommands.Helpers
{
    public class ModdedRaidWager : IncidentHelperVariables
    {
        public IncidentWorker worker;
        public  IncidentParms parms;
        public override Viewer Viewer { get; set; }
        public int pointsWager = 0;
        public IIncidentTarget target = null;
        //private bool separateChannel = false;
        public IncidentCategoryDef Category;

        public ModdedRaidWager()
        {
            
        }

        public override bool IsPossible(string a, Viewer viewer, bool separateChannel)
        {
            
            if (worker.def.earliestDay > GenDate.DaysPassed)
            {
                TwitchWrapper.SendChatMessage($"@{Viewer.username} This Event was Hardcoded to only be Executable after a certain day. Days left: " + (worker.def.earliestDay - GenDate.DaysPassed).ToString());
                return false;
            }


            this.Viewer = viewer;
            string[] command = message.Split(' ');
            if (command.Length < 3)
            {
                TwitchWrapper.SendChatMessage($"@{viewer.username} syntax is !buy raidtype coins");
                return false;
            }

            if (!VariablesHelpers.PointsWagerIsValid(
                    command[2],
                    viewer,
                    ref pointsWager,
                    ref storeIncident,
                    separateChannel
                ))
            {
                return false;
            }

            target = Current.Game.AnyPlayerHomeMap;
            if (target == null)
            {
                return false;
            }

            if(Category == null)
            {
                Category = worker.def.category;
            }

            parms = StorytellerUtility.DefaultParmsNow(Category, Helper.AnyPlayerMap);
            //parms.points = IncidentHelper_PointsHelper.RollProportionalGamePoints(storeIncident, pointsWager, parms.points);

            parms.points = StorytellerUtility.DefaultThreatPointsNow(parms.target);
            parms.points = IncidentHelper_PointsHelper.RollProportionalGamePoints(storeIncident, pointsWager, parms.points);

            bool canfire = worker.CanFireNow(parms);
            return canfire;
        }

        public override void TryExecute()
        {
            if (parms.points > 15000)
            {
                parms.points = 15000;
            }
            if (parms.points <= 0)
            {
                return;
            }

            if (worker.TryExecute(parms))
            {
                Viewer.TakeViewerCoins(pointsWager);
                Viewer.CalculateNewKarma(this.storeIncident.karmaType, pointsWager);
                VariablesHelpers.SendPurchaseMessage($"Starting Modded Raid with {pointsWager} points wagered and {(int)parms.points} raid points purchased by {Viewer.username}");
                return;
            }
            TwitchWrapper.SendChatMessage($"@{Viewer.username} could not generate parms for raid.");
        }
    }
}
