using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace CancerVisualizer
{
    public partial class Form1 : Form
    {
        Point _mousePt = new Point();
        bool _tracking = false;
        const int SCALE = 10;
        const int ORIGINAL_SIZE = 5000;
        const int MIN_SIZE = ORIGINAL_SIZE / SCALE;
        
        byte[] probabilities;
        Bitmap cancer_img;
        Bitmap clear_cancer_img;
        Bitmap label_img;
        string cancer_path;

        Point pointer;
        Point newPointer;
        int oldTrackBarValue = 1;


        #region history
        ExperimentHistory history;
        int[] actualCoord;
        int actualPredicted;
        string timestamp;
        string wsi_name;
        string folderPathToSaveResult;
        int alreadyDoneOwn = 0;
        int alreadyDoneSuggested = 0;
        #endregion

        #region suggested points
        List<int[]> suggestedPoints = new List<int[]>();
        int actualIdx = 0;
        int actualFlag = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();

            ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.button_class1, "tumor epithelium");            
            ToolTip toolTip2 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.button_class2, "homogénna kompozícia, zahŕňa tumor stroma, extra-tumoural stroma a hladký sval");
            ToolTip toolTip3 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.button_class3, "obsahujúce samostatné nádorové bunky a / alebo zopár imunitných buniek");
            ToolTip toolTip4 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.button_class4, "vrátane konglomerátov imunitných buniek a submukóznych lymfoidných folikulov");
            ToolTip toolTip5 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.button_class5, "vrátane nekrózy, krvácania a hlienu (necrosis, hemorrhage and mucus)");
            ToolTip toolTip6 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.button_class6, "normal mucosal glands");
            ToolTip toolTip7 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.button_class7, "tukové tkanivo");
            ToolTip toolTip8 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.button_class8, "pozadie (bez tkaniva)");


            pcBx_cancer.MouseDown += pcBx_cancer_MouseDown;
            pcBx_cancer.MouseMove += pcBx_cancer_MouseMove;
            pcBx_cancer.MouseUp += pcBx_cancer_MouseUp;
            pcBx_label.MouseDown += pcBx_cancer_MouseDown;
            pcBx_label.MouseMove += pcBx_cancer_MouseMove;
            pcBx_label.MouseUp += pcBx_cancer_MouseUp;

            trackBar1.Value = 1;
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 100;
            trackBar1.SmallChange = 1;
            trackBar1.Visible = false;

            panel_cancer.Size = new Size(MIN_SIZE + 5, MIN_SIZE + 5);
            panel_label.Size = new Size(MIN_SIZE + 5, MIN_SIZE + 5);
            pcBx_cancer.Size = new Size(MIN_SIZE, MIN_SIZE);
            pcBx_label.Size = new Size(MIN_SIZE, MIN_SIZE);

            foreach (var item in ExplanationDatabase.experimentsNames)
            {
                cmbBox_experiments.Items.Add(item);
            }
            cmbBox_experiments.DisplayMember = "Name";
            cmbBox_experiments.ValueMember = "Order";
            cmbBox_experiments.SelectedIndex = 6;
            
            chart1.Series[0].ChartType = SeriesChartType.Bar;
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            groupBox_accuracy.Enabled = false;
            
            this.history = new ExperimentHistory();
            this.timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            ExperimentsNames wsiIndexItem = new ExperimentsNames();
            this.Invoke(new MethodInvoker(delegate () { wsiIndexItem = (ExperimentsNames)cmbBox_experiments.SelectedItem; }));
            int wsiIndex = wsiIndexItem.Order;
                        
            cancer_path = ExplanationDatabase.wsi_paths[wsiIndex];
            string label_path = ExplanationDatabase.wsi_labels_paths[wsiIndex];

            richTxtBxInfo.Invoke((MethodInvoker)delegate {
                richTxtBxInfo.Text = $"Načitávam label map";
            });
            cancer_img = new Bitmap(cancer_path);
            label_img = new Bitmap(label_path);
            clear_cancer_img = new Bitmap(cancer_path);
            pcBx_cancer.Image = cancer_img;
            pcBx_label.Image = label_img;

            this.probabilities = LoadDatabase.LoadProbabilities(wsiIndex);

            trackBar1.Visible = true;

            this.wsi_name = wsiIndexItem.Name;
            folderPathToSaveResult = ExplanationDatabase.WSI_DATA_PATH + wsi_name + "\\results";
            Directory.CreateDirectory(folderPathToSaveResult);

            // load sugggested point to examine
            this.suggestedPoints = Utilities.LoadSuggestedPoints(this.wsi_name);
            this.suggestedPoints.Shuffle();
        }       
        

        
        private void panel_cancer_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                panel_label.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                panel_label.VerticalScroll.Value = e.NewValue;
        }

        private void panel_label_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                panel_cancer.HorizontalScroll.Value = e.NewValue;
            else if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                panel_cancer.VerticalScroll.Value = e.NewValue;
        }
                
        Size Zoom()
        {
            const double MaxScale = (double)SCALE; 
            const double MinScale = 1.0;

            double scale = (MaxScale-MinScale) * (trackBar1.Value - trackBar1.Minimum) 
                            / (trackBar1.Maximum - trackBar1.Minimum) + MinScale;

            Size newSize = new Size((int)(MIN_SIZE * scale),
                           (int)(MIN_SIZE * scale));

            return newSize;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 0)
            {
                pcBx_cancer.Size = Zoom();
                pcBx_label.Size = Zoom();
                this.newPointer = this.pointer;
                pcBx_label.Refresh();
                pcBx_cancer.Refresh();
                var point = SetDenormalizePoint(this.newPointer);
                int x = point.X - 250;
                int y = point.Y - 250;
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                this.panel_cancer.AutoScrollPosition = new Point(x, y);
                this.panel_label.AutoScrollPosition = new Point(x, y);
                oldTrackBarValue = trackBar1.Value;
            }
        }
        
        private Point SetNormalizePoint(Point coord)
        {
            const double MaxScale = (double)SCALE;
            const double MinScale = 1.0;
            double scale = (MaxScale - MinScale) * (oldTrackBarValue - trackBar1.Minimum)
                            / (trackBar1.Maximum - trackBar1.Minimum) + MinScale;
            return new Point((int)((double)coord.X / scale), (int)((double)coord.Y / scale));
        }

        private Point SetDenormalizePoint(Point normCoord)
        {
            const double MaxScale = (double)SCALE;
            const double MinScale = 1.0;
            double scale = (MaxScale - MinScale) * (trackBar1.Value - trackBar1.Minimum)
                            / (trackBar1.Maximum - trackBar1.Minimum) + MinScale;
            return new Point((int)((double)normCoord.X * scale), (int)((double)normCoord.Y * scale));
        }

        private void pcBx_cancer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _mousePt = e.Location;
                _tracking = true;
            }
        }
        private void pcBx_cancer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (_tracking &&
             (pcBx_cancer.Image.Width > this.ClientSize.Width ||
             pcBx_cancer.Image.Height > this.ClientSize.Height))
                {
                    panel_cancer.AutoScrollPosition = new Point(-panel_cancer.AutoScrollPosition.X + (_mousePt.X - e.X),
                     -panel_cancer.AutoScrollPosition.Y + (_mousePt.Y - e.Y));
                    panel_label.AutoScrollPosition = new Point(-panel_label.AutoScrollPosition.X + (_mousePt.X - e.X),
                     -panel_label.AutoScrollPosition.Y + (_mousePt.Y - e.Y));
                }
            }
        }

        private void pcBx_cancer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                _tracking = false;
        }

        private void pcBx_cancer_Click(object sender, EventArgs e)
        {
            if (pcBx_cancer.Image != null && pcBx_label.Image != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                if (me.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.pointer = this.SetNormalizePoint(coordinates);
                    this.newPointer = this.SetNormalizePoint(coordinates);

                    var coord = Utilities.GetAbsolutCoordinates(coordinates, ORIGINAL_SIZE, pcBx_cancer);
                    this.actualCoord = coord;
                    int x = coord[0];
                    int y = coord[1];

                    var pxColor = label_img.GetPixel(x, y);
                    int predictedLabel = ExplanationDatabase.GetLabel(pxColor);

                    var vector = LoadDatabase.GetProbabilityVector(probabilities, x, y);
                    string[] classes = new string[8];
                    double[] percent = new double[8];
                    for (int i = 0; i < 8; i++)
                    {
                        classes[i] = ExplanationDatabase.classes[i + 1];
                        percent[i] = Math.Round((double)vector[i] * 100, 2);
                    }
                    Array.Reverse(classes, 0, 8);
                    Array.Reverse(percent, 0, 8);
                    chart1.Series[0].Points.DataBindXY(classes, percent);

                    this.actualPredicted = predictedLabel;
                    //richTxtBxInfo.Text = $"Vybrané tkanivo je {ExplanationDatabase.classes[predictedLabel]}. ";
                    richTxtBxInfo.Text = $"Selected area of the tissue is type {ExplanationDatabase.classes[predictedLabel]}. ";
                    Utilities.HighlightWords(ExplanationDatabase.classes.Values.ToArray(), richTxtBxInfo);

                    groupBox_accuracy.Enabled = true;

                    pcBx_label.Refresh();
                    pcBx_cancer.Refresh();
                }
            }
        }

        private void button_class1_Click(object sender, EventArgs e)
        {
            this.history.predicted.Add(this.actualPredicted);
            this.history.ground_truths.Add(1);
            this.history.coords.Add(actualCoord);
            this.history.flags.Add(this.actualFlag);
            groupBox_accuracy.Enabled = false;
            if (this.actualFlag == 0)
                this.alreadyDoneOwn++;
            else this.alreadyDoneSuggested++;
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
            SaveResults();
            this.actualFlag = 0;
        }

        private void button_class2_Click(object sender, EventArgs e)
        {
            this.history.predicted.Add(this.actualPredicted);
            this.history.ground_truths.Add(2);
            this.history.coords.Add(actualCoord);
            this.history.flags.Add(this.actualFlag);
            if (this.actualFlag == 0)
                this.alreadyDoneOwn++;
            else this.alreadyDoneSuggested++;
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
            groupBox_accuracy.Enabled = false;
            SaveResults();
            this.actualFlag = 0;
        }

        private void button_class3_Click(object sender, EventArgs e)
        {
            this.history.predicted.Add(this.actualPredicted);
            this.history.ground_truths.Add(3);
            this.history.coords.Add(actualCoord);
            this.history.flags.Add(this.actualFlag);
            if (this.actualFlag == 0)
                this.alreadyDoneOwn++;
            else this.alreadyDoneSuggested++;
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
            groupBox_accuracy.Enabled = false;
            SaveResults();
            this.actualFlag = 0;
        }

        private void button_class4_Click(object sender, EventArgs e)
        {
            this.history.predicted.Add(this.actualPredicted);
            this.history.ground_truths.Add(4);
            this.history.coords.Add(actualCoord);
            this.history.flags.Add(this.actualFlag);
            if (this.actualFlag == 0)
                this.alreadyDoneOwn++;
            else this.alreadyDoneSuggested++;
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
            groupBox_accuracy.Enabled = false;
            SaveResults();
            this.actualFlag = 0;
        }

        private void button_class5_Click(object sender, EventArgs e)
        {
            this.history.predicted.Add(this.actualPredicted);
            this.history.ground_truths.Add(5);
            this.history.coords.Add(actualCoord);
            this.history.flags.Add(this.actualFlag);
            if (this.actualFlag == 0)
                this.alreadyDoneOwn++;
            else this.alreadyDoneSuggested++;
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
            groupBox_accuracy.Enabled = false;
            SaveResults();
            this.actualFlag = 0;
        }

        private void button_class6_Click(object sender, EventArgs e)
        {
            this.history.predicted.Add(this.actualPredicted);
            this.history.ground_truths.Add(6);
            this.history.coords.Add(actualCoord);
            this.history.flags.Add(this.actualFlag);
            if (this.actualFlag == 0)
                this.alreadyDoneOwn++;
            else this.alreadyDoneSuggested++;
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
            groupBox_accuracy.Enabled = false;
            SaveResults();
            this.actualFlag = 0;
        }

        private void button_class7_Click(object sender, EventArgs e)
        {
            this.history.predicted.Add(this.actualPredicted);
            this.history.ground_truths.Add(7);
            this.history.coords.Add(actualCoord);
            this.history.flags.Add(this.actualFlag);
            if (this.actualFlag == 0)
                this.alreadyDoneOwn++;
            else this.alreadyDoneSuggested++;
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
            groupBox_accuracy.Enabled = false;
            SaveResults();
            this.actualFlag = 0;
        }

        private void button_class8_Click(object sender, EventArgs e)
        {
            this.history.predicted.Add(this.actualPredicted);
            this.history.ground_truths.Add(8);
            this.history.coords.Add(actualCoord);
            this.history.flags.Add(this.actualFlag);
            if (this.actualFlag == 0)
                this.alreadyDoneOwn++;
            else this.alreadyDoneSuggested++;
            this.label_TODO.Text = $"Diagnostikovaných: {this.alreadyDoneOwn.ToString()} z 25 vlastných " +
                $"{this.alreadyDoneSuggested.ToString()} z 25 navrhnutých oblastí ";
            groupBox_accuracy.Enabled = false;
            SaveResults();
            this.actualFlag = 0;
        }

        private void SaveResults()
        {
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(this.history);
            System.IO.File.WriteAllText(this.folderPathToSaveResult+"\\CNN_"+this.wsi_name+timestamp, jsonResult);
        }

        private void panel_cancer_MouseEnter(object sender, EventArgs e)
        {
            panel_cancer.Focus();
        }

        private void pcBx_cancer_Paint(object sender, PaintEventArgs e)
        {
            var point = SetDenormalizePoint(this.newPointer);
            var g = e.Graphics;

            Pen mypen = new Pen(Color.Red, 5);

            int width = 20;
            int height = 20;
            int x = point.X - width / 2;
            int y = point.Y - height / 2;
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            g.DrawRectangle(mypen, x, y, width, height);
            
        }

        private void pcBx_label_Paint(object sender, PaintEventArgs e)
        {
            var point = SetDenormalizePoint(this.newPointer);
            var g = e.Graphics;

            Pen mypen = new Pen(Color.FromArgb(120, 50, 200), 5);

            int width = 20;
            int height = 20;
            int x = point.X - width / 2;
            int y = point.Y - height / 2;
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            g.DrawRectangle(mypen, x, y, width, height);
            
        }

        private void btn_Statistic_Click(object sender, EventArgs e)
        {
            if(history != null)
            {
                int truePred = 0;
                int falsePred = 0;
                for (int i = 0; i < history.predicted.Count; i++)
                {
                    if (history.predicted[i] == history.ground_truths[i]) truePred++;
                    else falsePred++;
                }

                MessageBox.Show($"Počet testovaných vzoriek bolo {history.predicted.Count.ToString()}.\n" +
                    $"Správne klasifikovaných bolo {truePred.ToString()}.\n" +
                    $"Nesprávne klasifikovaných bolo {falsePred.ToString()}.\n" +
                    $"Celková presnosť bola {Math.Round((double)truePred / (double)history.predicted.Count*100, 2)} %");
            }
        }

        private void btn_Backward_Click(object sender, EventArgs e)
        {
            this.actualIdx--;
            if (actualIdx < 0) actualIdx = suggestedPoints.Count - 1;
            var coord = Utilities.GetRelativeCoordinates(suggestedPoints[actualIdx][1],
                suggestedPoints[actualIdx][0], ORIGINAL_SIZE, pcBx_cancer);
            int x = coord[0];
            int y = coord[1];
            this.actualFlag = suggestedPoints[actualIdx][2];
            MouseEventArgs me = (MouseEventArgs)e;
            pcBx_cancer_Click(sender, new MouseEventArgs(me.Button, me.Clicks, x, y, me.Delta));
            trackBar1_Scroll(sender, e);
        }

        private void btn_Forward_Click(object sender, EventArgs e)
        {
            this.actualIdx++;
            if (actualIdx > suggestedPoints.Count - 1) actualIdx = 0;
            var coord = Utilities.GetRelativeCoordinates(suggestedPoints[actualIdx][1],
                suggestedPoints[actualIdx][0], ORIGINAL_SIZE, pcBx_cancer);
            int x = coord[0];
            int y = coord[1];
            this.actualFlag = suggestedPoints[actualIdx][2];
            MouseEventArgs me = (MouseEventArgs)e;
            pcBx_cancer_Click(sender, new MouseEventArgs(me.Button, me.Clicks, x, y, me.Delta));
            trackBar1_Scroll(sender, e);
        }
                
    }
}
