namespace XerShade.ImageSplitter
{
    partial class ImageSplitter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LblSourceImage = new Label();
            TxtSource = new TextBox();
            LblOutputPath = new Label();
            TxtOutputPath = new TextBox();
            LblRows = new Label();
            LblColumns = new Label();
            NumRows = new NumericUpDown();
            NumColumns = new NumericUpDown();
            PrgProgress = new ProgressBar();
            BtnGenerate = new Button();
            BtnBrowse = new Button();
            TxtOutputFormat = new TextBox();
            LblOutputFormat = new Label();
            OpenImageDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)NumRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumColumns).BeginInit();
            this.SuspendLayout();
            // 
            // LblSourceImage
            // 
            LblSourceImage.AutoSize = true;
            LblSourceImage.Location = new Point(12, 9);
            LblSourceImage.Name = "LblSourceImage";
            LblSourceImage.Size = new Size(82, 15);
            LblSourceImage.TabIndex = 0;
            LblSourceImage.Text = "Source Image:";
            // 
            // TxtSource
            // 
            TxtSource.Location = new Point(12, 27);
            TxtSource.Name = "TxtSource";
            TxtSource.Size = new Size(165, 23);
            TxtSource.TabIndex = 1;
            // 
            // LblOutputPath
            // 
            LblOutputPath.AutoSize = true;
            LblOutputPath.Location = new Point(12, 53);
            LblOutputPath.Name = "LblOutputPath";
            LblOutputPath.Size = new Size(75, 15);
            LblOutputPath.TabIndex = 2;
            LblOutputPath.Text = "Output Path:";
            // 
            // TxtOutputPath
            // 
            TxtOutputPath.Location = new Point(12, 71);
            TxtOutputPath.Name = "TxtOutputPath";
            TxtOutputPath.Size = new Size(165, 23);
            TxtOutputPath.TabIndex = 3;
            // 
            // LblRows
            // 
            LblRows.AutoSize = true;
            LblRows.Location = new Point(138, 97);
            LblRows.Name = "LblRows";
            LblRows.Size = new Size(38, 15);
            LblRows.TabIndex = 4;
            LblRows.Text = "Rows (Y):";
            // 
            // LblColumns
            // 
            LblColumns.AutoSize = true;
            LblColumns.Location = new Point(12, 97);
            LblColumns.Name = "LblColumns";
            LblColumns.Size = new Size(58, 15);
            LblColumns.TabIndex = 5;
            LblColumns.Text = "Columns (X):";
            // 
            // NumRows
            // 
            NumRows.Location = new Point(138, 115);
            NumRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumRows.Name = "NumRows";
            NumRows.Size = new Size(120, 23);
            NumRows.TabIndex = 6;
            NumRows.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // NumColumns
            // 
            NumColumns.Location = new Point(12, 115);
            NumColumns.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumColumns.Name = "NumColumns";
            NumColumns.Size = new Size(120, 23);
            NumColumns.TabIndex = 7;
            NumColumns.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // PrgProgress
            // 
            PrgProgress.Location = new Point(12, 144);
            PrgProgress.Name = "PrgProgress";
            PrgProgress.Size = new Size(246, 23);
            PrgProgress.TabIndex = 8;
            PrgProgress.Visible = false;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Location = new Point(12, 144);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(246, 23);
            BtnGenerate.TabIndex = 9;
            BtnGenerate.Text = "Generate";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += this.BtnGenerate_Click;
            // 
            // BtnBrowse
            // 
            BtnBrowse.Location = new Point(183, 26);
            BtnBrowse.Name = "BtnBrowse";
            BtnBrowse.Size = new Size(75, 23);
            BtnBrowse.TabIndex = 10;
            BtnBrowse.Text = "Browse";
            BtnBrowse.UseVisualStyleBackColor = true;
            BtnBrowse.Click += this.BtnBrowse_Click;
            // 
            // TxtOutputFormat
            // 
            TxtOutputFormat.Location = new Point(183, 71);
            TxtOutputFormat.Name = "TxtOutputFormat";
            TxtOutputFormat.Size = new Size(75, 23);
            TxtOutputFormat.TabIndex = 11;
            // 
            // LblOutputFormat
            // 
            LblOutputFormat.AutoSize = true;
            LblOutputFormat.Location = new Point(183, 53);
            LblOutputFormat.Name = "LblOutputFormat";
            LblOutputFormat.Size = new Size(48, 15);
            LblOutputFormat.TabIndex = 12;
            LblOutputFormat.Text = "Format:";
            // 
            // OpenImageDialog
            // 
            OpenImageDialog.Title = "Select Source Image";
            // 
            // ImageSplitter
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(277, 179);
            this.Controls.Add(LblOutputFormat);
            this.Controls.Add(TxtOutputFormat);
            this.Controls.Add(BtnBrowse);
            this.Controls.Add(PrgProgress);
            this.Controls.Add(BtnGenerate);
            this.Controls.Add(NumColumns);
            this.Controls.Add(NumRows);
            this.Controls.Add(LblColumns);
            this.Controls.Add(LblRows);
            this.Controls.Add(TxtOutputPath);
            this.Controls.Add(LblOutputPath);
            this.Controls.Add(TxtSource);
            this.Controls.Add(LblSourceImage);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageSplitter";
            this.Text = "Image Splitter";
            this.Load += this.ImageSplitter_Load;
            ((System.ComponentModel.ISupportInitialize)NumRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumColumns).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label LblSourceImage;
        private TextBox TxtSource;
        private Label LblOutputPath;
        private TextBox TxtOutputPath;
        private Label LblRows;
        private Label LblColumns;
        private NumericUpDown NumRows;
        private NumericUpDown NumColumns;
        private ProgressBar PrgProgress;
        private Button BtnGenerate;
        private Button BtnBrowse;
        private TextBox TxtOutputFormat;
        private Label LblOutputFormat;
        private OpenFileDialog OpenImageDialog;
    }
}