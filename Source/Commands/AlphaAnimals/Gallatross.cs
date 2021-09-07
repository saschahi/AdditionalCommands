using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class Gallatross : MiscEvents
    {
        public Gallatross()
        {
            worker = new IncidentWorker_Gallatross();
            worker.def = IncidentDef.Named("AA_Incident_Gallatross");
        }
    }
}
