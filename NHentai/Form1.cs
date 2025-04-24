using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHentaiAPI;
using NHentaiAPI.Models.Books;

namespace NHentai
{
    public partial class Form1 : Form
    {
        private readonly NHentaiClient _client;
        private Book _currentBook;
        private int _currentGalleryIndex = 1;
        private Size formOriginalSize;
        private Rectangle recGenButton;
        private Rectangle recThumbnailImage;
        private Rectangle recImages;
        private Rectangle recGeneratedCode;
        private Rectangle recVScrollBar;
        private Rectangle recPageLabel;
        public Form1()
        {
            InitializeComponent();
            _client = new NHentaiClient(""); //put your user agent here https://www.whatismybrowser.com/detect/what-is-my-user-agent/
            this.Resize += Form1_Resize;
            formOriginalSize = this.Size;
            recGenButton = new Rectangle(GenButton.Location, GenButton.Size);
            recThumbnailImage = new Rectangle(ThumbnailImage.Location, ThumbnailImage.Size);
            recImages = new Rectangle(Images.Location, Images.Size);
            recGeneratedCode = new Rectangle(GeneratedCode.Location, GeneratedCode.Size);
            recVScrollBar = new Rectangle(vScrollBar1.Location, vScrollBar1.Size);
            recPageLabel = new Rectangle(PageLabel.Location, PageLabel.Size);
        }

        private async void GenButton_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                int randomCode = random.Next(1, 500000);
                _currentBook = await _client.GetBookAsync(randomCode);
                var tags = string.Join("\n- ", _currentBook.Tags.Select(tag => tag.Name));
                GeneratedCode.Text = $"Code: {_currentBook.Id}\n\nTitle: {_currentBook.Title.English}\n\nTags:\n- {tags}";
                byte[] coverThumbnailBytes = await _client.GetBookThumbPictureAsync(_currentBook);
                using (var ms = new MemoryStream(coverThumbnailBytes))
                {
                    ThumbnailImage.Image = System.Drawing.Image.FromStream(ms);
                }
                _currentGalleryIndex = 1;
                vScrollBar1.Maximum = _currentBook.NumPages;
                vScrollBar1.Value = 1;

                UpdatePageLabel();
                await DisplayGalleryThumbnailAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch book details or gallery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DisplayGalleryThumbnailAsync()
        {
            try
            {
                byte[] thumbnailBytes = await _client.GetThumbPictureAsync(_currentBook, _currentGalleryIndex);
                using (var ms = new MemoryStream(thumbnailBytes))
                {
                    Images.Image = System.Drawing.Image.FromStream(ms);
                }
                UpdatePageLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to display gallery thumbnail for page {_currentGalleryIndex}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (_currentBook != null && e.NewValue > e.OldValue && _currentGalleryIndex < _currentBook.NumPages)
                {
                    _currentGalleryIndex++;
                    await DisplayGalleryThumbnailAsync();
                }
                else if (_currentBook != null && e.NewValue < e.OldValue && _currentGalleryIndex > 1)
                {
                    _currentGalleryIndex--;
                    await DisplayGalleryThumbnailAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load gallery page {_currentGalleryIndex}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePageLabel()
        {
            if (_currentBook != null)
            {
                PageLabel.Text = $"Page: {_currentGalleryIndex}/{_currentBook.NumPages}";
            }
            else
            {
                PageLabel.Text = "Page: 0/0";
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeControl(GenButton, recGenButton);
            ResizeControl(ThumbnailImage, recThumbnailImage);
            ResizeControl(Images, recImages);
            ResizeControl(GeneratedCode, recGeneratedCode);
            ResizeControl(vScrollBar1, recVScrollBar);
            ResizeControl(PageLabel, recPageLabel);
        }

        private void ResizeControl(Control control, Rectangle originalRect)
        {
            float xRatio = (float)this.Width / formOriginalSize.Width;
            float yRatio = (float)this.Height / formOriginalSize.Height;

            int newX = (int)(originalRect.X * xRatio);
            int newY = (int)(originalRect.Y * yRatio);

            int newWidth = (int)(originalRect.Width * xRatio);
            int newHeight = (int)(originalRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }
    }
}
