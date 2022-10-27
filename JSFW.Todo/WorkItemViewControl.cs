using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JSFW.Todo
{
    public partial class WorkItemViewControl : UserControl
    {
        internal TodoData TODO { get; set; } = null;
        public WorkItemViewControl()
        {
            InitializeComponent();
            this.Disposed += WorkItemViewControl_Disposed;
        }

        private void WorkItemViewControl_Disposed(object sender, EventArgs e)
        {
            TODO = null;
        }

        private void txtTEXT_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        internal void SetData(TodoData todo)
        {
            TODO = todo;
            txtTEXT.Text = GetText();
            ResizeTextBoxHight();

            if (string.IsNullOrWhiteSpace(todo.CompliteDate) == false)
            {
                txtTEXT.BackColor = Color.LightYellow;
            }
        }

        private void ResizeTextBoxHight()
        {
            int basicHeight = 24;
            int h = TextRenderer.MeasureText(txtTEXT.Text, txtTEXT.Font).Height + (this.Margin.Top + this.Margin.Bottom) + 6;
            if (basicHeight < h)
            {
                this.Height = h;
            }
            else
            {
                this.Height = basicHeight + 6;//padding 2더하고 보더값 상하 1씩 (=2) 인가보다
            }
        }

        private string GetText()
        {
            string txt = "";
            if (TODO == null) return txt;

            StringBuilder sb = new StringBuilder();
            using (System.IO.StringWriter sw = new System.IO.StringWriter(sb))
            {
                int odr = GetOrder(TODO.OrderIndex);
                sw.WriteLine($"요 청 자 : {(new string('★', odr))}{(new string('☆', 5 - odr))} ({TODO.FileDatas.Count:D3}) {TODO.Requester.Trim()} ");
                sw.WriteLine($"요청일자 : <{TODO.RequestDate} ~ {TODO.CompliteDate ?? "진행중"}> {(TODO.Issue ? "((이슈))" : "")}");
                if (string.IsNullOrWhiteSpace(TODO.MenuID) == false) 
                {
                sw.WriteLine($"관련화면 : [{TODO.MenuID}] {TODO.Title}");
                }
                else if (string.IsNullOrWhiteSpace(TODO.Title) == false)
                {
                sw.WriteLine($"제    목 : [{TODO.Title}] {TODO.MenuID}");
                }
                string[] lines = TODO.Working.Trim().Replace("\r", "").Split('\n').Select( s => s.Trim()).ToArray();
                sw.WriteLine($"내    용 : ");
                sw.WriteLine($"          {string.Join(Environment.NewLine + @"          ", lines)}");
                foreach (var daily in TODO.DailyItems)
                {
                    if (daily.IsDel == false)
                    {
                        if (string.IsNullOrWhiteSpace(daily.CompliteDate) == false)
                        {
                            sw.WriteLine($"          - (완료) <{daily.WorkingDate} ~ {daily.CompliteDate}>");
                        }
                        else if (string.IsNullOrWhiteSpace(daily.IssueDate) == false)
                        {
                            sw.WriteLine($"          - (이슈) <{daily.CompliteDate}>");
                        }
                        else
                        {
                            sw.WriteLine($"          - (등록) <{daily.WorkingDate}>");
                        }

                        if (string.IsNullOrWhiteSpace(daily.Comment) == false)
                        {
                            sw.WriteLine($"            {daily.Comment} ");
                        }
                    }
                }

                foreach (var grp in TODO.Menus.GroupBy( g => g.GroupName))
                {
                    sw.WriteLine($"          @{grp.Key}");
                    foreach (var mnu in TODO.Menus.Where( w => w.GroupName == grp.Key))
                    {
                        sw.WriteLine($"             .{mnu.Name},{mnu.Text}");
                    }
                }
            }
            txt = "" + sb; 
            return txt.Trim();
        }

        private int GetOrder(int orderIndex)
        {
            int odr = int.MaxValue;
            if (5 <= orderIndex)
            {
                odr = 5;
            }
            else
            {
                odr = orderIndex;
            }
            int order = 6 - orderIndex;
            if (order < 0) order = 1;

            return order;
        }

        internal string GetContent()
        {
            return txtTEXT.Text;
        }

        private void txtTEXT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                sw.WriteLine($"# {TODO.Title}");
                sw.WriteLine($"BEGIN [{TODO.RequestDate}]");
                sw.WriteLine($"     {TODO.Working.Replace(Environment.NewLine, Environment.NewLine + @"    ")}");
                foreach (DailyItem item in TODO.DailyItems)
                {                    
                    sw.WriteLine($"     - [{item.State}] [{item.CompliteDate}] {item.Comment}");
                }

                foreach (var grp in TODO.Menus.GroupBy(g => g.GroupName))
                {
                    sw.WriteLine($"     - @{grp.Key}");
                    foreach (var mnu in TODO.Menus.Where(w => w.GroupName == grp.Key))
                    {
                        sw.WriteLine($"       .{mnu.Name},{mnu.Text}");
                    }
                }
                sw.WriteLine($"END [{DateTime.Now:yyyy-MM-dd HH:mm:ss}]");
            }

            if (0 < sb.Length)
            {
                Clipboard.SetText("" + sb);
                MessageBox.Show("복사완료 [ctlr + V]");
            }
        }
    }
}
