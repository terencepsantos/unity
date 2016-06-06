using UnityEngine;

public static class HexToRGB
{
    public static Color32 ToColor(int HexVal)
    {
        byte R = (byte)((HexVal >> 16) & 0xFF);
        byte G = (byte)((HexVal >> 8) & 0xFF);
        byte B = (byte)((HexVal) & 0xFF);

        return new Color32(R, G, B, 255);
    }
}
