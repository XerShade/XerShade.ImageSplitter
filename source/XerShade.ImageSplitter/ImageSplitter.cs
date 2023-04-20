using XerShade.ImageSplitter.Extensions;

namespace XerShade.ImageSplitter
{
    public partial class ImageSplitter : Form
    {
        public ImageSplitter()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            prgProgress.Value = 0;
            prgProgress.Maximum = (int)numRows.Value * (int)numColumns.Value;
            prgProgress.Visible = true;

            for (int y = 0; y < (int)numRows.Value; y++)
            {
                for (int x = 0; x < (int)numColumns.Value; x++)
                {
                    var index = (int)(y * numColumns.Value + x);
                    prgProgress.Value = index;

                    Application.DoEvents();

                    // Do the image splitting things.
                }
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
