using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class Aerofleets : MiscEvents
    {
        public Aerofleets()
        {
            worker = new IncidentWorker_Aerofleets();
            worker.def = IncidentDef.Named("AA_Incident_Aerofleets");
        }
    }
}
