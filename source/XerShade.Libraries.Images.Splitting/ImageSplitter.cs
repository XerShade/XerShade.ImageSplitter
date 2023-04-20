using System.Drawing;
using XerShade.Libraries.Images.Splitting.EventArgs;
using XerShade.Libraries.Images.Splitting.Interfaces;

namespace XerShade.Libraries.Images.Splitting
{
    public class ImageSplitter : IImageSplitter
    {
        public event EventHandler<ImageSplitterIndexEventArgs>? IndexChanged;

        public string SourcePath { get; protected set; }
        public string OutputPath { get; protected set; }

        public ImageSplitter(string sourcePath, string outputPath)
        {
            SourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
            OutputPath = outputPath ?? throw new ArgumentNullException(nameof(outputPath));
        }

        public void Split(int rows, int columns, string outputFormat = "")
        {
            if (string.IsNullOrWhiteSpace(SourcePath)) { throw new NullReferenceException(nameof(SourcePath)); }
            if (string.IsNullOrWhiteSpace(OutputPath)) { throw new NullReferenceException(nameof(OutputPath)); }

            if (!File.Exists(SourcePath)) { throw new FileNotFoundException($"Source image not found at '{SourcePath}'.", SourcePath); }
            if (!Directory.Exists(OutputPath)) { Directory.CreateDirectory(OutputPath); }

            if (string.IsNullOrWhiteSpace(outputFormat))
            {
                var fileName = Path.GetFileNameWithoutExtension(SourcePath);
                var fileExtension = Path.GetExtension(SourcePath);
                outputFormat = string.Format("{1}-{0}{2}", "{0}", fileName, fileExtension);
            }

            Image source = Image.FromFile(SourcePath);
            var spliceWidth = (int)Math.Floor(source.Width / (float)columns);
            var spliceHeight = (int)Math.Floor(source.Height / (float)rows);
            var destRect = new Rectangle(0, 0, spliceWidth, spliceHeight);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    var srcRect = new Rectangle(x * spliceWidth, y * spliceHeight, spliceWidth, spliceHeight);
                    var index = y * columns + x;
                    IndexChanged?.Invoke(this, new ImageSplitterIndexEventArgs(index));

                    Bitmap splice = new(spliceWidth, spliceHeight);
                    Graphics graphics = Graphics.FromImage(splice);

                    graphics.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
                    graphics.Dispose();

                    if (outputFormat.Contains("{0}"))
                    {
                        splice.Save(Path.Combine(OutputPath, string.Format(outputFormat, index)));
                    }
                    else
                    {
                        splice.Save(Path.Combine(OutputPath, outputFormat));
                    }
                }
            }
        }
    }
}
