using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot.WinForms;
using StudentDiary.Data;

namespace StudentDiary.UI.Forms
{
    public partial class StatisticsForm : Form // Forma studiju statistikas apskatei
    {
        private FormsPlot barChart; // Stabiņu grafiks vidējā atzīme pa priekšmetiem
        private FormsPlot lineChart; // Līniju grafiks atzīmju dinamika laika gaitā

        public StatisticsForm() // Inicializē formu, izveido grafikus un ielādē visus datus
        {
            InitializeComponent();
            SetupCharts();
            LoadSummary();
            LoadBarChart();
            LoadLineChart();
        }

        // Izveido ScottPlot grafiku kontrolus un pievieno tos atbilstošajām cilnēm
        private void SetupCharts()
        {
            barChart = new FormsPlot();
            barChart.Dock = DockStyle.Fill;
            tabBar.Controls.Add(barChart);
            barChart.Interaction.Disable();
            
            lineChart = new FormsPlot();
            lineChart.Dock = DockStyle.Fill;
            tabLine.Controls.Add(lineChart);
            lineChart.Interaction.Disable();
        }

        private void LoadSummary() // Ielādē kopsavilkuma datus
        {
            using var connection = DatabaseCreation.GetConnection();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT AVG(CAST(Value AS REAL)) FROM Grades
                ";
                var result = cmd.ExecuteScalar();
                labelAvgGrade.Text = result == DBNull.Value || result == null ? "Vidējā atzīme: —"
                    : $"Vidējā atzīme: {Convert.ToDouble(result):F2}";
            }
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Grades";
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                labelTotalGrades.Text = $"Kopā atzīmju: {count}";
            }
        }
        private void LoadBarChart() // Ielādē un attēlo stabiņu grafiku
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Subjects.Name,
                       AVG(CAST(Grades.Value AS REAL)) AS Avg
                FROM Subjects
                JOIN Grades ON Grades.SubjectId = Subjects.Id
                GROUP BY Subjects.Id
                ORDER BY Avg DESC
            ";

            var names = new List<string>();
            var values = new List<double>();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                names.Add(reader["Name"].ToString());
                values.Add(Convert.ToDouble(reader["Avg"]));
            }

            if (values.Count == 0)
            {
                barChart.Plot.Title("Nav datu");
                barChart.Refresh();
                return;
            }

            barChart.Plot.Clear();
            var bars = values.Select((v, i) => new ScottPlot.Bar
            {
                Position = i,
                Value = v,
                FillColor = ScottPlot.Color.FromHex("#4A90D9")
            }).ToArray();

            barChart.Plot.Axes.Bottom.TickLabelStyle.FontSize = 16;
            barChart.Plot.Axes.Bottom.TickLabelStyle.Bold = true;

            barChart.Plot.Axes.Left.TickLabelStyle.FontSize = 16;
            barChart.Plot.Axes.Left.TickLabelStyle.Bold = true;
            barChart.Plot.Add.Bars(bars);


            double[] positions = Enumerable.Range(0, names.Count).Select(i => (double)i).ToArray();
            string[] labels = names.ToArray();
            barChart.Plot.Axes.Bottom.SetTicks(positions, labels);

            barChart.Plot.Axes.SetLimitsY(0, 10);
            barChart.Plot.Title("Vidējā atzīme pa priekšmetiem");
            barChart.Plot.YLabel("Atzīme");

            barChart.Refresh();
        }
        private void LoadLineChart() // Ielādē un attēlo līniju grafiku
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Date, AVG(CAST(Value AS REAL)) AS Avg
                FROM Grades
                GROUP BY Date
                ORDER BY Date ASC
            ";

            var dates = new List<double>();
            var values = new List<double>();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = DateTime.Parse(reader["Date"].ToString());
                dates.Add(date.ToOADate());
                values.Add(Convert.ToDouble(reader["Avg"]));
            }

            if (values.Count < 2)
            {
                lineChart.Plot.Title("Nav pietiekami datu");
                lineChart.Refresh();
                return;
            }

            lineChart.Plot.Clear();

            var scatter = lineChart.Plot.Add.Scatter(
                dates.ToArray(),
                values.ToArray()
            );
            scatter.LineWidth = 2;
            scatter.MarkerSize = 8;

            lineChart.Plot.Axes.DateTimeTicksBottom();

            lineChart.Plot.Axes.SetLimitsY(0, 10);
            lineChart.Plot.Title("Atzīmju dinamika");
            lineChart.Plot.YLabel("Atzīme");
            lineChart.Plot.Axes.Bottom.TickLabelStyle.FontSize = 16;
            lineChart.Plot.Axes.Bottom.TickLabelStyle.Bold = true;
            lineChart.Plot.Axes.Left.TickLabelStyle.FontSize = 16;
            lineChart.Plot.Axes.Left.TickLabelStyle.Bold = true;
            lineChart.Refresh();
        }

    }
}