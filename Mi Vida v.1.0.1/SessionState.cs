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
    public partial class SessionState : Form
    {
        public SessionState()
        {
            InitializeComponent();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AilurusOSPanel ailurusOSPanel = new AilurusOSPanel();
        }

        private void SessionState_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.CenterToScreen();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPanel login = new LoginPanel();
            login.Show();
            AilurusOSPanel ailurusOSPanel = new AilurusOSPanel();
            ailurusOSPanel.Close();
            
            this.Close();
           
        }
    }
}
