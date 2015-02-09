using System;
using Microsoft.SPOT;
using System.IO.Ports;
using SecretLabs.NETMF.Hardware.Netduino;
using Microsoft.SPOT.Hardware;

namespace Bluetooth
{
    class LedBrightnessControl
    {
        public LedBrightnessControl()
        {
            SerialPort serial = new SerialPort(SerialPorts.COM1,
                  9600, Parity.None, 8, StopBits.One);

            var led = new LedBrightness();
            serial.Open();

            while (true)
            {
                if (serial.BytesToRead > 0)
                {
                    int incoming = (byte)serial.ReadByte()-65;
                    incoming = incoming * 4;
                    if (incoming >= 0 && incoming <= 100)
                        led.brightnessPercent = (byte)incoming;
                    var message = "Set Brightness:" + incoming.ToString() + "\r\n";
                    Debug.Print(message);
                    serial.Write(System.Text.Encoding.UTF8.GetBytes(message),0,message.Length);
                }
            }
        }
    }
}
