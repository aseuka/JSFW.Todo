using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Todo
{
    public partial class WorkDailyItem : UserControl
    {
        public Action<string> DataChanged = null;

        public DailyItem Data { get; set; }

        public WorkDailyItem()
        {
            InitializeComponent();
        }
         
        public void SetDailyData(DailyItem data)
        {
            Data = data;
            DataBinding();
        }

        bool IsDataBinding = false;
        private void DataBinding()
        {
            try
            {
                IsDataBinding = true;
                DataClear(); 
                if (Data != null)
                {
                    txtDate.Text = Data.WorkingDate;
                    txtDate.BackColor = GetRequestDateBackColor(txtDate.Text);
                    txtDailyComment.Text = Data.Comment;
                    chkComplite.Checked = "완료" == Data.State;
                    chkIssue.Checked = "이슈" == Data.State;  
                    CompliteDate = Data.CompliteDate;
                    IssueDate = Data.IssueDate;
                    IsDel = Data.IsDel;
                    if (IsDel)
                    {
                        txtDailyComment.Font = new Font(txtDailyComment.Font, FontStyle.Strikeout);
                        chkComplite.Font = new Font(chkComplite.Font, FontStyle.Strikeout);
                        chkIssue.Font = new Font(chkIssue.Font, FontStyle.Strikeout);
                    }
                    else
                    {
                        txtDailyComment.Font = new Font(txtDailyComment.Font, FontStyle.Regular);
                        chkComplite.Font = new Font(chkComplite.Font, FontStyle.Regular);
                        chkIssue.Font = new Font(chkIssue.Font, FontStyle.Regular);
                    }
                    txtDailyComment.ReadOnly = (IsDel || chkComplite.Checked || chkIssue.Checked);
                    chkComplite.Enabled = !IsDel;
                    chkIssue.Enabled = !IsDel; 
                }
            }
            finally
            {
                IsDataBinding = false;
                txtDate.ReadOnly = true;
            }
        }

        private Color GetRequestDateBackColor(string date)
        {
            Color backcolor = SystemColors.Control;

            if (10 <= date.Trim().Length &&
                (string.Compare($"{DateTime.Now.AddDays(-4):yyyy-MM-dd}", date.Substring(0, 10)) <= 0 && string.Compare(date.Substring(0, 10), $"{DateTime.Now:yyyy-MM-dd}") <= 0))
            {
                backcolor = Color.Khaki;
            }
            return backcolor;
        }

        private void DataClear()
        {
            txtDate.Clear();
            txtDailyComment.Clear();
            chkIssue.Checked = false;
            chkComplite.Checked = false;
            CompliteDate = "";
            IssueDate = ""; 
            txtDailyComment.ReadOnly = IsDel;
        }

        private void txtDailyComment_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            Saving("Working");
        }

        private void Saving(string propName)
        {
            if (DataChanged != null) this.DoInvoke(t => DataChanged(propName));
        }

        string CompliteDate { get; set; }

        string IssueDate { get; set; }

        internal void DataFlush()
        {
            Data.Comment = txtDailyComment.Text.Trim();
            Data.WorkingDate = txtDate.Text.Trim();
            if (chkIssue.Checked)
            {
                Data.State = "이슈";
            }

            if (chkComplite.Checked)
            {
                Data.State = "완료";
            }
            Data.CompliteDate = CompliteDate;
            Data.IssueDate = IssueDate;
            Data.IsDel = IsDel;
        }

        private void chkComplite_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            if (chkComplite.Checked)
            {
                CompliteDate = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                chkIssue.Checked = false;
            }
            else
            {
                CompliteDate = "";
            }
            txtDailyComment.ReadOnly = (IsDel || chkComplite.Checked || chkIssue.Checked);
            Saving("Working");
        }

        private void chkIssue_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            if (chkIssue.Checked)
            {
                IssueDate = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                chkComplite.Checked = false;
            }
            else
            {
                IssueDate = "";
            }
            txtDailyComment.ReadOnly = (IsDel || chkComplite.Checked || chkIssue.Checked);
            Saving("Working");
        }

        bool IsDel { get; set; } = false;

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!IsDel)
            {
                if (MessageBox.Show("삭제?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    IsDel = true;
                }
                else return;
            }
            else
            {
                IsDel = false;
            }

            if (IsDel)
            {
                txtDailyComment.Font = new Font(txtDailyComment.Font, FontStyle.Strikeout);
                chkComplite.Font = new Font(chkComplite.Font, FontStyle.Strikeout);
                chkIssue.Font = new Font(chkIssue.Font, FontStyle.Strikeout);
            }
            else
            {
                txtDailyComment.Font = new Font(txtDailyComment.Font, FontStyle.Regular);
                chkComplite.Font = new Font(chkComplite.Font, FontStyle.Regular);
                chkIssue.Font = new Font(chkIssue.Font, FontStyle.Regular);
            }
            chkComplite.Enabled = !IsDel;
            chkIssue.Enabled = !IsDel;
            txtDailyComment.ReadOnly = (IsDel || chkComplite.Checked || chkIssue.Checked);
            Saving("Working");
        }

        internal void FirstFocus()
        {
            txtDailyComment.Focus();
        }
    }
}
