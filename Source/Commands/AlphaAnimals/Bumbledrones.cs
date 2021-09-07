using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class Bumbledrones : MiscEvents
    {
        public Bumbledrones()
        {
            worker = new IncidentWorker_Bumbledrones();
            worker.def = IncidentDef.Named("AA_Incident_Bumbledrones");
        }
    }
}
