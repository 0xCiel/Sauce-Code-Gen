using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhenCodeGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the URL: " + ex.Message);
            }
        }



    private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000);
            textBox1.Text = randomNumber.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string url = "https://nhentai.to/g/" + textBox1.Text;
                OpenUrl(url);
            } else
            {
                MessageBox.Show("Empty");
            }
        }
    }
}
