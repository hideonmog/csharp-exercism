using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        if (reading <= -2_147_483_649L)
        {
            return ToByteArray(reading, 8, 256 - 8);
        }
        else if (reading <= -32_769L)
        {
            return ToByteArray(reading, 4, 256 - 4);
        }
        else if (reading <= -1)
        {
            return ToByteArray(reading, 2, 256 - 2);
        }
        else if (reading <= 65_535)
        {
            return ToByteArray(reading, 2, 2);
        }
        else if (reading <= 2_147_483_647L)
        {
            return ToByteArray(reading, 4, 256 - 4);
        }
        else if (reading <= 4_294_967_295L)
        {
            return ToByteArray(reading, 4, 4);
        }
        else
        {
            return ToByteArray(reading, 8, 256 - 8);
        }
        
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte header = buffer[0];
        
        if (header == 256 - 8)
        {
            return BitConverter.ToInt64(buffer, 1);
        }
        else if (header == 256 - 4)
        {
            return BitConverter.ToInt32(buffer, 1);
        }
        else if (header == 256 - 2)
        {
            return BitConverter.ToInt16(buffer, 1);
        }
        else if (header == 2)
        {
            return BitConverter.ToUInt16(buffer, 1);
        }
        else if (header == 4)
        {
            return BitConverter.ToUInt32(buffer, 1);
        }
        else
        {
            return 0;
        }
    }

    public static byte[] ToByteArray(long number, int numOfBytes, byte header)
    {
        byte[] payloadBytes = BitConverter.GetBytes(number);
        byte[] ans = new byte[9];
        ans[0] = header;

        for (int i = 0; i < numOfBytes; i++)
        {
            ans[i + 1] = payloadBytes[i];
        }

        return ans;
    }
}
