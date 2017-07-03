using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalPushNotification
{
    public class Clients
    {
        public int clientID
        {
            get;
            set;
        }

        public string mobileTokens
        {
            get;
            set;
        }

        public int mobileType
        {
            get;
            set;
        }

        public bool isPlayerIdExists
        {
            get;
            set;
        }

        public Clients(int clientID, string mobileTokens, int mobileType, bool isPlayerIdExists = false)
        {
            this.clientID = clientID;
            this.mobileTokens = mobileTokens;
            this.mobileType = mobileType;
            this.isPlayerIdExists = isPlayerIdExists;
        }
    }
}
