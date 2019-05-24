using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mi_Vida_v._1._0._1
{
    public partial class p3rlloginpanel : Form
    {
        public p3rlloginpanel()
        {
            InitializeComponent();
            this.Opacity = 0;
            gecspanel.Enabled = true;
        }
        private float opac = 0.0f;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void p3rlloginpanel_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void gecspanel_Tick(object sender, EventArgs e)
        {
            opac += 0.1f;
            this.Opacity = opac;
            if (opac > 1.1)
            {
                gecspanel.Enabled = false;
                gecspanelkapan.Enabled = true;
            }
        }

        private void gecspanelkapan_Tick(object sender, EventArgs e)
        {
            opac -= 0.1f;
            this.Opacity = opac;
            if (this.Opacity==0.0f)
            {
                P3RL p3 = new P3RL();
                p3.Show();
                this.Close();
            }
        }
    }
}
