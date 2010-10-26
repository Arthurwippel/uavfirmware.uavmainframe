using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace UAV_Mainframe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void apriVoloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        /* Baud rate */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Int32.Parse(comboBox1.Text);
            AppTerminale("Baud Rate\t -> " + comboBox1.Text);

        }

        /* Data Bits */
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.DataBits = Int32.Parse(comboBox2.Text);
            AppTerminale("Data Bits\t\t -> " + comboBox2.Text);
        }

        /* Parità */
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "None") serialPort1.Parity = Parity.None;
            if (comboBox3.Text == "Even") serialPort1.Parity = Parity.Even;
            if (comboBox3.Text == "Odd") serialPort1.Parity = Parity.Odd;
            AppTerminale("Parità\t\t -> " + comboBox3.Text);
        }

        /* Stop Bits */
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "1") serialPort1.StopBits = StopBits.One;
            if (comboBox4.Text == "2") serialPort1.StopBits = StopBits.Two;
            AppTerminale("Stop Bits\t\t -> " + comboBox4.Text);
        }

        /* Nome Porta */
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox5.Text;
            AppTerminale("Porta COM\t -> " + comboBox5.Text);
        }

        /* Connetti */
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ConnettiSeriale();
        }

        /* Riconnetti */
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                DisconnettiSeriale();
                ConnettiSeriale();
            }
            else
            {
                ConnettiSeriale();
            }
        }

        /* Disconnetti */
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DisconnettiSeriale();
        }

        //Invia comando manualmente
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write(textBox14.Text);
                AppTerminale(textBox14.Text);
            }
            catch (Exception)
            {
                AppTerminale("ERROR: Invio messaggio fallito");
            }

            textBox14.Text = "";
        }

        

//-----------------------------------------------------------------------------
// Funzioni NON correlate a eventi
//-----------------------------------------------------------------------------
        /* Scrive sul terminale */
        public void AppTerminale(String ConsoleInput)
        {
            textBox5.Text = "\n\r" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\t" + ConsoleInput + "\n\r" + textBox5.Text;
        }

        /* Connetti */
        public void ConnettiSeriale()
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    AppTerminale("SYSTEM: Apertura porta seriale " + serialPort1.PortName);
                    serialPort1.Open();
                }
                else
                {
                    AppTerminale("WARNING: La porta è già aperta!");
                }
            }
            catch (Exception)
            {
                AppTerminale("ERROR: Connessione fallita!");
                serialPort1.Close();
            }
        }

        /* Disconnetti */
        public void DisconnettiSeriale()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    AppTerminale("SYSTEM: Chiusura porta seriale");
                    serialPort1.Close();
                }
                else
                {
                    AppTerminale("WARNING: La porta è già chiusa!");
                }
            }
            catch (Exception)
            {
                AppTerminale("ERROR: Disconnessione fallita!");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            AppTerminale("UAV: " + serialPort1.ReadLine());
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "Disattivato")
                timer1.Stop();
            if (toolStripComboBox1.Text == "1 secondo")
            {
                timer1.Interval = 1000;
                timer1.Start();
            }
            if (toolStripComboBox1.Text == "2 secondi")
            {
                timer1.Interval = 2000;
                timer1.Start();
            }
            if (toolStripComboBox1.Text == "5 secondi")
            {
                timer1.Interval = 5000;
                timer1.Start();
            }
            if (toolStripComboBox1.Text == "10 secondi")
            {
                timer1.Interval = 10000;
                timer1.Start();
            }
            if (toolStripComboBox1.Text == "30 secondi")
            {
                timer1.Interval = 30000;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }




//-----------------------------------------------------------------------------

    }
}
