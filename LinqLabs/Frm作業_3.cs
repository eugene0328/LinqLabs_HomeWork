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
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
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

        private void button33_Click(object sender, EventArgs e)
        {
            // split=> 數學成績 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
            var q = from ss in students_scores
                    group ss by Key(ss.Math) into g
                    select new { Key = g.Key, Count = g.Count() };

            chart1.DataSource = q.ToList();

            chart1.Series[0].LegendText = "人數";
            chart1.Series[0].XValueMember = "Key";
            chart1.Series[0].YValueMembers = "Count";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            button33.Enabled = false;
            var q = from ss in students_scores
                    select ss;

            chart1.DataSource = q.ToList();

            chart1.Series[0].LegendText = "chn";
            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = "Chn";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[1].XValueMember = "Name";
            chart1.Series[1].YValueMembers = "Eng";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[2].XValueMember = "Name";
            chart1.Series[2].YValueMembers = "Math";
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            button33.Enabled = false;
            var q = from ss in students_scores
                    where ss.Name == "Jack"
                    select ss;
;
            chart1.DataSource = q.ToList();

            chart1.Series[0].LegendText = "chn";
            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = "Chn";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[1].XValueMember = "Name";
            chart1.Series[1].YValueMembers = "Eng";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[2].XValueMember = "Name";
            chart1.Series[2].YValueMembers = "Math";
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private object Key(int i)
        {
            if (i <= 69)
                return "待加強";
            if (i <= 89)
                return "佳";
            else
                return "優良";
        }
    }
}
