using System;
using Tinkerforge;

namespace Program
{
    public class LCDDisplayBrickletHandler
    {
        private BrickletLCD128x64 lcd;

        public LCDDisplayBrickletHandler(IPConnection ipcon, string uid)
        {
            lcd = new BrickletLCD128x64(uid, ipcon);
        }

        public void DisplayText(byte lines, string text)
        {
            lcd.WriteLine(lines, 0, text);
            Console.WriteLine($"Text auf dem LCD-Display angezeigt: {text}");
        }
    }
}
