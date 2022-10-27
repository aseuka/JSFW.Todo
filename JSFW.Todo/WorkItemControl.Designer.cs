namespace JSFW.Todo
{
    partial class WorkItemControl
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
            this.txtWorking = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnComplite = new System.Windows.Forms.Button();
            this.txtRequestDate = new System.Windows.Forms.TextBox();
            this.txtRequester = new System.Windows.Forms.TextBox();
            this.btnAddDaily = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk05 = new System.Windows.Forms.CheckBox();
            this.chk04 = new System.Windows.Forms.CheckBox();
            this.chk03 = new System.Windows.Forms.CheckBox();
            this.chk02 = new System.Windows.Forms.CheckBox();
            this.chk01 = new System.Windows.Forms.CheckBox();
            this.lbFile = new JSFW.Todo.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkNotify = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.flpWorkDaily = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWorking
            // 
            this.txtWorking.AcceptsTab = true;
            this.txtWorking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWorking.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorking.Location = new System.Drawing.Point(130, 28);
            this.txtWorking.Margin = new System.Windows.Forms.Padding(0);
            this.txtWorking.Multiline = true;
            this.txtWorking.Name = "txtWorking";
            this.tableLayoutPanel1.SetRowSpan(this.txtWorking, 2);
            this.txtWorking.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWorking.Size = new System.Drawing.Size(408, 63);
            this.txtWorking.TabIndex = 2;
            this.txtWorking.TextChanged += new System.EventHandler(this.txtWorking_TextChanged);
            this.txtWorking.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorking_KeyDown);
            this.txtWorking.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtWorking_MouseDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.btnComplite, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtWorking, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRequestDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRequester, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddDaily, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbFile, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(32, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(600, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(694, 92);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseDown);
            // 
            // btnComplite
            // 
            this.btnComplite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnComplite.Location = new System.Drawing.Point(543, 1);
            this.btnComplite.Margin = new System.Windows.Forms.Padding(0);
            this.btnComplite.Name = "btnComplite";
            this.btnComplite.Size = new System.Drawing.Size(150, 26);
            this.btnComplite.TabIndex = 4;
            this.btnComplite.Text = "완료";
            this.btnComplite.UseVisualStyleBackColor = true;
            // 
            // txtRequestDate
            // 
            this.txtRequestDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtRequestDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequestDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRequestDate.Font = new System.Drawing.Font("굴림", 8F);
            this.txtRequestDate.Location = new System.Drawing.Point(1, 28);
            this.txtRequestDate.Margin = new System.Windows.Forms.Padding(0);
            this.txtRequestDate.Name = "txtRequestDate";
            this.txtRequestDate.ReadOnly = true;
            this.txtRequestDate.Size = new System.Drawing.Size(124, 20);
            this.txtRequestDate.TabIndex = 2;
            this.txtRequestDate.TextChanged += new System.EventHandler(this.txtRequestDate_TextChanged);
            this.txtRequestDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtRequestDate_MouseDown);
            // 
            // txtRequester
            // 
            this.txtRequester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequester.Font = new System.Drawing.Font("굴림", 8F);
            this.txtRequester.Location = new System.Drawing.Point(1, 3);
            this.txtRequester.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.txtRequester.Name = "txtRequester";
            this.txtRequester.Size = new System.Drawing.Size(124, 20);
            this.txtRequester.TabIndex = 0;
            this.txtRequester.TextChanged += new System.EventHandler(this.txtRequester_TextChanged);
            this.txtRequester.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtRequester_MouseDown);
            // 
            // btnAddDaily
            // 
            this.btnAddDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddDaily.Location = new System.Drawing.Point(543, 61);
            this.btnAddDaily.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddDaily.Name = "btnAddDaily";
            this.btnAddDaily.Size = new System.Drawing.Size(150, 30);
            this.btnAddDaily.TabIndex = 3;
            this.btnAddDaily.Text = "Daily 추가";
            this.btnAddDaily.UseVisualStyleBackColor = true;
            this.btnAddDaily.Click += new System.EventHandler(this.btnAddDaily_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk05);
            this.panel1.Controls.Add(this.chk04);
            this.panel1.Controls.Add(this.chk03);
            this.panel1.Controls.Add(this.chk02);
            this.panel1.Controls.Add(this.chk01);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(124, 28);
            this.panel1.TabIndex = 6;
            // 
            // chk05
            // 
            this.chk05.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk05.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk05.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.chk05.FlatAppearance.CheckedBackColor = System.Drawing.Color.Coral;
            this.chk05.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chk05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk05.Location = new System.Drawing.Point(98, 2);
            this.chk05.Margin = new System.Windows.Forms.Padding(1);
            this.chk05.Name = "chk05";
            this.chk05.Padding = new System.Windows.Forms.Padding(2);
            this.chk05.Size = new System.Drawing.Size(24, 24);
            this.chk05.TabIndex = 10;
            this.chk05.UseVisualStyleBackColor = true;
            this.chk05.CheckedChanged += new System.EventHandler(this.chk05_CheckedChanged);
            // 
            // chk04
            // 
            this.chk04.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk04.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk04.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.chk04.FlatAppearance.CheckedBackColor = System.Drawing.Color.Coral;
            this.chk04.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chk04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk04.Location = new System.Drawing.Point(74, 2);
            this.chk04.Margin = new System.Windows.Forms.Padding(1);
            this.chk04.Name = "chk04";
            this.chk04.Padding = new System.Windows.Forms.Padding(2);
            this.chk04.Size = new System.Drawing.Size(24, 24);
            this.chk04.TabIndex = 9;
            this.chk04.UseVisualStyleBackColor = true;
            this.chk04.CheckedChanged += new System.EventHandler(this.chk04_CheckedChanged);
            // 
            // chk03
            // 
            this.chk03.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk03.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk03.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.chk03.FlatAppearance.CheckedBackColor = System.Drawing.Color.Coral;
            this.chk03.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chk03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk03.Location = new System.Drawing.Point(50, 2);
            this.chk03.Margin = new System.Windows.Forms.Padding(1);
            this.chk03.Name = "chk03";
            this.chk03.Padding = new System.Windows.Forms.Padding(2);
            this.chk03.Size = new System.Drawing.Size(24, 24);
            this.chk03.TabIndex = 8;
            this.chk03.UseVisualStyleBackColor = true;
            this.chk03.CheckedChanged += new System.EventHandler(this.chk03_CheckedChanged);
            // 
            // chk02
            // 
            this.chk02.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk02.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk02.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.chk02.FlatAppearance.CheckedBackColor = System.Drawing.Color.Coral;
            this.chk02.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chk02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk02.Location = new System.Drawing.Point(26, 2);
            this.chk02.Margin = new System.Windows.Forms.Padding(1);
            this.chk02.Name = "chk02";
            this.chk02.Padding = new System.Windows.Forms.Padding(2);
            this.chk02.Size = new System.Drawing.Size(24, 24);
            this.chk02.TabIndex = 7;
            this.chk02.UseVisualStyleBackColor = true;
            this.chk02.CheckedChanged += new System.EventHandler(this.chk02_CheckedChanged);
            // 
            // chk01
            // 
            this.chk01.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk01.Dock = System.Windows.Forms.DockStyle.Left;
            this.chk01.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.chk01.FlatAppearance.CheckedBackColor = System.Drawing.Color.Coral;
            this.chk01.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chk01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk01.Location = new System.Drawing.Point(2, 2);
            this.chk01.Margin = new System.Windows.Forms.Padding(1);
            this.chk01.Name = "chk01";
            this.chk01.Padding = new System.Windows.Forms.Padding(2);
            this.chk01.Size = new System.Drawing.Size(24, 24);
            this.chk01.TabIndex = 6;
            this.chk01.UseVisualStyleBackColor = true;
            this.chk01.CheckedChanged += new System.EventHandler(this.chk01_CheckedChanged);
            // 
            // lbFile
            // 
            this.lbFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFile.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbFile.ForeColor = System.Drawing.Color.Maroon;
            this.lbFile.Location = new System.Drawing.Point(546, 28);
            this.lbFile.Name = "lbFile";
            this.lbFile.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lbFile.Size = new System.Drawing.Size(144, 32);
            this.lbFile.TabIndex = 9;
            this.lbFile.Text = "File";
            this.lbFile.DoubleClick += new System.EventHandler(this.lbFile_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTitle);
            this.panel2.Controls.Add(this.chkNotify);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(130, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel2.Size = new System.Drawing.Size(408, 26);
            this.panel2.TabIndex = 10;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(0, 2);
            this.txtTitle.MaxLength = 300;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(355, 21);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.ReadOnlyChanged += new System.EventHandler(this.txtTitle_ReadOnlyChanged);
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            this.txtTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMenu_KeyDown);
            // 
            // chkNotify
            // 
            this.chkNotify.AutoSize = true;
            this.chkNotify.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkNotify.Location = new System.Drawing.Point(355, 2);
            this.chkNotify.Name = "chkNotify";
            this.chkNotify.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkNotify.Size = new System.Drawing.Size(53, 24);
            this.chkNotify.TabIndex = 2;
            this.chkNotify.Text = "공지";
            this.chkNotify.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(32, 92);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.VisibleChanged += new System.EventHandler(this.checkBox1_VisibleChanged);
            this.checkBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkBox1_MouseDown);
            // 
            // flpWorkDaily
            // 
            this.flpWorkDaily.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpWorkDaily.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpWorkDaily.Location = new System.Drawing.Point(32, 92);
            this.flpWorkDaily.Name = "flpWorkDaily";
            this.flpWorkDaily.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flpWorkDaily.Size = new System.Drawing.Size(694, 0);
            this.flpWorkDaily.TabIndex = 3;
            this.flpWorkDaily.WrapContents = false;
            // 
            // WorkItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flpWorkDaily);
            this.Controls.Add(this.checkBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(726, 3000);
            this.MinimumSize = new System.Drawing.Size(726, 92);
            this.Name = "WorkItemControl";
            this.Size = new System.Drawing.Size(726, 92);
            this.Resize += new System.EventHandler(this.WorkItemControl_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtWorking;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtRequestDate;
        private System.Windows.Forms.TextBox txtRequester;
        private System.Windows.Forms.Button btnComplite;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnAddDaily;
        private System.Windows.Forms.FlowLayoutPanel flpWorkDaily;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chk05;
        private System.Windows.Forms.CheckBox chk04;
        private System.Windows.Forms.CheckBox chk03;
        private System.Windows.Forms.CheckBox chk02;
        private System.Windows.Forms.CheckBox chk01;
        private System.Windows.Forms.TextBox txtTitle;
        private Label lbFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkNotify;
    }
}
