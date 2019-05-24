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
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
            //timer1.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == label3.Text)
                {
                    AilurusOSPanel frm0x001 = new AilurusOSPanel();
                    frm0x001.ShowDialog();
                    this.Hide();
                }
                else
                {
                    textBox2.Clear();
                    timer1.Start();
                    MessageBox.Show("Please enter UserID or Passwd correctly","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            
            
        }
        
        private void LoginPanel_Load(object sender, EventArgs e)
        {
            try
            {
                string serverName = System.Windows.Forms.SystemInformation.ComputerName;
                label1.Text = serverName.ToString();
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
                this.CenterToScreen();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
           // timer2.Start();
            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer2.Start();
                string randomstring = string.Empty;
                char[] array = "0123456789qwertyuıopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
                Random rn = new Random();
                int number = Convert.ToInt32(textBox3.Text);
                for (int i = 0; i < number; i++)
                {
                    int point = rn.Next(1, array.Length);
                    if (!randomstring.Contains(array.GetValue(point).ToString()))
                        randomstring += array.GetValue(point);
                    else
                        i--;
                }
                label3.Text = randomstring;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void label3_Click(object sender, EventArgs e)
        {
                
        }
        

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                string a;
                a = label3.Text;
                textBox2.Text += a.ToString();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            
        }
    }
}
