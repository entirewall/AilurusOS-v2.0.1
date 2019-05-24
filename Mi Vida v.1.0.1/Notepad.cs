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

namespace Mi_Vida_v._1._0._1
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        

        private void Notepad_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int u = textBox1.TextLength;
                sayarlbl.Text = "Read/" + textBox1.TextLength.ToString();
                if (textBox1.Text == "")
                {
                    sayarlbl.Text = "-/-";
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad ntp = new Notepad();
            ntp.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Select Location";
                saveFileDialog1.Filter = "(*.doc)|*.doc|(*.txt)|*.txt|Tüm dosyalar(*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.InitialDirectory = "C:\\";
                saveFileDialog1.ShowDialog();
                StreamWriter Kaydet = new StreamWriter(saveFileDialog1.FileName);
                Kaydet.WriteLine(textBox1.Text);
                Kaydet.Close();
                MessageBox.Show("The source text document is printed.");
            }
            catch
            {
                MessageBox.Show("The source text document has not been printed!");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printPreviewDialog1.TopMost = true;
            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }

        private void characterSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowDialog();
            /*fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;*/
            fontDlg.MaxSize = 40;
            fontDlg.MinSize = 22;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDlg.Font;
            }

        }
    }
}
