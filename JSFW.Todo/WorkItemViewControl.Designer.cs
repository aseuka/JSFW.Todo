namespace JSFW.Todo
{
    partial class WorkItemViewControl
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
            this.txtTEXT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTEXT
            // 
            this.txtTEXT.BackColor = System.Drawing.Color.White;
            this.txtTEXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEXT.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTEXT.Location = new System.Drawing.Point(0, 0);
            this.txtTEXT.Multiline = true;
            this.txtTEXT.Name = "txtTEXT";
            this.txtTEXT.ReadOnly = true;
            this.txtTEXT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTEXT.Size = new System.Drawing.Size(681, 22);
            this.txtTEXT.TabIndex = 0;
            this.txtTEXT.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtTEXT_MouseDoubleClick);
            this.txtTEXT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtTEXT_MouseDown);
            // 
            // WorkItemViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.txtTEXT);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorkItemViewControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Size = new System.Drawing.Size(681, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTEXT;
    }
}
