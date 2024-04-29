using Tinkerforge;

namespace Program
{
    public class EPaperDisplay
    {
        private IPConnection ipcon;
        private BrickletEPaper296x128 epaper;

        public EPaperDisplay(IPConnection ipcon, string uid)
        {
            this.ipcon = ipcon;
            epaper = new BrickletEPaper296x128(uid, ipcon);
        }

        public void DisplayText(string text, int color)
        {
            epaper.DrawText(50, 50, BrickletEPaper296x128.FONT_18X32, (byte)color, BrickletEPaper296x128.ORIENTATION_HORIZONTAL, text);
            epaper.Draw();
        }

        public void DisplayTemperature(double temperature)
        {
            string displayText;
            int color;

            if (temperature > 30)
            {
                displayText = "warm";
                color = BrickletEPaper296x128.COLOR_RED; 
            }
            else
            {
                displayText = "normal";
                color = BrickletEPaper296x128.COLOR_BLACK;
            }

            
            DisplayText(displayText, color);
        }
    }
}
