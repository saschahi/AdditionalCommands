using AdditionalCommands.Helpers;
using RimWorld;

namespace AdditionalCommands.Commands
{
    class ColonyAge : CommandBase
    {
        public override void RunCommand(global::TwitchLib.Client.Models.Interfaces.ITwitchMessage twitchMessage)
        {
            int age = GenDate.DaysPassed;

            ToolkitCore.TwitchWrapper.SendChatMessage(twitchMessage.Username + " the colony has been alive for " + age + " days");
        }
    }
}
