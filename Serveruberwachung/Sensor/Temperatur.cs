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
        int temperature = ptc.GetTemperature();
        return temperature / 100.0; // Convert temperature to degrees Celsius
    }
}
