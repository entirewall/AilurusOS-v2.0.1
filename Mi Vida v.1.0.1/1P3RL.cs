using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Deployment.Application;
using System.Collections;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using Microsoft.Win32;
using System.Management;

namespace Mi_Vida_v._1._0._1
{
    public partial class P3RL : Form
    {
        public P3RL()
        {
            InitializeComponent();
            
        }
        private string IP()
        {
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostByName(host);
            return ip.AddressList[0].ToString();
            //birden fazla ip olabilceğinden burada ilk bulunanı alıyoruz.
        }
         
        private string MAC()
        {
            
                String macadress = string.Empty;
                string mac = null;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    OperationalStatus ot = nic.OperationalStatus;
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macadress = nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
                for (int i = 0; i <= macadress.Length - 1; i++)
                {
                    mac = mac + ":" + macadress.Substring(i, 2);
                    // mac adresini alırken parça parça aldığından 
                    //aralarına : işaretini biz atıyoruz.
                    i++;
                }
                mac = mac.Remove(0, 1);
                // en sonda kalan fazladan : işaretini siliyoruz.
                return mac;
            
        }
        private string OS()
        {
            string a;
            a = "AilurusOS version=2.1.12";
            return a;
        }
        private string NAME()
        {
            string serverName = System.Windows.Forms.SystemInformation.ComputerName;
            return serverName;
        }
        private void Traceroute_Load(object sender, EventArgs e)
        {
            try
            {
                cmbServer.SelectedIndex = 0;
                rgb.Start();
                label3.Text = "PC NAME :"+NAME()+"\n"+"IPv4 :" + IP() + "\n" + "MAC Address :" + MAC() + "\n" + "OS Properties :"+OS();
                label4.Text = "PC NAME :" + NAME() + "\n" + "IPv4 :" + IP() + "\n" + "MAC Address :" + MAC() + "\n" + "OS Properties :" + OS();
                this.TopMost = true;
                this.CenterToScreen();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            delaytmr.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delaytmr.Stop();
        }

        private void delaytmr_Tick(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    Ping ping = new Ping();
                    PingReply pr = ping.Send(textBox1.Text);
                    //Ping sınıfından PingReplay sınıfına gelen yanıtları Listbox'uma aktarıyorum.
                    listBox1.Items.Add(string.Format("{0}, {1} --> {2} ms.", pr.Status.ToString(), pr.Address.ToString(), pr.RoundtripTime.ToString()));
                }
                else
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        Ping ping = new Ping();
                        PingReply pr = ping.Send(textBox1.Text);
                        //Ping sınıfından PingReplay sınıfına gelen yanıtları Listbox'uma aktarıyorum.
                        listBox1.Items.Add(string.Format("{0}, {1} --> {2} ms.", pr.Status.ToString(), pr.Address.ToString(), pr.RoundtripTime.ToString()));
                    }
                    delaytmr.Stop();
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            
        }

        private void rgb_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            label3.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            label4.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        TcpClient tcpWhois;
        NetworkStream nsWhois;
        BufferedStream bfWhois;
        StreamWriter strmSend;
        StreamReader strmRecive;
        private void btnLookUp_Click(object sender, EventArgs e)
        {
            tcpWhois = new TcpClient(cmbServer.SelectedItem.ToString(), 43);

            // We assigned WHOis  Server(from comboBox) and its corresponding Port(43) to the TcpClient Constructor.

            nsWhois = tcpWhois.GetStream(); // Setup the Stream of Tcp client using GetStream() method

            bfWhois = new BufferedStream(nsWhois); // Initializing the Buffer

            strmSend = new StreamWriter(bfWhois);

            strmSend.WriteLine(txtHostName.Text);

            //Sending the Server & Host Name using StreamSend class

            strmSend.Flush(); // Clear the buffer

            txtxResponse.Items.Clear(); // clear the text box

            try

            {

                // Turn to Recive the data from Server

                strmRecive = new StreamReader(bfWhois);

                string response;

                // variable, which 'll store the response from server.

                //Continue the LOOP till it comes to the end (null)     

                while ((response = strmRecive.ReadLine()) != null)

                {

                    //at every response append to New line using "\r\n"

                    txtxResponse.Items.Add(response);

                    //increase the value of Progress Bar :D

                    if (progressBar1.Value < 100)

                        progressBar1.Value += 10;

                }

            }

            catch

            {

                //FOUND any exception

                MessageBox.Show("WHOis Server Error :x", "Error");

            }

           /* catch

            {

                MessageBox.Show("No Internet Connection or Any other Fault", "Error");

            }*/
            

            finally

            {

                try

                {
                    

                    tcpWhois.Close();

                }

                catch

                {
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtxResponse.Items.Clear();
        }
    }
}
