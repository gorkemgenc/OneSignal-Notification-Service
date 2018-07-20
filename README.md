# OneSignal-Push-Notification-Service

## Explanations

One signal is an free service to send push notification to any platform and this repository is an basic example of how OneSignal push notification services is implemented for mobile written in C# (Backend).

## Implementations

This part shows how to send message via the Google GCM and Apple APNS services.

## JSON TYPE:

        // IOS APNS
        
        var obj = new
        {
            app_id = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX(This is OneSignal App ID)",
            contents = new
            {
                en = "English Message for IOS",
                tr = "English Message for IOS"
            },
            headings = new
            {
                en = "Headings",
                tr = "English Message for IOS"
            },
            include_player_ids = array,
            content_available = true,
            ios_badgeType = "SetTo",
            ios_badgeCount = 1,
            data = content
        };
        string s = javaScriptSerializer.Serialize(obj);
        bytes = Encoding.UTF8.GetBytes(s);

        // Android GCM
        
        {
            var obj = new
            {
                app_id = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX(This is OneSignal App ID)",
                contents = new
                {
                    en = "English Message"
                },
                include_player_ids = array,
                data = content
            };
            string s = javaScriptSerializer.Serialize(obj);
            bytes = Encoding.UTF8.GetBytes(s);
        }

