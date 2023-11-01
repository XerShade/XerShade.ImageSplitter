using System.Drawing;
using XerShade.Libraries.Images.Splitting.EventArgs;
using XerShade.Libraries.Images.Splitting.Interfaces;

namespace XerShade.Libraries.Images.Splitting;

public class ImageSplitter : IImageSplitter
{
    public event EventHandler<ImageSplitterIndexEventArgs>? IndexChanged;

    public string SourcePath { get; protected set; }
    public string OutputPath { get; protected set; }

    public ImageSplitter(string sourcePath, string outputPath)
    {
        this.SourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        this.OutputPath = outputPath ?? throw new ArgumentNullException(nameof(outputPath));
    }

    public void Split(int rows, int columns, string outputFormat = "")
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

        Image source = Image.FromFile(this.SourcePath);
        int spliceWidth = (int)Math.Floor(source.Width / (float)columns);
        int spliceHeight = (int)Math.Floor(source.Height / (float)rows);
        Rectangle destRect = new(0, 0, spliceWidth, spliceHeight);

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Rectangle srcRect = new(x * spliceWidth, y * spliceHeight, spliceWidth, spliceHeight);
                int index = (y * columns) + x;
                IndexChanged?.Invoke(this, new ImageSplitterIndexEventArgs(index));

                Bitmap splice = new(spliceWidth, spliceHeight);
                Graphics graphics = Graphics.FromImage(splice);

                graphics.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
                graphics.Dispose();

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
    }
}
