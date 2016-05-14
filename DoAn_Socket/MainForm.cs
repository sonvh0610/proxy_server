using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Socket
{
    public partial class MainForm : Form
    {
        private Thread socketThread;
        private Server server;
        private bool isStopped;
        private List<string> lBlacklist;
        private IOBlacklist io;

        public MainForm()
        {
            InitializeComponent();
            this.socketThread = null;
            this.server = null;
            this.isStopped = true;
            this.io = new IOBlacklist("blacklist.conf");
            this.lBlacklist = this.io.ReadBlackList();
            this.FetchData();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.isStopped = false;
            socketThread = new Thread(HandleThread);
            socketThread.IsBackground = true;
            socketThread.Start();
        }
        
        // Because a listener need to enter loop to listen for connections from client
        // This will be lagged if we use blocking IO
        // We create a thread to handle this, anyelse do normally
        private void HandleThread()
        {
            if (txtPort.Text == "")
            {
                MessageBox.Show("Please input your port!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                sttlbProgress.Text = "Running...";
                int port = int.Parse(txtPort.Text);
                server = new Server(port);
                server.StartServer();

                while (!isStopped)
                {
                    server.AcceptConnection();
                }
                server.StopServer();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sttlbProgress.Text = "Stopped";
            isStopped = true;
        }

        private void FetchData()
        {
            if (lBlacklist.Count > 0)
            {
                foreach (string list in lBlacklist)
                {
                    lbBlacklist.Items.Add(list);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text != "")
            {
                string website = txtAdd.Text;
                lBlacklist.Add(website);
                this.io.WriteItem(website);
                lbBlacklist.Items.Add(website);
                txtAdd.Text = "";
            }
            else
            {
                MessageBox.Show("Please input your blocked website!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selectedItem = lbBlacklist.SelectedItem;
            if (selectedItem != null)
            {
                string itemName = selectedItem.ToString();
                var pos = lBlacklist.FindIndex(s => s.Equals(itemName));

                if (pos != -1)
                {
                    lbBlacklist.Items.RemoveAt(pos);
                    lBlacklist.RemoveAt(pos);
                    this.io.WriteBlackList(lBlacklist);
                }
            }
            else
            {
                MessageBox.Show("Please choose website to unblock!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
