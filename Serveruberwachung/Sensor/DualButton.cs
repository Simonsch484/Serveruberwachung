using System;
using Tinkerforge;

namespace Program
{
    public class DualButtonBrickletHandler
    {
        public BrickletDualButtonV2 dualButton;

        public event EventHandler<ButtonStateChangedEventArgs> ButtonStateChanged;

        public DualButtonBrickletHandler(IPConnection ipcon, string uid)
        {
            dualButton = new BrickletDualButtonV2(uid, ipcon);
            // dualButton.StateChangedCallback += OnButtonStateChanged;
            // dualButton.SetStateChangedCallbackConfiguration(true);

            ButtonStateChanged = delegate { };
        }

        public void OnButtonStateChanged(BrickletDualButtonV2 sender, byte buttonL, byte buttonR, byte ledL, byte ledR)
        {
            // Überprüfen ob button gedruckt ist
            bool buttonLeft = (buttonL == 1); 
            bool buttonRight = (buttonR == 1);
            ButtonStateChanged?.Invoke(this, new ButtonStateChangedEventArgs(buttonLeft, buttonRight));
             Console.WriteLine($"Linke Taste: {(buttonLeft ? "Losgelassen" : "Gedrückt")}, Rechte Taste: {(buttonRight ? "Losgelassen" : "Gedrückt")}");
        }

        public void GetLEDState()
        {
            // 1 = Led aus | 0 LED an
            byte ledL, ledR;
            dualButton.GetLEDState(out ledL, out ledR);
            Console.WriteLine($"LED Zustand - Linke Taste: {ledL}, Rechte Taste: {ledR}");
        }
    }

    public class ButtonStateChangedEventArgs : EventArgs
    {
        public bool ButtonLeft { get; }
        public bool ButtonRight { get; }

        public ButtonStateChangedEventArgs(bool buttonLeft, bool buttonRight)
        {
            ButtonLeft = buttonLeft;
            ButtonRight = buttonRight;
        }
    }
}
