namespace XerShade.Libraries.Images.Splitting.EventArgs;

public class OnSpliceImageEventArgs : System.EventArgs
{
    public int Value { get; private set; }

    public OnSpliceImageEventArgs(int value)
    {
        this.Value = value;
    }
}
