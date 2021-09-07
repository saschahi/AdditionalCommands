using AdditionalCommands.Helpers;
using AlphaBehavioursAndEvents;
using RimWorld;

namespace AdditionalCommands.Commands.AlphaAnimals
{
    class AnimaliskEnters : ModdedRaid
    {
        public AnimaliskEnters()
        {
            worker = new IncidentWorker_Animalisk();
            worker.def = IncidentDef.Named("AA_IncidentAnimaliskEnters");
        }
    }
}
