using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalPushNotification
{
    [Serializable]
    public class Result
    {
        /// <summary>
        ///  Process is successful or not
        /// </summary>
        public bool success
        {
            get;
            set;
        }

        /// <summary>
        /// Notification ID
        /// </summary>
        public string id
        {
            get;
            set;
        }
    }
}
