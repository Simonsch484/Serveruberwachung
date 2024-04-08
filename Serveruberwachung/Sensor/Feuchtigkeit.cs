namespace Program;
using System;
using Tinkerforge;

public class FeuchtigkeitSensor
{
    private BrickletHumidityV2 hum;

    public FeuchtigkeitSensor(IPConnection ipcon, string uid)
    {
        hum = new BrickletHumidityV2(uid, ipcon);
    }

    public double GetHumidity()
    {
        short humidity = hum.GetChipTemperature();
        Console.WriteLine("Feuchtigkeit:"+ humidity);
        return humidity; 
    }
}
