namespace RayTracer;

public static class ColorUtils
{
    // public static void WriteColor(TextWriter writer, Vec3 pixelColor)
    public static string WriteColor(Vec3 pixelColor)
    {
        // Translate the [0,1] color values to the byte range [0,255]
        var rByte = (int)(255.999 * pixelColor.X);
        var gByte = (int)(255.999 * pixelColor.Y);
        var bByte = (int)(255.999 * pixelColor.Z);
        
        // writer.Write($"{rByte} {gByte} {bByte}");
        return $"{rByte} {gByte} {bByte}";
    }
}