using Verse;
using RimWorld;
using TwitchToolkit.Store;
using TwitchToolkit;

namespace AdditionalCommands.Helpers
{
    public class HostileVisitor : IncidentHelper
    {
        private IncidentParms parms;
        public IncidentWorker worker;
        public IncidentCategoryDef Category;
        public IIncidentTarget target = null;

        public HostileVisitor()
        {
            
        }

        public override bool IsPossible()
        {
            target = Current.Game.AnyPlayerHomeMap;
            if (target == null)
            {
                return false;
            }

            parms = StorytellerUtility.DefaultParmsNow(Category, Helper.AnyPlayerMap);
            bool canfire = worker.CanFireNow(parms);
            return canfire;
        }

        public override void TryExecute() => this.worker.TryExecute(this.parms);
    }

}
