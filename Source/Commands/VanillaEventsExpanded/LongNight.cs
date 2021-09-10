using AdditionalCommands.Helpers;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEE;

namespace AdditionalCommands.Commands.VanillaEventsExpanded
{
    class LongNight : MiscEvents
    {
        public LongNight()
        {
            worker = new IncidentWorker_MakeGameConditionVEE();
            worker.def = IncidentDef.Named("VEE_LongNight");
        }
    }
}
