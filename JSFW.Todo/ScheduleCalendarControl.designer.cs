namespace JSFW.NPT.Controls
{
    partial class ScheduleCalendarControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.todayButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.YearMonthLabel = new JSFW.Todo.Label();
            this.NextWeekButton = new System.Windows.Forms.Button();
            this.PrevWeekButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DayViewPanel = new System.Windows.Forms.Panel();
            this.YearMonthPanel = new System.Windows.Forms.Panel();
            this.SubYearMonthLabel = new JSFW.Todo.Label();
            this.MainYearMonthLabel = new JSFW.Todo.Label();
            this.DaysPanel = new System.Windows.Forms.Panel();
            this.rdo_21 = new System.Windows.Forms.RadioButton();
            this.rdo_20 = new System.Windows.Forms.RadioButton();
            this.rdo_18 = new System.Windows.Forms.RadioButton();
            this.rdo_17 = new System.Windows.Forms.RadioButton();
            this.rdo_12 = new System.Windows.Forms.RadioButton();
            this.rdo_19 = new System.Windows.Forms.RadioButton();
            this.rdo_11 = new System.Windows.Forms.RadioButton();
            this.rdo_16 = new System.Windows.Forms.RadioButton();
            this.rdo_06 = new System.Windows.Forms.RadioButton();
            this.rdo_10 = new System.Windows.Forms.RadioButton();
            this.rdo_15 = new System.Windows.Forms.RadioButton();
            this.rdo_05 = new System.Windows.Forms.RadioButton();
            this.rdo_09 = new System.Windows.Forms.RadioButton();
            this.rdo_14 = new System.Windows.Forms.RadioButton();
            this.rdo_04 = new System.Windows.Forms.RadioButton();
            this.rdo_08 = new System.Windows.Forms.RadioButton();
            this.rdo_13 = new System.Windows.Forms.RadioButton();
            this.rdo_03 = new System.Windows.Forms.RadioButton();
            this.rdo_07 = new System.Windows.Forms.RadioButton();
            this.rdo_02 = new System.Windows.Forms.RadioButton();
            this.rdo_01 = new System.Windows.Forms.RadioButton();
            this.WeekButtonsPanel = new System.Windows.Forms.Panel();
            this.NextWeekViewButton = new System.Windows.Forms.Button();
            this.ThisWeekViewButton = new System.Windows.Forms.Button();
            this.PrevWeekViewButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.DayViewPanel.SuspendLayout();
            this.YearMonthPanel.SuspendLayout();
            this.DaysPanel.SuspendLayout();
            this.WeekButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.todayButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.panel1.Size = new System.Drawing.Size(769, 46);
            this.panel1.TabIndex = 0;
            // 
            // todayButton
            // 
            this.todayButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.todayButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.todayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.todayButton.Location = new System.Drawing.Point(425, 19);
            this.todayButton.Name = "todayButton";
            this.todayButton.Size = new System.Drawing.Size(75, 23);
            this.todayButton.TabIndex = 1;
            this.todayButton.Text = "오늘";
            this.todayButton.UseVisualStyleBackColor = false;
            this.todayButton.Click += new System.EventHandler(this.todayButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.YearMonthLabel);
            this.panel3.Controls.Add(this.NextWeekButton);
            this.panel3.Controls.Add(this.PrevWeekButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(419, 40);
            this.panel3.TabIndex = 0;
            // 
            // YearMonthLabel
            // 
            this.YearMonthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YearMonthLabel.Font = new System.Drawing.Font("굴림체", 15F, System.Drawing.FontStyle.Bold);
            this.YearMonthLabel.Location = new System.Drawing.Point(32, 0);
            this.YearMonthLabel.Name = "YearMonthLabel";
            this.YearMonthLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.YearMonthLabel.Size = new System.Drawing.Size(355, 40);
            this.YearMonthLabel.TabIndex = 2;
            this.YearMonthLabel.Text = "label1";
            this.YearMonthLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // NextWeekButton
            // 
            this.NextWeekButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NextWeekButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.NextWeekButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.NextWeekButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextWeekButton.Location = new System.Drawing.Point(387, 0);
            this.NextWeekButton.Name = "NextWeekButton";
            this.NextWeekButton.Size = new System.Drawing.Size(32, 40);
            this.NextWeekButton.TabIndex = 1;
            this.NextWeekButton.Text = "▷";
            this.NextWeekButton.UseVisualStyleBackColor = false;
            this.NextWeekButton.Click += new System.EventHandler(this.NextWeekButton_Click);
            // 
            // PrevWeekButton
            // 
            this.PrevWeekButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PrevWeekButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.PrevWeekButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.PrevWeekButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevWeekButton.Location = new System.Drawing.Point(0, 0);
            this.PrevWeekButton.Name = "PrevWeekButton";
            this.PrevWeekButton.Size = new System.Drawing.Size(32, 40);
            this.PrevWeekButton.TabIndex = 0;
            this.PrevWeekButton.Text = "◁";
            this.PrevWeekButton.UseVisualStyleBackColor = false;
            this.PrevWeekButton.Click += new System.EventHandler(this.PrevWeekButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DayViewPanel);
            this.panel2.Controls.Add(this.SelectAllButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 116);
            this.panel2.TabIndex = 1;
            // 
            // DayViewPanel
            // 
            this.DayViewPanel.Controls.Add(this.YearMonthPanel);
            this.DayViewPanel.Controls.Add(this.DaysPanel);
            this.DayViewPanel.Controls.Add(this.WeekButtonsPanel);
            this.DayViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DayViewPanel.Location = new System.Drawing.Point(32, 0);
            this.DayViewPanel.Name = "DayViewPanel";
            this.DayViewPanel.Size = new System.Drawing.Size(737, 116);
            this.DayViewPanel.TabIndex = 1;
            // 
            // YearMonthPanel
            // 
            this.YearMonthPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.YearMonthPanel.Controls.Add(this.SubYearMonthLabel);
            this.YearMonthPanel.Controls.Add(this.MainYearMonthLabel);
            this.YearMonthPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YearMonthPanel.Location = new System.Drawing.Point(0, 0);
            this.YearMonthPanel.Name = "YearMonthPanel";
            this.YearMonthPanel.Size = new System.Drawing.Size(737, 46);
            this.YearMonthPanel.TabIndex = 2;
            // 
            // SubYearMonthLabel
            // 
            this.SubYearMonthLabel.AutoEllipsis = true;
            this.SubYearMonthLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SubYearMonthLabel.Font = new System.Drawing.Font("굴림체", 15F, System.Drawing.FontStyle.Bold);
            this.SubYearMonthLabel.Location = new System.Drawing.Point(254, 0);
            this.SubYearMonthLabel.Name = "SubYearMonthLabel";
            this.SubYearMonthLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.SubYearMonthLabel.Size = new System.Drawing.Size(481, 44);
            this.SubYearMonthLabel.TabIndex = 3;
            this.SubYearMonthLabel.Text = "SubYearMonth";
            this.SubYearMonthLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // MainYearMonthLabel
            // 
            this.MainYearMonthLabel.AutoEllipsis = true;
            this.MainYearMonthLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainYearMonthLabel.Font = new System.Drawing.Font("굴림체", 15F, System.Drawing.FontStyle.Bold);
            this.MainYearMonthLabel.Location = new System.Drawing.Point(3, 0);
            this.MainYearMonthLabel.Name = "MainYearMonthLabel";
            this.MainYearMonthLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.MainYearMonthLabel.Size = new System.Drawing.Size(247, 44);
            this.MainYearMonthLabel.TabIndex = 3;
            this.MainYearMonthLabel.Text = "MainYearMonth";
            this.MainYearMonthLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DaysPanel
            // 
            this.DaysPanel.Controls.Add(this.rdo_21);
            this.DaysPanel.Controls.Add(this.rdo_20);
            this.DaysPanel.Controls.Add(this.rdo_18);
            this.DaysPanel.Controls.Add(this.rdo_17);
            this.DaysPanel.Controls.Add(this.rdo_12);
            this.DaysPanel.Controls.Add(this.rdo_19);
            this.DaysPanel.Controls.Add(this.rdo_11);
            this.DaysPanel.Controls.Add(this.rdo_16);
            this.DaysPanel.Controls.Add(this.rdo_06);
            this.DaysPanel.Controls.Add(this.rdo_10);
            this.DaysPanel.Controls.Add(this.rdo_15);
            this.DaysPanel.Controls.Add(this.rdo_05);
            this.DaysPanel.Controls.Add(this.rdo_09);
            this.DaysPanel.Controls.Add(this.rdo_14);
            this.DaysPanel.Controls.Add(this.rdo_04);
            this.DaysPanel.Controls.Add(this.rdo_08);
            this.DaysPanel.Controls.Add(this.rdo_13);
            this.DaysPanel.Controls.Add(this.rdo_03);
            this.DaysPanel.Controls.Add(this.rdo_07);
            this.DaysPanel.Controls.Add(this.rdo_02);
            this.DaysPanel.Controls.Add(this.rdo_01);
            this.DaysPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DaysPanel.Location = new System.Drawing.Point(0, 46);
            this.DaysPanel.Name = "DaysPanel";
            this.DaysPanel.Size = new System.Drawing.Size(737, 38);
            this.DaysPanel.TabIndex = 1;
            // 
            // rdo_21
            // 
            this.rdo_21.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_21.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_21.Location = new System.Drawing.Point(701, 1);
            this.rdo_21.Name = "rdo_21";
            this.rdo_21.Size = new System.Drawing.Size(36, 36);
            this.rdo_21.TabIndex = 0;
            this.rdo_21.TabStop = true;
            this.rdo_21.Text = "R1";
            this.rdo_21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_21.UseVisualStyleBackColor = true;
            this.rdo_21.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_21.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_20
            // 
            this.rdo_20.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_20.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_20.Location = new System.Drawing.Point(666, 1);
            this.rdo_20.Name = "rdo_20";
            this.rdo_20.Size = new System.Drawing.Size(36, 36);
            this.rdo_20.TabIndex = 0;
            this.rdo_20.TabStop = true;
            this.rdo_20.Text = "R1";
            this.rdo_20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_20.UseVisualStyleBackColor = true;
            this.rdo_20.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_20.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_18
            // 
            this.rdo_18.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_18.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_18.Location = new System.Drawing.Point(596, 1);
            this.rdo_18.Name = "rdo_18";
            this.rdo_18.Size = new System.Drawing.Size(36, 36);
            this.rdo_18.TabIndex = 0;
            this.rdo_18.TabStop = true;
            this.rdo_18.Text = "R1";
            this.rdo_18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_18.UseVisualStyleBackColor = true;
            this.rdo_18.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_18.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_17
            // 
            this.rdo_17.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_17.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_17.Location = new System.Drawing.Point(561, 1);
            this.rdo_17.Name = "rdo_17";
            this.rdo_17.Size = new System.Drawing.Size(36, 36);
            this.rdo_17.TabIndex = 0;
            this.rdo_17.TabStop = true;
            this.rdo_17.Text = "R1";
            this.rdo_17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_17.UseVisualStyleBackColor = true;
            this.rdo_17.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_17.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_12
            // 
            this.rdo_12.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_12.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_12.Location = new System.Drawing.Point(386, 1);
            this.rdo_12.Name = "rdo_12";
            this.rdo_12.Size = new System.Drawing.Size(36, 36);
            this.rdo_12.TabIndex = 0;
            this.rdo_12.TabStop = true;
            this.rdo_12.Text = "R1";
            this.rdo_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_12.UseVisualStyleBackColor = true;
            this.rdo_12.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_12.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_19
            // 
            this.rdo_19.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_19.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_19.Location = new System.Drawing.Point(631, 1);
            this.rdo_19.Name = "rdo_19";
            this.rdo_19.Size = new System.Drawing.Size(36, 36);
            this.rdo_19.TabIndex = 0;
            this.rdo_19.TabStop = true;
            this.rdo_19.Text = "R1";
            this.rdo_19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_19.UseVisualStyleBackColor = true;
            this.rdo_19.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_19.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_11
            // 
            this.rdo_11.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_11.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_11.Location = new System.Drawing.Point(351, 1);
            this.rdo_11.Name = "rdo_11";
            this.rdo_11.Size = new System.Drawing.Size(36, 36);
            this.rdo_11.TabIndex = 0;
            this.rdo_11.TabStop = true;
            this.rdo_11.Text = "R1";
            this.rdo_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_11.UseVisualStyleBackColor = true;
            this.rdo_11.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_11.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_16
            // 
            this.rdo_16.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_16.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_16.Location = new System.Drawing.Point(526, 1);
            this.rdo_16.Name = "rdo_16";
            this.rdo_16.Size = new System.Drawing.Size(36, 36);
            this.rdo_16.TabIndex = 0;
            this.rdo_16.TabStop = true;
            this.rdo_16.Text = "R1";
            this.rdo_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_16.UseVisualStyleBackColor = true;
            this.rdo_16.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_16.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_06
            // 
            this.rdo_06.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_06.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_06.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_06.Location = new System.Drawing.Point(176, 1);
            this.rdo_06.Name = "rdo_06";
            this.rdo_06.Size = new System.Drawing.Size(36, 36);
            this.rdo_06.TabIndex = 0;
            this.rdo_06.TabStop = true;
            this.rdo_06.Text = "R1";
            this.rdo_06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_06.UseVisualStyleBackColor = true;
            this.rdo_06.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_06.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_06.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_10
            // 
            this.rdo_10.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_10.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_10.Location = new System.Drawing.Point(316, 1);
            this.rdo_10.Name = "rdo_10";
            this.rdo_10.Size = new System.Drawing.Size(36, 36);
            this.rdo_10.TabIndex = 0;
            this.rdo_10.TabStop = true;
            this.rdo_10.Text = "R1";
            this.rdo_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_10.UseVisualStyleBackColor = true;
            this.rdo_10.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_10.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_15
            // 
            this.rdo_15.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_15.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_15.Location = new System.Drawing.Point(491, 1);
            this.rdo_15.Name = "rdo_15";
            this.rdo_15.Size = new System.Drawing.Size(36, 36);
            this.rdo_15.TabIndex = 0;
            this.rdo_15.TabStop = true;
            this.rdo_15.Text = "R1";
            this.rdo_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_15.UseVisualStyleBackColor = true;
            this.rdo_15.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_15.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_05
            // 
            this.rdo_05.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_05.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_05.Location = new System.Drawing.Point(141, 1);
            this.rdo_05.Name = "rdo_05";
            this.rdo_05.Size = new System.Drawing.Size(36, 36);
            this.rdo_05.TabIndex = 0;
            this.rdo_05.TabStop = true;
            this.rdo_05.Text = "R1";
            this.rdo_05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_05.UseVisualStyleBackColor = true;
            this.rdo_05.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_05.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_05.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_09
            // 
            this.rdo_09.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_09.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_09.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_09.Location = new System.Drawing.Point(281, 1);
            this.rdo_09.Name = "rdo_09";
            this.rdo_09.Size = new System.Drawing.Size(36, 36);
            this.rdo_09.TabIndex = 0;
            this.rdo_09.TabStop = true;
            this.rdo_09.Text = "R1";
            this.rdo_09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_09.UseVisualStyleBackColor = true;
            this.rdo_09.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_09.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_09.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_14
            // 
            this.rdo_14.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_14.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_14.Location = new System.Drawing.Point(456, 1);
            this.rdo_14.Name = "rdo_14";
            this.rdo_14.Size = new System.Drawing.Size(36, 36);
            this.rdo_14.TabIndex = 0;
            this.rdo_14.TabStop = true;
            this.rdo_14.Text = "R1";
            this.rdo_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_14.UseVisualStyleBackColor = true;
            this.rdo_14.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_14.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_04
            // 
            this.rdo_04.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_04.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_04.Location = new System.Drawing.Point(106, 1);
            this.rdo_04.Name = "rdo_04";
            this.rdo_04.Size = new System.Drawing.Size(36, 36);
            this.rdo_04.TabIndex = 0;
            this.rdo_04.TabStop = true;
            this.rdo_04.Text = "R1";
            this.rdo_04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_04.UseVisualStyleBackColor = true;
            this.rdo_04.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_04.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_04.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_08
            // 
            this.rdo_08.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_08.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_08.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_08.Location = new System.Drawing.Point(246, 1);
            this.rdo_08.Name = "rdo_08";
            this.rdo_08.Size = new System.Drawing.Size(36, 36);
            this.rdo_08.TabIndex = 0;
            this.rdo_08.TabStop = true;
            this.rdo_08.Text = "R1";
            this.rdo_08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_08.UseVisualStyleBackColor = true;
            this.rdo_08.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_08.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_08.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_13
            // 
            this.rdo_13.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_13.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_13.Location = new System.Drawing.Point(421, 1);
            this.rdo_13.Name = "rdo_13";
            this.rdo_13.Size = new System.Drawing.Size(36, 36);
            this.rdo_13.TabIndex = 0;
            this.rdo_13.TabStop = true;
            this.rdo_13.Text = "R1";
            this.rdo_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_13.UseVisualStyleBackColor = true;
            this.rdo_13.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_13.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_03
            // 
            this.rdo_03.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_03.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_03.Location = new System.Drawing.Point(71, 1);
            this.rdo_03.Name = "rdo_03";
            this.rdo_03.Size = new System.Drawing.Size(36, 36);
            this.rdo_03.TabIndex = 0;
            this.rdo_03.TabStop = true;
            this.rdo_03.Text = "R1";
            this.rdo_03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_03.UseVisualStyleBackColor = true;
            this.rdo_03.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_03.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_03.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_07
            // 
            this.rdo_07.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_07.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_07.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_07.Location = new System.Drawing.Point(211, 1);
            this.rdo_07.Name = "rdo_07";
            this.rdo_07.Size = new System.Drawing.Size(36, 36);
            this.rdo_07.TabIndex = 0;
            this.rdo_07.TabStop = true;
            this.rdo_07.Text = "R1";
            this.rdo_07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_07.UseVisualStyleBackColor = true;
            this.rdo_07.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_07.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_07.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_02
            // 
            this.rdo_02.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_02.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_02.Location = new System.Drawing.Point(36, 1);
            this.rdo_02.Name = "rdo_02";
            this.rdo_02.Size = new System.Drawing.Size(36, 36);
            this.rdo_02.TabIndex = 0;
            this.rdo_02.TabStop = true;
            this.rdo_02.Text = "R1";
            this.rdo_02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_02.UseVisualStyleBackColor = true;
            this.rdo_02.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_02.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_02.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // rdo_01
            // 
            this.rdo_01.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_01.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdo_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdo_01.Location = new System.Drawing.Point(1, 1);
            this.rdo_01.Name = "rdo_01";
            this.rdo_01.Size = new System.Drawing.Size(36, 36);
            this.rdo_01.TabIndex = 0;
            this.rdo_01.TabStop = true;
            this.rdo_01.Text = "R1";
            this.rdo_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdo_01.UseVisualStyleBackColor = true;
            this.rdo_01.CheckedChanged += new System.EventHandler(this.rdo_DayCheckedChanged);
            this.rdo_01.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdo_DayCheckedChanged);
            this.rdo_01.MouseHover += new System.EventHandler(this.rdo_MouseHover);
            // 
            // WeekButtonsPanel
            // 
            this.WeekButtonsPanel.Controls.Add(this.NextWeekViewButton);
            this.WeekButtonsPanel.Controls.Add(this.ThisWeekViewButton);
            this.WeekButtonsPanel.Controls.Add(this.PrevWeekViewButton);
            this.WeekButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WeekButtonsPanel.Location = new System.Drawing.Point(0, 84);
            this.WeekButtonsPanel.Name = "WeekButtonsPanel";
            this.WeekButtonsPanel.Size = new System.Drawing.Size(737, 32);
            this.WeekButtonsPanel.TabIndex = 0;
            // 
            // NextWeekViewButton
            // 
            this.NextWeekViewButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NextWeekViewButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.NextWeekViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextWeekViewButton.Location = new System.Drawing.Point(491, 0);
            this.NextWeekViewButton.Name = "NextWeekViewButton";
            this.NextWeekViewButton.Size = new System.Drawing.Size(246, 32);
            this.NextWeekViewButton.TabIndex = 0;
            this.NextWeekViewButton.Text = "차주";
            this.NextWeekViewButton.UseVisualStyleBackColor = false;
            this.NextWeekViewButton.Click += new System.EventHandler(this.NextWeekViewButton_Click);
            // 
            // ThisWeekViewButton
            // 
            this.ThisWeekViewButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ThisWeekViewButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.ThisWeekViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThisWeekViewButton.Location = new System.Drawing.Point(246, 0);
            this.ThisWeekViewButton.Name = "ThisWeekViewButton";
            this.ThisWeekViewButton.Size = new System.Drawing.Size(246, 32);
            this.ThisWeekViewButton.TabIndex = 0;
            this.ThisWeekViewButton.Text = "금주";
            this.ThisWeekViewButton.UseVisualStyleBackColor = false;
            this.ThisWeekViewButton.Click += new System.EventHandler(this.ThisWeekViewButton_Click);
            // 
            // PrevWeekViewButton
            // 
            this.PrevWeekViewButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PrevWeekViewButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.PrevWeekViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevWeekViewButton.Location = new System.Drawing.Point(1, 0);
            this.PrevWeekViewButton.Name = "PrevWeekViewButton";
            this.PrevWeekViewButton.Size = new System.Drawing.Size(246, 32);
            this.PrevWeekViewButton.TabIndex = 0;
            this.PrevWeekViewButton.Text = "전주";
            this.PrevWeekViewButton.UseVisualStyleBackColor = false;
            this.PrevWeekViewButton.Click += new System.EventHandler(this.PrevWeekViewButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SelectAllButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SelectAllButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.SelectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectAllButton.Location = new System.Drawing.Point(0, 0);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(32, 116);
            this.SelectAllButton.TabIndex = 0;
            this.SelectAllButton.Text = "All";
            this.SelectAllButton.UseVisualStyleBackColor = false;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // ScheduleCalendarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(771, 163);
            this.MinimumSize = new System.Drawing.Size(771, 163);
            this.Name = "ScheduleCalendarControl";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.Size = new System.Drawing.Size(771, 163);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.DayViewPanel.ResumeLayout(false);
            this.YearMonthPanel.ResumeLayout(false);
            this.DaysPanel.ResumeLayout(false);
            this.WeekButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private  System.Windows.Forms.Panel panel1;
        private  System.Windows.Forms.Panel panel3;
        private  System.Windows.Forms.Button NextWeekButton;
        private  System.Windows.Forms.Button PrevWeekButton;
        private  System.Windows.Forms.Panel panel2;
        private JSFW.Todo.Label YearMonthLabel;
        private  System.Windows.Forms.Button todayButton;
        private  System.Windows.Forms.Button SelectAllButton;
        private  System.Windows.Forms.Panel DayViewPanel;
        private  System.Windows.Forms.Panel DaysPanel;
        private  System.Windows.Forms.Panel WeekButtonsPanel;
        private  System.Windows.Forms.Button NextWeekViewButton;
        private  System.Windows.Forms.Button ThisWeekViewButton;
        private  System.Windows.Forms.Button PrevWeekViewButton;
        private  System.Windows.Forms.Panel YearMonthPanel;
        private JSFW.Todo.Label SubYearMonthLabel;
        private JSFW.Todo.Label MainYearMonthLabel;
        private  System.Windows.Forms.RadioButton rdo_18;
        private  System.Windows.Forms.RadioButton rdo_17;
        private  System.Windows.Forms.RadioButton rdo_12;
        private  System.Windows.Forms.RadioButton rdo_11;
        private  System.Windows.Forms.RadioButton rdo_16;
        private  System.Windows.Forms.RadioButton rdo_06;
        private  System.Windows.Forms.RadioButton rdo_10;
        private  System.Windows.Forms.RadioButton rdo_15;
        private  System.Windows.Forms.RadioButton rdo_05;
        private  System.Windows.Forms.RadioButton rdo_09;
        private  System.Windows.Forms.RadioButton rdo_14;
        private  System.Windows.Forms.RadioButton rdo_04;
        private  System.Windows.Forms.RadioButton rdo_08;
        private  System.Windows.Forms.RadioButton rdo_13;
        private  System.Windows.Forms.RadioButton rdo_03;
        private  System.Windows.Forms.RadioButton rdo_07;
        private  System.Windows.Forms.RadioButton rdo_02;
        private  System.Windows.Forms.RadioButton rdo_01;
        private  System.Windows.Forms.RadioButton rdo_21;
        private  System.Windows.Forms.RadioButton rdo_20;
        private  System.Windows.Forms.RadioButton rdo_19;
        private  System.Windows.Forms.ToolTip toolTip1;
    }
}
