using System.Drawing;
using XerShade.Libraries.Images.Splitting.EventArgs;
using XerShade.Libraries.Images.Splitting.Interfaces;

namespace XerShade.Libraries.Images.Splitting;

public class ImageSplitter : IImageSplitter
{
    private static int CalculateIndex(int columns, int rows, int y, int x, bool invert) => !invert ? CalculateXYIndex(columns, y, x) : CalculateYXIndex(rows, y, x);
    private static int CalculateYXIndex(int rows, int y, int x) => (x * rows) + y;
    private static int CalculateXYIndex(int columns, int y, int x) => (y * columns) + x;

    public event EventHandler<OnSpliceImageEventArgs>? OnSpliceImage;

    public string SourcePath { get; protected set; }
    public string OutputPath { get; protected set; }

    public ImageSplitter(string sourcePath, string outputPath)
    {
        this.SourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        this.OutputPath = outputPath ?? throw new ArgumentNullException(nameof(outputPath));
    }

    public void Split(int rows, int columns, string outputFormat = "", bool invertLoops = false)
    {
        if (string.IsNullOrWhiteSpace(this.SourcePath)) { throw new NullReferenceException(nameof(this.SourcePath)); }
        if (string.IsNullOrWhiteSpace(this.OutputPath)) { throw new NullReferenceException(nameof(this.OutputPath)); }

        if (!File.Exists(this.SourcePath)) { throw new FileNotFoundException($"Source image not found at '{this.SourcePath}'.", this.SourcePath); }
        if (!Directory.Exists(this.OutputPath)) { _ = Directory.CreateDirectory(this.OutputPath); }

        if (string.IsNullOrWhiteSpace(outputFormat))
        {
            string fileName = Path.GetFileNameWithoutExtension(this.SourcePath);
            string fileExtension = Path.GetExtension(this.SourcePath);
            outputFormat = string.Format("{1}-{0}{2}", "{0}", fileName, fileExtension);
        }

        try
        {
            using Image source = Image.FromFile(this.SourcePath);

            int spliceWidth = (int)Math.Floor(source.Width / (float)columns);
            int spliceHeight = (int)Math.Floor(source.Height / (float)rows);
            Rectangle destRect = new(0, 0, spliceWidth, spliceHeight);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    int index = CalculateIndex(columns, rows, y, x, invertLoops);
                    this.SpliceImage(index, outputFormat, source, spliceWidth, spliceHeight, destRect, y, x);
                }
            }

            source.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(string.Format("An exception has occured while trying to process: {0}{1}{2}", this.SourcePath, Environment.NewLine, e.Message));
        }        
    }

    private void SpliceImage(int index, string outputFormat, Image source, int spliceWidth, int spliceHeight, Rectangle destRect, int y, int x)
    {
        Rectangle srcRect = new(x * spliceWidth, y * spliceHeight, spliceWidth, spliceHeight);
        OnSpliceImage?.Invoke(this, new OnSpliceImageEventArgs(index));

        using Bitmap splice = new(spliceWidth, spliceHeight);
        using (Graphics graphics = Graphics.FromImage(splice))
        {
            graphics.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
            graphics.Dispose();
        }

        if (outputFormat.Contains("{0}"))
        {
            splice.Save(Path.Combine(this.OutputPath, string.Format(outputFormat, index)));
        }
        else
        {
            splice.Save(Path.Combine(this.OutputPath, outputFormat));
        }
    }
}
