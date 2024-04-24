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
            // BrickletAmbientLightV3 al = new("",ipcon);
            FeuchtigkeitSensor feucht = new FeuchtigkeitSensor(ipcon, "ViW");
            // BrickletDualButtonV2 dualb = new("", ipcon);
            // BrickletNFC nfc = new("", ipcon);

            // //Aktoren
            Speaker speaker = new Speaker(ipcon,"R7M");
            // BrickletEPaper296x128 epaper = new("", ipcon);
            Segment segment = new(ipcon, "Tre");
            // BrickletLCD128x64 lcd = new("", ipcon);

            ipcon.Connect(HOST, PORT);
            Console.WriteLine("Verbunden");

            buttonHandler.dualButton.StateChangedCallback += buttonHandler.OnButtonStateChanged;
            buttonHandler.dualButton.SetStateChangedCallbackConfiguration(true);

        do {

            Thread.Sleep(5000);

            // if(rgbLEDButton.GetButtonState()){
            //     rgbLEDButton.SetRGBLEDColor(255,0,0);
            // }
            // else{
            //     rgbLEDButton.SetRGBLEDColor(0,255,0);
            // }
            
            // segment.setText(tempSensor.GetTemperature());
            
            lcdDisplay.ClearText();
            var temp = tempSensor.GetTemperature();
            lcdDisplay.DisplayText(0,"Temp: " + temp + " øC");
            var light = lightSensor.GetLightIntensity();
            lcdDisplay.DisplayText(1,"Light: " + light);
            var motion = motionSensor.IsMotionDetected();
            lcdDisplay.DisplayText(2,"Motion: " + motion);
            var feuchtigkeit =feucht.GetHumidity();
            lcdDisplay.DisplayText(3,"Humidity: " + feuchtigkeit + "%");
            DateTime currentTime = DateTime.Now;
            lcdDisplay.DisplayText(7,"Time: " + currentTime.ToString("HH:mm:ss"));


        } while (!Console.KeyAvailable);

            ipcon.Disconnect();
            Console.WriteLine("Verbindung getrennt");
        }
    }
}
