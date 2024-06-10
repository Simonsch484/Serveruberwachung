using Tinkerforge;

public class Segment
{
    private IPConnection ipcon;
    private BrickletSegmentDisplay4x7V2 segment;
    private string time;
    public Segment(IPConnection ipcon, string uid)
    {
        this.ipcon = ipcon;
        segment = new BrickletSegmentDisplay4x7V2(uid, ipcon);
        var text = DateTime.Now.ToString("HHmm");
    }
    public void setText(string text)
    {
        //TEMPERATUR
        //var tempstring = temp.ToString();
        //for (int i = 0; i < tempstring.Length; i++)
        //{
        //    shortArray[i] = (short)tempstring[i];
        //    Console.WriteLine("Segment: " + shortArray[i]);
        //}
        //segment.SetNumericValue(shortArray);

        //TIME
        if (time == text) return;
        Console.WriteLine(text);
        short[] shortArray = new short[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            shortArray[i] = (short)text[i];
        }
        segment.SetSelectedSegment(32, true);
        segment.SetSelectedSegment(33, true);
        segment.SetNumericValue(shortArray);
        time = text;
    }
}