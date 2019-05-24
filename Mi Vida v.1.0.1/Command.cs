using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Mi_Vida_v._1._0._1
{
    public partial class Command : Form
    {
        public Command()
        {
            InitializeComponent();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        //private string state = string.Empty;
        private void Command_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("\t\t\t\t\t▂▃▄▅▆▇█▓▒░AilurusOS v.2.0.1░▒▓█▇▆▅▄▃▂");
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "Help" || textBox1.Text== "help" || textBox1.Text== "HELP" || textBox1.Text== "?")
                {
                    string a, b, c, d, j, f, g;
                    a = "clear - Clears previous codes";
                    b = "1P3RL <Domain> / <HostName> / <IP> <options> - Data paths to the specified address";
                    d = "LangChange <en> / <tr> - Change the System Language";
                    listBox1.Items.Add("┣▇ Program All Command ▇▇▇▇▇═─ ");
                    listBox1.Items.Add(a.ToString());
                    listBox1.Items.Add(b.ToString());
                    listBox1.Items.Add(d.ToString());
                    
                }
                if (textBox1.Text == "clear")
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("\t\t\t\t\t▂▃▄▅▆▇█▓▒░AilurusOS v.2.0.1░▒▓█▇▆▅▄▃▂");
                    
                }
                
               /* string z;
                z = "ping";
                
                if (textBox1.Text.Contains(z) == true)
                {
                    z = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                    Ping ping = new Ping();
                    PingReply pr = ping.Send(textBox1.Text);
                    //Ping sınıfından PingReplay sınıfına gelen yanıtları Listbox'uma aktarıyorum.
                    listBox1.Items.Add(string.Format("{0}, {1} --> {2} ms.", pr.Status.ToString(), pr.Address.ToString(), pr.RoundtripTime.ToString()));
                }*/
                    
                 if (textBox1.Text=="1P3RL"||textBox1.Text=="1p3rl")
                  {

                    p3rlloginpanel rlloginpanel = new p3rlloginpanel();
                    rlloginpanel.Show();
                    
                    /* if (NetworkInterface.GetIsNetworkAvailable() == true)
                      {

                      }
                     else
                      {
                        MessageBox.Show("You're not connected to the Internet now.");
                      }*/
                  }
                if (textBox1.Text == "exit")
                {
                    this.Close();
                }

                textBox1.Clear();


            }
            catch (Exception)
            {
                
            }
            
        }
    }
}
