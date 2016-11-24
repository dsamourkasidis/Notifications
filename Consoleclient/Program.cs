using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSNotification.Client;

namespace Consoleclient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Press 1 to send an alert to all users \n 2 to send an alert to a user with specified id \n or 3 to send an alert to a group of users");
                int x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("Type the message");
                    string msg = Console.ReadLine();
                    Class1.connserver(0, msg, "0");
                }
                else if (x == 2)
                {
                    Console.WriteLine("Type the message");
                    string msg = Console.ReadLine();
                    Console.WriteLine("Enter the user's id");
                    int id = int.Parse(Console.ReadLine());
                    Class1.connserver(id, msg, "0");
                }
                else if (x == 3)
                {
                    Console.WriteLine("Type the message");
                    string msg = Console.ReadLine();
                    Console.WriteLine("Enter the group's name");
                    string group = Console.ReadLine();
                    Class1.connserver(0, msg, group);
                }
                else
                {
                    Console.WriteLine("try again");
                }

            }
        }
    }
}
