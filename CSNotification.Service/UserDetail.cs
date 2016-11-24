using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNotification.Service
{
    public class UserDetail
    {
        public string ConnectionId { get; set; }
        public int UserId { get; set; }
    }

    public class UserMessage
    {
        public string msg { get; set; }
        public int UserId { get; set; }
    }
}
