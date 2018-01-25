using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Units
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> prefixes = new Dictionary<string, double>()
        {
            {"nm", 1e-9 },
            {"μm", 1e-6 },
            {"mm", 1e-3 },
            {"cm", 1e-2 },
            {"m", 1 },
            {"km", 1e3 },
            {"Mm", 1e6 },
            {"Gm", 1e9 }
        };

        public Form1()
        {
            InitializeComponent();
            foreach(string k in prefixes.Keys)
            {
                comboBox1.Items.Add(k);
                comboBox2.Items.Add(k);
            }
            comboBox1.SelectedIndex = 4;
            comboBox2.SelectedIndex = 4;
        }

        void update()
        {
            try
            {
                double d = double.Parse(textBox1.Text);
                double d2 = d * prefixes[comboBox1.Text] / prefixes[comboBox2.Text];
                label1.Text = d2.ToString();
            }
            catch
            {
                label1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }
    }
}
