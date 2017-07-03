using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalPushNotification
{
    public class Push
    {
        /// <summary>
        /// 
        /// </summary>
        public int pushType
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int serviceType
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string message
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Clients> clients
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pushType"></param>
        /// <param name="serviceType"></param>
        /// <param name="message"></param>
        /// <param name="clients"></param>
        public Push(int pushType, int serviceType, string message, List<Clients> clients)
        {
            this.pushType = pushType;
            this.serviceType = serviceType;
            this.message = message;
            this.clients = clients;
        }
    }
}
