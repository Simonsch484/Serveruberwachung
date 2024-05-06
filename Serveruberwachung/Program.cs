using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using Microsoft.VisualBasic;
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
            NFC nfc = new(ipcon, "22ND");
            EPaperDisplay ePaperDisplay = new EPaperDisplay(ipcon, "XGL");
            Segment segment = new(ipcon, "Tre");
            // BrickletLCD128x64 lcd = new("", ipcon);

            bool alarmActive = false;

            ipcon.Connect(HOST, PORT);
            Console.WriteLine("Verbunden");

            buttonHandler.dualButton.StateChangedCallback += buttonHandler.OnButtonStateChanged;
            buttonHandler.dualButton.SetStateChangedCallbackConfiguration(true);
            nfc.nfc.ReaderStateChangedCallback += nfc.ReaderStateChangedCB;
            nfc.nfc.SetMode(BrickletNFC.MODE_READER);

            do {

            Thread.Sleep(1000);

            //Temperatur

            //button switch
            if(rgbLEDButton.GetButtonState() && !alarmActive){
                alarmActive = true;
                rgbLEDButton.SetRGBLEDColor(255,0,0);
                
            }
            else if(rgbLEDButton.GetButtonState() && alarmActive){
                alarmActive = false;
                rgbLEDButton.SetRGBLEDColor(0,255,0);
            }

            if(tempSensor.GetTemperature() > 30 && alarmActive ){
                if(!nfc.NfcAuth()){
                    speaker.Beep(3 , 1000);
                    lcdDisplay.DisplayText(6,"   !-- Overheat --!");
                }
                
                Thread.Sleep(2000);
            }

        
            
            // segment.setText(tempSensor.GetTemperature());
            

            //lcd-Bildschirm Stats

            lcdDisplay.ClearText();
            var temp = tempSensor.GetTemperature();
            var light = lightSensor.GetLightIntensity();
            var motion = motionSensor.IsMotionDetected();
            var feuchtigkeit =feucht.GetHumidity();
            var now = new DateTime();
            lcdDisplay.DisplayText(0,"temp: " + temp.ToString().Replace(",", ".") + " °C");
            lcdDisplay.DisplayText(1,"Light: " + light.ToString().Replace(",", "."));
            lcdDisplay.DisplayText(2,"Motion detected: " + motion.ToString().Replace(",", "."));
            lcdDisplay.DisplayText(3,"Humidity: " + feuchtigkeit.ToString().Replace(",", ".") + "%");
            lcdDisplay.DisplayText(7,now.TimeOfDay.ToString());


        } while (!Console.KeyAvailable);

            ipcon.Disconnect();
            Console.WriteLine("Verbindung getrennt");
        }
    }
}
