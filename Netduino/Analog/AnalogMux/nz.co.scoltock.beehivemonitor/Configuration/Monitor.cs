using System;
using Microsoft.SPOT;
using System.Collections;

namespace nz.co.scoltock.beehivemonitor.configuration
{
    public class Monitor
    {
        public Monitor(string configurationString)
        {
            Sensors = new Hashtable();
            DeserialiseStringConfig(configurationString);
        }

        private void DeserialiseStringConfig(string configurationString)
        {
            var lines = configurationString.Split("\r\n".ToCharArray());
            HiveName = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i] != string.Empty)
                {
                    var values = lines[i].Split(',');
                    var x = new Sensor();
                    x.CoordX = byte.Parse(values[0]);
                    x.CoordY = byte.Parse(values[1]);
                    x.AddressInput = byte.Parse(values[2]);
                    x.AddressPosition = byte.Parse(values[3]);
                    x.bias = int.Parse(values[4]);
                    Sensors.Add(x.GetHashCode(), x);
                }
            }

        }

        public string HiveName { get; set; }
        public Hashtable Sensors { get; private set; }
    }
}
