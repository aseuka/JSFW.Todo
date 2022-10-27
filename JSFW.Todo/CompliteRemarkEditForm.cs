using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Todo
{
    public partial class CompliteRemarkEditForm : Form
    {
        public bool IsIssue { get => checkBox1.Checked; set => checkBox1.Checked = value; }

        public string Remark { get => textBox1.Text; set => textBox1.Text = value; }

        /// <summary>
        /// 난이도
        /// </summary>
        public DifficulyEnum Difficuly
        {
            get
            {
                return GetDifficuly();
            }
        }

        private DifficulyEnum GetDifficuly()
        {
            DifficulyEnum diff = DifficulyEnum.Low;

            if (rdoHigh.Checked)
            {
                diff = DifficulyEnum.High;
            }
            else if (rdoMedium.Checked)
            {
                diff = DifficulyEnum.Medium;
            }
            return diff;
        }

        public int WorkTime
        {
            get
            {
                return GetWorkTimeMinute();
            }
        }

        private int GetWorkTimeMinute()
        {
            int workTimeMinute = 0;
            workTimeMinute = (int)((numDay.Value * (8 * 60 ))  +  (numHour.Value * 60 ) + numMinute.Value);
            return workTimeMinute;
        }

        public CompliteRemarkEditForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            btnOK.Focus();
            DisplayWorkTime();
        }

        private void DisplayWorkTime()
        {
            lbTotalMinute.Text = $"총: {WorkTime:N0} 분";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                btnOK.PerformClick();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rdoTime30m_CheckedChanged(object sender, EventArgs e)
        {
            numDay.Value = 0;
            numHour.Value = 0;
            numMinute.Value = 30;
            DisplayWorkTime();
        }

        private void rdoTime1h_CheckedChanged(object sender, EventArgs e)
        {
            numDay.Value = 0;
            numHour.Value = 1;
            numMinute.Value = 0;
            DisplayWorkTime();
        }

        private void rdoTime3h_CheckedChanged(object sender, EventArgs e)
        {
            numDay.Value = 0;
            numHour.Value = 3;
            numMinute.Value = 0;
            DisplayWorkTime();
        }

        private void rdoTime8h_CheckedChanged(object sender, EventArgs e)
        {
            numDay.Value = 0;
            numHour.Value = 8;
            numMinute.Value = 0;
            DisplayWorkTime();
        }

        private void rdoTime1_5h_CheckedChanged(object sender, EventArgs e)
        {
            numDay.Value = 1;
            numHour.Value = 4;
            numMinute.Value = 0;
            DisplayWorkTime();
        }

        private void rdoTime2d_CheckedChanged(object sender, EventArgs e)
        {
            numDay.Value = 2;
            numHour.Value = 0;
            numMinute.Value = 0;
            DisplayWorkTime();
        }

        private void rdoTime3day_CheckedChanged(object sender, EventArgs e)
        {
            numDay.Value = 3;
            numHour.Value = 0;
            numMinute.Value = 0;
            DisplayWorkTime();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            numDay.Value = 5;  // 3일 이상일때 = 기본값 5일이상 걸림을 표시.
            numHour.Value = 0;
            numMinute.Value = 0;
            DisplayWorkTime();
        }
    }

    public enum DifficulyEnum
    { 
        /// <summary>
        /// 난이도.상
        /// </summary>
        High,
        /// <summary>
        /// 난이도.중
        /// </summary>
        Medium,
        /// <summary>
        /// 난이도.하
        /// </summary>
        Low
    }
}
