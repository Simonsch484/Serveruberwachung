namespace Program;
using System;
using System.Text;
using Tinkerforge;

public class NFC
{
    // private IPConnection ipcon;
    public BrickletNFC nfc;

    public NFC(IPConnection ipcon, string uid)
    {
        nfc = new BrickletNFC(uid, ipcon);
    }

    public void ReaderStateChangedCB(BrickletNFC sender, byte state, bool idle)
    {
        if (state == BrickletNFC.READER_STATE_REQUEST_TAG_ID_READY)
        {
            byte tagType;
            StringBuilder tagIDBuilder = new();
            string expectedTagIDHexString = "0xEA 0x8E 0x36 0x9E";
            byte[] tagID;
            String tagInfo;

            sender.ReaderGetTagID(out tagType, out tagID);

            foreach (byte b in tagID)
            {
                tagIDBuilder.AppendFormat("0x{0:X2} ", b);
            }
            string tagIDHexString = tagIDBuilder.ToString().Trim();


            if (tagIDHexString == expectedTagIDHexString)
                Console.WriteLine("ID IS CORRECT");
            else
                Console.WriteLine("ID DOES NOT MATCH");


            tagInfo = String.Format("Found tag of type {0} with ID [{1}]", tagType, tagIDHexString);
            Console.WriteLine(tagInfo);
        }

        if (idle)
        {
            sender.ReaderRequestTagID();
        }
    }
}
