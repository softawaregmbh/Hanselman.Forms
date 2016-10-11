using System;
using Microsoft.WindowsAzure.MobileServices;

namespace Hanselman.Portable.Auth
{
    public class ServiceClientManager
    {
        private static ServiceClientManager instance;

        private ServiceClientManager()
        {
            this.Client = new MobileServiceClient(new Uri("http://mobiledevops.azurewebsites.net/"));
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
