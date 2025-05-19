using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ABCAlg
{
    public partial class Form1 : Form
    {
        private ABCAlgorithm _abc;
        private Chart _convergenceChart;
        private TextBox _resultTextBox;
        private NumericUpDown _colonySizeNumeric;
        private NumericUpDown _maxIterationsNumeric;
        private NumericUpDown _limitNumeric;
        private NumericUpDown _dimensionNumeric;
        private ComboBox _functionComboBox;
        private Button _solveButton;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Form boyutunu ayarla
            this.Size = new Size(1000, 700);
            this.Text = "ABC Algoritması";

            // Kontrolleri oluştur
            _colonySizeNumeric = new NumericUpDown
            {
                Location = new Point(20, 20),
                Minimum = 10,
                Maximum = 1000,
                Value = 50,
                Width = 100
            };

            _maxIterationsNumeric = new NumericUpDown
            {
                Location = new Point(20, 50),
                Minimum = 100,
                Maximum = 10000,
                Value = 1000,
                Width = 100
            };

            _limitNumeric = new NumericUpDown
            {
                Location = new Point(20, 80),
                Minimum = 10,
                Maximum = 1000,
                Value = 100,
                Width = 100
            };

            _dimensionNumeric = new NumericUpDown
            {
                Location = new Point(20, 110),
                Minimum = 2,
                Maximum = 30,
                Value = 2,
                Width = 100
            };

            _functionComboBox = new ComboBox
            {
                Location = new Point(20, 140),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _functionComboBox.Items.AddRange(new string[] { "Sphere", "Rosenbrock", "Rastrigin" });
            _functionComboBox.SelectedIndex = 0;

            _solveButton = new Button
            {
                Location = new Point(20, 170),
                Text = "Çöz",
                Width = 100
            };
            _solveButton.Click += SolveButton_Click;

            _resultTextBox = new TextBox
            {
                Location = new Point(20, 210),
                Multiline = true,
                Width = 300,
                Height = 400,
                ReadOnly = true,
                Font = new Font("Consolas", 10)
            };

            _convergenceChart = new Chart
            {
                Location = new Point(340, 20),
                Size = new Size(600, 600)
            };

            var chartArea = new ChartArea();
            chartArea.AxisX.Title = "İterasyon";
            chartArea.AxisY.Title = "Amaç Fonksiyonu Değeri";
            chartArea.AxisY.IsLogarithmic = true;
            chartArea.AxisY.LogarithmBase = 10;
            
            var series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Blue;
            series.BorderWidth = 2;
            
            _convergenceChart.ChartAreas.Add(chartArea);
            _convergenceChart.Series.Add(series);

            // Kontrolleri forma ekle
            this.Controls.AddRange(new Control[] {
                _colonySizeNumeric,
                _maxIterationsNumeric,
                _limitNumeric,
                _dimensionNumeric,
                _functionComboBox,
                _solveButton,
                _resultTextBox,
                _convergenceChart
            });

            // Etiketleri ekle
            AddLabel("Kolon Boyutu:", 130, 22);
            AddLabel("Maksimum İterasyon:", 130, 52);
            AddLabel("Limit:", 130, 82);
            AddLabel("Boyut:", 130, 112);
            AddLabel("Test Fonksiyonu:", 180, 143);
        }

        private void AddLabel(string text, int x, int y)
        {
            var label = new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true
            };
            this.Controls.Add(label);
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            try
            {
                _solveButton.Enabled = false;
                Cursor = Cursors.WaitCursor;

                int colonySize = (int)_colonySizeNumeric.Value;
                int maxIterations = (int)_maxIterationsNumeric.Value;
                int limit = (int)_limitNumeric.Value;
                int dimension = (int)_dimensionNumeric.Value;

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
                switch (_functionComboBox.SelectedItem.ToString())
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
                _resultTextBox.Text = $"Test Fonksiyonu: {_functionComboBox.SelectedItem}\r\n";
                _resultTextBox.Text += $"Kolon Boyutu: {colonySize}\r\n";
                _resultTextBox.Text += $"Maksimum İterasyon: {maxIterations}\r\n";
                _resultTextBox.Text += $"Limit: {limit}\r\n";
                _resultTextBox.Text += $"Boyut: {dimension}\r\n\r\n";
                _resultTextBox.Text += $"En İyi Amaç Fonksiyonu Değeri: {_abc.BestFitness:F10}\r\n\r\n";
                _resultTextBox.Text += "En İyi Çözüm:\r\n";
                for (int i = 0; i < _abc.BestSolution.Length; i++)
                {
                    _resultTextBox.Text += $"x{i + 1} = {_abc.BestSolution[i]:F10}\r\n";
                }

                // Yakınsama grafiğini çiz
                _convergenceChart.Series[0].Points.Clear();
                for (int i = 0; i < _abc.ConvergenceHistory.Count; i++)
                {
                    _convergenceChart.Series[0].Points.AddXY(i, _abc.ConvergenceHistory[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _solveButton.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
