using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net.NetworkInformation;

namespace _24_04_hm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string path;
        Mutex mutex = new Mutex();

        public void Path()
        {
            mutex.WaitOne();
            path = $@"{textBox2.Text.ToString()}";
            listBox1.Items.Clear();
            string[] astrFiles = Directory.GetFiles(path);
            foreach (string file in astrFiles)
            {
                if (file.Contains(textBox1.Text))
                {
                    listBox1.Items.Add($"File:");
                    listBox1.Items.Add($"Path:");
                }
            }
            mutex.ReleaseMutex();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread myThread = new Thread(Path);
            myThread.Start();
        }
    }
}
