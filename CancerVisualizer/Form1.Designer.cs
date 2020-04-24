namespace CancerVisualizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_load = new System.Windows.Forms.Button();
            this.outputGrBx = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.richTxtBxInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox_zoom = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel_label = new System.Windows.Forms.Panel();
            this.pcBx_label = new System.Windows.Forms.PictureBox();
            this.panel_cancer = new System.Windows.Forms.Panel();
            this.pcBx_cancer = new System.Windows.Forms.PictureBox();
            this.groupBox_wsi = new System.Windows.Forms.GroupBox();
            this.cmbBox_experiments = new System.Windows.Forms.ComboBox();
            this.groupBox_accuracy = new System.Windows.Forms.GroupBox();
            this.button_class8 = new System.Windows.Forms.Button();
            this.button_class7 = new System.Windows.Forms.Button();
            this.button_class6 = new System.Windows.Forms.Button();
            this.button_class5 = new System.Windows.Forms.Button();
            this.button_class4 = new System.Windows.Forms.Button();
            this.button_class3 = new System.Windows.Forms.Button();
            this.button_class2 = new System.Windows.Forms.Button();
            this.button_class1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Statistic = new System.Windows.Forms.Button();
            this.btn_Backward = new System.Windows.Forms.Button();
            this.btn_Forward = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_TODO = new System.Windows.Forms.Label();
            this.outputGrBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox_zoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel_label.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBx_label)).BeginInit();
            this.panel_cancer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBx_cancer)).BeginInit();
            this.groupBox_accuracy.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load.Location = new System.Drawing.Point(24, 25);
            this.btn_load.Margin = new System.Windows.Forms.Padding(6);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(272, 88);
            this.btn_load.TabIndex = 2;
            this.btn_load.Text = "Load tissue sample";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // outputGrBx
            // 
            this.outputGrBx.Controls.Add(this.chart1);
            this.outputGrBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputGrBx.Location = new System.Drawing.Point(24, 377);
            this.outputGrBx.Margin = new System.Windows.Forms.Padding(6);
            this.outputGrBx.Name = "outputGrBx";
            this.outputGrBx.Padding = new System.Windows.Forms.Padding(6);
            this.outputGrBx.Size = new System.Drawing.Size(526, 823);
            this.outputGrBx.TabIndex = 6;
            this.outputGrBx.TabStop = false;
            this.outputGrBx.Text = "Probability distribution of the prediction";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 81);
            this.chart1.Margin = new System.Windows.Forms.Padding(6);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(502, 715);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            // 
            // richTxtBxInfo
            // 
            this.richTxtBxInfo.Location = new System.Drawing.Point(24, 188);
            this.richTxtBxInfo.Margin = new System.Windows.Forms.Padding(6);
            this.richTxtBxInfo.Name = "richTxtBxInfo";
            this.richTxtBxInfo.Size = new System.Drawing.Size(522, 173);
            this.richTxtBxInfo.TabIndex = 7;
            this.richTxtBxInfo.Text = "";
            // 
            // groupBox_zoom
            // 
            this.groupBox_zoom.Controls.Add(this.trackBar1);
            this.groupBox_zoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_zoom.Location = new System.Drawing.Point(868, 23);
            this.groupBox_zoom.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_zoom.Name = "groupBox_zoom";
            this.groupBox_zoom.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_zoom.Size = new System.Drawing.Size(2080, 154);
            this.groupBox_zoom.TabIndex = 21;
            this.groupBox_zoom.TabStop = false;
            this.groupBox_zoom.Text = "Zoom";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 40);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(6);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(2028, 90);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel_label
            // 
            this.panel_label.AutoScroll = true;
            this.panel_label.Controls.Add(this.pcBx_label);
            this.panel_label.Location = new System.Drawing.Point(1902, 238);
            this.panel_label.Margin = new System.Windows.Forms.Padding(6);
            this.panel_label.Name = "panel_label";
            this.panel_label.Size = new System.Drawing.Size(1000, 962);
            this.panel_label.TabIndex = 23;
            this.panel_label.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel_label_Scroll);
            // 
            // pcBx_label
            // 
            this.pcBx_label.Location = new System.Drawing.Point(6, 6);
            this.pcBx_label.Margin = new System.Windows.Forms.Padding(6);
            this.pcBx_label.Name = "pcBx_label";
            this.pcBx_label.Size = new System.Drawing.Size(1000, 962);
            this.pcBx_label.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcBx_label.TabIndex = 0;
            this.pcBx_label.TabStop = false;
            this.pcBx_label.Click += new System.EventHandler(this.pcBx_cancer_Click);
            this.pcBx_label.Paint += new System.Windows.Forms.PaintEventHandler(this.pcBx_label_Paint);
            // 
            // panel_cancer
            // 
            this.panel_cancer.AutoScroll = true;
            this.panel_cancer.Controls.Add(this.pcBx_cancer);
            this.panel_cancer.Location = new System.Drawing.Point(878, 238);
            this.panel_cancer.Margin = new System.Windows.Forms.Padding(6);
            this.panel_cancer.Name = "panel_cancer";
            this.panel_cancer.Size = new System.Drawing.Size(1000, 962);
            this.panel_cancer.TabIndex = 22;
            this.panel_cancer.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel_cancer_Scroll);
            this.panel_cancer.MouseEnter += new System.EventHandler(this.panel_cancer_MouseEnter);
            // 
            // pcBx_cancer
            // 
            this.pcBx_cancer.Location = new System.Drawing.Point(6, 6);
            this.pcBx_cancer.Margin = new System.Windows.Forms.Padding(6);
            this.pcBx_cancer.Name = "pcBx_cancer";
            this.pcBx_cancer.Size = new System.Drawing.Size(1000, 962);
            this.pcBx_cancer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcBx_cancer.TabIndex = 0;
            this.pcBx_cancer.TabStop = false;
            this.pcBx_cancer.Click += new System.EventHandler(this.pcBx_cancer_Click);
            this.pcBx_cancer.Paint += new System.Windows.Forms.PaintEventHandler(this.pcBx_cancer_Paint);
            // 
            // groupBox_wsi
            // 
            this.groupBox_wsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_wsi.Location = new System.Drawing.Point(868, 188);
            this.groupBox_wsi.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_wsi.Name = "groupBox_wsi";
            this.groupBox_wsi.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_wsi.Size = new System.Drawing.Size(2080, 1017);
            this.groupBox_wsi.TabIndex = 24;
            this.groupBox_wsi.TabStop = false;
            this.groupBox_wsi.Text = "Tissue and corresponding labelmap";
            // 
            // cmbBox_experiments
            // 
            this.cmbBox_experiments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBox_experiments.FormattingEnabled = true;
            this.cmbBox_experiments.Location = new System.Drawing.Point(308, 44);
            this.cmbBox_experiments.Margin = new System.Windows.Forms.Padding(6);
            this.cmbBox_experiments.Name = "cmbBox_experiments";
            this.cmbBox_experiments.Size = new System.Drawing.Size(238, 45);
            this.cmbBox_experiments.TabIndex = 25;
            // 
            // groupBox_accuracy
            // 
            this.groupBox_accuracy.Controls.Add(this.button_class8);
            this.groupBox_accuracy.Controls.Add(this.button_class7);
            this.groupBox_accuracy.Controls.Add(this.button_class6);
            this.groupBox_accuracy.Controls.Add(this.button_class5);
            this.groupBox_accuracy.Controls.Add(this.button_class4);
            this.groupBox_accuracy.Controls.Add(this.button_class3);
            this.groupBox_accuracy.Controls.Add(this.button_class2);
            this.groupBox_accuracy.Controls.Add(this.button_class1);
            this.groupBox_accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_accuracy.Location = new System.Drawing.Point(564, 25);
            this.groupBox_accuracy.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_accuracy.Name = "groupBox_accuracy";
            this.groupBox_accuracy.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_accuracy.Size = new System.Drawing.Size(292, 1181);
            this.groupBox_accuracy.TabIndex = 26;
            this.groupBox_accuracy.TabStop = false;
            this.groupBox_accuracy.Text = "Decision of a pathologist";
            // 
            // button_class8
            // 
            this.button_class8.BackColor = System.Drawing.Color.Black;
            this.button_class8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_class8.Location = new System.Drawing.Point(14, 1041);
            this.button_class8.Margin = new System.Windows.Forms.Padding(6);
            this.button_class8.Name = "button_class8";
            this.button_class8.Size = new System.Drawing.Size(266, 99);
            this.button_class8.TabIndex = 7;
            this.button_class8.Text = "Background";
            this.button_class8.UseVisualStyleBackColor = false;
            this.button_class8.Click += new System.EventHandler(this.button_class8_Click);
            // 
            // button_class7
            // 
            this.button_class7.BackColor = System.Drawing.Color.Silver;
            this.button_class7.Location = new System.Drawing.Point(14, 907);
            this.button_class7.Margin = new System.Windows.Forms.Padding(6);
            this.button_class7.Name = "button_class7";
            this.button_class7.Size = new System.Drawing.Size(266, 99);
            this.button_class7.TabIndex = 6;
            this.button_class7.Text = "Adipose tissue";
            this.button_class7.UseVisualStyleBackColor = false;
            this.button_class7.Click += new System.EventHandler(this.button_class7_Click);
            // 
            // button_class6
            // 
            this.button_class6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_class6.Location = new System.Drawing.Point(14, 773);
            this.button_class6.Margin = new System.Windows.Forms.Padding(6);
            this.button_class6.Name = "button_class6";
            this.button_class6.Size = new System.Drawing.Size(266, 99);
            this.button_class6.TabIndex = 5;
            this.button_class6.Text = "Normal mucosal glands";
            this.button_class6.UseVisualStyleBackColor = false;
            this.button_class6.Click += new System.EventHandler(this.button_class6_Click);
            // 
            // button_class5
            // 
            this.button_class5.BackColor = System.Drawing.Color.Fuchsia;
            this.button_class5.Location = new System.Drawing.Point(14, 639);
            this.button_class5.Margin = new System.Windows.Forms.Padding(6);
            this.button_class5.Name = "button_class5";
            this.button_class5.Size = new System.Drawing.Size(266, 99);
            this.button_class5.TabIndex = 4;
            this.button_class5.Text = "Debris";
            this.button_class5.UseVisualStyleBackColor = false;
            this.button_class5.Click += new System.EventHandler(this.button_class5_Click);
            // 
            // button_class4
            // 
            this.button_class4.BackColor = System.Drawing.Color.Blue;
            this.button_class4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_class4.Location = new System.Drawing.Point(12, 505);
            this.button_class4.Margin = new System.Windows.Forms.Padding(6);
            this.button_class4.Name = "button_class4";
            this.button_class4.Size = new System.Drawing.Size(266, 99);
            this.button_class4.TabIndex = 3;
            this.button_class4.Text = "Immune cells";
            this.button_class4.UseVisualStyleBackColor = false;
            this.button_class4.Click += new System.EventHandler(this.button_class4_Click);
            // 
            // button_class3
            // 
            this.button_class3.BackColor = System.Drawing.Color.Yellow;
            this.button_class3.Location = new System.Drawing.Point(12, 371);
            this.button_class3.Margin = new System.Windows.Forms.Padding(6);
            this.button_class3.Name = "button_class3";
            this.button_class3.Size = new System.Drawing.Size(266, 99);
            this.button_class3.TabIndex = 2;
            this.button_class3.Text = "Complex Stroma";
            this.button_class3.UseVisualStyleBackColor = false;
            this.button_class3.Click += new System.EventHandler(this.button_class3_Click);
            // 
            // button_class2
            // 
            this.button_class2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_class2.Location = new System.Drawing.Point(14, 237);
            this.button_class2.Margin = new System.Windows.Forms.Padding(6);
            this.button_class2.Name = "button_class2";
            this.button_class2.Size = new System.Drawing.Size(266, 99);
            this.button_class2.TabIndex = 1;
            this.button_class2.Text = "Simple Stroma";
            this.button_class2.UseVisualStyleBackColor = false;
            this.button_class2.Click += new System.EventHandler(this.button_class2_Click);
            // 
            // button_class1
            // 
            this.button_class1.BackColor = System.Drawing.Color.Red;
            this.button_class1.Location = new System.Drawing.Point(12, 103);
            this.button_class1.Margin = new System.Windows.Forms.Padding(6);
            this.button_class1.Name = "button_class1";
            this.button_class1.Size = new System.Drawing.Size(266, 99);
            this.button_class1.TabIndex = 0;
            this.button_class1.Text = "Tumour";
            this.button_class1.UseVisualStyleBackColor = false;
            this.button_class1.Click += new System.EventHandler(this.button_class1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 37);
            this.label1.TabIndex = 27;
            this.label1.Text = "Prediction result";
            // 
            // btn_Statistic
            // 
            this.btn_Statistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btn_Statistic.Location = new System.Drawing.Point(564, 1117);
            this.btn_Statistic.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Statistic.Name = "btn_Statistic";
            this.btn_Statistic.Size = new System.Drawing.Size(292, 88);
            this.btn_Statistic.TabIndex = 28;
            this.btn_Statistic.Text = "Štatistika";
            this.btn_Statistic.UseVisualStyleBackColor = true;
            this.btn_Statistic.Click += new System.EventHandler(this.btn_Statistic_Click);
            // 
            // btn_Backward
            // 
            this.btn_Backward.Location = new System.Drawing.Point(42, 100);
            this.btn_Backward.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Backward.Name = "btn_Backward";
            this.btn_Backward.Size = new System.Drawing.Size(84, 75);
            this.btn_Backward.TabIndex = 29;
            this.btn_Backward.Text = "<";
            this.btn_Backward.UseVisualStyleBackColor = true;
            this.btn_Backward.Click += new System.EventHandler(this.btn_Backward_Click);
            // 
            // btn_Forward
            // 
            this.btn_Forward.Location = new System.Drawing.Point(170, 100);
            this.btn_Forward.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Forward.Name = "btn_Forward";
            this.btn_Forward.Size = new System.Drawing.Size(84, 75);
            this.btn_Forward.TabIndex = 30;
            this.btn_Forward.Text = ">";
            this.btn_Forward.UseVisualStyleBackColor = true;
            this.btn_Forward.Click += new System.EventHandler(this.btn_Forward_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Backward);
            this.groupBox1.Controls.Add(this.btn_Forward);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(564, 913);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(292, 187);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Navrhované oblasti";
            // 
            // label_TODO
            // 
            this.label_TODO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_TODO.Location = new System.Drawing.Point(564, 44);
            this.label_TODO.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_TODO.Name = "label_TODO";
            this.label_TODO.Size = new System.Drawing.Size(292, 88);
            this.label_TODO.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2972, 1271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox_accuracy);
            this.Controls.Add(this.cmbBox_experiments);
            this.Controls.Add(this.panel_label);
            this.Controls.Add(this.panel_cancer);
            this.Controls.Add(this.groupBox_wsi);
            this.Controls.Add(this.groupBox_zoom);
            this.Controls.Add(this.richTxtBxInfo);
            this.Controls.Add(this.outputGrBx);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Statistic);
            this.Controls.Add(this.label_TODO);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Plain CNN";
            this.outputGrBx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox_zoom.ResumeLayout(false);
            this.groupBox_zoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel_label.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcBx_label)).EndInit();
            this.panel_cancer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcBx_cancer)).EndInit();
            this.groupBox_accuracy.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.GroupBox outputGrBx;
        private System.Windows.Forms.RichTextBox richTxtBxInfo;
        private System.Windows.Forms.GroupBox groupBox_zoom;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel_label;
        private System.Windows.Forms.PictureBox pcBx_label;
        private System.Windows.Forms.Panel panel_cancer;
        private System.Windows.Forms.PictureBox pcBx_cancer;
        private System.Windows.Forms.GroupBox groupBox_wsi;
        private System.Windows.Forms.ComboBox cmbBox_experiments;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox_accuracy;
        private System.Windows.Forms.Button button_class8;
        private System.Windows.Forms.Button button_class7;
        private System.Windows.Forms.Button button_class6;
        private System.Windows.Forms.Button button_class5;
        private System.Windows.Forms.Button button_class4;
        private System.Windows.Forms.Button button_class3;
        private System.Windows.Forms.Button button_class2;
        private System.Windows.Forms.Button button_class1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Statistic;
        private System.Windows.Forms.Button btn_Backward;
        private System.Windows.Forms.Button btn_Forward;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_TODO;
    }
}

