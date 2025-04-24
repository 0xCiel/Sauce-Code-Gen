namespace NHentai
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GenButton = new Button();
            GeneratedCode = new RichTextBox();
            ThumbnailImage = new PictureBox();
            vScrollBar1 = new VScrollBar();
            Images = new PictureBox();
            PageLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ThumbnailImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Images).BeginInit();
            SuspendLayout();
            // 
            // GenButton
            // 
            GenButton.Location = new Point(400, 416);
            GenButton.Name = "GenButton";
            GenButton.Size = new Size(122, 44);
            GenButton.TabIndex = 0;
            GenButton.Text = "Generate Code";
            GenButton.UseVisualStyleBackColor = true;
            GenButton.Click += GenButton_Click;
            // 
            // GeneratedCode
            // 
            GeneratedCode.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GeneratedCode.Location = new Point(263, 51);
            GeneratedCode.Name = "GeneratedCode";
            GeneratedCode.ReadOnly = true;
            GeneratedCode.Size = new Size(419, 359);
            GeneratedCode.TabIndex = 1;
            GeneratedCode.Text = "";
            // 
            // ThumbnailImage
            // 
            ThumbnailImage.Location = new Point(12, 51);
            ThumbnailImage.Name = "ThumbnailImage";
            ThumbnailImage.Size = new Size(245, 359);
            ThumbnailImage.TabIndex = 2;
            ThumbnailImage.TabStop = false;
            // 
            // vScrollBar1
            // 
            vScrollBar1.LargeChange = 1;
            vScrollBar1.Location = new Point(900, 55);
            vScrollBar1.Maximum = 500;
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(25, 290);
            vScrollBar1.TabIndex = 1;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // Images
            // 
            Images.Location = new Point(692, 55);
            Images.Name = "Images";
            Images.Size = new Size(205, 290);
            Images.TabIndex = 4;
            Images.TabStop = false;
            // 
            // PageLabel
            // 
            PageLabel.AutoSize = true;
            PageLabel.Location = new Point(764, 348);
            PageLabel.Name = "PageLabel";
            PageLabel.Size = new Size(56, 15);
            PageLabel.TabIndex = 5;
            PageLabel.Text = "Page: 0/0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 467);
            Controls.Add(PageLabel);
            Controls.Add(Images);
            Controls.Add(vScrollBar1);
            Controls.Add(ThumbnailImage);
            Controls.Add(GeneratedCode);
            Controls.Add(GenButton);
            Name = "Form1";
            Text = "NHentai Generator by Ciel | @0xciel";
            ((System.ComponentModel.ISupportInitialize)ThumbnailImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)Images).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GenButton;
        private RichTextBox GeneratedCode;
        private PictureBox ThumbnailImage;
        private VScrollBar vScrollBar1;
        private PictureBox Images;
        private Label PageLabel;
    }
}
