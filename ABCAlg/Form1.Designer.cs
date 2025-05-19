namespace ABCAlg
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
            this.labelColony = new System.Windows.Forms.Label();
            this.labelIter = new System.Windows.Forms.Label();
            this.labelLimit = new System.Windows.Forms.Label();
            this.labelDim = new System.Windows.Forms.Label();
            this.labelFunc = new System.Windows.Forms.Label();
            this.numericColony = new System.Windows.Forms.NumericUpDown();
            this.numericIter = new System.Windows.Forms.NumericUpDown();
            this.numericLimit = new System.Windows.Forms.NumericUpDown();
            this.numericDim = new System.Windows.Forms.NumericUpDown();
            this.comboFunc = new System.Windows.Forms.ComboBox();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.textResult = new System.Windows.Forms.TextBox();
            this.chartConvergence = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.numericColony)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConvergence)).BeginInit();
            this.SuspendLayout();
            // 
            // labelColony
            // 
            this.labelColony.AutoSize = true;
            this.labelColony.Location = new System.Drawing.Point(35, 31);
            this.labelColony.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelColony.Name = "labelColony";
            this.labelColony.Size = new System.Drawing.Size(91, 16);
            this.labelColony.TabIndex = 0;
            this.labelColony.Text = "Koloni Boyutu:";
            // 
            // labelIter
            // 
            this.labelIter.AutoSize = true;
            this.labelIter.Location = new System.Drawing.Point(35, 71);
            this.labelIter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIter.Name = "labelIter";
            this.labelIter.Size = new System.Drawing.Size(133, 16);
            this.labelIter.TabIndex = 1;
            this.labelIter.Text = "Maksimum İterasyon:";
            // 
            // labelLimit
            // 
            this.labelLimit.AutoSize = true;
            this.labelLimit.Location = new System.Drawing.Point(35, 107);
            this.labelLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLimit.Name = "labelLimit";
            this.labelLimit.Size = new System.Drawing.Size(37, 16);
            this.labelLimit.TabIndex = 2;
            this.labelLimit.Text = "Limit:";
            // 
            // labelDim
            // 
            this.labelDim.AutoSize = true;
            this.labelDim.Location = new System.Drawing.Point(35, 148);
            this.labelDim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDim.Name = "labelDim";
            this.labelDim.Size = new System.Drawing.Size(44, 16);
            this.labelDim.TabIndex = 3;
            this.labelDim.Text = "Boyut:";
            // 
            // labelFunc
            // 
            this.labelFunc.AutoSize = true;
            this.labelFunc.Location = new System.Drawing.Point(35, 189);
            this.labelFunc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFunc.Name = "labelFunc";
            this.labelFunc.Size = new System.Drawing.Size(109, 16);
            this.labelFunc.TabIndex = 4;
            this.labelFunc.Text = "Test Fonksiyonu:";
            // 
            // numericColony
            // 
            this.numericColony.Location = new System.Drawing.Point(176, 25);
            this.numericColony.Margin = new System.Windows.Forms.Padding(4);
            this.numericColony.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericColony.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericColony.Name = "numericColony";
            this.numericColony.Size = new System.Drawing.Size(133, 22);
            this.numericColony.TabIndex = 5;
            this.numericColony.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericIter
            // 
            this.numericIter.Location = new System.Drawing.Point(176, 71);
            this.numericIter.Margin = new System.Windows.Forms.Padding(4);
            this.numericIter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericIter.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericIter.Name = "numericIter";
            this.numericIter.Size = new System.Drawing.Size(133, 22);
            this.numericIter.TabIndex = 6;
            this.numericIter.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numericLimit
            // 
            this.numericLimit.Location = new System.Drawing.Point(176, 105);
            this.numericLimit.Margin = new System.Windows.Forms.Padding(4);
            this.numericLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericLimit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericLimit.Name = "numericLimit";
            this.numericLimit.Size = new System.Drawing.Size(133, 22);
            this.numericLimit.TabIndex = 7;
            this.numericLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericDim
            // 
            this.numericDim.Location = new System.Drawing.Point(176, 146);
            this.numericDim.Margin = new System.Windows.Forms.Padding(4);
            this.numericDim.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericDim.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericDim.Name = "numericDim";
            this.numericDim.Size = new System.Drawing.Size(133, 22);
            this.numericDim.TabIndex = 8;
            this.numericDim.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // comboFunc
            // 
            this.comboFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFunc.FormattingEnabled = true;
            this.comboFunc.Items.AddRange(new object[] {
            "Sphere",
            "Rosenbrock",
            "Rastrigin"});
            this.comboFunc.Location = new System.Drawing.Point(176, 186);
            this.comboFunc.Margin = new System.Windows.Forms.Padding(4);
            this.comboFunc.Name = "comboFunc";
            this.comboFunc.Size = new System.Drawing.Size(199, 24);
            this.comboFunc.TabIndex = 5;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(27, 222);
            this.buttonSolve.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(133, 28);
            this.buttonSolve.TabIndex = 6;
            this.buttonSolve.Text = "Çöz";
            this.buttonSolve.UseVisualStyleBackColor = true;
            // 
            // textResult
            // 
            this.textResult.Font = new System.Drawing.Font("Consolas", 10F);
            this.textResult.Location = new System.Drawing.Point(13, 258);
            this.textResult.Margin = new System.Windows.Forms.Padding(4);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.ReadOnly = true;
            this.textResult.Size = new System.Drawing.Size(399, 491);
            this.textResult.TabIndex = 7;
            // 
            // chartConvergence
            // 
            this.chartConvergence.Location = new System.Drawing.Point(437, 11);
            this.chartConvergence.Margin = new System.Windows.Forms.Padding(4);
            this.chartConvergence.Name = "chartConvergence";
            this.chartConvergence.Size = new System.Drawing.Size(688, 738);
            this.chartConvergence.TabIndex = 8;
            this.chartConvergence.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1333, 862);
            this.Controls.Add(this.labelColony);
            this.Controls.Add(this.labelIter);
            this.Controls.Add(this.labelLimit);
            this.Controls.Add(this.labelDim);
            this.Controls.Add(this.labelFunc);
            this.Controls.Add(this.numericColony);
            this.Controls.Add(this.numericIter);
            this.Controls.Add(this.numericLimit);
            this.Controls.Add(this.numericDim);
            this.Controls.Add(this.comboFunc);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.chartConvergence);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ABC Algoritması";
            ((System.ComponentModel.ISupportInitialize)(this.numericColony)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConvergence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelColony;
        private System.Windows.Forms.Label labelIter;
        private System.Windows.Forms.Label labelLimit;
        private System.Windows.Forms.Label labelDim;
        private System.Windows.Forms.Label labelFunc;
        private System.Windows.Forms.NumericUpDown numericColony;
        private System.Windows.Forms.NumericUpDown numericIter;
        private System.Windows.Forms.NumericUpDown numericLimit;
        private System.Windows.Forms.NumericUpDown numericDim;
        private System.Windows.Forms.ComboBox comboFunc;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConvergence;
    }
}

