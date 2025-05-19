using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ABCAlg
{
    public partial class Form1 : Form
    {
        private ABCAlgorithm _abc;

        public Form1()
        {
            InitializeComponent();
            buttonSolve.Click += SolveButton_Click;
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            try
            {
                buttonSolve.Enabled = false;
                Cursor = Cursors.WaitCursor;

                int colonySize = (int)numericColony.Value;
                int maxIterations = (int)numericIter.Value;
                int limit = (int)numericLimit.Value;
                int dimension = (int)numericDim.Value;

                // Sınırları belirle
                double[] lowerBound = new double[dimension];
                double[] upperBound = new double[dimension];
                for (int i = 0; i < dimension; i++)
                {
                    lowerBound[i] = -5.12;
                    upperBound[i] = 5.12;
                }

                // Test fonksiyonunu seç
                Func<double[], double> objectiveFunction;
                switch (comboFunc.SelectedItem.ToString())
                {
                    case "Sphere":
                        objectiveFunction = TestFunctions.Sphere;
                        break;
                    case "Rosenbrock":
                        objectiveFunction = TestFunctions.Rosenbrock;
                        break;
                    case "Rastrigin":
                        objectiveFunction = TestFunctions.Rastrigin;
                        break;
                    default:
                        objectiveFunction = TestFunctions.Sphere;
                        break;
                }

                // ABC algoritmasını oluştur ve çalıştır
                _abc = new ABCAlgorithm(colonySize, maxIterations, limit, dimension, lowerBound, upperBound, objectiveFunction);
                _abc.Solve();

                // Sonuçları göster
                textResult.Text = $"Test Fonksiyonu: {comboFunc.SelectedItem}\r\n";
                textResult.Text += $"Kolon Boyutu: {colonySize}\r\n";
                textResult.Text += $"Maksimum İterasyon: {maxIterations}\r\n";
                textResult.Text += $"Limit: {limit}\r\n";
                textResult.Text += $"Boyut: {dimension}\r\n\r\n";
                textResult.Text += $"En İyi Amaç Fonksiyonu Değeri: {_abc.BestFitness:F10}\r\n\r\n";
                textResult.Text += "En İyi Çözüm:\r\n";
                for (int i = 0; i < _abc.BestSolution.Length; i++)
                {
                    textResult.Text += $"x{i + 1} = {_abc.BestSolution[i]:F10}\r\n";
                }

                // Yakınsama grafiğini çiz
                chartConvergence.Series.Clear();
                if (chartConvergence.ChartAreas.Count == 0)
                {
                    chartConvergence.ChartAreas.Add(new ChartArea());
                }
                var series = new Series
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Blue,
                    BorderWidth = 2
                };
                chartConvergence.Series.Add(series);
                for (int i = 0; i < _abc.ConvergenceHistory.Count; i++)
                {
                    series.Points.AddXY(i, _abc.ConvergenceHistory[i]);
                }
                chartConvergence.ChartAreas[0].AxisX.Title = "İterasyon";
                chartConvergence.ChartAreas[0].AxisY.Title = "Amaç Fonksiyonu Değeri";
                chartConvergence.ChartAreas[0].AxisY.IsLogarithmic = true;
                chartConvergence.ChartAreas[0].AxisY.LogarithmBase = 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonSolve.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }
}
