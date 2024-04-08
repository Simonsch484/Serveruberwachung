using System;
    using Tinkerforge;

    public class MotionSensor
    {
        private IPConnection ipcon;
        private BrickletMotionDetectorV2 motionDetector;

        public MotionSensor(IPConnection ipcon, string uid)
        {
            this.ipcon = ipcon;
            motionDetector = new BrickletMotionDetectorV2(uid, ipcon);
        }

        public bool IsMotionDetected()
        {
            bool motion = Convert.ToBoolean(motionDetector.GetMotionDetected());
            Console.WriteLine("Motion: " + motion);
            return motion;
        }
    }