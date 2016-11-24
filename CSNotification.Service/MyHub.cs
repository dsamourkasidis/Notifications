using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
namespace CSNotification.Service
{
    public class MyHub : Hub
    {
        static Dictionary<int, UserDetail> ConnectedUsersExt = new Dictionary<int, UserDetail>();
        static Dictionary<int, UserMessage> PendingAlerts = new Dictionary<int, UserMessage>();
        public void Connect(int id, string group)
        {   //Check for Alerts sent while user was disconnected
            if (PendingAlerts.ContainsKey(id))
            {   
                UserMessage TempUserMessage = PendingAlerts[id];
                string msg = TempUserMessage.msg;
                Clients.Caller.receiveAlert(msg);
                conndb.Dbquery(id, "0", msg, 2);
                PendingAlerts.Remove(id);
            }
            var connid = Context.ConnectionId;
            //Check if there is already connected a user with the same id
            if (ConnectedUsersExt.ContainsKey(id))
            {
                Clients.Caller.receiveAlert("User already connected");
            }
            else
            {   //Add the new user along with his Connid from signalr to a dic
                ConnectedUsersExt.Add(id, new UserDetail { ConnectionId = connid, UserId = id });
                //Also add the user to the group manager of hubs
                Groups.Add(connid, group);
                
            }
        }
        public  void SendToAll(string message)
        {   //Get the info from myhub and call the client side function receiveAlert
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            hubContext.Clients.All.receiveAlert(message);
            conndb.Dbquery(0, "0", message, 2);
        }
        public  void SendPrivateAlert(int id, string message)
        {   //Check if the user is connected, else add the alert to the PendingAlerts dic to sent later
            if (ConnectedUsersExt.ContainsKey(id))
            {   //Search the dic for the connid of the user id entered
                IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                UserDetail TempUserDetail = ConnectedUsersExt[id];
                string connId = TempUserDetail.ConnectionId;
                hubContext.Clients.Client(TempUserDetail.ConnectionId).receiveAlert(message);
                conndb.Dbquery(id, "0", message, 2);
            }
            else
            {
                PendingAlerts.Add(id, new UserMessage { msg = message, UserId = id });
                conndb.Dbquery(id, "0", message, 1);
            }
        }
        public  void SendToGroup(string group, string message)
        {
            
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            hubContext.Clients.Group(group).receiveAlert(message);//System.Diagnostics.Debug.Write(group);
            conndb.Dbquery(0, group, message, 2);
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            string connid = Context.ConnectionId;
            foreach (var discuser in ConnectedUsersExt.Where(kvp => kvp.Value.ConnectionId == connid).ToList())
            {   //Remove the user from the ConnectedUsers dic on disconnect
                ConnectedUsersExt.Remove(discuser.Key);
            }

            return base.OnDisconnected(true);
        }
            

    }
}
