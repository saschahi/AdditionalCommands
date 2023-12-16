using ToolkitCore;
using TwitchLib.Client.Models.Interfaces;
using TwitchToolkit;
using Verse;

namespace AdditionalCommands
{
    public class BitCatcher : TwitchInterfaceBase
    {
        public BitCatcher(Game game)
        {

        }

        public override void ParseMessage(ITwitchMessage twitchMessage)
        {
            usebits(twitchMessage);
        }

        public void usebits(ITwitchMessage twitchMessage)
        {
            if (Main.bitstocoin && Main.coinsperbit > 0)
            {
                int bits = twitchMessage.ChatMessage.Bits;

                bits = 10; //DELETE

                if (bits != 0)
                {
                    Log.Message("Starting usercheck");
                    Log.Message("To find: " + twitchMessage.ChatMessage.UserId);
                    Log.Message("Check: " + Viewers.All.FirstOrFallback().id);

                    Viewer viewer = Viewers.All.Find(x => x.id.ToString() == twitchMessage.ChatMessage.UserId);
                    if (viewer != null)
                    {
                        int coinstogive = bits * Main.coinsperbit;
                        viewer.GiveViewerCoins(coinstogive);
                        Log.Message("Test3");

                        if (Main.partymode)
                        {
                            Log.Message("Test4");

                            int coinsparty = (coinstogive / Main.partypercentage);
                            Viewers.AwardViewersCoins(coinsparty);
                            //so the Viewer that gifts the bits doesn't get the extrabits. since AwardViewersCoins doesn't have a way to exclude someone
                            viewer.TakeViewerCoins(coinsparty);
                            TwitchWrapper.SendChatMessage("Awarded " + twitchMessage.Username + " " + coinstogive + " coins for Donating " + bits + " Bits! KomodoHype PartyMode is enabled so everyone else also gets " + coinsparty + " Coins");
                        }
                        else
                        {
                            Log.Message("Test5");

                            TwitchWrapper.SendChatMessage("Awarded " + twitchMessage.Username + " " + coinstogive + " coins for Donating " + bits + " Bits!");
                        }
                    }
                }
            }
        }
    }
}
