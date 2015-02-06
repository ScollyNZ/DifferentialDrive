using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Bluetooth
{
    public class Program
    {
        public static void Main()
        {
            //var x = new HC05SetSlave();
            //var x = new VoltageControl();
            var x = new BasicEcho();


        }

    }
}
