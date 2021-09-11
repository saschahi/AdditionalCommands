using AdditionalCommands.Helpers;
using RimWorld;
using System.Collections.Generic;
using TwitchToolkit;
using Verse;
using Verse.Sound;

namespace AdditionalCommands.Commands
{
    public class ClearCommand : CommandBase
    {
        public override void RunCommand(global::TwitchLib.Client.Models.Interfaces.ITwitchMessage twitchMessage)
        {
            Viewer viewer = TwitchToolkit.Viewers.GetViewer(twitchMessage.Username);
            //if(viewer.mod)
            if(TwitchToolkit.Viewer.IsModerator(twitchMessage.Username))
            {
                RemoveForbidden(twitchMessage.Username);
            }
        }

        public static void RemoveForbidden(string user)
        {
            Map currentMap = Find.CurrentMap;
            if (currentMap == null)
                return;
            List<Thing> allThings = Find.CurrentMap.listerThings.AllThings;
            List<Thing> thingstodestroy = new List<Thing>();
            foreach (Thing item in allThings.ToArray())
            {
                //Thing thing = item;
                CompForbiddable compForbiddable = item is ThingWithComps thingWithComps ? thingWithComps.GetComp<CompForbiddable>() : (CompForbiddable)null;
                if (compForbiddable != null)
                {
                    bool flag = currentMap.fogGrid.IsFogged(item.Position);
                    var homearea = currentMap.areaManager.Home;
                    bool test = homearea[item.Position];
                    if (compForbiddable != null && compForbiddable.Forbidden && !flag && !test)
                    {
                        thingstodestroy.Add(item);
                    }
                }
            }

            int count = thingstodestroy.Count;

            if(count < 30)
            {
                Messages.Message(user + " Requested a Cleanup. Assuming this was a misshap since there is less than 30 Forbidden Items on the map.", MessageTypeDefOf.SilentInput);
                
            }
            else
            {
                foreach (var item in thingstodestroy)
                {
                    item.Destroy();
                }
                Messages.Message(user + " Requested a Cleanup. We cleaned up " + count + " Disallowed Items on the Map", MessageTypeDefOf.SilentInput);
            }

            

        }
    }
}

