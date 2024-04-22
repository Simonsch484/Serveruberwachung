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

        public void GetButtonState()
        {
            bool buttonPressed = Convert.ToBoolean(rgbLEDButton.GetButtonState());
            Console.WriteLine($"Taste gedrückt: {buttonPressed}");
        }

        public void SetRGBLEDColor(byte red, byte green, byte blue)
        {
            rgbLEDButton.SetColor(red, green, blue);
            Console.WriteLine($"RGB-LED-Farbe gesetzt: Rot: {red}, Grün: {green}, Blau: {blue}");
        }
    }
}
