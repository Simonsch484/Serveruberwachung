namespace Program;
using System;
using Tinkerforge;

public class TemperaturSensor
{
    private IPConnection ipcon;
    private BrickletPTCV2 ptc;

    public TemperaturSensor(string host, int port, string uid)
    {
        ipcon = new IPConnection(); // Create IP connection
        ptc = new BrickletPTCV2(uid, ipcon); // Create device object

        ipcon.Connect(host, port); // Connect to brickd
        // Don't use device before ipcon is connected
    }

    public double GetTemperature()
    {
        int temperature = ptc.GetTemperature();
        return temperature / 100.0; // Convert temperature to degrees Celsius
    }

    public void Disconnect()
    {
        ipcon.Disconnect();
    }
}
