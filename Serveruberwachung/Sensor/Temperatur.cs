namespace Program;
using System;
using Tinkerforge;

public class TemperaturSensor
{
    // private IPConnection ipcon;
    private BrickletPTCV2 ptc;

    public TemperaturSensor(IPConnection ipcon, string uid)
    {
        ptc = new BrickletPTCV2(uid, ipcon);
    }

    public double GetTemperature()
    {
        double temperatur = ptc.GetTemperature();
        Console.WriteLine("Temperatur: " + temperatur/100 + " °C");
        return temperatur/100;
    }
}
