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

        Dictionary<string, double> areas = new Dictionary<string, double>()
        {
            {"nm\xB2", 1e-18 },
            {"μm\xB2", 1e-12 },
            {"mm\xB2", 1e-6 },
            {"cm\xB2", 1e-4 },
            {"m\xB2", 1 },
            {"km\xB2", 1e6 },
            {"Mm\xB2", 1e12 },
            {"Gm\xB2", 1e18 }
        };

        Dictionary<string, double> volumes = new Dictionary<string, double>()
        {
            {"nm\xB3", 1e-27 },
            {"μm\xB3", 1e-18 },
            {"mm\xB3", 1e-9 },
            {"cm\xB3", 1e-6 },
            {"m\xB3", 1 },
            {"km\xB3", 1e9 },
            {"Mm\xB3", 1e18 },
            {"Gm\xB3", 1e27 }
        };

        string type = "prefix";

        public Form1()
        {
            InitializeComponent();
            foreach(string k in prefixes.Keys)
            {
                comboBox1.Items.Add(k);
                comboBox2.Items.Add(k);
            }
            foreach (string k in areas.Keys)
                comboBox1.Items.Add(k);
            foreach (string k in volumes.Keys)
                comboBox1.Items.Add(k);
            comboBox1.SelectedIndex = 4;
            comboBox2.SelectedIndex = 4;
        }

        void update()
        {
            try
            {
                double d = double.Parse(textBox1.Text);
                double d2;
                if (comboBox1.SelectedIndex < prefixes.Count)
                    d2 = d * prefixes[comboBox1.Text] / prefixes[comboBox2.Text];
                else if (comboBox1.SelectedIndex < 2 * prefixes.Count)
                    d2 = d * areas[comboBox1.Text] / areas[comboBox2.Text];
                else
                    d2 = d * volumes[comboBox1.Text] / volumes[comboBox2.Text];
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
            if (comboBox1.SelectedIndex < prefixes.Count)
            {
                if (type != "prefix")
                {
                    comboBox2.Items.Clear();
                    foreach (string k in prefixes.Keys)
                        comboBox2.Items.Add(k);
                    comboBox2.SelectedIndex = 4;
                    type = "prefix";
                }   
            }
            else if (comboBox1.SelectedIndex < 2 * prefixes.Count)
            {
                if (type != "area")
                {
                    comboBox2.Items.Clear();
                    foreach (string k in areas.Keys)
                        comboBox2.Items.Add(k);
                    comboBox2.SelectedIndex = 4;
                    type = "area";
                }    
            } 
            else
            {
                if (type != "volume")
                {
                    comboBox2.Items.Clear();
                    foreach (string k in volumes.Keys)
                        comboBox2.Items.Add(k);
                    comboBox2.SelectedIndex = 4;
                    type = "volume";
                }
            }    
            update();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }
    }
}
