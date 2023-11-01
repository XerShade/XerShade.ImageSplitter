using XerShade.Libraries.Images.Splitting.EventArgs;

namespace XerShade.Libraries.Images.Splitting.Interfaces;

public interface IImageSplitter
{
    string OutputPath { get; }
    string SourcePath { get; }

    event EventHandler<OnSpliceImageEventArgs>? OnSpliceImage;

    void Split(int rows, int columns, string outputFormat = "", bool invertLoops = false);
}
