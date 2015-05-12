using System;
using Microsoft.SPOT;

namespace nz.co.scoltock.beehivemonitor.configuration
{
    public class Sensor
    {
        public byte CoordX{get;set;}
        public byte CoordY { get; set; }
        public byte AddressInput { get; set; }      //Which analog input or which mux
        public byte AddressPosition { get; set; }   //Which address on mux
        public int bias { get; set; }      //Calibration adjustment
        public override int GetHashCode()
        {
            return (CoordX * 256) + CoordY;
        }
    }
}
