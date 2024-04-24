using System.Diagnostics.CodeAnalysis;
using Tinkerforge;

namespace Program
{
    class ExampleAuthenticate
    {
        private static string HOST = "172.20.10.242";
        private static int PORT = 4223;

        static void Main()
        {
            IPConnection ipcon = new IPConnection();
            // //Sensoren
            TemperaturSensor tempSensor = new TemperaturSensor(ipcon, "Wcg");
            LightSensor lightSensor = new LightSensor(ipcon, "Pdw");
            MotionSensor motionSensor = new MotionSensor(ipcon, "ML4");
            DualButtonBrickletHandler buttonHandler = new DualButtonBrickletHandler(ipcon, "Vd8");
            RGBLEDButtonBrickletHandler rgbLEDButton = new RGBLEDButtonBrickletHandler(ipcon, "23Qx");
            LCDDisplayBrickletHandler lcdDisplay = new LCDDisplayBrickletHandler(ipcon, "24Rh");
            // BrickletPiezoSpeakerV2 ps = new("R7M", ipcon);
            // BrickletAmbientLightV3 al = new("",ipcon);
            FeuchtigkeitSensor feucht = new FeuchtigkeitSensor(ipcon, "ViW");
            // BrickletMotionDetectorV2 mo = new("", ipcon);
            // BrickletRGBLEDButton rgbbutton = new("", ipcon);
            // BrickletDualButtonV2 dualb = new("", ipcon);
            // BrickletNFC nfc = new("", ipcon);
            // //Aktoren
            Speaker speaker = new Speaker(ipcon,"R7M");
            // BrickletPiezoSpeakerV2 piezo = new("", ipcon);
            // BrickletEPaper296x128 epaper = new("", ipcon);
            // BrickletSegmentDisplay4x7V2 segment = new("", ipcon);
            // BrickletLCD128x64 lcd = new("", ipcon);

            ipcon.Connect(HOST, PORT);
            Console.WriteLine("Verbdunden");

            buttonHandler.dualButton.StateChangedCallback += buttonHandler.OnButtonStateChanged;
            buttonHandler.dualButton.SetStateChangedCallbackConfiguration(true);

            // EventHandler hinzufügen
            // #pragma warning disable CS8622
            // buttonHandler.ButtonStateChanged += OnButtonStateChanged;
            // #pragma warning restore CS8622

            Console.WriteLine("connected");

        do {

            Thread.Sleep(5000);
            
            lcdDisplay.ClearText();
            var temp = tempSensor.GetTemperature();
            lcdDisplay.DisplayText(0,"temp: " + temp.ToString().Replace(",", ".") + " °C");
            var light = lightSensor.GetLightIntensity();
            lcdDisplay.DisplayText(1,"Light: " + light.ToString().Replace(",", "."));
            var motion = motionSensor.IsMotionDetected();
            lcdDisplay.DisplayText(2,"Motion detected: " + motion.ToString().Replace(",", "."));
            var feuchtigkeit =feucht.GetHumidity();
            lcdDisplay.DisplayText(3,"Humidity: " + feuchtigkeit.ToString().Replace(",", ".") + "%");
            var now = new DateTime();
            lcdDisplay.DisplayText(7,now.TimeOfDay.ToString());

            // buttonHandler.GetLEDState();
            // if(rgbLEDButton.GetButtonState() == true){
            //     rgbLEDButton.SetRGBLEDColor(255,0,0);
            // }
            // else{
            //     rgbLEDButton.SetRGBLEDColor(0,255,0);
            // }
            
            

        } while (!Console.KeyAvailable);

            ipcon.Disconnect();
            Console.WriteLine("Verbindung getrennt");
        }
    }
}
