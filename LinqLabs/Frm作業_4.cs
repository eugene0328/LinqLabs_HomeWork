using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_4 : Form
    {
        public Frm作業_4()
        {
            InitializeComponent();
            ordersTableAdapter1.Fill(nwDataSet1.Orders);
            order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);
            productsTableAdapter1.Fill(nwDataSet1.Products);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
            int[] nums = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };

            var q = from i in nums
                    group i by Key(i) into g
                    select new { Key = g.Key, Count = g.Count(), Sum = g.Sum(), Avg = g.Average(), Group = g };

            dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                TreeNode tn = treeView1.Nodes.Add(group.Key.ToString());

                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.ToString());
                }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Clear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            string s = "size";
            var q = from f in files
                    orderby f.Length descending
                    group f by SysKey(f.Length, s) into g
                    select new { 檔案大小 = g.Key, Count = g.Count(), Group = g };

            dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                TreeNode tn = treeView1.Nodes.Add(group.檔案大小.ToString());

                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.Name.ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            string s = "year";
            var q = from f in files
                    orderby f.CreationTime.Year descending
                    group f by SysKey(f.CreationTime.Year, s) into g
                    select new { 建立年分 = g.Key, Count = g.Count(), Group = g };

            dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                TreeNode tn = treeView1.Nodes.Add(group.建立年分.ToString());

                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.Name.ToString());
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Clear();
            var q = from p in nwDataSet1.Products
                    group p by ProductKey((int)p.UnitPrice) into g
                    select new { Price = g.Key, Count = g.Count(), Group = g };

            dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                TreeNode tn = treeView1.Nodes.Add(group.Price.ToString());

                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.ProductName.ToString());
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Clear();
            var q = from o in nwDataSet1.Orders
                    group o by o.OrderDate.Year into g
                    select new { Year = g.Key, Count = g.Count(), Group = g };

            dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                TreeNode tn = treeView1.Nodes.Add(group.Year.ToString());

                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.OrderID.ToString());
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Clear();
            var q = from o in nwDataSet1.Orders
                    group o by new { o.OrderDate.Year, o.OrderDate.Month } into g
                    select new { YearMonth = g.Key, Count = g.Count(), Group = g };

            dataGridView1.DataSource = q.ToList();
            foreach (var group in q)
            {
                string s = $"{group.YearMonth.Year}/{group.YearMonth.Month}";
                TreeNode tn = treeView1.Nodes.Add(s);

                foreach (var item in group.Group)
                {
                    tn.Nodes.Add(item.OrderID.ToString());
                }
            }
        }

        private void Clear()
        {
            dataGridView1.Columns.Clear();
            treeView1.Nodes.Clear();
        }

        private static object Key(int i)
        {
            if (i < 11)
                return "小";
            if (i < 21)
                return "中";
            else
                return "大";
        }

        private static object SysKey(long i, string s)
        {
            if (s == "size")
            {
                if (i < 500000)
                    return "小";
                if (i < 1000000)
                    return "中";
                else
                    return "大";
            }
            else if (s == "year")
            {
                if (i < 2015)
                    return "小";
                if (i < 2020)
                    return "中";
                else
                    return "大";
            }
            else
                return null;
        }

        private static object ProductKey(int i)
        {
            if (i < 100)
                return "低";
            if (i < 200)
                return "中";
            else
                return "高";
        }
    }
}
