namespace RayTracer;

public partial class RayForm : Form
{
    public RayForm()
    {
        InitializeComponent();

        // Generate image

        var imageWidth = 256;
        var imageHeight = 256;

        List<string> lines =
        [
            "P3",
            $"{imageWidth} {imageHeight}",
            "255"
        ];

        for (var j = 0; j < imageHeight; j++)
        for (var i = 0; i < imageWidth; i++)
        {
            var r = (double)i / (imageWidth - 1);
            var g = (double)j / (imageHeight - 1);
            var b = 0.0;

            var pixelColor = new Vec3(r, g, b);

            lines.Add(ColorUtils.WriteColor(pixelColor));
        }

        var docPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        using var outputFile = new StreamWriter(Path.Combine(docPath, "img.txt"));
        foreach (var line in lines) outputFile.WriteLine(line);
    }
}