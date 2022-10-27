namespace JSFW.Todo
{
    partial class CompliteRemarkEditForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new JSFW.Todo.Label();
            this.rdoHigh = new System.Windows.Forms.RadioButton();
            this.rdoMedium = new System.Windows.Forms.RadioButton();
            this.rdoLvLow = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rdoTime3day = new System.Windows.Forms.RadioButton();
            this.rdoTime2d = new System.Windows.Forms.RadioButton();
            this.rdoTime1_5h = new System.Windows.Forms.RadioButton();
            this.rdoTime8h = new System.Windows.Forms.RadioButton();
            this.rdoTime3h = new System.Windows.Forms.RadioButton();
            this.rdoTime1h = new System.Windows.Forms.RadioButton();
            this.rdoTime30m = new System.Windows.Forms.RadioButton();
            this.numMinute = new System.Windows.Forms.NumericUpDown();
            this.numHour = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.label7 = new JSFW.Todo.Label();
            this.label6 = new JSFW.Todo.Label();
            this.label5 = new JSFW.Todo.Label();
            this.label4 = new JSFW.Todo.Label();
            this.lbTotalMinute = new JSFW.Todo.Label();
            this.label8 = new JSFW.Todo.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("굴림체", 9F);
            this.textBox1.Location = new System.Drawing.Point(8, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(588, 79);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(212, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(300, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(524, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 28);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "이슈";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "내용";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(8, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(588, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "완료?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rdoHigh);
            this.panel1.Controls.Add(this.rdoMedium);
            this.panel1.Controls.Add(this.rdoLvLow);
            this.panel1.Location = new System.Drawing.Point(8, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 30);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "난이도 : ";
            // 
            // rdoHigh
            // 
            this.rdoHigh.AutoSize = true;
            this.rdoHigh.Location = new System.Drawing.Point(226, 7);
            this.rdoHigh.Name = "rdoHigh";
            this.rdoHigh.Size = new System.Drawing.Size(47, 16);
            this.rdoHigh.TabIndex = 0;
            this.rdoHigh.TabStop = true;
            this.rdoHigh.Text = "높음";
            this.rdoHigh.UseVisualStyleBackColor = true;
            // 
            // rdoMedium
            // 
            this.rdoMedium.AutoSize = true;
            this.rdoMedium.Location = new System.Drawing.Point(162, 7);
            this.rdoMedium.Name = "rdoMedium";
            this.rdoMedium.Size = new System.Drawing.Size(47, 16);
            this.rdoMedium.TabIndex = 0;
            this.rdoMedium.TabStop = true;
            this.rdoMedium.Text = "중간";
            this.rdoMedium.UseVisualStyleBackColor = true;
            // 
            // rdoLvLow
            // 
            this.rdoLvLow.AutoSize = true;
            this.rdoLvLow.Checked = true;
            this.rdoLvLow.Location = new System.Drawing.Point(98, 7);
            this.rdoLvLow.Name = "rdoLvLow";
            this.rdoLvLow.Size = new System.Drawing.Size(47, 16);
            this.rdoLvLow.TabIndex = 0;
            this.rdoLvLow.TabStop = true;
            this.rdoLvLow.Text = "낮음";
            this.rdoLvLow.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbTotalMinute);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.rdoTime3day);
            this.panel2.Controls.Add(this.rdoTime2d);
            this.panel2.Controls.Add(this.rdoTime1_5h);
            this.panel2.Controls.Add(this.rdoTime8h);
            this.panel2.Controls.Add(this.rdoTime3h);
            this.panel2.Controls.Add(this.rdoTime1h);
            this.panel2.Controls.Add(this.rdoTime30m);
            this.panel2.Controls.Add(this.numMinute);
            this.panel2.Controls.Add(this.numHour);
            this.panel2.Controls.Add(this.numDay);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(8, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 60);
            this.panel2.TabIndex = 4;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(493, 38);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(69, 16);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "3일 이상";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rdoTime3day
            // 
            this.rdoTime3day.AutoSize = true;
            this.rdoTime3day.Location = new System.Drawing.Point(444, 38);
            this.rdoTime3day.Name = "rdoTime3day";
            this.rdoTime3day.Size = new System.Drawing.Size(41, 16);
            this.rdoTime3day.TabIndex = 3;
            this.rdoTime3day.Text = "3일";
            this.rdoTime3day.UseVisualStyleBackColor = true;
            this.rdoTime3day.CheckedChanged += new System.EventHandler(this.rdoTime3day_CheckedChanged);
            // 
            // rdoTime2d
            // 
            this.rdoTime2d.AutoSize = true;
            this.rdoTime2d.Location = new System.Drawing.Point(395, 38);
            this.rdoTime2d.Name = "rdoTime2d";
            this.rdoTime2d.Size = new System.Drawing.Size(41, 16);
            this.rdoTime2d.TabIndex = 3;
            this.rdoTime2d.Text = "2일";
            this.rdoTime2d.UseVisualStyleBackColor = true;
            this.rdoTime2d.CheckedChanged += new System.EventHandler(this.rdoTime2d_CheckedChanged);
            // 
            // rdoTime1_5h
            // 
            this.rdoTime1_5h.AutoSize = true;
            this.rdoTime1_5h.Location = new System.Drawing.Point(336, 38);
            this.rdoTime1_5h.Name = "rdoTime1_5h";
            this.rdoTime1_5h.Size = new System.Drawing.Size(51, 16);
            this.rdoTime1_5h.TabIndex = 3;
            this.rdoTime1_5h.Text = "1.5일";
            this.rdoTime1_5h.UseVisualStyleBackColor = true;
            this.rdoTime1_5h.CheckedChanged += new System.EventHandler(this.rdoTime1_5h_CheckedChanged);
            // 
            // rdoTime8h
            // 
            this.rdoTime8h.AutoSize = true;
            this.rdoTime8h.Location = new System.Drawing.Point(275, 38);
            this.rdoTime8h.Name = "rdoTime8h";
            this.rdoTime8h.Size = new System.Drawing.Size(53, 16);
            this.rdoTime8h.TabIndex = 3;
            this.rdoTime8h.Text = "8시간";
            this.rdoTime8h.UseVisualStyleBackColor = true;
            this.rdoTime8h.CheckedChanged += new System.EventHandler(this.rdoTime8h_CheckedChanged);
            // 
            // rdoTime3h
            // 
            this.rdoTime3h.AutoSize = true;
            this.rdoTime3h.Checked = true;
            this.rdoTime3h.Location = new System.Drawing.Point(214, 38);
            this.rdoTime3h.Name = "rdoTime3h";
            this.rdoTime3h.Size = new System.Drawing.Size(53, 16);
            this.rdoTime3h.TabIndex = 3;
            this.rdoTime3h.TabStop = true;
            this.rdoTime3h.Text = "3시간";
            this.rdoTime3h.UseVisualStyleBackColor = true;
            this.rdoTime3h.CheckedChanged += new System.EventHandler(this.rdoTime3h_CheckedChanged);
            // 
            // rdoTime1h
            // 
            this.rdoTime1h.AutoSize = true;
            this.rdoTime1h.Location = new System.Drawing.Point(153, 38);
            this.rdoTime1h.Name = "rdoTime1h";
            this.rdoTime1h.Size = new System.Drawing.Size(53, 16);
            this.rdoTime1h.TabIndex = 3;
            this.rdoTime1h.Text = "1시간";
            this.rdoTime1h.UseVisualStyleBackColor = true;
            this.rdoTime1h.CheckedChanged += new System.EventHandler(this.rdoTime1h_CheckedChanged);
            // 
            // rdoTime30m
            // 
            this.rdoTime30m.AutoSize = true;
            this.rdoTime30m.Location = new System.Drawing.Point(98, 38);
            this.rdoTime30m.Name = "rdoTime30m";
            this.rdoTime30m.Size = new System.Drawing.Size(47, 16);
            this.rdoTime30m.TabIndex = 3;
            this.rdoTime30m.Text = "30분";
            this.rdoTime30m.UseVisualStyleBackColor = true;
            this.rdoTime30m.CheckedChanged += new System.EventHandler(this.rdoTime30m_CheckedChanged);
            // 
            // numMinute
            // 
            this.numMinute.Location = new System.Drawing.Point(266, 8);
            this.numMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinute.Name = "numMinute";
            this.numMinute.Size = new System.Drawing.Size(47, 21);
            this.numMinute.TabIndex = 2;
            // 
            // numHour
            // 
            this.numHour.Location = new System.Drawing.Point(182, 8);
            this.numHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(47, 21);
            this.numHour.TabIndex = 2;
            this.numHour.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numDay
            // 
            this.numDay.Location = new System.Drawing.Point(98, 8);
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(47, 21);
            this.numDay.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "분";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "시";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "일";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "소요시간 : ";
            // 
            // lbTotalMinute
            // 
            this.lbTotalMinute.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTotalMinute.Location = new System.Drawing.Point(355, 6);
            this.lbTotalMinute.Name = "lbTotalMinute";
            this.lbTotalMinute.Size = new System.Drawing.Size(226, 23);
            this.lbTotalMinute.TabIndex = 4;
            this.lbTotalMinute.Text = "=  ";
            this.lbTotalMinute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(6, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "(1일 = 8시간)";
            // 
            // CompliteRemarkEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 295);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CompliteRemarkEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "요청내용 처리 내역 입력";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private Label label3;
        private System.Windows.Forms.RadioButton rdoHigh;
        private System.Windows.Forms.RadioButton rdoMedium;
        private System.Windows.Forms.RadioButton rdoLvLow;
        private System.Windows.Forms.Panel panel2;
        private Label label4;
        private System.Windows.Forms.NumericUpDown numMinute;
        private System.Windows.Forms.NumericUpDown numHour;
        private System.Windows.Forms.NumericUpDown numDay;
        private Label label7;
        private Label label6;
        private Label label5;
        private System.Windows.Forms.RadioButton rdoTime30m;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton rdoTime3day;
        private System.Windows.Forms.RadioButton rdoTime2d;
        private System.Windows.Forms.RadioButton rdoTime1_5h;
        private System.Windows.Forms.RadioButton rdoTime8h;
        private System.Windows.Forms.RadioButton rdoTime3h;
        private System.Windows.Forms.RadioButton rdoTime1h;
        private Label lbTotalMinute;
        private Label label8;
    }
}