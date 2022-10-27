namespace JSFW.Todo
{
    partial class MainTodoForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOpenHistory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRequesterAll = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.txtSearch = new DevAge.Windows.Forms.DevAgeTextBoxButton();
            this.label2 = new JSFW.Todo.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelCancel = new System.Windows.Forms.Button();
            this.btnDelOK = new System.Windows.Forms.Button();
            this.flpnlRequester = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvMnu = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new JSFW.Todo.Label();
            this.btnSelMnu = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnTXT = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnMenuHist = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 287F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRequesterAll, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlToolbar, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpnlRequester, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1256, 691);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMenuHist);
            this.panel2.Controls.Add(this.btnOpenHistory);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 28);
            this.panel2.TabIndex = 5;
            // 
            // btnOpenHistory
            // 
            this.btnOpenHistory.Location = new System.Drawing.Point(137, 1);
            this.btnOpenHistory.Name = "btnOpenHistory";
            this.btnOpenHistory.Size = new System.Drawing.Size(63, 26);
            this.btnOpenHistory.TabIndex = 2;
            this.btnOpenHistory.Text = "이력보기";
            this.btnOpenHistory.UseVisualStyleBackColor = true;
            this.btnOpenHistory.Click += new System.EventHandler(this.btnOpenHistory_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "할일";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRequesterAll
            // 
            this.btnRequesterAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRequesterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequesterAll.Location = new System.Drawing.Point(5, 33);
            this.btnRequesterAll.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnRequesterAll.Name = "btnRequesterAll";
            this.btnRequesterAll.Size = new System.Drawing.Size(199, 34);
            this.btnRequesterAll.TabIndex = 2;
            this.btnRequesterAll.Text = "전체";
            this.btnRequesterAll.UseVisualStyleBackColor = true;
            this.btnRequesterAll.Click += new System.EventHandler(this.btnRequesterAll_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.label2);
            this.pnlToolbar.Controls.Add(this.btnSearch);
            this.pnlToolbar.Controls.Add(this.btnDel);
            this.pnlToolbar.Controls.Add(this.btnAdd);
            this.pnlToolbar.Controls.Add(this.btnDelCancel);
            this.pnlToolbar.Controls.Add(this.btnDelOK);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlToolbar.Location = new System.Drawing.Point(211, 1);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(752, 28);
            this.pnlToolbar.TabIndex = 4;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.Location = new System.Drawing.Point(90, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(172, 20);
            this.txtSearch.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "검색어";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(268, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(47, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(633, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 28);
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(525, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelCancel
            // 
            this.btnDelCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCancel.Location = new System.Drawing.Point(633, 0);
            this.btnDelCancel.Name = "btnDelCancel";
            this.btnDelCancel.Size = new System.Drawing.Size(100, 28);
            this.btnDelCancel.TabIndex = 0;
            this.btnDelCancel.Text = "취소";
            this.btnDelCancel.UseVisualStyleBackColor = true;
            this.btnDelCancel.Click += new System.EventHandler(this.btnDelCancel_Click);
            // 
            // btnDelOK
            // 
            this.btnDelOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelOK.Location = new System.Drawing.Point(525, 0);
            this.btnDelOK.Name = "btnDelOK";
            this.btnDelOK.Size = new System.Drawing.Size(100, 28);
            this.btnDelOK.TabIndex = 0;
            this.btnDelOK.Text = "확인";
            this.btnDelOK.UseVisualStyleBackColor = true;
            this.btnDelOK.Click += new System.EventHandler(this.btnDelOK_Click);
            // 
            // flpnlRequester
            // 
            this.flpnlRequester.BackColor = System.Drawing.Color.Gainsboro;
            this.flpnlRequester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnlRequester.Location = new System.Drawing.Point(5, 71);
            this.flpnlRequester.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.flpnlRequester.Name = "flpnlRequester";
            this.flpnlRequester.Size = new System.Drawing.Size(199, 614);
            this.flpnlRequester.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(211, 30);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(752, 655);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(964, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl1, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(287, 681);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvMnu);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(279, 655);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "메뉴";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvMnu
            // 
            this.lvMnu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMnu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvMnu.HideSelection = false;
            this.lvMnu.Location = new System.Drawing.Point(0, 28);
            this.lvMnu.MultiSelect = false;
            this.lvMnu.Name = "lvMnu";
            this.lvMnu.Size = new System.Drawing.Size(279, 627);
            this.lvMnu.TabIndex = 9;
            this.lvMnu.UseCompatibleStateImageBehavior = false;
            this.lvMnu.View = System.Windows.Forms.View.Details;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnSelMnu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 28);
            this.panel3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "완료시 각 화면에 내역 저장";
            // 
            // btnSelMnu
            // 
            this.btnSelMnu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelMnu.Location = new System.Drawing.Point(204, 3);
            this.btnSelMnu.Name = "btnSelMnu";
            this.btnSelMnu.Size = new System.Drawing.Size(74, 23);
            this.btnSelMnu.TabIndex = 1;
            this.btnSelMnu.Text = "화면선택";
            this.btnSelMnu.UseVisualStyleBackColor = true;
            this.btnSelMnu.Click += new System.EventHandler(this.btnSelMnu_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(279, 655);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "파일";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AllowDrop = true;
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 28);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(279, 627);
            this.flowLayoutPanel2.TabIndex = 6;
            this.flowLayoutPanel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel2_DragDrop);
            this.flowLayoutPanel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel2_DragEnter);
            this.flowLayoutPanel2.Resize += new System.EventHandler(this.flowLayoutPanel2_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnTXT);
            this.panel1.Controls.Add(this.btnCapture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 28);
            this.panel1.TabIndex = 7;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(224, 1);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(54, 27);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "XLSX";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnTXT
            // 
            this.btnTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTXT.Location = new System.Drawing.Point(171, 1);
            this.btnTXT.Name = "btnTXT";
            this.btnTXT.Size = new System.Drawing.Size(54, 27);
            this.btnTXT.TabIndex = 1;
            this.btnTXT.Text = "TXT";
            this.btnTXT.UseVisualStyleBackColor = true;
            this.btnTXT.Click += new System.EventHandler(this.btnTXT_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(1, 1);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(55, 27);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "캡쳐";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnMenuHist
            // 
            this.btnMenuHist.Location = new System.Drawing.Point(68, 1);
            this.btnMenuHist.Name = "btnMenuHist";
            this.btnMenuHist.Size = new System.Drawing.Size(63, 26);
            this.btnMenuHist.TabIndex = 2;
            this.btnMenuHist.Text = "메뉴이력";
            this.btnMenuHist.UseVisualStyleBackColor = true;
            this.btnMenuHist.Click += new System.EventHandler(this.btnMenuHist_Click);
            // 
            // MainTodoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1256, 691);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(1272, 4000);
            this.MinimumSize = new System.Drawing.Size(1272, 200);
            this.Name = "MainTodoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "할 일...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainTodoForm_FormClosing);
            this.Move += new System.EventHandler(this.MainTodoForm_Move);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRequesterAll;
        private System.Windows.Forms.FlowLayoutPanel flpnlRequester;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelCancel;
        private System.Windows.Forms.Button btnDelOK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnTXT;
        private Label label2;
        private System.Windows.Forms.Button btnSearch;
        private DevAge.Windows.Forms.DevAgeTextBoxButton txtSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOpenHistory;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSelMnu;
        private System.Windows.Forms.ListView lvMnu;
        private Label label3;
        private System.Windows.Forms.Button btnMenuHist;
    }
}

