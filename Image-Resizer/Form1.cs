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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < extension.Length; i++)
            {
                comboBox.Items.Add(extension[i]);
            }
        }
    }
}
