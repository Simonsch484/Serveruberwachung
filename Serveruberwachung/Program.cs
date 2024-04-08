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
        TemperaturSensor sensor = new(ipcon, "Wcg");
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
            Thread.Sleep(1000);
            double temperature = sensor.GetTemperature();
            Console.WriteLine("Temperature: " + temperature + " °C");
            feucht.GetHumidity();

        } while (!Console.KeyAvailable);
        ipcon.Disconnect();
    }
}
