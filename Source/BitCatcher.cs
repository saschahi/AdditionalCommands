﻿using ToolkitCore;
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
            if (Main.bitstocoin && Main.coinsperbit != 0)
            {
                int bits = twitchMessage.ChatMessage.Bits;

                if (bits != 0)
                {
                    Viewer viewer = Viewers.All.Find(x => x.username == twitchMessage.Username);

                    if (viewer != null)
                    {
                        int coinstogive = bits * Main.coinsperbit;
                        viewer.GiveViewerCoins(coinstogive);

                        if (Main.partymode)
                        {
                            Viewers.AwardViewersCoins(coinstogive / Main.partypercentage);
                            //so the Viewer that gifts the bits doesn't get the extrabits. since AwardViewersCoins doesn't have a way to exclude someone
                            viewer.TakeViewerCoins(coinstogive / Main.partypercentage);
                        }
                    }
                }
            }
        }
    }
}