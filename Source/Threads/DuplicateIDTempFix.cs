using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchToolkit;


namespace AdditionalCommands.Threads
{
    /*
    public class DuplicateIDTempFix
    {
        public void RunThread()
        {
            while(true)
            {
                foreach(var item in Viewers.All)
                {
                    if (item.id != 0)
                    {
                        var Viewerlist = Viewers.All.FindAll(x => x.username == item.username);
                        if (Viewerlist.Count() > 1)
                        {
                            var MainViewer = Viewers.All.FirstOrDefault(x => x.username == item.username);
                            Viewerlist.Remove(MainViewer);
                            foreach (var item2 in Viewerlist)
                            {
                                int index = Viewers.All.IndexOf(item2);
                                Viewers.All[index].coins = 0;
                                Viewers.All[index].karma = 0;
                                Viewers.All[index].id = 0;
                            }
                        }
                    }
                }

                Thread.Sleep(600000);
            }
        }
    }
    */
}
