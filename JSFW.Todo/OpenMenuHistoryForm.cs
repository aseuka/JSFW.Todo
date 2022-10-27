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
    public partial class OpenMenuHistoryForm : Form
    { 
        string __ROOT_DIR { get; set; }
        string __PROJECT { get; set; }
        string __TODOLIST_FILENAME { get; set; }
        string __COMPLITE_DIR { get; set; }

        List<Mnu> Menus { get; set; }

        public List<Mnu> MnuSelected { get; private set; } = new List<Mnu>();

        public OpenMenuHistoryForm()
        {
            InitializeComponent();

            Menus = Ux.LoadFile<List<Mnu>>($"{MainTodoForm.__Menu_DIR}{MainTodoForm.__MENULIST_FILENAME}");
            if (Menus == null)
            {
                Menus = new List<Mnu>();
            }

            //Menus.Add(new Mnu() { GroupName = "경비", Name = "M01", Text = "경비 메뉴001" });
            //Menus.Add(new Mnu() { GroupName = "경비", Name = "M02", Text = "경비 메뉴002" });
            //Menus.Add(new Mnu() { GroupName = "경비", Name = "M03", Text = "경비 메뉴003" });

            //Menus.Add(new Mnu() { GroupName = "공통", Name = "G01", Text = "공통 메뉴001" });
            //Menus.Add(new Mnu() { GroupName = "공통", Name = "G02", Text = "공통 메뉴001" });

            lvMnu.Columns.Clear();
            lvMnu.Columns.Add("ID").Width = 0;
            lvMnu.Columns.Add("Eng").Width = 220;
            lvMnu.Columns.Add("Kor").Width = 330;

            lvMnu.Groups.Clear();
            foreach (var g in Menus.GroupBy(m => m.GroupName))
            {
                lvMnu.Groups.Add(g.Key, g.Key);
            }

            foreach (var m in Menus)
            {
                ListViewGroup g = lvMnu.Groups[m.GroupName];
                ListViewItem item = lvMnu.Items.Add(m.GUID);
                item.Group = g;
                item.SubItems.Add(m.Name);
                item.SubItems.Add(m.Text);
                item.Tag = m;
            }
        }

        readonly int __MAX_WIDTH = 1600;
        private void OpenMenuHistoryForm_Move(object sender, EventArgs e)
        {
            //Windows 10 일때 Full! 
            Screen currentScreen = Screen.FromControl(this);
            this.MaximumSize = new Size(__MAX_WIDTH, (int)(currentScreen.WorkingArea.Height * 0.9) + 16);
        }

        internal void SetData(string root, string project, string todoFileName, string complite)
        {
            __ROOT_DIR = root;
            __PROJECT = project;
            __TODOLIST_FILENAME = todoFileName;
            __COMPLITE_DIR = complite;

            if (System.IO.Directory.Exists(__ROOT_DIR + __PROJECT + __COMPLITE_DIR) == false)
            {
                System.IO.Directory.CreateDirectory(__ROOT_DIR + __PROJECT + __COMPLITE_DIR);
            }
        }

        private void lvMnu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hitInfo = lvMnu.HitTest(e.Location);
            ListViewItem currentItem = null;
            try
            {
                if (hitInfo.Item == null)//그룹
                {
                    int pt_X = e.X + 5;
                    int pt_Y = e.Y + 5;
                    do
                    {
                        currentItem = lvMnu.GetItemAt(pt_X, pt_Y);
                        pt_X += 5; pt_Y += 5;
                        if (lvMnu.Height < pt_Y) break;
                    } while (currentItem == null);

                    if (currentItem == null) return;
                }
                else
                {
                    currentItem = hitInfo.Item;
                }

                if (currentItem == null)
                    return;

                Mnu mnu = currentItem.Tag as Mnu;

                label1.Text = "";
                if (mnu == null) return;

                label1.Text = $"{mnu.Name} $ {mnu.Text} [{mnu.GUID}]";

                txtFind.Clear();

                LoadMnuHist(mnu);
            }
            finally
            {

            }
        }

        private void LoadMnuHist(Mnu mnu)
        {
            string dir = $"{MainTodoForm.__Menu_DIR}{mnu.GUID}";
            if ( Directory.Exists( dir ) == false )
            {
                Directory.CreateDirectory(dir);
            }

            List<TodoData> tmp = new List<TodoData>();
            string[] files = System.IO.Directory.GetFiles(dir);
            foreach (string file in files)
            {
                TodoData todo = Ux.LoadFile<TodoData>(file);
                tmp.Add(todo);
            }

            try
            {
                flowLayoutPanel1.SuspendLayout();
                for (int loop = flowLayoutPanel1.Controls.Count - 1; loop >= 0; loop--)
                {
                    using (flowLayoutPanel1.Controls[loop])
                    {
                        if (flowLayoutPanel1.Controls[loop] is Label)
                        {
                            flowLayoutPanel1.Controls[loop].DoubleClick -= Day_DoubleClick;
                        }
                        else
                        {
                            flowLayoutPanel1.Controls[loop].Tag = null;
                            flowLayoutPanel1.Controls[loop].MouseDown -= OpenHistoryForm_MouseDown;
                        }
                        flowLayoutPanel1.Controls.RemoveAt(loop);
                    }
                }

                string date = "-----------------";
                Label day = null;
                foreach (TodoData todo in tmp.OrderBy(o => o?.RequestDate.Substring(0, "yyyy-MM-dd".Length)).ThenBy(o => o?.OrderIndex))
                {
                    if (todo == null) continue;

                    if (!todo.RequestDate.StartsWith(date))
                    {
                        date = todo.RequestDate.Substring(0, "yyyy-MM-dd".Length);
                        day = new Label();
                        day.ForeColor = Color.Maroon;
                        day.Font = new Font(day.Font, FontStyle.Bold);
                        day.AutoSize = false;
                        day.Width = 100;
                        day.Height = 22;
                        day.Text = "# " + date;
                        day.TextAlign = ContentAlignment.MiddleCenter;
                        day.DoubleClick += Day_DoubleClick;
                        flowLayoutPanel1.Controls.Add(day);
                    }

                    WorkItemViewControl wc = new WorkItemViewControl();
                    wc.SetData(todo);
                    flowLayoutPanel1.Controls.Add(wc);
                    wc.Margin = new Padding(50, 3, 3, 3);
                    wc.Width = flowLayoutPanel1.Width - 74;
                    wc.MouseDown += OpenHistoryForm_MouseDown;
                    wc.Tag = day;

                    if (flowLayoutPanel1.VerticalScroll.Visible)
                    {
                        wc.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout(false);
                flowLayoutPanel1.PerformLayout();
            }
        }

        private void Day_DoubleClick(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb != null)
            {
                string date = (lb.Text.Trim()).Trim('#');
                using (OpenHistoryForm ohf = new OpenHistoryForm())
                {
                    ohf.SetData(__ROOT_DIR, __PROJECT, MainTodoForm.__TODOLIST_FILENAME, MainTodoForm.__COMPLITE_DIR, date);
                    ohf.ShowDialog(this);
                }
            }
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
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
         
        private void OpenHistoryForm_MouseDown(object sender, MouseEventArgs e)
        {
            SetCurrentWorkView(sender as WorkItemViewControl);
        }

        WorkItemViewControl CurrentWorkView { get; set; } = null;

        private void SetCurrentWorkView(WorkItemViewControl crrnt)
        {
            if (CurrentWorkView == crrnt)
            {
                return;
            }

            if (CurrentWorkView != null)
            {
                CurrentWorkView.BackColor = Color.Gainsboro;
                ClearFileInfo();
            }
            CurrentWorkView = crrnt;

            if (CurrentWorkView != null)
            {
                CurrentWorkView.BackColor = Color.DodgerBlue;
                SetFileInfo(CurrentWorkView);
            }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string findSearchText = txtFind.Text.Trim().ToUpper();
             
            Mnu mnu = lvMnu.FocusedItem?.Tag as Mnu;

            if (mnu == null)
            {
                MessageBox.Show("메뉴 선택 먼저.");
                return;
            }
             
            try
            {
                flowLayoutPanel1.SuspendLayout();
  
                foreach (Control item in flowLayoutPanel1.Controls)
                {
                    item.Visible = string.IsNullOrWhiteSpace( findSearchText ); 
                    // 검색어가 없으면 무조건 표시
                    if (!string.IsNullOrWhiteSpace(findSearchText) && item is WorkItemViewControl)
                    {
                        item.Visible |= ((WorkItemViewControl)item).TODO.Title.Contains(findSearchText);

                        item.Visible |= ((WorkItemViewControl)item).TODO.Working.Contains(findSearchText);

                        item.Visible |= ((WorkItemViewControl)item).TODO.Requester.Contains(findSearchText);

                        item.Visible |= ((WorkItemViewControl)item).TODO.Remark.Contains(findSearchText);

                        Label lb = item.Tag as Label;
                        if (lb != null)
                        {
                            lb.Visible = item.Visible;
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

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 내보내기
            // 내보내기  todoList.html 
            string fileName = __ROOT_DIR + __PROJECT + "MenuTree.html";
            string menuHtml = CreateMenuHtml();
            try
            {
                File.WriteAllText(fileName, menuHtml, Encoding.UTF8);
                System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CreateHtml(Mnu mnu)
        {
            /*
                    메뉴 트리  : iframe으로 menu별 html
                     노드 클릭 : iframe에 menuitem(id).html 바인딩 처리             
            */

            string html = @"<html>
<head>
    <meta charset=""utf-8"" />   
    <title>작업내역</title>
    <style type=""text/css"">
        div, body
        {
            border:0px black solid;
            width:98%;
            height:100%;
        }

        table th td
        {
            border:0px black solid;
            width:100%
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

        .infoTable
        {
            border:0px black solid;
            width:100%
        }

        .infoReq
        {
            border-bottom: 0px solid black;
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
                if (mnu == null)
                {
                    html += "기록 없음.";
                }
                else
                {
                    string dir = $"{MainTodoForm.__Menu_DIR}{mnu.GUID}";
                    if (Directory.Exists(dir) == false)
                    {
                        html += "기록 없음.";
                    }
                    else
                    {
                        List<TodoData> tmp = new List<TodoData>();
                        string[] files = System.IO.Directory.GetFiles(dir);
                        foreach (string file in files)
                        {
                            TodoData todo = Ux.LoadFile<TodoData>(file);
                            tmp.Add(todo);
                        }

                        html += $@"<table cellspacing=""0"" cellpadding=""0"" border=""0"">";  
                        string date = "-----------------";
                        foreach (TodoData todo in tmp.OrderBy(o => o?.RequestDate.Substring(0, "yyyy-MM-dd".Length)).ThenBy(o => o?.OrderIndex))
                        {
                            if (todo == null)
                            { 
                                continue;
                            }

                            if (!todo.RequestDate.StartsWith(date))
                            {
                                date = todo.RequestDate.Substring(0, "yyyy-MM-dd".Length);
                                html += @"<tr style=""height:35px"" valign=""bottom"">";
                                html += $@"<th align=""Left"" height=""30"">{date}</th>";
                                html += "</tr>";
                            }
                            html += "<tr>";
                            html += "<td>";

                            html += $@"<div style=""margin-left:25px; width:90%; height:100%"">";
                            html += $@"<table class=""infoTable"" cellspacing=""0"" cellpadding=""0"">";
                            html += $"<tbody>";
                            if (!string.IsNullOrWhiteSpace(todo.Title))
                            {
                                html += $"<tr>";
                                html += $@"<th colspan=""3"" align=""Left"">";
                                html += $"{todo.Title}";
                                html += $"</th>";
                                html += $"</tr>";
                            }
                            html += $"<tr>";
                            html += $@"<td colspan=""3"" class=""infoTd_TLRB"">";
                            html += $"[{todo.Requester}] {todo.RequestDate} ~ {(string.IsNullOrWhiteSpace(todo.CompliteDate) ? "진행중" : todo.CompliteDate)}";
                            html += $"</td>";
                            html += $"</tr>";

                            html += $"<tr>";
                            html += $@"<td valign=""top"" class=""infoTd_LB"">";
                            html += $@"<p align=""Left"">{(todo.Working ?? "").Replace(Environment.NewLine, "<br />")}</p>";
                            html += $"<ul>";
                            foreach (DailyItem day in todo.DailyItems)
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
                            if (todo.Menus.Count <= 0)
                            {
                                html += $"&nbsp;";
                            }
                            else
                            {
                                foreach (var group in todo.Menus.GroupBy(m => m.GroupName))
                                {
                                    html += $@"※ {group.Key}<br />";
                                    html += $"<ul>";
                                    foreach (Mnu mnu2 in todo.Menus.Where(w => group.Key == w.GroupName))
                                    {
                                        html += $@"<li>{mnu2.Name} ({mnu2.Text})</li>";
                                    }
                                    html += $"</ul>";
                                }
                                html += $"</td>";
                            }

                            html += $@"<td class=""fileCols infoTd_LBR"" valign=""top"" >";
                            if (todo.FileDatas.Count <= 0)
                            {
                                html += $"&nbsp;";
                            }
                            else
                            {
                                html += $"<ul>";
                                foreach (FileData fd in todo.FileDatas)
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
                                    href = href.Replace(@"\", @"/").Trim();

                                    html += $@"<li><a href=""../../{href}"" target=""_blank"">{fileName}</a></li>";
                                }
                                html += $"</ul>";
                                html += $"</td>";
                            }
                            html += $"</tr>";
                            html += $"</tbody>";
                            html += $"</table>";

                            html += $"</div>";
                            html += "</td>";
                            html += "</tr>";
                        }
                        html += "</table>";
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

        private string CreateMenuHtml()
        {
            /*
                    메뉴 트리  : iframe으로 menu별 html
                     노드 클릭 : iframe에 menuitem(id).html 바인딩 처리             
            */

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

        .UnderLine
        {
            border-bottom: 1px solid black;
        } 

        #floatdiv 
        { 
            position:fixed; 
            width:55px; 
            display:inline-block; 
            right:0px; /* 창에서 오른쪽 길이 */ 
            top:94%; /* 창에서 위에서 부터의 높이 */ 
            background-color:gray;
	        cursor:pointer;
            margin:0; 
        }

    </style>

    <script type=""text/javascript"" >

        function setframe( menuID )
        {
            //alert(menuID);
            document.getElementById(""content"").src = menuID + "".html"";
        }

   
        function calcHeight()
        {
            //find the height of the internal page
            var the_height = document.getElementById('content').contentWindow.document.body.scrollHeight;

            //change the height of the iframe
            document.getElementById('content').height = the_height;

            //document.getElementById('content').scrolling = ""no"";
            document.getElementById('content').style.overflow = ""hidden"";
        } 

        function setTop()
	    {
	        window.scrollTo(0, 0)
	    }
    </script>

</head>
<body>
        <div id=""floatdiv"" onclick=""setTop()"">위로</div> 
            "; 
            try
            {
                html += @"<div style=""width:30%;height:100vh;float:left"">";
                html += @"<table hegiht=""100%"" cellspacing=""0"" cellpadding=""0"">";
                foreach (ListViewGroup g in lvMnu.Groups)
                {
                    html += "<tr>";
                    html += @"<td colspan=""3"" class=""UnderLine"">";
                    html += $@"◇ {g.Header}";
                    html += "</td>";
                    html += "</tr>";
                    foreach (ListViewItem item in g.Items)
                    {
                        html += "<tr>";
                        html += @"<td width=""15px"">&nbsp;</td>";
                        html += $@"<td onclick=""setframe( './Menu/{item.Text}/{item.SubItems[1].Text}')"" style=""width:220px; cursor:pointer"">";
                        html += $@"- {item.SubItems[1].Text}";
                        html += "</td>";
                        html += @"<td>";
                        html += $@"{item.SubItems[2].Text}";
                        html += "</td>"; 
                        html += "</tr>"; 
                        string workhtml = CreateHtml(item.Tag as Mnu);
                        string menuDir = $@"{MainTodoForm.__Menu_DIR}{item.Text}\";
                        string menufileName = $@"{menuDir}{item.SubItems[1].Text}.html";
                        if (Directory.Exists(menuDir) == false)
                        {
                            Directory.CreateDirectory(menuDir);
                        }
                        File.WriteAllText(menufileName, workhtml, Encoding.UTF8);
                    }
                }
                html += "</table>";
                html += "</div>";
                html += @"<iframe id=""content"" width=""64%"" onload=""calcHeight();"" frameborder=""0"" scrolling=""no"" style=""float:left;overflow-x:hidden; overflow: auto; min-height:100vh;""> ";
                html += "</iframe>";
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
