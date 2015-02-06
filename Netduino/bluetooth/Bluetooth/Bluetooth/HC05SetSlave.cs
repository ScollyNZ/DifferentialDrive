using System;
using Microsoft.SPOT;
using System.IO.Ports;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Threading;

namespace Bluetooth
{
    /// <summary>
    /// Digital 0 is RXD so connect to TXD on HC-05
    /// Digital 1 is TXD so connect to RXD on HC-05
    /// </summary>
    class HC05SetSlave
    {
        public HC05SetSlave()
        {
            SerialPort serial = new SerialPort(SerialPorts.COM1,
                   38400, Parity.None, 8, StopBits.One);
            serial.Open();
            SendCommand(serial, "at+reset\r\n", "OK");
            SendCommand(serial, "AT+ROLE=0\r\n", "OK"); //ROLE: 0 = slave, 1 = master
            SendCommand(serial, "AT+CMODE=0\r\n", "OK");
            //SendCommand(serial, "AT+UART=9600,0,0", "OK");
            SendCommand(serial, "at+init\r\n", "OK");   //Init: 
            SendCommand(serial, "at+name=BotLeft\r\n", "OK");
            SendCommand(serial, "at+name?\r\n", "OK");

            SendCommand(serial, "at+iac=9e8b33\r\n", "OK");
            SendCommand(serial, "at+class=0\r\n", "OK");
            SendCommand(serial, "at+inqm=1,9,48\r\n", "OK");

            while (true)
            {
                SendCommand(serial, "at+inq\r\n");
                getResponse(serial);
                Thread.Sleep(1000);
            }
        }



        private static void getResponse(SerialPort serial)
        {
            getResponse(serial, string.Empty);
        }

        private static void getResponse(SerialPort serial, string waitForResponse)
        {
            String response = "";
            byte[] buf = new byte[1000];
            int toRead = serial.BytesToRead;
            if (waitForResponse.Length > 0)
            {
                DateTime start = DateTime.Now;
                while (toRead < 1 && (DateTime.Now - start).Seconds < 5)
                {
                    Thread.Sleep(100);
                    toRead = serial.BytesToRead;
                }
            }

            if (toRead > 0)
            {
                Debug.Print("To Read: " + toRead.ToString());
                serial.Read(buf, 0, toRead);
                int read = 0;

                foreach (char byteChar in buf)
                {
                    response += byteChar;
                    if (read++ == toRead) break;
                }
            }
            else
            {
                response = "nothing heard";
            }
            Debug.Print(response);
        }

        private void SendCommand(SerialPort serial, string cmd)
        {
            SendCommand(serial, cmd, string.Empty);
        }

        private void SendCommand(SerialPort serial, string cmd, string waitForResponse)
        {
            foreach (var character in cmd)
            {
                serial.WriteByte((byte)character);
            }

            Debug.Print("Sent '" + cmd + "'");
            Thread.Sleep(500);
            getResponse(serial, waitForResponse);
        }
    }
}

