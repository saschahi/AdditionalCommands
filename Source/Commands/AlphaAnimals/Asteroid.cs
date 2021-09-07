using RimWorld;
using AlphaBehavioursAndEvents;
using AdditionalCommands.Helpers;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class Asteroid : MiscEvents
    {
        public Asteroid()
        {
            worker = new IncidentWorker_Asteroid();
            worker.def = IncidentDef.Named("AA_Incident_SkyMeteorite");
        }
    }
}
