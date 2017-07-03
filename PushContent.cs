using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalPushNotification
{
    public class PushContent : Push
    {
        /// <summary>
        /// In this application we use activityID. You can use another information whatever you want
        /// </summary>
        public int activityID
        {
            get;
            set;
        }

        /// <summary>
        /// In this application we use activityID. You can use another information whatever you want
        /// </summary>
        public string activityName
        {
            get;
            set;
        }

        /// <summary>
        /// 6 parameter constructor.
        /// </summary>
        /// <param name="activityID"></param>
        /// <param name="activityName"></param>
        /// <param name="pushType"></param>
        /// <param name="serviceType"></param>
        /// <param name="message"></param>
        /// <param name="clients"></param>
        public PushContent(int activityID, string activityName, int pushType, int serviceType, string message, List<Clients> clients) : base(pushType, serviceType, message, clients)
		{
            this.activityID = activityID;
            this.activityName = activityName;
        }
    }
}
