using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalPushNotification
{
    public class PlayerID
    {
        /// <summary>
        /// 
        /// </summary>
        public int clientID
        {
            get;
            set;
        }

        /// <summary>
        /// GCM or APNS mobile token
        /// </summary>
        public string token
        {
            get;
            set;
        }

        /// <summary>
        /// Creating by OneSignal
        /// </summary>
        public string playerID
        {
            get;
            set;
        }

        /// <summary>
        /// OneSignal keep all client with creating playerID
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="mobileToken"></param>
        /// <param name="playerID"></param>
        public PlayerID(int clientID, string token, string playerID)
        {
            this.clientID = clientID;
            this.token = token;
            this.playerID = playerID;
        }
    }
}
