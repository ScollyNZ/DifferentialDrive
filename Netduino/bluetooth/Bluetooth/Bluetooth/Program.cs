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
            //var x = new VoltageControl();     //low flash LED and produce voltage for low pass filter
            //var x = new BasicEcho();          //echo chars coming in the rs232 port back + 1
            //var x = new LedOnOffControl();    // turn onboard led on if 1 is rxd, of if anything else
            var x = new LedBrightnessControl(); //modify brightness based on ascii value (0 to 100 + 65) of incoming char

        }

    }
}
