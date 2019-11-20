using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Resizer
{
    public partial class Form1 : Form
    {
        private Image image;
        private string[] extension = {".PNG", ".JPEG", ".JPG", ".GIF"};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < extension.Length; i++)
            {
                comboBox.Items.Add(extension[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "images | *.png;*.jpg;*.jpeg;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedPicturePath.Text = openFileDialog.FileName;
                image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                savedPicturePath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(this.width.Text);
            int height = Convert.ToInt32(this.height.Text);
            image = Resize(image, width, height);
            ((Button) sender).Enabled = false;
            MessageBox.Show("Image has been resized successfully!");
        }

        Image Resize(Image image, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.DrawImage(image, 0, 0, width, height);
            graphic.Dispose();
            return bitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int dot = 0, slash = 0;
            for (int j = selectedPicturePath.Text.Length - 1; j >= 0; j--)
            {
                if (selectedPicturePath.Text[j] == '.')
                {
                    dot = j;
                }
                else if (selectedPicturePath.Text[j] == '\\')
                {
                    slash = j;
                    break;
                }
            }
            image.Save(savedPicturePath.Text + "\\" + selectedPicturePath.Text.Substring(slash + 1, dot - slash - 1) + extension[comboBox.SelectedIndex]);
            ((Button) sender).Enabled = false;
            MessageBox.Show("Image Saved Successfully!");
        }
    }
}
