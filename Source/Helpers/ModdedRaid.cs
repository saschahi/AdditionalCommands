using Verse;
using RimWorld;
using TwitchToolkit.Store;
using TwitchToolkit;
using ToolkitCore;
using TwitchToolkit.IncidentHelpers;

namespace AdditionalCommands.Helpers
{
    public class ModdedRaid : IncidentHelper
    {
        public int pointsWager = 0;
        public IIncidentTarget target = null;
        public IncidentCategoryDef Category;
        public IncidentWorker worker;
        private IncidentParms parms;

        public override bool IsPossible()
        {
            if (Main.trySkipEarliestDayCheck)
            {
                worker.def.earliestDay = 0;
            }

            if (worker.def.earliestDay > GenDate.DaysPassed)
            {
                TwitchWrapper.SendChatMessage($"@{Viewer.username} This Event was Hardcoded to only be Executable after a certain day. Days left: " + (worker.def.earliestDay - GenDate.DaysPassed).ToString());
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
            if (parms.points == 0)
            {
                parms.points = StorytellerUtility.DefaultThreatPointsNow(parms.target);
            }
            bool canfire = worker.CanFireNow(parms);
            return canfire;
        }

        public override void TryExecute()
        {
            worker.TryExecute(parms);
        }
    }

}
