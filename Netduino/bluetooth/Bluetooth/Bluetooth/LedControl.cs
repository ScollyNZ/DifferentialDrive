using System;
using Microsoft.SPOT;
using System.IO.Ports;
using SecretLabs.NETMF.Hardware.Netduino;
using Microsoft.SPOT.Hardware;

namespace Bluetooth
{
    class LedControl
    {
        public LedControl()
        {
            SerialPort serial = new SerialPort(SerialPorts.COM1,
                  9600, Parity.None, 8, StopBits.One);

            var ledPort = new OutputPort(Pins.ONBOARD_LED,false);
            serial.Open();

            while (true)
            {
                if (serial.BytesToRead > 0)
                {
                    var incoming = serial.ReadByte();

                    var ledState = incoming == '1';
                    ledPort.Write(ledState);

                    if (ledState)
                        serial.WriteByte((byte)'1');
                    else
                        serial.WriteByte((byte)'0');
                }
            }
        }
    }
}
