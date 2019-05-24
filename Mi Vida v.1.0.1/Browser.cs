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
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void Browser_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteCustomSource.AddRange(new string[] { "http://www.google.com/", "https://www.facebook.com/", "https://twitter.com/", "https://www.instagram.com/", "http://www.microsoft.com/", "http://www.balikesir.edu.tr/", "https://www.bundlehaber.com/", "https://www.cybrary.it/" });
                webBrowser1.ScriptErrorsSuppressed = true;
                this.TopMost = true;
                this.CenterToScreen();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
          webBrowser1.Navigate(textBox1.Text);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           webBrowser1.GoBack();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            webBrowser1.Navigate("https://www.google.com/");
        }
        
       private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("https://www.google.com/")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
             webBrowser1.Navigate(textBox1.Text);
            }
        }
        
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
