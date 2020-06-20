using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LahoreSocketAsync;
namespace SocketServerWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            acceptAsync.Enabled = true;
            btnStopServer.Enabled = false;
        }

        private void acceptAsync_Click(object sender, EventArgs e)
        {
           
            LahoreSocketAsync.MyServer.StartListeningForIncomingConnection();
            acceptAsync.Enabled = false;
            btnStopServer.Enabled = true;
            label1.Text = string.Format("IP Address: {0} - Port: {1}", LahoreSocketAsync.MyServer.mIp.ToString(), LahoreSocketAsync.MyServer.mPort);

        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            LahoreSocketAsync.MyServer.SendToAll(txtMessage.Text.Trim());
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            LahoreSocketAsync.MyServer.StopServer();
            acceptAsync.Enabled = true;
            btnStopServer.Enabled = false;
            label1.Text = "Server connection ended.";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LahoreSocketAsync.MyServer.StopServer();
        }
    }
}
