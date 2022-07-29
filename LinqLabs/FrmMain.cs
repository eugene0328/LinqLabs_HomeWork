using LinqLabs.作業;
using MyHomeWork;
using Starter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm作業_1 f = new Frm作業_1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm作業_2 f = new Frm作業_2();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm作業_3 f = new Frm作業_3();
            f.Show();
        }
    }
}
