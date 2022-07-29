using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            ordersTableAdapter1.Fill(nwDataSet1.Orders);
            order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);
            productsTableAdapter1.Fill(nwDataSet1.Products);
        }

        List<Student> students_scores = new List<Student>()
        {
            new Student{ Name = "Peter", Class = "CS_101", Chn = 85, Eng = 80, Math = 55, Gender = "Male" },
            new Student{ Name = "Jack", Class = "CS_102", Chn = 80, Eng = 85, Math = 100, Gender = "Male" },
            new Student{ Name = "May", Class = "CS_101", Chn = 60, Eng = 55, Math = 75, Gender = "Female" },
            new Student{ Name = "Iris", Class = "CS_102", Chn = 85, Eng = 70, Math = 85, Gender = "Female" },
            new Student{ Name = "Rose", Class = "CS_101", Chn = 80, Eng = 85, Math = 55, Gender = "Female" },
            new Student{ Name = "Lisa", Class = "CS_102", Chn = 80, Eng = 80, Math = 85, Gender = "Female" },
        };

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chn { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        int k;

        private void button13_Click(object sender, EventArgs e)
        {
            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)
            if ("".Equals(textBox1.Text))
                return;

            int j = int.Parse(textBox1.Text);
            if (k <= nwDataSet1.Products.Count / j)
                k++;

            var q = from p in nwDataSet1.Products.Take(k * j).Skip((k - 1) * j)
                    orderby p.ProductID
                    select p;

            dataGridView1.DataSource = q.ToList();
            //Distinct()
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();

            this.dataGridView1.DataSource = files;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	


            // 數學不及格 ... 是誰 
            #endregion

            var q = from ss in students_scores
                    //where ss.Name == "Peter" || ss.Name == "Jack" || ss.Name == "May"
                    where ss.Name == "Jack"
                    //where ss.Name != "Jack"
                    //where ss.Math < 60
                    select ss;

            List<Student> list = q.ToList();
            dataGridView1.DataSource = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    where f.CreationTime.Year == 2019
                    //where f.CreationTime.Year == 2017
                    select f;

            List<System.IO.FileInfo> list = q.ToList();
            dataGridView1.DataSource = list;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    where f.Length > 1000000
                    select f;

            List<System.IO.FileInfo> list = q.ToList();
            dataGridView1.DataSource = list;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var q = from o in nwDataSet1.Orders
                    select o;

            dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ("".Equals(comboBox1.Text))
                return;

            int i = int.Parse(comboBox1.Text);

            var q1 = from o in nwDataSet1.Orders
                     where o.OrderDate.Year == i
                    select o;

            dataGridView1.DataSource = q1.ToList();

            var q2 = from ol in nwDataSet1.Order_Details
                     join o in nwDataSet1.Orders on ol.OrderID equals o.OrderID
                     where o.OrderDate.Year == i
                     select ol;

            dataGridView2.DataSource = q2.ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if ("".Equals(textBox1.Text))
                return;

            int j = int.Parse(textBox1.Text);
            if (k > 1)
                k--;

            var q = from p in nwDataSet1.Products.Take(k * j).Skip((k - 1) * j)
                     orderby p.ProductID
                     select p;

            dataGridView1.DataSource = q.ToList();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //new {.....  Min=33, Max=34.}
            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |		

            //var q = from ss in students_scores
            //        where ss.Name == "Peter" || ss.Name == "Jack" || ss.Name == "May"
            //        select new { ss.Name, ss.Chn, ss.Math };

            //個人 所有科的  sum, min, max, avg
            var q = students_scores.Where(s => s.Name == "Jack").Select(s => new
            {
                s.Name,
                sum = s.Chn + s.Eng + s.Math,
                min = Min(s.Chn, s.Eng, s.Math),
                max = Max(s.Chn, s.Eng, s.Math),
                avg = (s.Chn + s.Eng + s.Math) / 3
            });
            dataGridView1.DataSource = q.ToList();
        }

        static object Min(int chn, int eng, int math)
        {
            int[] i = { chn, eng, math };
            return i.Min();
        }

        static object Max(int chn, int eng, int math)
        {
            int[] i = { chn, eng, math };
            return i.Max();
        }
    }
}
