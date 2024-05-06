namespace Program;
using System;
using Tinkerforge;

public class TemperaturSensor
{
    // private IPConnection ipcon;
    private BrickletPTCV2 temp;

    public TemperaturSensor(IPConnection ipcon, string uid)
    {
        temp = new BrickletPTCV2(uid, ipcon);
    }

    public double GetTemperature()
    {
        double temperatur = temp.GetTemperature();
        // Console.WriteLine("Temperatur: " + temperatur/100 + " °C");
        return temperatur/100;
    }
}
