using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Bluetooth
{
    class LedBrightness
    {
        PWM led1, led2;
        public LedBrightness()
        {
            led1 = new PWM(PWMChannels.PWM_ONBOARD_LED, 100, .5, false); // Set later
            led2 = new PWM(PWMChannels.PWM_PIN_D5, 100, .5, false); //50% brightness

            led1.Frequency = 100;
            led1.DutyCycle = 1;

            led1.Start();
            led2.Start();
        }

        internal int brightnessPercent
        {
            set
            {
                var brightness = value * .01;
                led1.DutyCycle = brightness;
                led2.DutyCycle = brightness;
                Debug.Print("Set Brightness:" + brightness.ToString());
            }
        }
    }
}

