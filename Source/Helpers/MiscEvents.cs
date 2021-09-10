using RimWorld;
using ToolkitCore;
using TwitchToolkit;
using TwitchToolkit.Store;
using Verse;

namespace AdditionalCommands.Helpers
{
    class MiscEvents : IncidentHelper
    {
        private IncidentParms parms;
        public IncidentWorker worker;
        public IncidentCategoryDef Category;
        public IIncidentTarget target = null;

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
            bool canfire = worker.CanFireNow(parms);
            return canfire;
        }

        public override void TryExecute()
        {
            worker.TryExecute(parms);
        }
    }
}
