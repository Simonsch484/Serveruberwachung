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
            FeuchtigkeitSensor feucht = new FeuchtigkeitSensor(ipcon, "ViW");

            // //Aktoren
            Speaker speaker = new Speaker(ipcon,"R7M");
            // BrickletEPaper296x128 epaper = new("", ipcon);
            NFC nfc = new(ipcon, "22ND");
            Segment segment = new(ipcon, "Tre");
            // BrickletLCD128x64 lcd = new("", ipcon);

            ipcon.Connect(HOST, PORT);
            Console.WriteLine("Verbunden");

            buttonHandler.dualButton.StateChangedCallback += buttonHandler.OnButtonStateChanged;
            buttonHandler.dualButton.SetStateChangedCallbackConfiguration(true);
            nfc.nfc.ReaderStateChangedCallback += nfc.ReaderStateChangedCB;
            nfc.nfc.SetMode(BrickletNFC.MODE_READER);

            do {

            Thread.Sleep(1000);
            if(rgbLEDButton.GetButtonState()){
                rgbLEDButton.SetRGBLEDColor(255,0,0);
            }
            else{
                rgbLEDButton.SetRGBLEDColor(0,255,0);
            }
            segment.setText(tempSensor.GetTemperature());
                /*
                #region lcdDisplay
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
                #endregion
                */
            } while (!Console.KeyAvailable);

            ipcon.Disconnect();
            Console.WriteLine("Verbindung getrennt");
        }
    }
}
