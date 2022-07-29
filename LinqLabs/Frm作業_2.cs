using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            productPhotoTableAdapter1.Fill(nwDataSet1.ProductPhoto);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            clear("");
            var q = from p in nwDataSet1.ProductPhoto
                    orderby p.ModifiedDate
                    select p;

            dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear("");
            var q = from p in nwDataSet1.ProductPhoto
                    where p.ModifiedDate >= dateTimePicker1.Value && 
                    p.ModifiedDate <= dateTimePicker2.Value
                    orderby p.ModifiedDate
                    select p;

            dataGridView1.DataSource = q.ToList();           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear("y");
            if ("".Equals(comboBox3.Text))
                return;

            int i = int.Parse(comboBox3.Text);

            var q = from p in nwDataSet1.ProductPhoto
                    where p.ModifiedDate.Year == i
                    orderby p.ModifiedDate
                    select p;

            dataGridView1.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if ("".Equals(comboBox3.Text) || "".Equals(comboBox2.Text))
                return;

            int i = int.Parse(comboBox3.Text);
            string s = "";
            int j = 0, k = 0, l = 0;

            if (comboBox2.Text == "第一季") 
            {
                s = "一"; j = 1;k = 2;l = 3;
            } 
            else if (comboBox2.Text == "第二季")
            {
                s = "二"; j = 4;k = 5;l = 6;
            }
            else if (comboBox2.Text == "第三季")
            {
                s = "三"; j = 7;k = 8;l = 9;
            }
            else if (comboBox2.Text == "第四季")
            {
                s = "四"; j = 10; k = 11; l = 12;
            }
            var q = from p in nwDataSet1.ProductPhoto
                    where p.ModifiedDate.Year == i && (
                    p.ModifiedDate.Month == j ||
                    p.ModifiedDate.Month == k ||
                    p.ModifiedDate.Month == l)
                    orderby p.ModifiedDate
                    select p;

            dataGridView1.DataSource = q.ToList();
            label1.Text = "第" + s + "季腳踏車，共" + dataGridView1.Rows.Count + "筆";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int position = e.RowIndex;
            if (position < 0)
            {
                return;
            }

            var q = nwDataSet1.ProductPhoto.OrderBy(p => p.ModifiedDate).Select(p => p.LargePhoto);
            pictureBox1.Image = Image.FromStream(new MemoryStream(q.ToList()[position]));
        }

        private void Frm作業_2_Load(object sender, EventArgs e)
        {
            var q = (from p in nwDataSet1.ProductPhoto
                    orderby p.ModifiedDate.Year
                    select p.ModifiedDate.Year).Distinct();
            foreach (int i in q)
                comboBox3.Items.Add(i);
        }

        private void clear(string s) {
            label1.Text = "";
            comboBox2.Text = "";
            if (!"y".Equals(s))
                comboBox3.Text = "";
        }
    }
}
