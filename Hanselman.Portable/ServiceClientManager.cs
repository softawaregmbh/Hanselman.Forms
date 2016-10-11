using System;
using Microsoft.WindowsAzure.MobileServices;

namespace Hanselman.Portable.Auth
{
    public class ServiceClientManager
    {
        // Define a authenticated user.
        private MobileServiceUser user;

        private static ServiceClientManager instance;

        private ServiceClientManager()
        {
            this.Client = new MobileServiceClient(new Uri("http://MobileDevOps.servicebus.windows.net/"));
        }

        public MobileServiceClient Client { get; private set; }

        public static ServiceClientManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceClientManager();
                }
                return instance;
            }
        }
    }
}
