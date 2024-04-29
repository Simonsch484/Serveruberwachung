using Tinkerforge;

public class Segment
{
    private IPConnection ipcon;
    private BrickletSegmentDisplay4x7V2 segment;

    public Segment(IPConnection ipcon, string uid)
    {
        this.ipcon = ipcon;
        segment = new BrickletSegmentDisplay4x7V2(uid, ipcon);
    }
    public void setText(double temp)
    {
        var tempstring = temp.ToString();
        segment.SetBrightness(7);
        short[] shortArray = new short[tempstring.Length];
        for (int i = 0; i < tempstring.Length; i++)
        {
            shortArray[i] = (short)tempstring[i];
            Console.WriteLine("Segment: " + shortArray[i]);
        }
        segment.SetNumericValue(shortArray);
    }
}