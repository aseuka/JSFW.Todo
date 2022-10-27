using Greenshot;
using Greenshot.Destinations;
using Greenshot.Helpers;
using Greenshot.IniFile;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;
using GreenshotPlugin.UnmanagedHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Todo
{
    public partial class MainTodoForm : Form
    {
        
        internal static readonly string _DRIVE = GetDrive(@"D:\") ;

        /// <summary>
        /// D:\JSFW\TODO\
        /// </summary>
        internal static readonly string __ROOT_DIR = _DRIVE  + @"JSFW\TODO\";

        /// <summary>
        /// 커맨드라인으로 들어오는 프로젝트 명.
        /// </summary>
        internal static string ProjectName = "";

        /// <summary>
        /// \JSFW\TODO\CAPTURE\
        /// </summary>
        internal static string __CAPTURE_DIR
        {
            get { return __ROOT_DIR + ProjectName + @"CAPTURE\"; }
        }

        /// <summary>
        /// \JSFW\TODO\Menu\
        /// </summary>
        internal static string __Menu_DIR
        {
            get { return __ROOT_DIR + ProjectName + @"Menu\"; }
        }

        /// <summary>
        /// Complite
        /// </summary>
        internal static readonly string __COMPLITE_DIR = "Complite";

        /// <summary>
        /// todoList.txt
        /// </summary>
        internal static readonly string __TODOLIST_FILENAME = "todoList.txt";

        /// <summary>
        /// menuList.txt
        /// </summary>
        internal static readonly string __MENULIST_FILENAME = "menuList.txt";

        /// <summary>
        /// Requester
        /// </summary>
        internal static readonly string __REQUESTER = "Requester";

        internal static readonly string __ORDERINDEX = "OrderIndex";

        internal static readonly string __MENUS = "MENUS";

        private static string GetDrive(string drive)
        {
            if (!Directory.GetLogicalDrives().Contains(drive))
            {
                drive = Directory.GetLogicalDrives()[0];
            }
            return drive;
        }

        WorkItemControl CurrentWorkItem { get; set; } = null;
          
        public MainTodoForm()
        { 
            InitializeComponent();

            DoubleBuffered = true;
             
            //string day = "2019-12-21";
            //string startDay = "2019-12-15 09:53:12";
            //string endDay = "2019-12-25 23:01:35";

            //if (startDay.CompareTo($"{day} 23:59:59") <= 0 && $"{day} 00:00:00".CompareTo(endDay) <= 0)
            //{
            //}
            //else
            //{ 
            //}

            Ux.SetNonPublicProperty(tableLayoutPanel1, "DoubleBuffered", true);

            txtSearch.Button.Click += Button_Click;
            txtSearch.TextBox.Enter += txtSearch_Enter;
            txtSearch.TextBox.KeyDown += txtSearch_KeyDown;
            txtSearch.Button.Font = new Font("Webdings", 6f);
            txtSearch.Button.Text = "r";
            txtSearch.Button.TextAlign = ContentAlignment.MiddleCenter;

            if (Directory.Exists(__ROOT_DIR) == false)
            {
                Directory.CreateDirectory(__ROOT_DIR);
            }

            //string[] cmdArgs = null;

            //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            //{
            //    cmdArgs = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
            //}
            //else
            //{
            //    cmdArgs = Environment.GetCommandLineArgs();
            //}

            //if (cmdArgs != null && 1 < cmdArgs.Length)
            //{
            //    ProjectName = cmdArgs[1];

            //    foreach (char c in Path.GetInvalidPathChars())
            //    {
            //        ProjectName = ProjectName.Replace(""+c, "");
            //    }
            //    ProjectName = ProjectName + @"\";
            //}

            string[] projectDirectories = Directory.GetDirectories(__ROOT_DIR);

            if (projectDirectories != null)
            {
                if (1 < projectDirectories.Length)
                {
                    // 선택 팝업.
                    using (SelectProjectForm sf = new SelectProjectForm(projectDirectories.Select(s => s.Replace(__ROOT_DIR, "")).ToArray()))
                    {
                        sf.ShowDialog();
                        ProjectName = sf.SelectedProjectName.Trim();
                        ProjectName = ProjectName + @"\";
                    }
                }
                else if (0 < projectDirectories.Length)
                {
                    ProjectName = projectDirectories[0].Replace(__ROOT_DIR, "");
                    ProjectName = ProjectName + @"\";
                }
            }

            Properties.Settings.Default.LastProject = (ProjectName?.ToUpper()??"").TrimEnd('\\');
            Properties.Settings.Default.Save();

            if (Directory.Exists(__ROOT_DIR + ProjectName) == false)
            {
                Directory.CreateDirectory(__ROOT_DIR + ProjectName);
            }

            if (Directory.Exists(__CAPTURE_DIR) == false)
            {
                Directory.CreateDirectory(__CAPTURE_DIR);
            }

            if (Directory.Exists(__Menu_DIR) == false)
            {
                Directory.CreateDirectory(__Menu_DIR);
            }
             
            IniConfig.Init();
            MainForm._conf = IniConfig.GetIniSection<CoreConfiguration>();
            MainForm._conf.Language = "ko-kr";
            Language.CurrentLanguage = "ko-kr";

            MainForm._conf.OutputDestinations.Clear();
            // MainForm._conf.OutputDestinations.Add(EditorDestination.DESIGNATION);
            MainForm._conf.OutputDestinations.Add(FileDestination.DESIGNATION);
            MainForm._conf.OutputDestinations.Add(ClipboardDestination.DESIGNATION);
            MainForm._conf.OutputFilePath = __CAPTURE_DIR;
            MainForm._conf.IECapture = true;
            MainForm._conf.CaptureDelay = 600;

            string LogFileLocation; LogFileLocation = LogHelper.InitializeLog4Net();

            IniConfig.Save();

            bool ignoreFailedRegistration = false;

            HotkeyControl.RegisterHotkeyHwnd(Handle);

            if (!RegisterWrapper(Keys.Alt, Keys.PrintScreen, this.Handle, CaptureWin, ignoreFailedRegistration))
            {
            }

            //Ctrl + Shift + PrintScreen
            if (!RegisterWrapper(Keys.Control | Keys.Shift, Keys.PrintScreen, this.Handle, CaptureIE, ignoreFailedRegistration))
            {

            }
            this.Disposed += MainForm_Disposed;


            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                this.Text = $"할 일 ... [{GetVersion()}] 위치:{__ROOT_DIR + ProjectName}";
            }
            else
            {
                this.Text = $"할 일 ... 위치:{__ROOT_DIR + ProjectName}";
            }
        }

        private object GetVersion()
        {
            string version = "";

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                version = ""+System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            return version;
        }

        readonly int __MAX_WIDTH = 1269;
        private void MainTodoForm_Move(object sender, EventArgs e)
        {
            //Windows 10 일때 Full! 
            Screen currentScreen = Screen.FromControl(this);
            this.MaximumSize = new Size(__MAX_WIDTH, (int)(currentScreen.WorkingArea.Height * 0.9) + 16);
        }
         
        private void MainForm_Disposed(object sender, EventArgs e)
        {
            UnregisterHotkeys();

            SetCurrentWorkItem(null);
        }
         
        protected override void OnLoad(EventArgs e)
        {
            // TodoList 로딩!
            DataLoad();

            this.Top = 0;
            this.Height = this.MaximumSize.Height;
            base.OnLoad(e);
        }

        private void MainTodoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (WorkItemControl item in flowLayoutPanel1.Controls)
            {
                if (item.IsNew)
                {
                    e.Cancel = true;
                    MessageBox.Show($"신규 등록건 저장이 필요함.");
                    return;
                }
            }

            e.Cancel = IsSaving;
            if (e.Cancel)
            {
                MessageBox.Show($"{delayTime/1000}초 남음.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 
            WorkItemControl newWorkItemCtrl = new WorkItemControl(true);
            TodoData newData = new TodoData()
            {
                GUID = Guid.NewGuid().ToString("N"),
                Requester = this.Requester,
                RequestDate = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
            };

            newWorkItemCtrl.MouseDown += NewWorkItemCtrl_MouseDown;
            newWorkItemCtrl.DataChanged = NewWorkItemCtrl_DataChanged;
            newWorkItemCtrl.Complite += NewWorkItemCtrl_btnCompliteClick;
            SetCurrentWorkItem(newWorkItemCtrl);
            newWorkItemCtrl.SetTodoData(newData);
            flowLayoutPanel1.Controls.Add(newWorkItemCtrl);
            flowLayoutPanel1.Controls.SetChildIndex(newWorkItemCtrl, 0);
            flowLayoutPanel1.ScrollControlIntoView(newWorkItemCtrl);
            newWorkItemCtrl.SetFirstFocus();
            newWorkItemCtrl.SetDeleteMode(false);

            flowLayoutPanel1.ScrollControlIntoView(newWorkItemCtrl);
        }

        private void NewWorkItemCtrl_btnCompliteClick(object sender, EventArgs e)
        {
            // 완료 버튼 >> TodoData 이동
            WorkItemControl workItem = sender as WorkItemControl;
            if (workItem != null)
            {
                SetCurrentWorkItem(null);
                using (CompliteRemarkEditForm fm = new CompliteRemarkEditForm())
                {
                    if (fm.ShowDialog() == DialogResult.OK)
                    {
                        workItem.DataFlush();
                        TodoData data = workItem.Data;

                        data.Issue = fm.IsIssue;
                        data.Remark = fm.Remark.Trim();
                        data.CompliteDate = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";

                        data.Difficuly = fm.Difficuly;
                        data.WorkTime = fm.WorkTime;

                        string fileName = $"{data.CompliteDate.Replace("-", "").Replace(":", "")}) {data.Requester.Trim()} ({data.RequestDate.Replace("-", "").Replace(":", "")} {(data.Issue? "이슈" : "")}";
                        Ux.SaveFile(data, Path.Combine(__ROOT_DIR + ProjectName, $"{__COMPLITE_DIR}\\{fileName}.txt"));
                        foreach (Mnu mnu in data.Menus)
                        {
                            if(!Directory.Exists($"{__Menu_DIR}{mnu.GUID}"))
                            {
                                Directory.CreateDirectory($"{__Menu_DIR}{mnu.GUID}");
                            }
                            Ux.SaveFile(data, $"{__Menu_DIR}{mnu.GUID}\\{fileName}.txt");
                        }
                        flowLayoutPanel1.Controls.Remove(workItem);
                        DataSave(true);
                    }
                }
            }
        }

        int delayTime = 3 * 1000; // 3초
        bool IsSaving = false;
        int cnt = 0;
        List<string> changeKeys = new List<string>();

        private void NewWorkItemCtrl_DataChanged(string prop)
        {
            if (CurrentWorkItem?.IsNew ?? false) return;

            if (prop == "Save")
            {
                if (IsSaving)
                {
                    delayTime = 0;
                }
                else
                {
                    delayTime = 0;
                    FireSaving();
                }
                return;
            }

            if (changeKeys.Contains(prop) == false)
            {
                changeKeys.Add(prop);
            }

            delayTime = 3 * 1000;
            // 시간차 ( 10초 이내 입력 없으면 초기화 )
            if (IsSaving == false)
            {
                label1.BackColor = Color.Coral;

                IsSaving = true;
                Ux.AsyncCall(() => FireSaving());
            } 
        }

        private void FireSaving()
        {
            while (0 < delayTime)
            {
                System.Threading.Thread.Sleep(200);
                delayTime -= 200;
            }
            this.DoInvoke(fm => 
            { 
                DataSave();
                label1.BackColor = Color.WhiteSmoke;
            });
            IsSaving = false;
        }

        private void NewWorkItemCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            WorkItemControl workItem = sender as WorkItemControl;
            SetCurrentWorkItem(workItem);
        }

        private void SetCurrentWorkItem(WorkItemControl workItem)
        {
            if (CurrentWorkItem == workItem) return;

            if (CurrentWorkItem != null)
            {
                CurrentWorkItem.BackColor = Color.WhiteSmoke;
            }

            ClearFileItems();

            ClearMenus();

            CurrentWorkItem = workItem;

            if (CurrentWorkItem != null)
            {
                CurrentWorkItem.BackColor = Color.DeepSkyBlue;
                SetFileItems(CurrentWorkItem);

                SetMenus(CurrentWorkItem);
            } 
        }

        private void SetMenus(WorkItemControl currentWorkItem)
        {
            if (currentWorkItem == null || currentWorkItem.Data == null || currentWorkItem.Data.Menus == null) return;

            int max = 120;
            if (0 < currentWorkItem.Data.Menus.Count)
            {
               max = currentWorkItem.Data.Menus.Max(mnu => TextRenderer.MeasureText(mnu.Name, lvMnu.Font).Width + 20);
            }
            if (max < 120) max = 120;

            lvMnu.Columns.Clear();
            lvMnu.Columns.Add("ID").Width = 0;
            lvMnu.Columns.Add("Eng").Width = max;
            lvMnu.Columns.Add("Kor").Width = lvMnu.Width - (max + 10);

            List<Mnu> Menus = Ux.LoadFile<List<Mnu>>($"{MainTodoForm.__Menu_DIR}{MainTodoForm.__MENULIST_FILENAME}");

            for (int loop = currentWorkItem.Data.Menus.Count - 1; loop >= 0; loop--)
            {
                var mnu = currentWorkItem.Data.Menus[loop];
                if (Menus.Any(m => m.GUID == mnu.GUID)) continue;
                currentWorkItem.Data.Menus.RemoveAt(loop);
            }

            lvMnu.Groups.Clear();
            foreach (var g in currentWorkItem.Data.Menus.GroupBy(m => m.GroupName))
            {
                lvMnu.Groups.Add(g.Key, g.Key);
            }

            foreach (var m in currentWorkItem.Data.Menus)
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

        private void ClearFileItems()
        {
            try
            {

                //flowLayoutPanel2.SuspendLayout();

                for (int loop = flowLayoutPanel2.Controls.Count - 1; loop >= 0; loop--)
                {
                    Control ctrl = flowLayoutPanel2.Controls[loop];
                    using (ctrl)
                    {
                        FileItemControl fileItem = ctrl as FileItemControl;
                        if (fileItem != null)
                        {
                            fileItem.DataChanged = null;
                        }
                    }
                }
            }
            finally
            { 
                //flowLayoutPanel2.ResumeLayout(false);
                //flowLayoutPanel2.PerformLayout();
            }
        }

        private void SetFileItems(WorkItemControl workItem)
        {
            if (workItem == null || workItem.Data == null) return;
            try
            {
                //flowLayoutPanel2.SuspendLayout();
                List<FileData> delFiles = new List<FileData>();
                foreach (FileData filedata in workItem.Data.FileDatas)
                {
                    if (!filedata.HasFileExists())
                    {
                        delFiles.Add(filedata);
                        continue;
                    }

                    FileItemControl fileItem = new FileItemControl();
                    fileItem.DataChanged = NewWorkItemCtrl_DataChanged;
                    fileItem.SetData(filedata);
                    flowLayoutPanel2.Controls.Add(fileItem);

                    fileItem.Width = flowLayoutPanel2.Width - 0;
                    if (flowLayoutPanel2.VerticalScroll.Visible)
                    {
                        fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }

                if (0 < delFiles.Count)
                {
                    for (int loop = delFiles.Count - 1; loop >= 0; loop--)
                    {
                        workItem.Data.FileDatas.Remove(delFiles[loop]);
                    }

                    FireSaving();
                }
            }
            finally
            {
                //flowLayoutPanel2.ResumeLayout(false);
                //flowLayoutPanel2.PerformLayout();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (WorkItemControl item in flowLayoutPanel1.Controls)
            {
                item.IsDeleteSelect = false;
                item.SetDeleteMode(true);
            } 
            btnDelOK.BringToFront();
            btnDelCancel.BringToFront();
        }

        private void btnDelOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제?", "삭제확인", MessageBoxButtons.OK) != DialogResult.OK) return;

            SetCurrentWorkItem(null);
            List<WorkItemControl> delWorkItems = new List<WorkItemControl>();
            foreach (WorkItemControl item in flowLayoutPanel1.Controls)
            {
                if (item.IsDeleteSelect)
                {
                    delWorkItems.Add(item);
                }
            }

            if (0 < delWorkItems.Count)
            {
                for (int loop = delWorkItems.Count - 1; loop >= 0; loop--)
                {
                    using (delWorkItems[loop])
                    { 
                        delWorkItems[loop].MouseDown -= NewWorkItemCtrl_MouseDown;
                        delWorkItems[loop].DataChanged = null;
                        delWorkItems[loop].Complite -= NewWorkItemCtrl_btnCompliteClick;
                    }
                }
            }

            btnDelOK.SendToBack();
            btnDelCancel.SendToBack();

            // 목록 저장.
            DataSave(true);
        }
         
        private void btnDelCancel_Click(object sender, EventArgs e)
        {
            foreach (WorkItemControl item in flowLayoutPanel1.Controls)
            {
                item.SetDeleteMode(false);
            }

            btnDelOK.SendToBack();
            btnDelCancel.SendToBack();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            try
            { 
                //flowLayoutPanel1.SuspendLayout(); 
                foreach (WorkItemControl item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.Width - 6;
                    if (flowLayoutPanel1.VerticalScroll.Visible)
                    {
                        item.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }
            }
            finally
            { 
                //flowLayoutPanel1.ResumeLayout(false);
                //flowLayoutPanel1.PerformLayout();
            }
        }

        private void flowLayoutPanel1_Move(object sender, EventArgs e)
        {
          //ResizeFlowLayoutPanel();
        } 

        private void DataSave(bool isDel = false)
        {
            if (CurrentWorkItem?.IsNew ?? false) return;

            bool hasNewItem = false;
            List<TodoData> tmp = new List<TodoData>();
            foreach (WorkItemControl item in flowLayoutPanel1.Controls)
            {
                item.DataFlush();
                tmp.Add(item.Data);
                if (item.IsNew)
                {
                    hasNewItem = true;
                }
            }
            Ux.SaveFile(tmp, Path.Combine(__ROOT_DIR + ProjectName, __TODOLIST_FILENAME));

            string guid = "";
            if (CurrentWorkItem != null && CurrentWorkItem.Data != null)
            {
                guid = CurrentWorkItem.Data.GUID;
            }             
            if (hasNewItem || isDel || changeKeys.Contains(__REQUESTER) || changeKeys.Contains(__ORDERINDEX) || changeKeys.Contains(__MENUS))
            {
                DataLoad();
                if (string.IsNullOrWhiteSpace(guid))
                {
                    foreach (WorkItemControl item in flowLayoutPanel1.Controls)
                    {
                        if (item.Data.GUID == guid)
                        {
                            SetCurrentWorkItem(item);
                            flowLayoutPanel1.ScrollControlIntoView(CurrentWorkItem);
                            break;
                        }
                    }
                }
            }
            changeKeys.Clear();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public void DataLoad(string guid = "")
        {
            try
            {
                this.tableLayoutPanel1.SuspendLayout();
                
                // todo
                flowLayoutPanel1.Visible = false;

                string GUID = "";
                if (CurrentWorkItem != null && CurrentWorkItem.Data != null)
                {
                    GUID = CurrentWorkItem.Data?.GUID;
                }

                SetCurrentWorkItem(null);
                for (int loop = flowLayoutPanel1.Controls.Count - 1; loop >= 0; loop--)
                {
                    WorkItemControl workItem = flowLayoutPanel1.Controls[loop] as WorkItemControl;
                    using (workItem)
                    {
                        workItem.MouseDown -= NewWorkItemCtrl_MouseDown;
                        workItem.DataChanged = null;
                        workItem.Complite -= NewWorkItemCtrl_btnCompliteClick;
                    }
                }
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Refresh();
                
                List<TodoData> tmp = Ux.LoadFile<List<TodoData>>(Path.Combine(__ROOT_DIR + ProjectName, __TODOLIST_FILENAME));
                if (tmp != null)
                {
                    Dictionary<string, int> Requester = new Dictionary<string, int>();
                    foreach (TodoData data in tmp.OrderBy(o => o.OrderIndex).ThenBy(o => o.RequestDate))
                    {
                        string requester = data.Requester?.Trim() ?? "";
                        if (!Requester.ContainsKey(requester))
                        {
                            Requester.Add(requester, 0);
                        }
                        Requester[data.Requester]++;

                        WorkItemControl workItemCtrl = new WorkItemControl(false);
                        workItemCtrl.MouseDown += NewWorkItemCtrl_MouseDown;
                        workItemCtrl.DataChanged = NewWorkItemCtrl_DataChanged;
                        workItemCtrl.Complite += NewWorkItemCtrl_btnCompliteClick;

                        workItemCtrl.SetTodoData(data);
                        flowLayoutPanel1.Controls.Add(workItemCtrl);
                        flowLayoutPanel1.Refresh();
                        if (data.GUID == GUID)
                        {
                            SetCurrentWorkItem(workItemCtrl);
                        }
                    }

                    for (int loop = flpnlRequester.Controls.Count - 1; loop >= 0; loop--)
                    {
                        Button btn = flpnlRequester.Controls[loop] as Button;
                        using (btn)
                        {
                            btn.Click -= Btn_Click;
                        }
                    }

                    foreach (var item in Requester)
                    {
                        Button btn = new Button() { Name = item.Key, Text = $"{item.Key} ({item.Value})", Height = 37, TextAlign = ContentAlignment.MiddleCenter, Margin = new Padding(0, 3, 0, 3) };
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.BackColor = Color.White;
                        btn.Click += Btn_Click;

                        flpnlRequester.Controls.Add(btn);
                        btn.Width = flpnlRequester.Width - 0;
                        if (flpnlRequester.VerticalScroll.Visible)
                        {
                            btn.Width -= SystemInformation.VerticalScrollBarWidth;
                        }
                    }
                }
                tmp = null;
            }
            finally
            {
                flowLayoutPanel1.Visible = true; 
                tableLayoutPanel1.ResumeLayout(false);
                //this.ResumeLayout(false);
                if (CurrentWorkItem != null)
                {
                    flowLayoutPanel1.ScrollControlIntoView(CurrentWorkItem);
                }
            }
        }
         
        private void btnRequesterAll_Click(object sender, EventArgs e)
        {
            // 필터
            Filter("");
        }
         
        private void Btn_Click(object sender, EventArgs e)
        {
            // 필터
            Button btn = sender as Button;
            Filter(btn?.Name);
        }

        string Requester { get; set; } = "";
        private void Filter(string requester)
        {
            Requester = "" + requester;
            try
            {
                flowLayoutPanel1.SuspendLayout(); 
                SetCurrentWorkItem(null);

                foreach (WorkItemControl item in flowLayoutPanel1.Controls)
                {
                    if (string.IsNullOrWhiteSpace(requester))
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = ("" + item.Data?.Requester).Trim() == requester.Trim();
                    }
                }
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout(false);
                flowLayoutPanel1.PerformLayout();
            }
        }

        private void flowLayoutPanel2_DragDrop(object sender, DragEventArgs e)
        {
            if (CurrentWorkItem != null && e.Data.GetDataPresent("FileDrop") &&
               ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy ||
                 (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move ||
                 (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link))
            {
                object datas = e.Data.GetData("FileDrop");

                if (datas is string[])
                {
                    string[] files = datas as string[];

                    if (files != null)
                    {
                        string parentPath = Path.Combine(__ROOT_DIR + ProjectName, CurrentWorkItem.Data.GUID );
                        if (!Directory.Exists(parentPath))
                        {
                            Directory.CreateDirectory(parentPath);
                        }

                        foreach (string file in files)
                        {
                            FileData filedata = new FileData() { GUID = Guid.NewGuid().ToString("N"), OriginalFilePath = file }; 
                            filedata.CopyFile(parentPath);
                            CurrentWorkItem.Data.FileDatas.Add(filedata);
                            FileItemControl fileItem = new FileItemControl();
                            fileItem.DataChanged = NewWorkItemCtrl_DataChanged; 
                            fileItem.SetData(filedata);
                            flowLayoutPanel2.Controls.Add(fileItem);

                            fileItem.Width = flowLayoutPanel2.Width - 0;
                            if (flowLayoutPanel2.VerticalScroll.Visible)
                            {
                                fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
                            }
                        }
                        delayTime = 0;
                        FireSaving();
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
         
        private void flowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
        { 
            if (CurrentWorkItem != null &&
                e.Data.GetDataPresent("FileNameW") && e.Data.GetDataPresent("FileDrop") &&
               ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy ||
                 (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move ||
                 (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link))
            {
                e.Effect = e.AllowedEffect;
            }
            else
            {
                if (CurrentWorkItem == null)
                {
                    MessageBox.Show("작업을 선택하여야 함.");
                } 
                e.Effect = DragDropEffects.None;
            }
        }

        private void flowLayoutPanel2_Resize(object sender, EventArgs e)
        {
            ResizeFlowLayoutPanel2();
        }

        private void ResizeFlowLayoutPanel2()
        {
            try
            {
                //flowLayoutPanel2.SuspendLayout();
                foreach (FileItemControl item in flowLayoutPanel2.Controls)
                {
                    item.Width = flowLayoutPanel2.Width - 6;
                    if (flowLayoutPanel2.VerticalScroll.Visible)
                    {
                        item.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }
            }
            finally
            {
                //flowLayoutPanel2.ResumeLayout(false);
                //flowLayoutPanel2.PerformLayout();
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            // 캡쳐!
            if (CurrentWorkItem == null || CurrentWorkItem.Data == null)
            {
                MessageBox.Show("선택된 작업내역이 없음.");
                return;
            }

            try
            {
                CaptureHelper.Install(Handle);
                CaptureHelper.CaptureRegion(true);
            }
            finally
            {
                CaptureHelper.UnInstall();

                if (!(CurrentWorkItem == null || CurrentWorkItem.Data == null))
                {
                    string parentPath = Path.Combine(__ROOT_DIR + ProjectName, CurrentWorkItem.Data.GUID);
                    if (!Directory.Exists(parentPath))
                    {
                        Directory.CreateDirectory(parentPath);
                    }
                    FileInfo dummyFile = new FileInfo(MainForm._conf.OutputFileAsFullpath);
                    if (dummyFile.Exists && 0 < dummyFile.Length)
                    {
                        FileData filedata = new FileData() { GUID = Guid.NewGuid().ToString("N"), OriginalFilePath = MainForm._conf.OutputFileAsFullpath };
                        filedata.CopyFile(parentPath);
                        CurrentWorkItem.Data.FileDatas.Add(filedata);
                        FileItemControl fileItem = new FileItemControl();
                        fileItem.DataChanged = NewWorkItemCtrl_DataChanged;
                        fileItem.SetData(filedata);
                        flowLayoutPanel2.Controls.Add(fileItem);

                        fileItem.Width = flowLayoutPanel2.Width - 0;
                        if (flowLayoutPanel2.VerticalScroll.Visible)
                        {
                            fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
                        }
                        delayTime = 0;
                        FireSaving();
                    }
                }
            }
        }

        void CaptureWin()
        { 
            try
            {
                if (CurrentWorkItem == null || CurrentWorkItem.Data == null)
                {
                    MessageBox.Show("선택된 작업내역이 없음.");
                    return;
                }

                CaptureHelper.Install(Handle);
                if (MainForm._conf.CaptureWindowsInteractive)
                {
                    CaptureHelper.CaptureWindowInteractive(true);
                }
                else
                {
                    CaptureHelper.CaptureWindow(true);
                }
            }
            finally
            {
                CaptureHelper.UnInstall();

                if (!(CurrentWorkItem == null || CurrentWorkItem.Data == null))
                { 
                    string parentPath = Path.Combine(__ROOT_DIR + ProjectName, CurrentWorkItem.Data.GUID);
                    if (!Directory.Exists(parentPath))
                    {
                        Directory.CreateDirectory(parentPath);
                    }

                    FileData filedata = new FileData() { GUID = Guid.NewGuid().ToString("N"), OriginalFilePath = MainForm._conf.OutputFileAsFullpath };
                    filedata.CopyFile(parentPath);
                    CurrentWorkItem.Data.FileDatas.Add(filedata);
                    FileItemControl fileItem = new FileItemControl();
                    fileItem.DataChanged = NewWorkItemCtrl_DataChanged;
                    fileItem.SetData(filedata);
                    flowLayoutPanel2.Controls.Add(fileItem);

                    fileItem.Width = flowLayoutPanel2.Width - 0;
                    if (flowLayoutPanel2.VerticalScroll.Visible)
                    {
                        fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                    delayTime = 0;
                    FireSaving();
                }
            }
        } 

        private void CaptureIE()
        {
            if (CurrentWorkItem == null || CurrentWorkItem.Data == null)
            {
                MessageBox.Show("선택된 작업내역이 없음.");
                return;
            }

            try
            { 
                CaptureHelper.Install(Handle);
                CaptureHelper.CaptureIe(true, null);
            }
            finally
            {
                CaptureHelper.UnInstall();

                if (!(CurrentWorkItem == null || CurrentWorkItem.Data == null))
                {
                    string parentPath = Path.Combine(__ROOT_DIR + ProjectName, CurrentWorkItem.Data.GUID);
                    if (!Directory.Exists(parentPath))
                    {
                        Directory.CreateDirectory(parentPath);
                    }

                    FileData filedata = new FileData() { GUID = Guid.NewGuid().ToString("N"), OriginalFilePath = MainForm._conf.OutputFileAsFullpath };
                    filedata.CopyFile(parentPath);
                    CurrentWorkItem.Data.FileDatas.Add(filedata);
                    FileItemControl fileItem = new FileItemControl();
                    fileItem.DataChanged = NewWorkItemCtrl_DataChanged;
                    fileItem.SetData(filedata);
                    flowLayoutPanel2.Controls.Add(fileItem);

                    fileItem.Width = flowLayoutPanel2.Width - 0;
                    if (flowLayoutPanel2.VerticalScroll.Visible)
                    {
                        fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                    delayTime = 0;
                    FireSaving();
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (HandleMessages(ref m))
            {
                return;
            }
            // BUG-1809 prevention, filter the InputLangChange messages
            if (PreFilterMessageExternal(ref m))
            {
                return;
            }
            base.WndProc(ref m);
        }
         
        public static void UnregisterHotkeys()
        {
            foreach (int hotkey in KeyHandlers.Keys)
            {
                UnregisterHotKey(_hotkeyHwnd, hotkey);
            }
            // Remove all key handlers
            KeyHandlers.Clear();
        }

        /// <summary>
        /// Also used in the MainForm WndProc
        /// </summary>
        /// <param name="m">Message</param>
        /// <returns>true if the message should be filtered</returns>
        public static bool PreFilterMessageExternal(ref Message m)
        {
            WindowsMessages message = (WindowsMessages)m.Msg;
            if (message == WindowsMessages.WM_INPUTLANGCHANGEREQUEST || message == WindowsMessages.WM_INPUTLANGCHANGE)
            {
                // For now we always return true
                return true;
                // But it could look something like this:
                //return (m.LParam.ToInt64() | 0x7FFFFFFF) != 0;
            }
            return false;
        }

        /// <summary>
        /// Handle WndProc messages for the hotkey
        /// </summary>
        /// <param name="m"></param>
        /// <returns>true if the message was handled</returns>
        public static bool HandleMessages(ref Message m)
        {
            if (m.Msg != WM_HOTKEY)
            {
                return false;
            }

            HotKeyHandler handler;
            if (KeyHandlers.TryGetValue((int)m.WParam, out handler))
            {
                handler();
            }
            return true;
        }


        // Delegates for hooking up events.
        public delegate void HotKeyHandler();

        private static bool RegisterWrapper(Keys modifierKeyCode, Keys virtualKeyCode, IntPtr _hotkeyHwnd, HotKeyHandler handler, bool ignoreFailedRegistration)
        {
            int success = RegisterHotKey(modifierKeyCode, virtualKeyCode, _hotkeyHwnd, handler);
            return 0 < success;
        }

        // Holds the list of hotkeys
        private static readonly IDictionary<int, HotKeyHandler> KeyHandlers = new Dictionary<int, HotKeyHandler>();
        private static int _hotKeyCounter = 1;
        private const uint WM_HOTKEY = 0x312;
        private static IntPtr _hotkeyHwnd;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public enum Modifiers : uint
        {
            NONE = 0,
            ALT = 1,
            CTRL = 2,
            SHIFT = 4,
            WIN = 8,
            NO_REPEAT = 0x4000
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint virtualKeyCode);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int GetKeyNameText(uint lParam, [Out] StringBuilder lpString, int nSize);

        /// <summary>
        /// Register a hotkey
        /// </summary>
        /// <param name="modifierKeyCode">The modifier, e.g.: Modifiers.CTRL, Modifiers.NONE or Modifiers.ALT</param>
        /// <param name="virtualKeyCode">The virtual key code</param>
        /// <param name="handler">A HotKeyHandler, this will be called to handle the hotkey press</param>
        /// <returns>the hotkey number, -1 if failed</returns>
        public static int RegisterHotKey(Keys modifierKeyCode, Keys virtualKeyCode, IntPtr _hotkeyHwnd, HotKeyHandler handler)
        {
            if (virtualKeyCode == Keys.None)
            {

                return 0;
            }
            // Convert Modifiers to fit HKM_SETHOTKEY
            uint modifiers = 0;
            if ((modifierKeyCode & Keys.Alt) > 0)
            {
                modifiers |= (uint)Modifiers.ALT;
            }
            if ((modifierKeyCode & Keys.Control) > 0)
            {
                modifiers |= (uint)Modifiers.CTRL;
            }
            if ((modifierKeyCode & Keys.Shift) > 0)
            {
                modifiers |= (uint)Modifiers.SHIFT;
            }
            if (modifierKeyCode == Keys.LWin || modifierKeyCode == Keys.RWin)
            {
                modifiers |= (uint)Modifiers.WIN;
            }
            // Disable repeating hotkey for Windows 7 and beyond, as described in #1559
            //if (IsWindows7OrOlder)
            //{
            //    modifiers |= (uint)Modifiers.NO_REPEAT;
            //}
            if (RegisterHotKey(_hotkeyHwnd, _hotKeyCounter, modifiers, (uint)virtualKeyCode))
            {
                KeyHandlers.Add(_hotKeyCounter, handler);
                return _hotKeyCounter++;
            }
            else
            {
                return -1;
            }
        }

        private void btnTXT_Click(object sender, EventArgs e)
        {
            if (CurrentWorkItem == null || CurrentWorkItem.Data == null) return;

            string parentPath = Path.Combine(__ROOT_DIR + ProjectName, CurrentWorkItem.Data.GUID);
            if (!Directory.Exists(parentPath))
            {
                Directory.CreateDirectory(parentPath);
            }

            FileData filedata = new FileData() { GUID = Guid.NewGuid().ToString("N"), OriginalFilePath = "텍스트.txt" };
            filedata.Create(parentPath);
            CurrentWorkItem.Data.FileDatas.Add(filedata);
            FileItemControl fileItem = new FileItemControl();
            fileItem.DataChanged = NewWorkItemCtrl_DataChanged;
            fileItem.SetData(filedata);
            flowLayoutPanel2.Controls.Add(fileItem);

            fileItem.Width = flowLayoutPanel2.Width - 0;
            if (flowLayoutPanel2.VerticalScroll.Visible)
            {
                fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
            } 

            delayTime = 0;            
            FireSaving();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (CurrentWorkItem == null || CurrentWorkItem.Data == null) return;

            string parentPath = Path.Combine(__ROOT_DIR + ProjectName, CurrentWorkItem.Data.GUID);
            if (!Directory.Exists(parentPath))
            {
                Directory.CreateDirectory(parentPath);
            }
            FileData filedata = new FileData() { GUID = Guid.NewGuid().ToString("N"), OriginalFilePath = "엑셀파일.xlsx" };
            filedata.CopyFile(parentPath);
            CurrentWorkItem.Data.FileDatas.Add(filedata);
            FileItemControl fileItem = new FileItemControl();
            fileItem.DataChanged = NewWorkItemCtrl_DataChanged;
            fileItem.SetData(filedata);
            flowLayoutPanel2.Controls.Add(fileItem);

            fileItem.Width = flowLayoutPanel2.Width - 0;
            if (flowLayoutPanel2.VerticalScroll.Visible)
            {
                fileItem.Width -= SystemInformation.VerticalScrollBarWidth;
            } 
          
            delayTime = 0;
            FireSaving();
        }
        
        private void MainTodoForm_Resize(object sender, EventArgs e)
        {
            try
            {
                flowLayoutPanel1.Width = this.Width - (flowLayoutPanel2.Width + flpnlRequester.Width + 22);
            }
            finally
            {
                flowLayoutPanel1.Refresh();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string txt = txtSearch.TextBox.Text.Trim();

                //flowLayoutPanel1.SuspendLayout(); 
                SetCurrentWorkItem(null); 
                foreach (WorkItemControl item in flowLayoutPanel1.Controls)
                {
                    if (string.IsNullOrWhiteSpace(txt))
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = ("" + item.Data?.Working).Trim().Contains( txt );
                    }
                }
            }
            finally
            {
                //flowLayoutPanel1.ResumeLayout(false);
                //flowLayoutPanel1.PerformLayout();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.TextBox.SelectAll();
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            txtSearch.TextBox.Text = "";
            btnSearch.PerformClick();
        }

        private void btnOpenHistory_Click(object sender, EventArgs e)
        {
            using (OpenHistoryForm ohf = new OpenHistoryForm())
            {
                ohf.SetData(__ROOT_DIR, ProjectName, __TODOLIST_FILENAME, __COMPLITE_DIR);
                ohf.ShowDialog(this);
            }
        }

        private void btnSelMnu_Click(object sender, EventArgs e)
        {
            // 화면 선택!
            using (MnuManagerFm mf = new MnuManagerFm())
            {
                if (CurrentWorkItem != null)
                {
                    mf.HasCheckBoxs = true;
                    mf.SetMenus(CurrentWorkItem.Data.Menus);
                }
                else {
                    mf.HasCheckBoxs = false;
                }

                if (mf.ShowDialog(this) == DialogResult.OK)
                {
                    if (CurrentWorkItem == null) return;

                    // 선택된 화면 목록 >>> 
                    List<Mnu> SelectionMnu = mf.MnuSelected;
                    CurrentWorkItem.Data.Menus.Clear();
                    CurrentWorkItem.Data.Menus.AddRange(SelectionMnu);

                    ClearMenus();
                    SetMenus(CurrentWorkItem);

                    changeKeys.Add(__MENUS);
                    delayTime = 0;
                    FireSaving();
                }
            }
        }

        private void btnMenuHist_Click(object sender, EventArgs e)
        {
            using (OpenMenuHistoryForm ohf = new OpenMenuHistoryForm())
            {
                ohf.SetData(__ROOT_DIR, ProjectName, __TODOLIST_FILENAME, __COMPLITE_DIR);
                ohf.ShowDialog();
            }
        }
    }

    public static class Ux
    {
        public static void SaveFile<T>(T obj, string filePath, Encoding encoding = null)
        {
            if (obj == null) return;

            if (string.IsNullOrWhiteSpace(filePath)) return;

            string dir = Path.GetDirectoryName(filePath);
            if (string.IsNullOrWhiteSpace( dir ) == false && Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            File.WriteAllText(filePath, json, encoding ?? Encoding.UTF8);
        }

        public static T LoadFile<T>(string filePath, Encoding encoding = null)
        {
            T obj = default(T);
             
            if (string.IsNullOrWhiteSpace( filePath ) == false && File.Exists(filePath) == false)
            {
                return obj;
            }

            try
            {
                string json = File.ReadAllText(filePath, encoding ?? Encoding.UTF8);
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                obj = default(T);
            }
            return obj;
        }

        /// <summary>
        /// 컨트롤 비동기 호출! 
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="ctrl"></param>
        /// <param name="action"></param>
        public static void DoInvoke<TControl>(this TControl ctrl, Action<TControl> action) where TControl : Control
        {
            try
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(action, ctrl);
                }
                else
                {
                    action(ctrl);
                }
            }
            catch { 
                //error?
            }
        }

        public static void AsyncCall(Action asyncMethod = null)
        {
            if (asyncMethod != null)
            {
                try
                {
                    asyncMethod.BeginInvoke(ir => asyncMethod.EndInvoke(ir), null);
                }
                catch { }
            }
        }

        public static void AsyncCall<T>(T args, Action<T> asyncMethod = null)
        {
            if (asyncMethod != null)
            {
                asyncMethod.BeginInvoke(args, ir => asyncMethod.EndInvoke(ir), asyncMethod);
            }
        }

        public static object GetNonPublicProperty(object obj, string propertyName)
        {
            PropertyInfo p = obj.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            return p.GetValue(obj, null);
        }

        public static void SetNonPublicProperty(object obj, string propertyName, object value)
        {
            PropertyInfo p = obj.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty);
            p.SetValue(obj, value);
        }

        public static void GetNonPublicMethod(object obj, string methodName, object[] values)
        {
            MethodInfo m = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
            m.Invoke(obj, values);
        }
         
        public static DateTime? ToDateTime(this object obj, string Fmt)
        {
            DateTime _datetime;
            //try
            //{ 
            //    _datetime = DateTime.ParseExact("" + obj, "yyyy-MM-dd tt H:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal);
            //    return _datetime;
            //}
            //catch (Exception)
            //{ } 

            if (string.IsNullOrEmpty(Fmt)) Fmt = "yyyy-MM-dd tt hh:mm:ss";

            //if (obj.IsNull() || string.IsNullOrEmpty(("" + obj))) return null;
            //else
            //{
            //    return DateTime.ParseExact("" + obj, Fmt, null, System.Globalization.DateTimeStyles.AssumeLocal);
            //}
            string dt = "" + obj;
            if (dt.Contains("오전") || dt.Contains("오후"))
            {
                if (dt.Length == "yyyy-MM-dd 오후 hh:mm:ss".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd tt hh:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd 오후 H:mm:ss".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd tt H:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
            }
            else
            {
                if (dt.Length == "yyyy-MM-dd hh:mm:ss".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd hh:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd h:mm:ss".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd h:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd hh:mm:ss.fff".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd hh:mm:ss.fff", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd h:mm:ss.fff".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd h:mm:ss.fff", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyyMMdd".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
            }
            return null;
        }
    }

    public class TodoData
    {
        public string GUID { get; set; }

        public string Title { get; set; }
        public string MenuID { get; set; }

        public string Working { get; set; }
        public string Requester { get; set; }
        public string RequestDate { get; set; }

        public string CompliteDate { get; set; }
        public bool Issue { get; set; } = false;
        public string Remark { get; set; }

        public int OrderIndex { get; set; } = int.MaxValue;

        public List<FileData> FileDatas { get; set; } = new List<FileData>();

        public List<DailyItem> DailyItems { get; set; } = new List<DailyItem>();

        public List<Mnu> Menus { get; set; } = new List<Mnu>();

        public bool IsNotify { get; set; } = false;

        public int WorkTime { get; set; }

        public DifficulyEnum Difficuly { get; set; }
    }

    public class FileData
    {
        public string GUID { get; set; }

        public string Alias { get; set; }

        public string OriginalFilePath { get; set; }

        public string NewFilePath { get; set; }

        internal void CopyFile(string parentDir)
        {
            if (Directory.Exists(parentDir) == false) return;
            if (File.Exists(OriginalFilePath) == false) return;
            string extension = Path.GetExtension(OriginalFilePath); 
            string newFileName = Path.Combine(parentDir, GUID) + extension;
            File.Copy(OriginalFilePath, newFileName, true);
            NewFilePath = newFileName;
        }

        internal string GetFilePath()
        {
            string href = NewFilePath.Replace(@"\\", @"\");
            href = href.Replace( MainTodoForm.__ROOT_DIR + MainTodoForm.ProjectName, "");
            href = href.Replace(MainTodoForm.__ROOT_DIR, "");
            href = MainTodoForm.__ROOT_DIR + MainTodoForm.ProjectName + href.Trim(); //Replace(@"\", @"/")
            return href;
        }

        internal bool HasFileExists()
        {
            string filePath = GetFilePath();
            if (string.IsNullOrWhiteSpace(filePath)) return false;
            return File.Exists(filePath);
        }

        internal void Create(string parentDir)
        {
            if (Directory.Exists(parentDir) == false) return;
            string extension = Path.GetExtension(OriginalFilePath);
            string newFileName = Path.Combine(parentDir, GUID) + extension;
            using (var fs = File.Create(newFileName))
            {
                fs.Close();
            }
            NewFilePath = newFileName;
        }

        public bool IsDelete { get; set; } 
    }

    public class DailyItem
    { 
        public string WorkingDate { get; set; }
        
        public string Comment { get; set; }

        public string CompliteDate { get; set; }

        public string IssueDate { get; set; }

        public string State { get; set; }

        public bool IsDel { get; set; }
    }

    //상태 : [등록], [완료], [삭제]

    public class Mnu
    {
        public string GUID { get; set; }

        public Mnu()
        {
            GUID = Guid.NewGuid().ToString("N");
        }

        public string GroupName { get; set; }

        public string Text { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
