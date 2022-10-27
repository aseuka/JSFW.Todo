namespace JSFW.Todo
{
    partial class OpenHistoryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lvMnu = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.label2 = new JSFW.Todo.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnNote = new System.Windows.Forms.Button();
            this.label1 = new JSFW.Todo.Label();
            this.scheduleCalendarControl1 = new JSFW.NPT.Controls.ScheduleCalendarControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.lvMnu);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 196);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1254, 365);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(694, 359);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // lvMnu
            // 
            this.lvMnu.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvMnu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvMnu.HideSelection = false;
            this.lvMnu.Location = new System.Drawing.Point(697, 3);
            this.lvMnu.MultiSelect = false;
            this.lvMnu.Name = "lvMnu";
            this.lvMnu.Size = new System.Drawing.Size(297, 359);
            this.lvMnu.TabIndex = 3;
            this.lvMnu.UseCompatibleStateImageBehavior = false;
            this.lvMnu.View = System.Windows.Forms.View.Details;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(994, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 359);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(997, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(254, 359);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.Resize += new System.EventHandler(this.flowLayoutPanel2_Resize);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddMenu);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtFind);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnNote);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1254, 33);
            this.panel2.TabIndex = 2;
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMenu.Location = new System.Drawing.Point(933, 11);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(62, 23);
            this.btnAddMenu.TabIndex = 6;
            this.btnAddMenu.Text = "+ 메뉴";
            this.btnAddMenu.UseVisualStyleBackColor = true;
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(539, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "작업내용, 일일 코멘트, 메뉴Eng, 메뉴Kor";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(492, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(334, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(157, 21);
            this.txtFind.TabIndex = 3;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1095, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "내보내기";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnNote
            // 
            this.btnNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNote.Location = new System.Drawing.Point(1176, 11);
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(75, 23);
            this.btnNote.TabIndex = 1;
            this.btnNote.Text = "Note";
            this.btnNote.UseVisualStyleBackColor = true;
            this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.label1.Size = new System.Drawing.Size(1254, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "조회 내용은 xx일 입니다.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // scheduleCalendarControl1
            // 
            this.scheduleCalendarControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scheduleCalendarControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scheduleCalendarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.scheduleCalendarControl1.Location = new System.Drawing.Point(0, 0);
            this.scheduleCalendarControl1.MaximumSize = new System.Drawing.Size(771, 163);
            this.scheduleCalendarControl1.MinimumSize = new System.Drawing.Size(771, 163);
            this.scheduleCalendarControl1.Name = "scheduleCalendarControl1";
            this.scheduleCalendarControl1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.scheduleCalendarControl1.Size = new System.Drawing.Size(771, 163);
            this.scheduleCalendarControl1.TabIndex = 0;
            this.scheduleCalendarControl1.DaySelected += new JSFW.NPT.Controls.CalendarSelected(this.scheduleCalendarControl1_DaySelected);
            // 
            // OpenHistoryForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1254, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.scheduleCalendarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(1270, 5000);
            this.MinimumSize = new System.Drawing.Size(1270, 600);
            this.Name = "OpenHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "이력보기";
            this.Move += new System.EventHandler(this.OpenHistoryForm_Move);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NPT.Controls.ScheduleCalendarControl scheduleCalendarControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private Label label1;
        private System.Windows.Forms.Button btnNote;
        private System.Windows.Forms.ListView lvMnu;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFind;
        private Label label2;
        private System.Windows.Forms.Button btnAddMenu;
        private System.Windows.Forms.Button btnExport;
    }
}