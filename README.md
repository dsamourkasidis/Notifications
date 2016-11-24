# Notifications
Notifications implements a notifications system using ASP.NET SignalR
### It consists of
1. A CSNotification.Service .dll, which contains the SignalR Hub Class
2. A CSNotification.Client, which connects to the Hub and it is the only one responsible for sending notifications to users. Therefore, it acts like an administrator
3. A Consoleclient, which is a simple console user interface for the CSNotification.Client
4. Finally, a WEB website, where users can connect and receive notifications
