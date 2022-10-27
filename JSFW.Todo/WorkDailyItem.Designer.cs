namespace JSFW.Todo
{
    partial class WorkDailyItem
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
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtDailyComment = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.chkIssue = new System.Windows.Forms.CheckBox();
            this.chkComplite = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDate.Font = new System.Drawing.Font("굴림", 9F);
            this.txtDate.Location = new System.Drawing.Point(8, 1);
            this.txtDate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(116, 21);
            this.txtDate.TabIndex = 3;
            // 
            // txtDailyComment
            // 
            this.txtDailyComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDailyComment.Font = new System.Drawing.Font("굴림체", 9F);
            this.txtDailyComment.Location = new System.Drawing.Point(124, 1);
            this.txtDailyComment.Name = "txtDailyComment";
            this.txtDailyComment.Size = new System.Drawing.Size(233, 21);
            this.txtDailyComment.TabIndex = 4;
            this.txtDailyComment.TextChanged += new System.EventHandler(this.txtDailyComment_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.chkIssue);
            this.panel1.Controls.Add(this.chkComplite);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(357, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 21);
            this.panel1.TabIndex = 5;
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(74, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(22, 21);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "-";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // chkIssue
            // 
            this.chkIssue.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIssue.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkIssue.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.chkIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIssue.Font = new System.Drawing.Font("굴림", 8F);
            this.chkIssue.Location = new System.Drawing.Point(37, 0);
            this.chkIssue.Name = "chkIssue";
            this.chkIssue.Size = new System.Drawing.Size(37, 21);
            this.chkIssue.TabIndex = 1;
            this.chkIssue.Text = "이슈";
            this.chkIssue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIssue.UseVisualStyleBackColor = true;
            this.chkIssue.CheckedChanged += new System.EventHandler(this.chkIssue_CheckedChanged);
            // 
            // chkComplite
            // 
            this.chkComplite.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkComplite.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkComplite.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.chkComplite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkComplite.Font = new System.Drawing.Font("굴림", 8F);
            this.chkComplite.Location = new System.Drawing.Point(0, 0);
            this.chkComplite.Name = "chkComplite";
            this.chkComplite.Size = new System.Drawing.Size(37, 21);
            this.chkComplite.TabIndex = 0;
            this.chkComplite.Text = "완료";
            this.chkComplite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkComplite.UseVisualStyleBackColor = true;
            this.chkComplite.CheckedChanged += new System.EventHandler(this.chkComplite_CheckedChanged);
            // 
            // WorkDailyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDailyComment);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtDate);
            this.MaximumSize = new System.Drawing.Size(5000, 23);
            this.MinimumSize = new System.Drawing.Size(400, 23);
            this.Name = "WorkDailyItem";
            this.Padding = new System.Windows.Forms.Padding(8, 1, 2, 1);
            this.Size = new System.Drawing.Size(455, 23);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtDailyComment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkIssue;
        private System.Windows.Forms.CheckBox chkComplite;
        private System.Windows.Forms.Button btnDel;
    }
}
