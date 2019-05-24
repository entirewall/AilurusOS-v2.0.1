using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Mi_Vida_v._1._0._1
{
    public partial class AilurusOSPanel : Form
    {
        public AilurusOSPanel()
        {
            //this.BackgroundImage = Properties.Resources.background;
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        public void ResimDegistir(Image resim)
        {
            pictureBox1.Image = resim;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                ControlExtension.Draggable(pictureBox2, true);
                ControlExtension.Draggable(pictureBox3, true);
                ControlExtension.Draggable(pictureBox4, true);
                this.WindowState = FormWindowState.Maximized;

                this.TopMost = true;
                this.CenterToScreen();
                toolStripLabel1.ForeColor = Color.DarkRed;
                toolStripLabel2.ForeColor = Color.DarkRed;
                toolStripLabel1.Text = DateTime.Now.ToShortDateString();
                toolStripLabel2.Text = DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.P)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void sessionStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SessionState ss = new SessionState();
                
                    ss.Show();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void refleshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
           // pictureBox1.Visible = false;
            timer2.Start();
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
           // pictureBox1.Visible = true;
            timer2.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Command cc = new Command();
                cc.Show();
                

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Command cc = new Command();
                cc.Show();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Notepad ntp = new Notepad();
                ntp.Show();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void checklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Notepad ntp = new Notepad();
                ntp.Show();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Browser brw = new Browser();
                brw.Show();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void MiVidaPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public void tRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[0].Text = "Yeni";
            contextMenuStrip1.Items[1].Text = "Yenile";
            contextMenuStrip1.Items[2].Text = "Özelleştir";
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDown.Items[0].Text = "Dosya";
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDown.Items[1].Text = "Not Defteri";
            toolStripDropDownButton1.DropDownItems[0].Text = "Uygulamalar";
            toolStripDropDownButton1.DropDownItems[1].Text = "Not Defteri";
            toolStripDropDownButton1.DropDownItems[2].Text = "Tarayıcı";
            toolStripDropDownButton1.DropDownItems[4].Text = "Kullanıcı Ayarları";
            toolStripDropDownButton1.DropDownItems[5].Text = "Oturum Durumu";
        }

        public void eNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[0].Text = "New";
            contextMenuStrip1.Items[1].Text = "Refresh";
            contextMenuStrip1.Items[2].Text = "Personalize";
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDown.Items[0].Text = "Folder";
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDown.Items[1].Text = "Notepad";
            toolStripDropDownButton1.DropDownItems[0].Text = "Applications";
            toolStripDropDownButton1.DropDownItems[1].Text = "Notepad";
            toolStripDropDownButton1.DropDownItems[2].Text = "Browser";
            toolStripDropDownButton1.DropDownItems[4].Text = "User Settings";
            toolStripDropDownButton1.DropDownItems[5].Text = "Session State";
        }

        private void p3RLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p3rlloginpanel rlloginpanel = new p3rlloginpanel();
            rlloginpanel.Show();
        }

        private void shellxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void userSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSetting srtsd = new UserSetting();
            srtsd.Show();
        }

        private void personalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSetting userSetting = new UserSetting();
            userSetting.Show();
        }

        private void browserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browser browser = new Browser();
            browser.Show();
        }
    }
}
