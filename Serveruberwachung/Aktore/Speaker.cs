using Tinkerforge;

    public class Speaker
    {
        private IPConnection ipcon;
        private BrickletPiezoSpeakerV2 piezoSpeaker;

        public Speaker(IPConnection ipcon, string uid)
        {
            this.ipcon = ipcon;
            piezoSpeaker = new BrickletPiezoSpeakerV2(uid, ipcon);
        }

        public void Alarm(byte volume, long duration)
        {
            piezoSpeaker.SetAlarm(800, 2000, 10, 1, volume, duration);;
        }

        public void Beep(byte volume, long duration)
        {
            piezoSpeaker.SetBeep(1000,volume,duration);
        }
    }