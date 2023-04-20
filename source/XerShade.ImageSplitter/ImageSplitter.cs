using XerShade.ImageSplitter.Extensions;
using XerShade.Libraries.Images.Splitting.EventArgs;
using XerShade.Libraries.Images.Splitting.Interfaces;
using XSplitter = XerShade.Libraries.Images.Splitting.ImageSplitter;

namespace XerShade.ImageSplitter
{
    public partial class ImageSplitter : Form
    {
        private IImageSplitter? splitter;

        public ImageSplitter()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            prgProgress.Value = 0;
            prgProgress.Maximum = (int)numRows.Value * (int)numColumns.Value;
            prgProgress.Visible = true;

            if (txtSource.Text.Substring(txtSource.Text.Length - 1, 1) == Constants.DirectorySeparatorChar)
            {
                if (Directory.Exists(txtSource.Text))
                {
                    foreach(var file in Directory.GetFiles(txtSource.Text))
                    {
                        var fileName = Path.GetFileNameWithoutExtension(file);
                        var fileExtension = Path.GetExtension(file);
                        txtOutputFormat.Text = string.Format(Constants.OutputName, "{0}", fileName, fileExtension);

                        splitter = new XSplitter(file, txtOutputPath.Text);
                        splitter.IndexChanged += (object? sender, ImageSplitterIndexEventArgs e) => { prgProgress.Value = e.Value; Application.DoEvents(); };
                        splitter.Split((int)numRows.Value, (int)numColumns.Value, txtOutputFormat.Text);
                    }
                }
            }
            else
            {
                splitter = new XSplitter(txtSource.Text, txtOutputPath.Text);
                splitter.IndexChanged += (object? sender, ImageSplitterIndexEventArgs e) => { prgProgress.Value = e.Value; Application.DoEvents(); };
                splitter.Split((int)numRows.Value, (int)numColumns.Value, txtOutputFormat.Text);
            }

            prgProgress.Visible = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openImageDialog.ShowDialog() != DialogResult.OK) { return; }

            txtSource.Text = openImageDialog.FileName;

            var fileName = Path.GetFileNameWithoutExtension(txtSource.Text);
            var fileExtension = Path.GetExtension(txtSource.Text);
            txtOutputFormat.Text = string.Format(Constants.OutputName, "{0}", fileName, fileExtension);
        }

        private void ImageSplitter_Load(object sender, EventArgs e)
        {
            txtSource.Text = Constants.ApplicationPath;
            txtOutputPath.Text = Constants.OutputPath;
            openImageDialog.InitialDirectory = Constants.ApplicationPath;
            numRows.Maximum = Constants.MaxRows;
            numColumns.Maximum = Constants.MaxColumns;

            prgProgress.VisibleChanged += (object? sender, EventArgs e) => { 
                this.Enable(!prgProgress.Visible);
                Application.DoEvents();
            };
        }
    }
}
