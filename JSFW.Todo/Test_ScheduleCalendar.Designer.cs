namespace JSFW.Todo
{
    partial class Test_ScheduleCalendar
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
            this.scheduleCalendarControl1 = new JSFW.NPT.Controls.ScheduleCalendarControl();
            this.SuspendLayout();
            // 
            // scheduleCalendarControl1
            // 
            this.scheduleCalendarControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scheduleCalendarControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scheduleCalendarControl1.Location = new System.Drawing.Point(39, 34);
            this.scheduleCalendarControl1.MaximumSize = new System.Drawing.Size(771, 163);
            this.scheduleCalendarControl1.MinimumSize = new System.Drawing.Size(771, 163);
            this.scheduleCalendarControl1.Name = "scheduleCalendarControl1";
            this.scheduleCalendarControl1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.scheduleCalendarControl1.Size = new System.Drawing.Size(771, 163);
            this.scheduleCalendarControl1.TabIndex = 0;
            // 
            // Test_ScheduleCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 235);
            this.Controls.Add(this.scheduleCalendarControl1);
            this.Name = "Test_ScheduleCalendar";
            this.Text = "Test_ScheduleCalendar";
            this.ResumeLayout(false);

        }

        #endregion

        private NPT.Controls.ScheduleCalendarControl scheduleCalendarControl1;
    }
}