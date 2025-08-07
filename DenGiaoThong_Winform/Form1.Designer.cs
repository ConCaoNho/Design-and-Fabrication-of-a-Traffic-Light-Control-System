namespace DenGiaoThong
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.nudYellowTime = new System.Windows.Forms.NumericUpDown();
            this.nudGreenTime = new System.Windows.Forms.NumericUpDown();
            this.txtRed = new System.Windows.Forms.Label();
            this.txtYellow = new System.Windows.Forms.Label();
            this.txtGreen = new System.Windows.Forms.Label();
            this.btnNightMode = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnWarningMode = new System.Windows.Forms.Button();
            this.lblRedTime = new System.Windows.Forms.Label();
            this.btnPriorityD = new System.Windows.Forms.Button();
            this.btnPriorityN = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.nudLeftTime = new System.Windows.Forms.NumericUpDown();
            this.txtLeft = new System.Windows.Forms.Label();
            this.btnManualMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudYellowTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreenTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(214, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đèn Giao Thông";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(438, 273);
            this.comboBoxPort.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(92, 21);
            this.comboBoxPort.TabIndex = 1;
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnConnect.ForeColor = System.Drawing.Color.Lime;
            this.btnConnect.Location = new System.Drawing.Point(278, 265);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 36);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // nudYellowTime
            // 
            this.nudYellowTime.Location = new System.Drawing.Point(79, 275);
            this.nudYellowTime.Margin = new System.Windows.Forms.Padding(2);
            this.nudYellowTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudYellowTime.Name = "nudYellowTime";
            this.nudYellowTime.Size = new System.Drawing.Size(90, 20);
            this.nudYellowTime.TabIndex = 4;
            this.nudYellowTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudYellowTime.ValueChanged += new System.EventHandler(this.TimeValueChanged);
            // 
            // nudGreenTime
            // 
            this.nudGreenTime.Location = new System.Drawing.Point(79, 310);
            this.nudGreenTime.Margin = new System.Windows.Forms.Padding(2);
            this.nudGreenTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudGreenTime.Name = "nudGreenTime";
            this.nudGreenTime.Size = new System.Drawing.Size(90, 20);
            this.nudGreenTime.TabIndex = 5;
            this.nudGreenTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudGreenTime.ValueChanged += new System.EventHandler(this.TimeValueChanged);
            // 
            // txtRed
            // 
            this.txtRed.AutoSize = true;
            this.txtRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtRed.ForeColor = System.Drawing.Color.Crimson;
            this.txtRed.Location = new System.Drawing.Point(22, 241);
            this.txtRed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(42, 20);
            this.txtRed.TabIndex = 6;
            this.txtRed.Text = "Red";
            // 
            // txtYellow
            // 
            this.txtYellow.AutoSize = true;
            this.txtYellow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtYellow.ForeColor = System.Drawing.Color.Gold;
            this.txtYellow.Location = new System.Drawing.Point(9, 271);
            this.txtYellow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtYellow.Name = "txtYellow";
            this.txtYellow.Size = new System.Drawing.Size(61, 20);
            this.txtYellow.TabIndex = 7;
            this.txtYellow.Text = "Yellow";
            // 
            // txtGreen
            // 
            this.txtGreen.AutoSize = true;
            this.txtGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtGreen.ForeColor = System.Drawing.Color.Lime;
            this.txtGreen.Location = new System.Drawing.Point(12, 306);
            this.txtGreen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(59, 20);
            this.txtGreen.TabIndex = 8;
            this.txtGreen.Text = "Green";
            // 
            // btnNightMode
            // 
            this.btnNightMode.Location = new System.Drawing.Point(20, 63);
            this.btnNightMode.Margin = new System.Windows.Forms.Padding(2);
            this.btnNightMode.Name = "btnNightMode";
            this.btnNightMode.Size = new System.Drawing.Size(81, 36);
            this.btnNightMode.TabIndex = 9;
            this.btnNightMode.Text = "Ban Đêm";
            this.btnNightMode.UseVisualStyleBackColor = true;
            this.btnNightMode.Click += new System.EventHandler(this.btnNightMode_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 167);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 36);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(278, 63);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(252, 148);
            this.txtStatus.TabIndex = 12;
            // 
            // btnWarningMode
            // 
            this.btnWarningMode.Location = new System.Drawing.Point(20, 117);
            this.btnWarningMode.Margin = new System.Windows.Forms.Padding(2);
            this.btnWarningMode.Name = "btnWarningMode";
            this.btnWarningMode.Size = new System.Drawing.Size(81, 36);
            this.btnWarningMode.TabIndex = 13;
            this.btnWarningMode.Text = "Cảnh báo";
            this.btnWarningMode.UseVisualStyleBackColor = true;
            this.btnWarningMode.Click += new System.EventHandler(this.btnWarningMode_Click);
            // 
            // lblRedTime
            // 
            this.lblRedTime.Location = new System.Drawing.Point(79, 244);
            this.lblRedTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRedTime.Name = "lblRedTime";
            this.lblRedTime.Size = new System.Drawing.Size(90, 18);
            this.lblRedTime.TabIndex = 16;
            this.lblRedTime.Text = "10";
            // 
            // btnPriorityD
            // 
            this.btnPriorityD.Location = new System.Drawing.Point(118, 63);
            this.btnPriorityD.Margin = new System.Windows.Forms.Padding(2);
            this.btnPriorityD.Name = "btnPriorityD";
            this.btnPriorityD.Size = new System.Drawing.Size(90, 36);
            this.btnPriorityD.TabIndex = 14;
            this.btnPriorityD.Text = "Ưu tiên Dọc";
            this.btnPriorityD.UseVisualStyleBackColor = true;
            this.btnPriorityD.Click += new System.EventHandler(this.btnPriorityD_Click);
            // 
            // btnPriorityN
            // 
            this.btnPriorityN.Location = new System.Drawing.Point(118, 117);
            this.btnPriorityN.Margin = new System.Windows.Forms.Padding(2);
            this.btnPriorityN.Name = "btnPriorityN";
            this.btnPriorityN.Size = new System.Drawing.Size(90, 36);
            this.btnPriorityN.TabIndex = 15;
            this.btnPriorityN.Text = "Ưu tiên Ngang";
            this.btnPriorityN.UseVisualStyleBackColor = true;
            this.btnPriorityN.Click += new System.EventHandler(this.btnPriorityN_Click);
            // 
            // nudLeftTime
            // 
            this.nudLeftTime.Location = new System.Drawing.Point(79, 345);
            this.nudLeftTime.Margin = new System.Windows.Forms.Padding(2);
            this.nudLeftTime.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudLeftTime.Name = "nudLeftTime";
            this.nudLeftTime.Size = new System.Drawing.Size(90, 20);
            this.nudLeftTime.TabIndex = 6;
            this.nudLeftTime.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudLeftTime.ValueChanged += new System.EventHandler(this.TimeValueChanged);
            // 
            // txtLeft
            // 
            this.txtLeft.AutoSize = true;
            this.txtLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtLeft.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtLeft.Location = new System.Drawing.Point(9, 342);
            this.txtLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(63, 20);
            this.txtLeft.TabIndex = 17;
            this.txtLeft.Text = "Rẽ trái";
            // 
            // btnManualMode
            // 
            this.btnManualMode.Location = new System.Drawing.Point(118, 167);
            this.btnManualMode.Margin = new System.Windows.Forms.Padding(2);
            this.btnManualMode.Name = "btnManualMode";
            this.btnManualMode.Size = new System.Drawing.Size(90, 36);
            this.btnManualMode.TabIndex = 18;
            this.btnManualMode.Text = "Thủ công";
            this.btnManualMode.UseVisualStyleBackColor = true;
            this.btnManualMode.Click += new System.EventHandler(this.btnManualMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 366);
            this.Controls.Add(this.btnPriorityD);
            this.Controls.Add(this.btnPriorityN);
            this.Controls.Add(this.btnWarningMode);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNightMode);
            this.Controls.Add(this.txtGreen);
            this.Controls.Add(this.txtYellow);
            this.Controls.Add(this.txtRed);
            this.Controls.Add(this.lblRedTime);
            this.Controls.Add(this.nudGreenTime);
            this.Controls.Add(this.nudYellowTime);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.nudLeftTime);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnManualMode);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudYellowTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGreenTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.NumericUpDown nudYellowTime;
        private System.Windows.Forms.NumericUpDown nudGreenTime;
        private System.Windows.Forms.Label txtRed;
        private System.Windows.Forms.Label txtYellow;
        private System.Windows.Forms.Label txtGreen;
        private System.Windows.Forms.Button btnNightMode;
        private System.Windows.Forms.Button btnPriorityD;
        private System.Windows.Forms.Button btnPriorityN;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnWarningMode;
        private System.Windows.Forms.Label lblRedTime;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown nudLeftTime;
        private System.Windows.Forms.Label txtLeft;
        private System.Windows.Forms.Button btnManualMode;

    }
}
