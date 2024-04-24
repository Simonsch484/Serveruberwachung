using Tinkerforge;

    public class LightSensor
    {
        private IPConnection ipcon;
        private BrickletAmbientLightV3 ambientLight;

        public LightSensor(IPConnection ipcon, string uid)
        {
            this.ipcon = ipcon;
            ambientLight = new BrickletAmbientLightV3(uid, ipcon);
        }

        public double GetLightIntensity()
        {
            long intensity = ambientLight.GetIlluminance();
            Console.WriteLine("Helligkeit: " + intensity/100);
            return intensity/100;
        }
    }