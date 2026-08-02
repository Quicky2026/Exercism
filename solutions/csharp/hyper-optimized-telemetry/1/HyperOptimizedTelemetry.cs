public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
    
        int payloadBytes;
        bool isSigned;
    
        // 1. UNSIGNED 2 bytes first
        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            payloadBytes = 2;
            isSigned = false;
            ushort v = (ushort)reading;
            byte[] p = BitConverter.GetBytes(v);
            buffer[1] = p[0];
            buffer[2] = p[1];
        }
        // 2. SIGNED 2 bytes second
        else if (reading >= short.MinValue && reading <= short.MaxValue)
        {
            payloadBytes = 2;
            isSigned = true;
            short v = (short)reading;
            byte[] p = BitConverter.GetBytes(v);
            buffer[1] = p[0];
            buffer[2] = p[1];
        }
        // 3. SIGNED 4 bytes
        else if (reading >= int.MinValue && reading <= int.MaxValue)
        {
            payloadBytes = 4;
            isSigned = true;
            int v = (int)reading;
            byte[] p = BitConverter.GetBytes(v);
            Array.Copy(p, 0, buffer, 1, 4);
        }
        // 4. UNSIGNED 4 bytes
        else if (reading >= 0 && reading <= uint.MaxValue)
        {
            payloadBytes = 4;
            isSigned = false;
            uint v = (uint)reading;
            byte[] p = BitConverter.GetBytes(v);
            Array.Copy(p, 0, buffer, 1, 4);
        }
        // 5. SIGNED 8 bytes
        else
        {
            payloadBytes = 8;
            isSigned = true;
            long v = reading;
            byte[] p = BitConverter.GetBytes(v);
            Array.Copy(p, 0, buffer, 1, 8);
        }
    
        buffer[0] = isSigned
            ? (byte)(256 - payloadBytes)
            : (byte)payloadBytes;
    
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];
    
        int payloadBytes;
        bool isSigned;
    
        if (prefix <= 8)
        {
            payloadBytes = prefix;
            isSigned = false;
        }
        else
        {
            payloadBytes = 256 - prefix;
            isSigned = true;
        }

        // FIX: impossible payload sizes → return 0
        if (payloadBytes > 8 || payloadBytes < 0)
            return 0;
    
        // FIX: prefix 0 → no payload → return 0
        if (payloadBytes == 0)
            return 0;
    
        byte[] payload = new byte[payloadBytes];
        Array.Copy(buffer, 1, payload, 0, payloadBytes);
    
        if (payloadBytes == 2 && !isSigned)
            return BitConverter.ToUInt16(payload, 0);
    
        if (payloadBytes == 2 && isSigned)
            return BitConverter.ToInt16(payload, 0);
    
        if (payloadBytes == 4 && !isSigned)
            return BitConverter.ToUInt32(payload, 0);
    
        if (payloadBytes == 4 && isSigned)
            return BitConverter.ToInt32(payload, 0);
    
        return BitConverter.ToInt64(payload, 0);
    }

}
