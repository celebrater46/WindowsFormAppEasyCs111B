using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs111B
{
    public partial class Form1 : Form
    {
        private TextBox tb;
        private Label[] lbs = new Label[5];
        private Button bt;
        private TableLayoutPanel tlp;
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Get Othes's Address";
            this.Width = 300;
            this.Height = 200;

            tb = new TextBox();
            tb.Dock = DockStyle.Fill;

            bt = new Button();
            bt.Width = this.Width;
            bt.Text = "Search";
            bt.Dock = DockStyle.Bottom;

            tlp = new TableLayoutPanel();
            tlp.Dock = DockStyle.Fill;

            for (int i = 0; i < lbs.Length; i++)
            {
                lbs[i] = new Label();
                lbs[i].Dock = DockStyle.Fill;
            }

            tlp.ColumnCount = 2;
            tlp.RowCount = 3;

            lbs[0].Text = "Input here.";
            lbs[1].Text = "Host: ";
            lbs[3].Text = "IP: ";

            lbs[0].Parent = tlp;
            tb.Parent = tlp;

            for (int i = 1; i < lbs.Length; i++)
            {
                lbs[i].Parent = tlp;
            }

            bt.Parent = this;
            tlp.Parent = this;
            bt.Click += new EventHandler(BtClick);

        }

        public void BtClick(Object sender, EventArgs e)
        {
            try
            {
                IPHostEntry ih = Dns.GetHostEntry(tb.Text);
                IPAddress ia = ih.AddressList[0];
                lbs[2].Text = ih.HostName;
                lbs[4].Text = ia.ToString();
            }
            catch
            {
                MessageBox.Show("Error.");
            }
        }
    }
}