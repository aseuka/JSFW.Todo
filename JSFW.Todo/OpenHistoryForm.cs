using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Todo
{
    public partial class OpenHistoryForm : Form
    {
        string __ROOT_DIR { get; set; }
        string __PROJECT { get; set; }
        string __TODOLIST_FILENAME { get; set; }
        string __COMPLITE_DIR { get; set; }

        public OpenHistoryForm()
        {
            InitializeComponent();

            btnAddMenu.Visible = false;
            this.FormClosing += OpenHistoryForm_FormClosing;
        }

        private void OpenHistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetCurrentWorkView(null);
        }

        readonly int __MAX_WIDTH = 1600;
        private void OpenHistoryForm_Move(object sender, EventArgs e)
        {
            //Windows 10 일때 Full! 
            Screen currentScreen = Screen.FromControl(this);
            this.MaximumSize = new Size(__MAX_WIDTH, (int)(currentScreen.WorkingArea.Height * 0.9) + 16);
        }

        protected override void OnShown(EventArgs e)
        {
            this.Top = 0;
            this.Height = this.MaximumSize.Height;
            base.OnShown(e);
        }

        internal void SetData(string root, string project, string todoFileName, string complite, string date = "")
        {
            __ROOT_DIR = root;
            __PROJECT = project;
            __TODOLIST_FILENAME = todoFileName;
            __COMPLITE_DIR = complite;

            if (System.IO.Directory.Exists(__ROOT_DIR + __PROJECT + __COMPLITE_DIR) == false)
            {
                System.IO.Directory.CreateDirectory(__ROOT_DIR + __PROJECT + __COMPLITE_DIR);
            }

            DateTime currentDate = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(date))
            {
                currentDate = date.Trim().ToDateTime("yyyy-MM-dd") ?? DateTime.Now;
            }
            scheduleCalendarControl1.CurrentDate = currentDate;
        }

        private void scheduleCalendarControl1_DaySelected(NPT.Controls.RangeType range, string from, string to)
        {
            LoadHistory(range, from, to);
        }

        private void LoadHistory(NPT.Controls.RangeType range, string from, string to)
        {
            if (range == NPT.Controls.RangeType.Week)
            {
                label1.Text = $"조회기간은 ({range}) {from}~{to} 입니다.";
            }
            else if (range == NPT.Controls.RangeType.All)
            {
                label1.Text = $"조회기간은 전체입니다.";
            }
            else
            {
                label1.Text = $"조회기간은 ({range}) {from} 입니다.";
            }
            List<TodoData> tmp = Ux.LoadFile<List<TodoData>>(System.IO.Path.Combine(__ROOT_DIR, __PROJECT, __TODOLIST_FILENAME));
            if (tmp == null)
            {
                tmp = new List<TodoData>();
            }

            string[] files = System.IO.Directory.GetFiles(__ROOT_DIR + __PROJECT + __COMPLITE_DIR);
            foreach (var file in files)
            {
                TodoData t1 = Ux.LoadFile<TodoData>(file);
                tmp.Add(t1);
            }

            List<TodoData> Filter = new List<TodoData>();
            switch (range)
            {
                case NPT.Controls.RangeType.Day:
                    var v = tmp.Where(w => (w.RequestDate ?? "2000-01-01 00:00:00").CompareTo($"{from} 23:59:59") <= 0 && $"{from} 00:00:00".CompareTo(w.CompliteDate ?? "9999-12-31 23:59:59") <= 0);
                    int vcnt = v.Count();
                    if (0 < vcnt) Filter.AddRange(v.ToArray());
                    break;
                case NPT.Controls.RangeType.Week:
                    var r = tmp.Where(w => (w.RequestDate ?? "2000-01-01 00:00:00").CompareTo($"{to} 23:59:59") <= 0 && $"{from} 00:00:00".CompareTo(w.CompliteDate ?? "9999-12-31 23:59:59") <= 0);
                    int rcnt = r.Count();
                    if (0 < rcnt) Filter.AddRange(r.ToArray());
                    break;
                case NPT.Controls.RangeType.All:
                    Filter.AddRange(tmp.ToArray());
                    break;
            }

            SetData(Filter, range, from, to);
        }

        bool IsDataBinding = false;
        private void SetData(List<TodoData> filter, NPT.Controls.RangeType range, string from, string to)
        {
            try
            {
                btnAddMenu.Visible = false;
                SetCurrentWorkView(null);

                IsDataBinding = true;
                flowLayoutPanel1.SuspendLayout();
                for (int loop = flowLayoutPanel1.Controls.Count - 1; loop >= 0; loop--)
                {
                    using (flowLayoutPanel1.Controls[loop])
                    {
                        flowLayoutPanel1.Controls[loop].MouseDown -= OpenHistoryForm_MouseDown;
                        flowLayoutPanel1.Controls.RemoveAt(loop);
                    }
                }
                string date = "-----------------";
                foreach (TodoData todo in filter.OrderBy(o => o.RequestDate.Substring(0, "yyyy-MM-dd".Length)).ThenBy(o => o.OrderIndex))
                {
                    if (!todo.RequestDate.StartsWith(date))
                    {
                        date = todo.RequestDate.Substring(0, "yyyy-MM-dd".Length);
                        Label day = new Label();
                        day.ForeColor = Color.Maroon;
                        day.Font = new Font(day.Font, FontStyle.Bold);
                        day.AutoSize = false;
                        day.Width = 100;
                        day.Height = 22;
                        day.Text = "# " + date;
                        day.TextAlign = ContentAlignment.MiddleCenter;
                        flowLayoutPanel1.Controls.Add(day);
                    }
                    WorkItemViewControl wc = new WorkItemViewControl();
                    wc.MouseDown += OpenHistoryForm_MouseDown;
                    wc.SetData(todo);
                    flowLayoutPanel1.Controls.Add(wc);
                    wc.Margin = new Padding(50, 3, 3, 3);
                    wc.Width = flowLayoutPanel1.Width - 58;

                    if (flowLayoutPanel1.VerticalScroll.Visible)
                    {
                        wc.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }
            }
            finally
            {
                IsDataBinding = false;
                flowLayoutPanel1.ResumeLayout(false);
                flowLayoutPanel1.PerformLayout();
            }
        }

        private void OpenHistoryForm_MouseDown(object sender, MouseEventArgs e)
        {
            SetCurrentWorkView(sender as WorkItemViewControl);
        }

        WorkItemViewControl CurrentWorkView { get; set; } = null;

        private void SetCurrentWorkView(WorkItemViewControl crrnt)
        {
            btnAddMenu.Visible = false;

            if (CurrentWorkView == crrnt)
            {
                btnAddMenu.Visible = string.IsNullOrWhiteSpace(CurrentWorkView?.TODO.CompliteDate) == false;
                return;
            }
             
            if (CurrentWorkView != null)
            {
                CurrentWorkView.BackColor = Color.Gainsboro;
                ClearFileInfo();
            }

            ClearMenus();

            CurrentWorkView = crrnt;

            if (CurrentWorkView != null)
            {
                CurrentWorkView.BackColor = Color.DodgerBlue;
                SetFileInfo(CurrentWorkView);
                SetMenus(CurrentWorkView);
                btnAddMenu.Visible = string.IsNullOrWhiteSpace(CurrentWorkView.TODO.CompliteDate) == false;
            }
        }

        private void SetMenus(WorkItemViewControl currentWorkItem)
        {
            if (currentWorkItem == null || currentWorkItem.TODO == null || currentWorkItem.TODO.Menus == null) return;

            int max = 120;
            if (0 < currentWorkItem.TODO.Menus.Count)
            {
                max = currentWorkItem.TODO.Menus.Max(mnu => TextRenderer.MeasureText(mnu.Name, lvMnu.Font).Width + 20);
            }
            if (max < 120) max = 120;

            lvMnu.Columns.Clear();
            lvMnu.Columns.Add("ID").Width = 0;
            lvMnu.Columns.Add("Eng").Width = max;
            lvMnu.Columns.Add("Kor").Width = lvMnu.Width - (max + 10);

            List<Mnu> Menus = Ux.LoadFile<List<Mnu>>($"{MainTodoForm.__Menu_DIR}{MainTodoForm.__MENULIST_FILENAME}");

            for (int loop = currentWorkItem.TODO.Menus.Count - 1; loop >= 0; loop--)
            {
                var mnu = currentWorkItem.TODO.Menus[loop];
                if (Menus.Any(m => m.GUID == mnu.GUID)) continue;
                currentWorkItem.TODO.Menus.RemoveAt(loop);
            }

            lvMnu.Groups.Clear();
            foreach (var g in currentWorkItem.TODO.Menus.GroupBy(m => m.GroupName))
            {
                lvMnu.Groups.Add(g.Key, g.Key);
            }

            foreach (var m in currentWorkItem.TODO.Menus)
            {
                ListViewGroup g = lvMnu.Groups[m.GroupName];
                ListViewItem item = lvMnu.Items.Add(m.GUID);
                item.Group = g;
                item.SubItems.Add(m.Name);
                item.SubItems.Add(m.Text);
                item.Tag = m;
            }
            Menus = null;
        }

        private void ClearMenus()
        {
            foreach (ListViewItem item in lvMnu.Items)
            {
                item.Tag = null;
            }
            lvMnu.Items.Clear();
        }

        private void SetFileInfo(WorkItemViewControl workItem)
        {
            try
            {
                if (workItem.TODO == null) return;

                flowLayoutPanel2.SuspendLayout();

                foreach (var filedata in workItem.TODO.FileDatas)
                {
                    FileItemControl fileItem = new FileItemControl(true);
                    fileItem.SetData(filedata);
                    flowLayoutPanel2.Controls.Add(fileItem);
                    fileItem.Width = flowLayoutPanel2.Width - 8;
                    if (flowLayoutPanel2.VerticalScroll.Visible)
                    {
                        fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }
            }
            finally
            {
                flowLayoutPanel2.ResumeLayout(false);
                flowLayoutPanel2.PerformLayout();
            }
        }

        private void ClearFileInfo()
        {
            try
            {
                flowLayoutPanel2.SuspendLayout();
                for (int loop = flowLayoutPanel2.Controls.Count - 1; loop >= 0; loop--)
                {
                    using (flowLayoutPanel2.Controls[loop])
                    {
                    }
                }
            }
            finally
            {
                flowLayoutPanel2.ResumeLayout(false);
                flowLayoutPanel2.PerformLayout();
            }
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            try
            {
                flowLayoutPanel1.SuspendLayout();
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is WorkItemViewControl)
                    {
                        ctrl.Width = flowLayoutPanel1.Width - 58;
                        if (flowLayoutPanel1.VerticalScroll.Visible)
                        {
                            ctrl.Width -= SystemInformation.VerticalScrollBarWidth;
                        }
                    }
                }
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout(false);
                flowLayoutPanel1.PerformLayout();
            }
        }

        private void flowLayoutPanel2_Resize(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            try
            {
                flowLayoutPanel2.SuspendLayout();
                foreach (FileItemControl fileItem in flowLayoutPanel2.Controls)
                {
                    fileItem.Width = flowLayoutPanel2.Width - 8;
                    if (flowLayoutPanel2.VerticalScroll.Visible)
                    {
                        fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }
            }
            finally
            {
                flowLayoutPanel2.ResumeLayout(false);
                flowLayoutPanel2.PerformLayout();
            }
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            // 노트
            //DialogResult result = MessageBox.Show("공지포함", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            StringBuilder sb = new StringBuilder();
            using (System.IO.StringWriter sw = new System.IO.StringWriter(sb))
            {
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is Label)
                    {
                        if (0 < sb.Length) sw.WriteLine();
                        sw.WriteLine(ctrl.Text);
                    }
                    else if (ctrl is WorkItemViewControl)
                    {
                        //if (((WorkItemViewControl)ctrl).TODO.IsNotify && result != DialogResult.Yes)
                        //{
                        //    continue;
                        //}
                        sw.WriteLine(((WorkItemViewControl)ctrl).GetContent());
                    }
                }
            }
            string txt = "" + sb;
            if (string.IsNullOrWhiteSpace(txt) == false)
            {
                Clipboard.SetText(txt);
                MessageBox.Show("복사완료 [붙여넣기:Ctrl + V]");
            }
            else
            {
                MessageBox.Show("노트기록이 없음.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 검색
            string findSearchText = txtFind.Text.Trim().ToUpper();

            try
            {
                SetCurrentWorkView(null);

                List<TodoData> tmp = Ux.LoadFile<List<TodoData>>(System.IO.Path.Combine(__ROOT_DIR, __PROJECT, __TODOLIST_FILENAME));
                string[] files = System.IO.Directory.GetFiles(__ROOT_DIR + __PROJECT + __COMPLITE_DIR);
                foreach (var file in files)
                {
                    TodoData t1 = Ux.LoadFile<TodoData>(file);
                    tmp.Add(t1);
                }

                List<TodoData> filter = new List<TodoData>();
                var v = tmp.Where(w =>
                {
                    bool isWhere = false;
                    isWhere |= w.Working.ToUpper().Contains(findSearchText);
                    isWhere |= w.DailyItems.Any(d => d.Comment.ToUpper().Contains(findSearchText));
                    isWhere |= w.Menus.Any(m => m.Name.ToUpper().Contains(findSearchText) || m.Text.ToUpper().Contains(findSearchText));
                    return isWhere;
                });
                int vcnt = v.Count();
                if (0 < vcnt) filter.AddRange(v.ToArray());

                IsDataBinding = true;
                flowLayoutPanel1.SuspendLayout();
                for (int loop = flowLayoutPanel1.Controls.Count - 1; loop >= 0; loop--)
                {
                    using (flowLayoutPanel1.Controls[loop])
                    {
                        flowLayoutPanel1.Controls[loop].MouseDown -= OpenHistoryForm_MouseDown;
                        flowLayoutPanel1.Controls.RemoveAt(loop);
                    }
                }

                string date = "-----------------";
                foreach (TodoData todo in filter.OrderBy(o => o.RequestDate.Substring(0, "yyyy-MM-dd".Length)).ThenBy(o => o.OrderIndex))
                {
                    if (!todo.RequestDate.StartsWith(date))
                    {
                        date = todo.RequestDate.Substring(0, "yyyy-MM-dd".Length);
                        Label day = new Label();
                        day.ForeColor = Color.Maroon;
                        day.Font = new Font(day.Font, FontStyle.Bold);
                        day.AutoSize = false;
                        day.Width = 100;
                        day.Height = 22;
                        day.Text = "# " + date;
                        day.TextAlign = ContentAlignment.MiddleCenter;
                        flowLayoutPanel1.Controls.Add(day);
                    }
                    WorkItemViewControl wc = new WorkItemViewControl();
                    wc.MouseDown += OpenHistoryForm_MouseDown;
                    wc.SetData(todo);
                    flowLayoutPanel1.Controls.Add(wc);
                    wc.Margin = new Padding(50, 3, 3, 3);
                    wc.Width = flowLayoutPanel1.Width - 58;

                    if (flowLayoutPanel1.VerticalScroll.Visible)
                    {
                        wc.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }
            }
            finally
            {
                IsDataBinding = false;
                flowLayoutPanel1.ResumeLayout(false);
                flowLayoutPanel1.PerformLayout();
            }
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            //메뉴 추가! (완료된 것만 추가 가능)
            if (CurrentWorkView != null && string.IsNullOrWhiteSpace(CurrentWorkView.TODO.CompliteDate) == false)
            {
                using (MnuManagerFm mf = new MnuManagerFm())
                {
                    if (CurrentWorkView != null)
                    {
                        mf.HasCheckBoxs = true;
                        mf.SetMenus(CurrentWorkView.TODO.Menus);
                    }
                    else
                    {
                        mf.HasCheckBoxs = false;
                    }
                    
                    if (mf.ShowDialog(this) == DialogResult.OK && MessageBox.Show("변경?", "변경확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (CurrentWorkView == null) return;

                        List<Mnu> SelectionMnu = mf.MnuSelected;

                        TodoData data = CurrentWorkView.TODO;
                        string fileName = $"{data.CompliteDate.Replace("-", "").Replace(":", "")}) {data.Requester.Trim()} ({data.RequestDate.Replace("-", "").Replace(":", "")} {(data.Issue ? "이슈" : "")}";
                        foreach (Mnu mnu in data.Menus.Where( m => !SelectionMnu.Any( im => im.GUID == m.GUID)))
                        {
                            if (!Directory.Exists($"{MainTodoForm.__Menu_DIR}{mnu.GUID}"))
                            {
                                Directory.CreateDirectory($"{MainTodoForm.__Menu_DIR}{mnu.GUID}");
                            }
                            File.Delete($"{MainTodoForm.__Menu_DIR}{mnu.GUID}\\{fileName}.txt"); 
                            //기존 메뉴에서 새로 선택된 메뉴목록에 없는 항목 삭제
                        }

                        // 선택된 화면 목록 >>> 
                        CurrentWorkView.TODO.Menus.Clear();
                        CurrentWorkView.TODO.Menus.AddRange(SelectionMnu);
                        CurrentWorkView.SetData(CurrentWorkView.TODO);

                        ClearMenus();
                        SetMenus(CurrentWorkView);

                        data = CurrentWorkView.TODO;
                        Ux.SaveFile(data, Path.Combine(__ROOT_DIR, __PROJECT, $"{__COMPLITE_DIR}\\{fileName}.txt"));
                        foreach (Mnu mnu in data.Menus)
                        {
                            if (!Directory.Exists($"{MainTodoForm.__Menu_DIR}{mnu.GUID}"))
                            {
                                Directory.CreateDirectory($"{MainTodoForm.__Menu_DIR}{mnu.GUID}");
                            }
                            //todo파일을 새로운 메뉴파일로 등록.
                            Ux.SaveFile(data, $"{MainTodoForm.__Menu_DIR}{mnu.GUID}\\{fileName}.txt");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("완료된 이력에만 메뉴를 추가 가능.");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 내보내기  todoList.html 
            string fileName = __ROOT_DIR + __PROJECT + "todoList.html";
            string html = CreateHtml();
            try
            { 
                //if (File.Exists( fileName))
                //{
                //    File.Delete(fileName);
                //}
                File.WriteAllText(fileName, "", Encoding.UTF8);
                File.WriteAllText(fileName, html, Encoding.UTF8);
                System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CreateHtml()
        { 
            string html = @"<html>
<head>
    <meta charset=""utf-8"" />   
    <title>작업내역</title>
    <style type=""text/css"">
        div 
        {
            border:0px black solid;
            width:100%
        }

        table
        {
            border:0px black solid;
            width:100%
        }
    
        table, th, td 
        {
            border: 0px solid black;
        }

        table tr
        {
            height:27px
        }
        
        .mnuCols {
            width:400px
        }
        .fileCols {
            width:350px
        }

        ul 
        {
            list-style-type : circle;
        }

        .infoTd_TLRB
        {
            border-top: 1px solid black;
            border-left: 1px solid black;
            border-right: 1px solid black;
            border-bottom: 1px solid black;
        } 

        .infoTd_LB
        {
            border-left: 1px solid black;
            border-bottom: 1px solid black;
        } 

        .infoTd_LBR
        {
            border-left: 1px solid black;
            border-bottom: 1px solid black;
            border-right: 1px solid black;
        } 

    </style>
</head>
<body>";
            try
            {
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is WorkItemViewControl)
                    {
                        WorkItemViewControl wvc = ctrl as WorkItemViewControl;
                        html += $@"<div style=""margin:10 0 0 0"">";
                        html += $@"<table cellspacing=""0"" cellpadding=""0"" border=""0"">";
                        html += $"<tbody>";
                        if (!string.IsNullOrWhiteSpace(wvc.TODO.Title))
                        {
                            html += $"<tr>";
                            html += $@"<th colspan=""3"" align=""Left"">";
                            html += $"{wvc.TODO.Title}";
                            html += $"</th>";
                            html += $"</tr>";
                        }
                        html += $"<tr>";
                        html += $@"<td colspan=""3"" class=""infoTd_TLRB"">";
                        html += $"[{wvc.TODO.Requester}] {wvc.TODO.RequestDate} ~ {(string.IsNullOrWhiteSpace(wvc.TODO.CompliteDate) ? "진행중" : wvc.TODO.CompliteDate)}";
                        html += $"</th>";
                        html += $"</tr>";

                        html += $"<tr>";
                        html += $@"<td valign=""top"" class=""infoTd_LB"">";                        
                        html += $@"<p align=""Left"">{(wvc.TODO.Working ?? "").Replace(Environment.NewLine, "<br />")}</p>";
                        html += $"<ul>";
                        foreach (DailyItem day in wvc.TODO.DailyItems)
                        {
                            if (day.IsDel) continue;
                            if (day.State == "이슈")
                            {
                                html += $"<li><span>[{day.State}]<span>[..{day.IssueDate}]{(day.Comment ?? "").Replace(Environment.NewLine, "<br />")}</li>";
                            }
                            else
                            {
                                html += $"<li><span>[{day.State}]<span>[~{day.CompliteDate}]{(day.Comment ?? "").Replace(Environment.NewLine, "<br />")}</li>";
                            }
                        }
                        html += $"</ul>";
                        html += $"&nbsp;<br />";
                        html += $"</td>";

                        html += $@"<td class=""mnuCols infoTd_LB"" valign=""top"" >";
                        if (wvc.TODO.Menus.Count <= 0)
                        {
                            html += $"&nbsp;";
                        }
                        else
                        {
                            foreach (var group in wvc.TODO.Menus.GroupBy(m => m.GroupName))
                            {
                                html += $@"※ {group.Key}<br />";
                                html += $"<ul>";
                                foreach (Mnu mnu in wvc.TODO.Menus.Where(w => group.Key == w.GroupName))
                                {
                                    html += $@"<li><a href=""./Menu/{mnu.GUID}/{mnu.Name}.html"" target=""_blank"">{mnu.Name} ({mnu.Text})</a></li>";
                                }
                                html += $"</ul>";
                            }
                            html += $"</td>";
                        }

                        html += $@"<td class=""fileCols infoTd_LBR"" valign=""top"" >";
                        if (wvc.TODO.FileDatas.Count <= 0)
                        {
                            html += $"&nbsp;";
                        }
                        else
                        {
                            html += $"<ul>";
                            foreach (FileData fd in wvc.TODO.FileDatas)
                            {
                                if (fd.IsDelete) continue;

                                string fileName = Path.GetFileName(fd.OriginalFilePath);

                                if (!string.IsNullOrWhiteSpace(Path.GetExtension(fileName)))
                                {
                                    fileName = fileName.Replace(Path.GetExtension(fileName), "");
                                }

                                if (!string.IsNullOrWhiteSpace(fd.Alias))
                                {
                                    fileName = fd.Alias;
                                }

                                string href = fd.NewFilePath.Replace(@"\\", @"\");
                                href = href.Replace(__ROOT_DIR + __PROJECT, "");
                                href = href.Replace(__ROOT_DIR, "");
                                href = "./" + (href).Replace(@"\", @"/").Trim(); 
                                html += $@"<li><a href=""{href}"" target=""_blank"">{fileName}</a></li>";
                            }
                            html += $"</ul>";
                            html += $"</td>";
                        }
                        html += $"</tr>";
                        html += $"</tbody>";
                        html += $"</table>";

                        html += $"</div>";
                    }
                }
            }
            catch (Exception ex)
            { 
            
            }
            html += "</body>";
            html += "</html>";
            return html;
        }

    }
}
