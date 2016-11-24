using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNotification.Client
{
    public class Class1
    { 

        public static void connserver(int id,string msg,string group)
        {
            HubConnection hubConnection = new HubConnection("http://localhost:54646/");
            IHubProxy myHubProxy = hubConnection.CreateHubProxy("MyHub");
            hubConnection.Start().Wait();
            while (true) {
                if (id == 0 && group == "0") 
                {
                    myHubProxy.Invoke("sendToAll", msg);
                    break;
                   
                }
                 if (id == 0 && group != "0")
                {
                    myHubProxy.Invoke("sendToGroup", group, msg);
                    break;
                }
               if (id != 0 && group == "0")
                {
                    myHubProxy.Invoke("sendPrivateAlert", id, msg);
                    break;
                }

            }
        }
    }
}
