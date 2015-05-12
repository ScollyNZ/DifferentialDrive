using System;
using System.Text;
using nz.co.scoltock.beehivemonitor.configuration;

namespace nz.co.scoltock.beehivemonitor.tests
{
    class ConfigurationTests
    {
        string testConfigString = @"L3317-001
7, 7, 0, 0,0
105, 7, 0, 1,0
207, 7, 0, 2,0
7, 100,2,3,0
105, 100,2,4,0
210, 100,2,5,0";

        Monitor testConfig;

        public ConfigurationTests()
        {
            testConfig = new Monitor(testConfigString);

            ConfigHasTitle();
            ConfigReadCorrectNumberOfSensors();
            FirstSensorHasCorrectValues();
            LastSensorHasCorrectValues();
        }

        private void LastSensorHasCorrectValues()
        {
            throw new NotImplementedException();
        }

        private void FirstSensorHasCorrectValues()
        {
            throw new NotImplementedException();
        }

        private void ConfigReadCorrectNumberOfSensors()
        {
            if (testConfig.Sensors.Count != 6)
                throw new ApplicationException("CorrectNumberOfSensors fails");
        }

        private void ConfigHasTitle()
        {
            if (testConfig.HiveName != "L3317-001")
                throw new ApplicationException("ConfigHasTitle fails");
        }
    }
}
