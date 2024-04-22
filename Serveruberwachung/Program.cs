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
            // BrickletAmbientLightV3 al = new("",ipcon);
            FeuchtigkeitSensor feucht = new FeuchtigkeitSensor(ipcon, "ViW");
            // BrickletRGBLEDButton rgbbutton = new("", ipcon);
            // BrickletDualButtonV2 dualb = new("", ipcon);
            // BrickletNFC nfc = new("", ipcon);
            // //Aktoren
            Speaker speaker = new Speaker(ipcon,"R7M");
            // BrickletPiezoSpeakerV2 piezo = new("", ipcon);
            // BrickletEPaper296x128 epaper = new("", ipcon);
            Segment segment = new(ipcon, "Tre");
            // BrickletLCD128x64 lcd = new("", ipcon);

            ipcon.Connect(HOST, PORT);
            Console.WriteLine("Verbunden");

            buttonHandler.dualButton.StateChangedCallback += buttonHandler.OnButtonStateChanged;
            buttonHandler.dualButton.SetStateChangedCallbackConfiguration(true);


            Console.WriteLine("connected");

        do {

            Thread.Sleep(500);
            // buttonHandler.GetLEDState();
            if(rgbLEDButton.GetButtonState()){
                rgbLEDButton.SetRGBLEDColor(255,0,0);
            }
            else{
                rgbLEDButton.SetRGBLEDColor(0,255,0);
            }
            
                segment.setText(tempSensor.GetTemperature());
            // tempSensor.GetTemperature();
            // lightSensor.GetLightIntensity();
            // motionSensor.IsMotionDetected();
            // feucht.GetHumidity();

        } while (!Console.KeyAvailable);

            ipcon.Disconnect();
            Console.WriteLine("Verbindung getrennt");
        }
    }
}
