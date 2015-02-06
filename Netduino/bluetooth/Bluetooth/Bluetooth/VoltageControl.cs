using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Bluetooth
{
    class VoltageControl
    {
        public VoltageControl()
        {
            PWM led1 = new PWM(PWMChannels.PWM_ONBOARD_LED, 100, .5, false); // Set later
            PWM led2 = new PWM(PWMChannels.PWM_PIN_D5, 100, .5, false); //50% brightness

            led1.Frequency = 100;
            led1.DutyCycle = 1;

            led1.Start();
            led2.Start();

            while (true)
            {
                double startValue, endValue;

                for (startValue = 4.712; startValue < 10.995; startValue = startValue + 0.05)
                {
                    endValue = System.Math.Sin(startValue) * .5 + .5;
                    led1.DutyCycle = endValue;
                    led2.DutyCycle = endValue;
                    Debug.Print(endValue.ToString());
                    Thread.Sleep(5);
                }
            }
        }

        public void SlowFlash()
        {
            var state = true;
            var led = new OutputPort(Pins.ONBOARD_LED, state);
            while (true)
            {
                state = !state;
                led.Write(state);
                Thread.Sleep(1000);
            }
        }
    }
}
