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
    public partial class UserSetting : Form
    {
        public UserSetting()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (panel1.Width == 58)
            {
                acilr.Start();
            }
            else
                kapanr.Start();
        }
        
        private void acilr_Tick(object sender, EventArgs e)
        {
            panel1.Width = panel1.Width + 2;
            if(panel1.Width==170)
            {
                acilr.Stop();
            }
        }

        private void kapanr_Tick(object sender, EventArgs e)
        {
            panel1.Width = panel1.Width - 2;
            if (panel1.Width == 58)
            {
                kapanr.Stop();
            }
        }

        private void UserSetting_Load(object sender, EventArgs e)
        {
            
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void UserSetting_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void UserSetting_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void UserSetting_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true)
                panel6.Visible = false;
            panel2.Visible = true;
            
                
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(panel2.Visible==true)
                panel2.Visible = false;
            
                panel6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bit = new Bitmap(open.FileName);
                    pictureBox5.Image = bit;
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            AilurusOSPanel ailurusOSPanel = new AilurusOSPanel();
            ailurusOSPanel.ResimDegistir(pictureBox5.Image);
                ailurusOSPanel.Show();
            
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                AilurusOSPanel ailurus = new AilurusOSPanel();
                ailurus.contextMenuStrip1.Items[0].Text = "New";
                ailurus.contextMenuStrip1.Items[1].Text = "Refresh";
                ailurus.contextMenuStrip1.Items[2].Text = "Personalize";
                (ailurus.contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDown.Items[0].Text = "Folder";
                (ailurus.contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDown.Items[1].Text = "Notepad";
                ailurus.toolStripDropDownButton1.DropDownItems[0].Text = "Applications";
                ailurus.toolStripDropDownButton1.DropDownItems[1].Text = "Notepad";
                ailurus.toolStripDropDownButton1.DropDownItems[2].Text = "Browser";
                ailurus.toolStripDropDownButton1.DropDownItems[4].Text = "User Settings";
                ailurus.toolStripDropDownButton1.DropDownItems[5].Text = "Session State";
                ailurus.Show();
            }
            if (radioButton5.Checked == true)
            {
                AilurusOSPanel ailurus = new AilurusOSPanel();
                ailurus.contextMenuStrip1.Items[0].Text = "Yeni";
                ailurus.contextMenuStrip1.Items[1].Text = "Yenile";
                ailurus.contextMenuStrip1.Items[2].Text = "Özelleştir";
                (ailurus.contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDown.Items[0].Text = "Dosya";
                (ailurus.contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDown.Items[1].Text = "Not Defteri";
                ailurus.toolStripDropDownButton1.DropDownItems[0].Text = "Uygulamalar";
                ailurus.toolStripDropDownButton1.DropDownItems[1].Text = "Not Defteri";
                ailurus.toolStripDropDownButton1.DropDownItems[2].Text = "Tarayıcı";
                ailurus.toolStripDropDownButton1.DropDownItems[4].Text = "Kullanıcı Ayarları";
                ailurus.toolStripDropDownButton1.DropDownItems[5].Text = "Oturum Durumu";
                ailurus.Show();
            }
        }
    }
}
