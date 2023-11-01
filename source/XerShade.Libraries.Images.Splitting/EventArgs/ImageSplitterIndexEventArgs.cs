namespace XerShade.Libraries.Images.Splitting.EventArgs;

public class ImageSplitterIndexEventArgs : System.EventArgs
{
    public int Value { get; private set; }

    public ImageSplitterIndexEventArgs(int value)
    {
        this.Value = value;
    }
}
