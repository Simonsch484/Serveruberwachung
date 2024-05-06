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
        static int nfcCounter = 0;
        static bool alarmActive = false;
        static async void Main()
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
            

            ipcon.Connect(HOST, PORT);
            Console.WriteLine("Verbunden");

            buttonHandler.dualButton.StateChangedCallback += buttonHandler.OnButtonStateChanged;
            buttonHandler.dualButton.SetStateChangedCallbackConfiguration(true);
            nfc.nfc.ReaderStateChangedCallback += nfc.ReaderStateChangedCB;
            nfc.nfc.SetMode(BrickletNFC.MODE_READER);

            do {

                await Task.Delay(1000);
                var temp = tempSensor.GetTemperature();
                var light = lightSensor.GetLightIntensity();
                var motion = motionSensor.IsMotionDetected();
                var feuchtigkeit = feucht.GetHumidity();
                //nach 15 Malen wird zurückgesetzt
                NFCCounter(nfc, 15);

                //Alarm switch
                if (!rgbLEDButton.GetButtonState() && !alarmActive){
                alarmActive = true;
                rgbLEDButton.SetRGBLEDColor(255,0,0);
                
                }
                else if(!rgbLEDButton.GetButtonState() && alarmActive){
                    alarmActive = false;
                    rgbLEDButton.SetRGBLEDColor(0,255,0);
                }
                else if(nfc.NfcAuth() && alarmActive){
                    alarmActive = false;
                    rgbLEDButton.SetRGBLEDColor(0,0,255);
                }

                await CheckTemp(temp,nfc,speaker,lcdDisplay);

                //segment.setText(temp);


                //lcd-Bildschirm Stats
                if (light > 500)
                    await ShowLCDDisplay(temp, light, motion, feuchtigkeit, lcdDisplay);


            } while (!Console.KeyAvailable);

            ipcon.Disconnect();
            Console.WriteLine("Verbindung getrennt");
        }
        static async Task ShowLCDDisplay(double temp, double light, bool motion, double feuchtigkeit, LCDDisplayBrickletHandler lcdDisplay)
        {

                lcdDisplay.ClearText();
                lcdDisplay.DisplayText(0, $"Temp: {temp:F2} °C");
                lcdDisplay.DisplayText(1, $"Light: {light:F2}");
                lcdDisplay.DisplayText(2, $"Motion detected: {motion}");
                lcdDisplay.DisplayText(3, $"Humidity: {feuchtigkeit:F2} %");
        }
        static async Task CheckTemp(double temp, NFC nfc, Speaker speaker, LCDDisplayBrickletHandler lcdDisplay)
        {
            if (temp > 27 && alarmActive)
            {
                System.Console.WriteLine(nfc.NfcAuth());
                if (!nfc.NfcAuth())
                {
                    speaker.Beep(3, 1000);
                    lcdDisplay.DisplayText(6, "   !-- Overheat --!");
                }

                await Task.Delay(2000);
            }
        }
        static void NFCCounter(NFC nfc, int counter)
        {
            if (nfc.NfcAuth())
            {
                if (nfcCounter >= counter)
                {
                    nfc.tagIDHexString = "";
                    nfcCounter = 0;
                }
                else
                    nfcCounter++;
            }
            else
                nfcCounter = 0;
        }
    }
}
