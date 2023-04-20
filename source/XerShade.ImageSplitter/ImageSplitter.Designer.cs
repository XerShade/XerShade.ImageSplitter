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
            lblSourceImage = new Label();
            txtSource = new TextBox();
            lblOutputPath = new Label();
            txtOutputPath = new TextBox();
            lblRows = new Label();
            lblColumns = new Label();
            numRows = new NumericUpDown();
            numColumns = new NumericUpDown();
            prgProgress = new ProgressBar();
            btnGenerate = new Button();
            btnBrowse = new Button();
            txtOutputFormat = new TextBox();
            lblOutputFormat = new Label();
            openImageDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)numRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numColumns).BeginInit();
            SuspendLayout();
            // 
            // lblSourceImage
            // 
            lblSourceImage.AutoSize = true;
            lblSourceImage.Location = new Point(12, 9);
            lblSourceImage.Name = "lblSourceImage";
            lblSourceImage.Size = new Size(82, 15);
            lblSourceImage.TabIndex = 0;
            lblSourceImage.Text = "Source Image:";
            // 
            // txtSource
            // 
            txtSource.Location = new Point(12, 27);
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(165, 23);
            txtSource.TabIndex = 1;
            // 
            // lblOutputPath
            // 
            lblOutputPath.AutoSize = true;
            lblOutputPath.Location = new Point(12, 53);
            lblOutputPath.Name = "lblOutputPath";
            lblOutputPath.Size = new Size(75, 15);
            lblOutputPath.TabIndex = 2;
            lblOutputPath.Text = "Output Path:";
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(12, 71);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(165, 23);
            txtOutputPath.TabIndex = 3;
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.Location = new Point(12, 97);
            lblRows.Name = "lblRows";
            lblRows.Size = new Size(38, 15);
            lblRows.TabIndex = 4;
            lblRows.Text = "Rows:";
            // 
            // lblColumns
            // 
            lblColumns.AutoSize = true;
            lblColumns.Location = new Point(138, 97);
            lblColumns.Name = "lblColumns";
            lblColumns.Size = new Size(58, 15);
            lblColumns.TabIndex = 5;
            lblColumns.Text = "Columns:";
            // 
            // numRows
            // 
            numRows.Location = new Point(12, 115);
            numRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRows.Name = "numRows";
            numRows.Size = new Size(120, 23);
            numRows.TabIndex = 6;
            numRows.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numColumns
            // 
            numColumns.Location = new Point(138, 115);
            numColumns.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numColumns.Name = "numColumns";
            numColumns.Size = new Size(120, 23);
            numColumns.TabIndex = 7;
            numColumns.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // prgProgress
            // 
            prgProgress.Location = new Point(12, 144);
            prgProgress.Name = "prgProgress";
            prgProgress.Size = new Size(246, 23);
            prgProgress.TabIndex = 8;
            prgProgress.Visible = false;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 144);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(246, 23);
            btnGenerate.TabIndex = 9;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(183, 26);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 10;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtOutputFormat
            // 
            txtOutputFormat.Location = new Point(183, 71);
            txtOutputFormat.Name = "txtOutputFormat";
            txtOutputFormat.Size = new Size(75, 23);
            txtOutputFormat.TabIndex = 11;
            // 
            // lblOutputFormat
            // 
            lblOutputFormat.AutoSize = true;
            lblOutputFormat.Location = new Point(183, 53);
            lblOutputFormat.Name = "lblOutputFormat";
            lblOutputFormat.Size = new Size(48, 15);
            lblOutputFormat.TabIndex = 12;
            lblOutputFormat.Text = "Format:";
            // 
            // openImageDialog
            // 
            openImageDialog.Title = "Select Source Image";
            // 
            // ImageSplitter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 179);
            Controls.Add(lblOutputFormat);
            Controls.Add(txtOutputFormat);
            Controls.Add(btnBrowse);
            Controls.Add(prgProgress);
            Controls.Add(btnGenerate);
            Controls.Add(numColumns);
            Controls.Add(numRows);
            Controls.Add(lblColumns);
            Controls.Add(lblRows);
            Controls.Add(txtOutputPath);
            Controls.Add(lblOutputPath);
            Controls.Add(txtSource);
            Controls.Add(lblSourceImage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImageSplitter";
            Text = "Image Splitter";
            Load += ImageSplitter_Load;
            ((System.ComponentModel.ISupportInitialize)numRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)numColumns).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSourceImage;
        private TextBox txtSource;
        private Label lblOutputPath;
        private TextBox txtOutputPath;
        private Label lblRows;
        private Label lblColumns;
        private NumericUpDown numRows;
        private NumericUpDown numColumns;
        private ProgressBar prgProgress;
        private Button btnGenerate;
        private Button btnBrowse;
        private TextBox txtOutputFormat;
        private Label lblOutputFormat;
        private OpenFileDialog openImageDialog;
    }
}