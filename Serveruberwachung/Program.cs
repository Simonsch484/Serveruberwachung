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
<<<<<<< HEAD
=======
            LCDDisplayBrickletHandler lcdDisplay = new LCDDisplayBrickletHandler(ipcon, "24Rh");
            // BrickletPiezoSpeakerV2 ps = new("R7M", ipcon);
>>>>>>> dc6c958224d36905496c03e78db413a78310e3e0
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

<<<<<<< HEAD
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
=======
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
            
            
>>>>>>> dc6c958224d36905496c03e78db413a78310e3e0

        } while (!Console.KeyAvailable);

            ipcon.Disconnect();
            Console.WriteLine("Verbindung getrennt");
        }
    }
}
