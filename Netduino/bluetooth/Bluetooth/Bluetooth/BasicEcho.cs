using System;
using Microsoft.SPOT;
using System.IO.Ports;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Bluetooth
{
    class BasicEcho
    {
        public BasicEcho()
        {
            SerialPort serial = new SerialPort(SerialPorts.COM1,
                  9600, Parity.None, 8, StopBits.One);
            serial.Open();

            while (true)
            {
                if (serial.BytesToRead > 0)
                {
                    var incoming = serial.ReadByte();
                    serial.WriteByte((byte)(incoming + 1));
                }
            }
        }
    }
}
