using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace AnalogMux
{
    public class Program
    {
        static OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
        static int readPortNumber = 0;
        static OutputPort port0 = new OutputPort(Pins.GPIO_PIN_D0, true);
        static OutputPort port1 = new OutputPort(Pins.GPIO_PIN_D1, true);
        static OutputPort port2 = new OutputPort(Pins.GPIO_PIN_D2, true);

        public static void Main()
        {
            var reader = new Thread(ReadAndDisplayAnalog);

            reader.Start();

            var button = new InterruptPort(Pins.ONBOARD_SW1, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeHigh);
            button.OnInterrupt += new NativeEventHandler(button_OnInterrupt);


            //while (1 == 1)
            //{
            //    Thread.Sleep(5000);
            //    IncrementReadPort();
            //}

            Thread.Sleep(Timeout.Infinite);
        }

        static void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {

            led.Write(true);
            Thread.Sleep(300);
            led.Write(false);
            IncrementReadPort();

        }

        private static void IncrementReadPort()
        {
            readPortNumber++;
            if (readPortNumber > 5)
                readPortNumber = 0;


            port0.Write((readPortNumber & 1) == 1);
            port1.Write((readPortNumber & 2) == 2);
            port2.Write((readPortNumber & 4) == 4);

            Debug.Print("Read Port = " + readPortNumber.ToString());
            Debug.Print(port0.Read().ToString());

        }


        public static void ReadAndDisplayAnalog()
        {
            using (var analogPort = new AnalogInput(Cpu.AnalogChannel.ANALOG_0))
            {
                while (1 == 1)
                {
                    string readValue = analogPort.Read().ToString();
                    if (readValue.Length > 4) readValue = readValue.Substring(0, 4);
                    Debug.Print(readPortNumber + "    :" + readValue + " : " + analogPort.ReadRaw().ToString());
                    Thread.Sleep(1000);
                }
            }
        }

    }
}
