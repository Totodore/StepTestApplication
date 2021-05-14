using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using MathNet.Numerics.LinearRegression;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StepTestData1
{
    /// <summary>
    /// Here the TabTestForm where a participant test takes place
    /// </summary>
    public partial class TabTest : Form
    {
        /// <summary>
        /// Current participant infos
        /// </summary>
        private readonly ParticipantInfos participant;
        /// <summary>
        /// The five level values entered by the participant
        /// </summary>
        private readonly List<int> levels = new List<int>(5) { 0, 0, 0, 0, 0 };
        /// <summary>
        /// The height of the step
        /// </summary>
        private readonly int stepHeight;

        /// <summary>
        /// Series objects for the chart
        /// </summary>
        private Series points;
        private Series HR85Serie;
        private Series HR50Serie;
        private Series lines;
        private Series finalLine;

        /// <summary>
        /// The different computed values that perform the test
        /// </summary>
        private double HR50; 
        private double HR85;
        private Rating? rating;
        private int aerobic;
        /// <summary>
        /// We get the participant and the stepHeight from the TestSession form that give us the current participant data
        /// </summary>
        /// <param name="participant">The current participant</param>
        /// <param name="stepHeight">The height of the step</param>
        public TabTest(ParticipantInfos participant, int stepHeight)
        {
            this.participant = participant;
            this.stepHeight = stepHeight;
            InitializeComponent();
        }

        /// <summary>
        /// We the test tab is loading we:
        /// - Compute the 2 HR (50% and 85%)
        /// - Hide the save btn because we can't use it know
        /// - We set all the header values in the UI
        /// - We initialize all the chart series
        /// - We set the two axis with a min and a max
        /// - We draw the HR axis (50 and 85)
        /// </summary>
        private void TabTest_Load(object sender, EventArgs e)
        {
            HR50 = (double)(220 - participant.Age) * 0.5;
            HR85 = (double)(220 - participant.Age) * 0.85;

            SaveBtn.Hide();
            NameVal.Text = participant.Name;
            AgeVal.Text = participant.Age.ToString();
            MaxHRVal.Text = (220 - participant.Age).ToString() + " b/min";
            MaxHR85Val.Text = HR85.ToString() + "b/min";
            DateTestVal.Text = DateTime.Today.ToString().Substring(0, 10);
            StepHeightVal.Text = stepHeight.ToString() + "cm";

            points = Chart.Series.Add("Points");
            lines = Chart.Series.Add("Progression");
            HR50Serie = Chart.Series.Add("HR50");
            HR85Serie = Chart.Series.Add("HR85");
            finalLine = Chart.Series.Add("Computing Line");

            lines.ChartType = SeriesChartType.Line;
            HR50Serie.ChartType = SeriesChartType.Line;
            HR85Serie.ChartType = SeriesChartType.Line;
            finalLine.ChartType = SeriesChartType.Line;
            points.ChartType = SeriesChartType.Point;

            lines.Color = Color.DarkViolet;
            HR50Serie.Color = Color.Red;
            HR85Serie.Color = Color.Red;
            finalLine.Color = Color.ForestGreen;
            points.Color = Color.Black;

            HR50Serie.BorderWidth = 3;
            HR85Serie.BorderWidth = 3;
            lines.BorderWidth = 2;
            points.BorderWidth = 3;
            finalLine.BorderWidth = 3;

            var chartArea = Chart.ChartAreas[0];
            chartArea.AxisX.ArrowStyle = AxisArrowStyle.SharpTriangle;
            chartArea.AxisY.ArrowStyle = AxisArrowStyle.Triangle;
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea.AxisX.Maximum = 76;
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Title = "mlsO2/kg/min";
            chartArea.AxisX.Interval = 2;
            chartArea.AxisY.Minimum = 60;
            chartArea.AxisY.Maximum = (double)(220 - participant.Age);
            chartArea.AxisY.Interval = 10;
            chartArea.AxisY.Title = "Heart Rate (beats/min)";
            DrawHRAxis();
        }

        /// <summary>
        /// This methods is executed each time the user edit the hr levels input
        /// If they are not all set we display nothing
        /// Then if a heart rate is under 10 and above MaxHR it is invalid so we do noting
        /// The we compute the linear function that best fit to the points
        /// We get the aerobic capacity by computing the pre-image of the function at y = MaxHR
        /// We draw the estimated linear function
        /// We draw the vertical line that gives us the aerobic capacity 
        /// We get the rating label, if the rating is not null we display the save btn
        /// </summary>
        private void TryComputeData()
        {
            if (levels.Count != 5)
            {
                SaveBtn.Hide();
                AerobicVal.Text = "Aerobic Capacity:";
                FitnessVal.Text = "Fitness Rating:";
                return;
            }
            foreach (var level in levels)
                if (level < 10 || level > 220 - participant.Age)
                {
                    SaveBtn.Hide();
                    AerobicVal.Text = "Aerobic Capacity:";
                    FitnessVal.Text = "Fitness Rating:";
                    return;
                }
            var maxHR = 220 - participant.Age;
            var xdata = new List<double>();
            var ydata = new List<double>();

            var p = GetLine(); //1: Intercept, 2: Slope
            aerobic = (int)((maxHR - p.Item1) / p.Item2);
            DrawLine((0, p.Item1), (aerobic, maxHR));
            DrawComputingLine((aerobic, maxHR), (aerobic, 0d));
            rating = Utils.ComputeRatingFromScore(aerobic, (int)participant.Age, (Sex)participant.Sex);
            AerobicVal.Text = $"Aerobic Capacity: {aerobic} mlsO2/kg/min";
            FitnessVal.Text = $"Fitness Rating: {rating}";
            Console.WriteLine($"Rating : {rating}");
            if (rating != null)
                SaveBtn.Show();
            else SaveBtn.Hide();
        }

        /// <summary>
        /// Get the estimated linear function from the 5 entered maxHR
        /// - We start by filtering the hr that are ok
        /// - Then for each hr we add the x-coordinate (given by the methods GetAerobicCapacityFromStep) and the y-coordinate (the hr)
        /// - If they are not valid and that there are more one point valid we keep them in our estimation (special case handling)
        /// - We use the simple regression methods to get the most optimized function
        /// </summary>
        /// <returns>A tuple with the intersect and the slope</returns>
        private Tuple<double, double> GetLine()
        {
            var acceptedLevels = levels.Where(el => el < HR85 && el > HR50);
            var xdata = new List<double>();
            var ydata = new List<double>();
            for (int i = 0; i < levels.Count; i++)
            {
                if (acceptedLevels.Count() >= 2 && (levels[i] > HR85 || levels[i] < HR50))
                    continue;
                ydata.Add((int)levels[i]);
                xdata.Add((double)Utils.GetAreobicCapacityFromStep(i, stepHeight));
            }
            return SimpleRegression.Fit(xdata.ToArray(), ydata.ToArray());
        }

        /// <summary>
        /// Draw all the points set by the user
        /// </summary>
        private void DrawPoints()
        {
            points.Points.Clear();
            for (int i = 0; i < levels.Count; i++)
            {
                if (levels[i] < 10 || levels[i] > 220 - participant.Age)
                    continue;
                var abs = (double)Utils.GetAreobicCapacityFromStep(i, stepHeight);
                points.Points.Add(new DataPoint(abs, (int)levels[i]));
            }
        }
        /// <summary>
        /// Draw the linear function estimated from the point
        /// </summary>
        /// <param name="p1">A point representing the beginning of the function</param>
        /// <param name="p2">A point representing the end of the function</param>
        private void DrawLine((double, double) p1, (double, double) p2)
        {
            lines.Points.Clear();
            lines.Points.Add(new DataPoint(p1.Item1, p1.Item2));
            lines.Points.Add(new DataPoint(p2.Item1, p2.Item2));
        }
        /// <summary>
        /// Draw the 2 lines representing the 85% HR and the 50% HR
        /// </summary>
        private void DrawHRAxis()
        {
            HR50Serie.Points.Add(new DataPoint(0d, HR50));
            HR50Serie.Points.Add(new DataPoint(76d, HR50));
            HR85Serie.Points.Add(new DataPoint(0d, HR85));
            HR85Serie.Points.Add(new DataPoint(76d, HR85));
        }
        /// <summary>
        /// Draw the vertical line representing the result (the x-coordinate at the MaxHr=f(x))
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void DrawComputingLine((double, double) p1, (double, double) p2)
        {
            finalLine.Points.Clear();
            finalLine.Points.Add(new DataPoint(p1.Item1, p1.Item2));
            finalLine.Points.Add(new DataPoint(p2.Item1, p2.Item2));
        }
        /// <summary>
        /// The next five methods are just event handler we a HR in changed
        /// The corresponding level is updated.
        /// We then try to compute the data (lines and points) and we draw the points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstLevelValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                levels[0] = int.Parse(FirstLevelValue.Text);
            }
            catch
            {
                FirstLevelValue.Text = "";
            }
            TryComputeData();
            DrawPoints();
        }

        private void SecondLevelValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                levels[1] = int.Parse(SecondLevelValue.Text);
            }
            catch
            {
                SecondLevelValue.Text = "";
            }
            TryComputeData();
            DrawPoints();

        }

        private void ThirdLevelValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                levels[2] = int.Parse(ThirdLevelValue.Text);
            }
            catch
            {
                ThirdLevelValue.Text = "";
            }
            TryComputeData();
            DrawPoints();
        }

        private void FourthLevelValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                levels[3] = int.Parse(FourthLevelValue.Text);
            }
            catch
            {
                FourthLevelValue.Text = "";
            }
            TryComputeData();
            DrawPoints();

        }

        private void FifthLevelValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                levels[4] = int.Parse(FifthLevelValue.Text);
            }
            catch
            {
                FifthLevelValue.Text = "";

            }
            TryComputeData();
            DrawPoints();
        }

        /// <summary>
        /// If the save btn is clicked then we add the participant to the database and we close the current form tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                await DatabaseContext.Add(new Test
                {
                    Age = participant.Age,
                    Date = DateTime.Now,
                    Score = aerobic,
                    Sex = participant.Sex,
                    UserName = participant.Name
                });
            } catch
            {
                MessageBox.Show("Could not save test into database!");
                return;
            }
            Close();
        }
    }
}