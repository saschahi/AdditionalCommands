using AdditionalCommands.Helpers;
using MeteorIncident;
using RimWorld;

namespace AdditionalCommands.Commands.YayoMeteor
{
    class YayoMeteor : MiscEvents
    {
        public YayoMeteor()
        {
            worker = new IncidentWorker_MeteorStormCondition();
            worker.def = IncidentDef.Named("MeteorStorm");
        }
    }
}
