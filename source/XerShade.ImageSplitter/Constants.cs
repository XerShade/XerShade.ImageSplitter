namespace XerShade.ImageSplitter
{
    public static class Constants
    {
        public static readonly string ApplicationPath = Application.StartupPath;
        public static readonly string DirectorySeparatorChar = Path.DirectorySeparatorChar.ToString();
        public static readonly string OutputPath = $"{ApplicationPath}Output";
        public static readonly string OutputName = "{1}-{0}{2}";
        public static readonly int MaxRows = 1024;
        public static readonly int MaxColumns = 1024;
    }
}
