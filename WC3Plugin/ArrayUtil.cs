namespace WC3Plugin;

internal static class ArrayUtil
{
    public static bool IsEmpty(this ReadOnlySpan<byte> data)
    {
        foreach (byte b in data)
        {
            if (b is not (0 or 0xFF))
                return false;
        }
        return true;
    }
    public static bool IsEmpty(this byte[] data)
    {
        return IsEmpty(data.AsSpan());
    }
}
