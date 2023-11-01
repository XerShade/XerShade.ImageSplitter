using XerShade.ImageSplitter.Extensions;
using XerShade.Libraries.Images.Splitting.EventArgs;
using XerShade.Libraries.Images.Splitting.Interfaces;
using XSplitter = XerShade.Libraries.Images.Splitting.ImageSplitter;

namespace XerShade.ImageSplitter;

public partial class ImageSplitter : Form
{
    private IImageSplitter? splitter;

    public ImageSplitter() => this.InitializeComponent();

    private void BtnGenerate_Click(object sender, EventArgs e)
    {
        this.PrgProgress.Value = 0;
        this.PrgProgress.Maximum = (int)this.NumRows.Value * (int)this.NumColumns.Value;
        this.PrgProgress.Visible = true;

        if (this.TxtSource.Text.Substring(this.TxtSource.Text.Length - 1, 1) == Constants.DirectorySeparatorChar)
        {
            if (Directory.Exists(this.TxtSource.Text))
            {
                foreach(string file in Directory.GetFiles(this.TxtSource.Text))
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    string fileExtension = Path.GetExtension(file);
                    this.TxtOutputFormat.Text = string.Format(Constants.OutputName, "{0}", fileName, fileExtension);

                    this.splitter = new XSplitter(file, this.TxtOutputPath.Text);
                    this.splitter.IndexChanged += (object? sender, ImageSplitterIndexEventArgs e) => { this.PrgProgress.Value = e.Value; Application.DoEvents(); };
                    this.splitter.Split((int)this.NumRows.Value, (int)this.NumColumns.Value, this.TxtOutputFormat.Text);
                }
            }
        }
        else
        {
            this.splitter = new XSplitter(this.TxtSource.Text, this.TxtOutputPath.Text);
            this.splitter.IndexChanged += (object? sender, ImageSplitterIndexEventArgs e) => { this.PrgProgress.Value = e.Value; Application.DoEvents(); };
            this.splitter.Split((int)this.NumRows.Value, (int)this.NumColumns.Value, this.TxtOutputFormat.Text);
        }

        this.PrgProgress.Visible = false;
    }

    private void BtnBrowse_Click(object sender, EventArgs e)
    {
        if (this.OpenImageDialog.ShowDialog() != DialogResult.OK) { return; }

        this.TxtSource.Text = this.OpenImageDialog.FileName;

        string fileName = Path.GetFileNameWithoutExtension(this.TxtSource.Text);
        string fileExtension = Path.GetExtension(this.TxtSource.Text);
        this.TxtOutputFormat.Text = string.Format(Constants.OutputName, "{0}", fileName, fileExtension);
    }

    private void ImageSplitter_Load(object sender, EventArgs e)
    {
        this.TxtSource.Text = Constants.ApplicationPath;
        this.TxtOutputPath.Text = Constants.OutputPath;
        this.OpenImageDialog.InitialDirectory = Constants.ApplicationPath;
        this.NumRows.Maximum = Constants.MaxRows;
        this.NumColumns.Maximum = Constants.MaxColumns;

        this.PrgProgress.VisibleChanged += (object? sender, EventArgs e) => { 
            this.Enable(!this.PrgProgress.Visible);
            Application.DoEvents();
        };
    }
}
