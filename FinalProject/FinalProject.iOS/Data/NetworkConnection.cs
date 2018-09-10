using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalProject.Data;
using Foundation;
using UIKit;

namespace FinalProject.iOS.Data
{
    class NetworkConnection : INetworkConnection
    {
        public bool IsConnected
        {
            get; set;
        }

        public void CheckNetworkConnection()
        {
            InternetStatus();
        }

        private bool InternetStatus()
        {
            return true;
        }
    }
}