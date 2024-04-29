using System;
using Tinkerforge;

namespace Program
{
    public class RGBLEDButtonBrickletHandler
    {
        public BrickletRGBLEDButton rgbLEDButton;

        public RGBLEDButtonBrickletHandler(IPConnection ipcon, string uid)
        {
            rgbLEDButton = new BrickletRGBLEDButton(uid, ipcon);
        }

        public bool GetButtonState()
        {
            bool buttonPressed = Convert.ToBoolean(rgbLEDButton.GetButtonState());
            //Console.WriteLine($"Taste gedrückt: {buttonPressed}");
            return buttonPressed;
        }

        public void SetRGBLEDColor(byte red, byte green, byte blue)
        {
            rgbLEDButton.SetColor(red, green, blue);
            //Console.WriteLine($"RGB-LED-Farbe gesetzt: Rot: {red}, Grün: {green}, Blau: {blue}");
        }
    }
}
