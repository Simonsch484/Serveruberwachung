using Tinkerforge;

namespace Program;
class ExampleAuthenticate
{
    private static string HOST = "172.20.10.242";
    private static int PORT = 4223;

    static void Main()
    {
        IPConnection ipcon = new IPConnection();
        // //Sensoren
<<<<<<< HEAD
        TemperaturSensor sensor = new(ipcon, "Wcg");
=======
        TemperaturSensor tempSensor = new TemperaturSensor(ipcon, "Wcg");
        LightSensor lightSensor = new LightSensor(ipcon, "Pdw");
        MotionSensor motionSensor = new MotionSensor(ipcon, "ML4");
>>>>>>> b03d0db55e508cdf73f6c469fbb7b250dab4c42c
        // BrickletPiezoSpeakerV2 ps = new("R7M", ipcon);
        // BrickletAmbientLightV3 al = new("",ipcon);
        FeuchtigkeitSensor feucht = new(ipcon, "ViW");
        // BrickletMotionDetectorV2 mo = new("", ipcon);
        // BrickletRGBLEDButton rgbbutton = new("", ipcon);
        // BrickletDualButtonV2 dualb = new("", ipcon);
        // BrickletNFC nfc = new("", ipcon);
        // //Aktoren
        // BrickletPiezoSpeakerV2 piezo = new("", ipcon);
        // BrickletEPaper296x128 epaper = new("", ipcon);
        // BrickletSegmentDisplay4x7V2 segment = new("", ipcon);
        // BrickletLCD128x64 lcd = new("", ipcon);

        
        ipcon.Connect(HOST, PORT);
        Console.WriteLine("connected");

        do {

            //ps.SetBeep(1000, 1, 1000);
<<<<<<< HEAD
            Thread.Sleep(1000);
            double temperature = sensor.GetTemperature();
            Console.WriteLine("Temperature: " + temperature + " °C");
            feucht.GetHumidity();
=======
        Thread.Sleep(1000);
        tempSensor.GetTemperature();
        lightSensor.GetLightIntensity();
        motionSensor.IsMotionDetected();
>>>>>>> b03d0db55e508cdf73f6c469fbb7b250dab4c42c

        } while (!Console.KeyAvailable);
        ipcon.Disconnect();
    }
}
