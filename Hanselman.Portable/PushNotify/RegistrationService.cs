using System;
using Android.App;
using Android.Content;

namespace Hanselman.Portable.PushNotify
{
    [Service]
    public class RegistrationService : IntentService
    {
        public const string GCM_SENDER_ID = "YOUR-SENDER-ID";

        public static event Action<string> TokenRefreshed;

        public static void Register(Context context)
        {
            context.StartService(new Intent(context, typeof(RegistrationService)));
        }

        protected override void OnHandleIntent(Intent intent)
        {
            // Get the new token and send to the server
            var instanceID = InstanceID.GetInstance(Application.Context);
            var token = instanceID.GetToken(GCM_SENDER_ID, GoogleCloudMessaging.InstanceIdScope);

            // Fire the event for any UI subscribed to it
            TokenRefreshed?.Invoke(token);

            Console.WriteLine("OnTokenRefresh: {0}", token);
        }
    }
}
