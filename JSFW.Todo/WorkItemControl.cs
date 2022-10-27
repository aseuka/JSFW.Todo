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
    public partial class WorkItemControl : UserControl
    {
        internal TodoData Data { get; private set; }

        public Action<string> DataChanged = null;

        public event EventHandler Complite = null; 

        public bool IsDeleteSelect
        {
            get => checkBox1.Checked;
            set => checkBox1.Checked = value;
        }

        public bool IsNew { get; private set; }

        int Order
        {
            get { return GetOrder(); }
            set { SetOrder(value); }
        }

        private void SetOrder(int value)
        {
            try
            {
                chk01.Checked = false;
                chk02.Checked = false;
                chk03.Checked = false;
                chk04.Checked = false;
                chk05.Checked = false;

                int odr = int.MaxValue;
                if (5 <= value) odr = 5;
                else odr = value;
                chk01.Checked = odr <= 5;
                chk02.Checked = odr <= 4;
                chk03.Checked = odr <= 3;
                chk04.Checked = odr <= 2;
                chk05.Checked = odr <= 1;
            }
            finally
            {
            }
        }

        private int GetOrder()
        {
            int odr = 6;
            if (chk01.Checked) --odr;
            if (chk02.Checked) --odr;
            if (chk03.Checked) --odr;
            if (chk04.Checked) --odr;
            if (chk05.Checked) --odr; 
            if (5 < odr) odr = int.MaxValue; 
            return odr;
        }

        public WorkItemControl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Ux.SetNonPublicProperty(tableLayoutPanel1, "DoubleBuffered", true);

            this.btnComplite.Click += BtnComplite_Click;
            this.Disposed += WorkItemControl_Disposed;
        }

        private void BtnComplite_Click(object sender, EventArgs e)
        {
            if (IsNew)
            {
                btnComplite.Text = "완료";
                btnComplite.BackColor = Color.Transparent;
                btnComplite.ForeColor = Color.Black;
                IsNew = false;
                Saving(MainTodoForm.__ORDERINDEX);
                return;
            }

            if (Complite != null ) //&& MessageBox.Show("완료?", "확인", MessageBoxButtons.YesNo ) == DialogResult.Yes )
            {
                Complite(this, e);
            }
        }

        public WorkItemControl(bool isNew) : this()
        {
            IsNew = isNew;
            if (IsNew)
            {
                btnComplite.Text = "작성완료";
                btnComplite.BackColor = Color.Coral;
                btnComplite.ForeColor = Color.White;
            }
            chkNotify.Enabled = isNew;
        }

        private void WorkItemControl_Disposed(object sender, EventArgs e)
        {
            Data = null;
        }

        public void SetTodoData(TodoData data)
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
                    txtTitle.Text = Data.Title;
                    txtWorking.Text = Data.Working;
                    txtRequestDate.Text = Data.RequestDate;
                    txtRequester.Text = Data.Requester;
                    Order = Data.OrderIndex;

                    chkNotify.Checked = Data.IsNotify;
                    chkNotify.Enabled = IsNew;

                    lbFile.Text = "";
                    if (0 < Data.FileDatas.Count)
                    {
                        lbFile.Text = $"File ({Data.FileDatas.Count})";
                    }

                    txtRequestDate.BackColor = GetRequestDateBackColor(txtRequestDate.Text);

                    try
                    {
                        flpWorkDaily.SuspendLayout(); 
                        foreach (var daily in Data.DailyItems)
                        {
                            WorkDailyItem ctrl = new WorkDailyItem();
                            ctrl.DataChanged = DataChanged;
                            ctrl.SetDailyData(daily);
                            flpWorkDaily.Controls.Add(ctrl);
                        }
                    }
                    finally
                    {
                        flpWorkDaily.ResumeLayout(false);
                        flpWorkDaily.PerformLayout();
                    }
                }
            }
            finally
            {
                ResizeDaily();

                IsDataBinding = false;
                txtRequestDate.ReadOnly = true;
                flpWorkDaily.Height = (flpWorkDaily.Controls.Count * 24) + (flpWorkDaily.Controls.Count * 6);
                ResizeTextBoxHight();
            }
        }

        private Color GetRequestDateBackColor(string date)
        {
            Color backcolor = SystemColors.Control;
             
            if (10 <= date.Trim().Length &&
                (string.Compare($"{DateTime.Now.AddDays(-7):yyyy-MM-dd}", date.Substring(0, 10)) <= 0 && string.Compare(date.Substring(0, 10), $"{DateTime.Now:yyyy-MM-dd}") <= 0))
            {
                backcolor = Color.LightGreen;
            }
            return backcolor;
        }

        private void ResizeTextBoxHight()
        {
            int basicHeight = 90;
            int h = (int)tableLayoutPanel1.RowStyles[0].Height + TextRenderer.MeasureText(txtWorking.Text, txtWorking.Font).Height + (this.Margin.Top + this.Margin.Bottom) + flpWorkDaily.Height + 4 + 3;
            if ((basicHeight + flpWorkDaily.Height) < h)
            {
                this.Height = h;
            }
            else
            {
                this.Height = basicHeight + flpWorkDaily.Height + 4 + 3;//padding 2더하고 보더값 상하 1씩 (=2) 인가보다
            }
        }

        internal void SetFirstFocus()
        { 
            if (IsNew)
            {
                txtTitle.ReadOnly = false;
                txtRequester.Focus();
                if (string.IsNullOrWhiteSpace(txtRequester.Text) == false)
                {
                    txtTitle.Focus();
                }
            }
            else
            {
                txtTitle.ReadOnly = true;
                txtWorking.Focus();
            }
        }

        private void DataClear()
        {
            txtTitle.Clear();
            txtWorking.Clear();
            txtRequestDate.Clear();
            txtRequester.Clear();

            lbFile.Text = $"";

            chkNotify.Checked = false;

            try
            {
                flpWorkDaily.SuspendLayout();
                for (int idx = flpWorkDaily.Controls.Count - 1; idx >= 0; idx--)
                {
                    WorkDailyItem item = flpWorkDaily.Controls[idx] as WorkDailyItem;
                    if (item != null)
                    {
                        using (item)
                        {
                            flpWorkDaily.Controls.Remove(item);
                            item.DataChanged = null;
                        }
                    }
                }
            }
            catch (Exception)
            { 
            }
            finally
            {
                flpWorkDaily.ResumeLayout(false);
                flpWorkDaily.PerformLayout();
            } 
        }

        private void txtWorking_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            ResizeTextBoxHight();

            Saving("Working");
        }

        private void txtRequestDate_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            //Saving();
        }

        private void txtRequester_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            Saving(MainTodoForm.__REQUESTER);
        }

        private void numOrderIndex_ValueChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            Saving(MainTodoForm.__ORDERINDEX);
        }

        private void Saving(string propName)
        {
            if (IsNew) return;
            if (DataChanged != null) this.DoInvoke(t => DataChanged(propName));
        }
         
        internal void SetDeleteMode(bool deleteMode)
        {
            try
            {
                checkBox1.Visible = true;
            }
            finally
            {
                checkBox1.Visible = deleteMode;
            }
        }
         
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void txtWorking_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void txtRequestDate_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void txtRequester_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        internal void DataFlush()
        {
            if (Data != null)
            {
                Data.Title = txtTitle.Text.Trim();
                Data.MenuID = ""; 
                Data.RequestDate = txtRequestDate.Text.Trim();
                Data.Requester = txtRequester.Text.Trim();
                Data.Working = txtWorking.Text.Trim();
                Data.OrderIndex = Order;
                Data.IsNotify = chkNotify.Checked;
                foreach (WorkDailyItem ctrl in flpWorkDaily.Controls)
                {
                    ctrl.DataFlush();
                } 
            }
        }

        private void txtWorking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                Saving("Save");
            }
            else if (e.KeyCode == Keys.F5)
            {
                Saving("Save");
            }
        }

        private void numOrderIndex_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void btnAddDaily_Click(object sender, EventArgs e)
        {
            //데일리 붙이기.
            DailyItem daily = new DailyItem() {
                WorkingDate = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                State = "등록"
            };
            Data.DailyItems.Add(daily);
            WorkDailyItem ctrl = new WorkDailyItem();
            ctrl.DataChanged = DataChanged;
            ctrl.SetDailyData(daily);
            flpWorkDaily.Controls.Add(ctrl);
            flpWorkDaily.Height = ( flpWorkDaily.Controls.Count * 23 ) + (flpWorkDaily.Controls.Count * 6);
            ctrl.FirstFocus();
            ResizeDaily();
            ResizeTextBoxHight();

            Saving("Working");
            FlowLayoutPanel flp = Parent as FlowLayoutPanel;
            if (flp != null)
            {
                flp.ScrollControlIntoView(this);
            }
        }
        
        private void WorkItemControl_Resize(object sender, EventArgs e)
        { 
            ResizeDaily();
        }

        private void ResizeDaily()
        {
            try
            {
                flpWorkDaily.SuspendLayout();
                foreach (WorkDailyItem item in flpWorkDaily.Controls)
                {
                    item.Width = flpWorkDaily.Width - 6;
                    if (flpWorkDaily.VerticalScroll.Visible)
                    {
                        item.Width -= SystemInformation.VerticalScrollBarWidth;
                    }
                }
            }
            finally
            {
                flpWorkDaily.ResumeLayout(false);
                flpWorkDaily.PerformLayout();
            }
        }
         
        private void chk01_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            IsDataBinding = true;
            SetOrder(5);
            IsDataBinding = false;
            OnMouseDown(null);
            Saving(MainTodoForm.__ORDERINDEX);
        }

        private void chk02_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            IsDataBinding = true;
            SetOrder(4);
            IsDataBinding = false;
            OnMouseDown(null);
            Saving(MainTodoForm.__ORDERINDEX);
        }

        private void chk03_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            IsDataBinding = true;
            SetOrder(3);
            IsDataBinding = false;
            OnMouseDown(null);
            Saving(MainTodoForm.__ORDERINDEX);
        }

        private void chk04_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            IsDataBinding = true;
            SetOrder(2);
            IsDataBinding = false;
            OnMouseDown(null);
            Saving(MainTodoForm.__ORDERINDEX);
        }

        private void chk05_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            IsDataBinding = true;
            SetOrder(1);
            IsDataBinding = false;
            OnMouseDown(null);
            Saving(MainTodoForm.__ORDERINDEX);
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            Saving("Working");
            SetReadOnlyProperty();
        }

        int delayTime = 3 * 1000; // 3초
        bool IsEditLock = false;
        private void SetReadOnlyProperty()
        {
            if (IsNew) return;

            delayTime = 3 * 1000;
            if (IsEditLock == false)
            {
                IsEditLock = true;
                Ux.AsyncCall(() => SetReadOnly());
            }
        } 
        private void SetReadOnly()
        {
            while (0 < delayTime)
            {
                System.Threading.Thread.Sleep(200);
                delayTime -= 200;
            }
            this.DoInvoke(fm =>
            {
                txtTitle.ReadOnly = true;
            });
            IsEditLock = false;
        }

        private void txtMenu_KeyDown(object sender, KeyEventArgs e)
        {
            //제목과 메뉴 텍스트박스에 키다운이벤트를 같이 하고 있음.
            TextBox tb = sender as TextBox;

            if (tb == null) return;

            if (e.KeyCode == Keys.F2)
            {
                tb.ReadOnly = false;
                SetReadOnlyProperty();
            }
        }

        private void txtTitle_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (txtTitle.ReadOnly)
            {
                txtTitle.BackColor = Color.FromArgb(255, 224, 192);
            }
            else
            {
                txtTitle.BackColor = Color.White;
            }
        }
         
        private void checkBox1_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox1.Visible)
            {
                checkBox1.Width = 32;
            }
            else
            {
                checkBox1.Width = 0;
            }
        }

        private void lbFile_DoubleClick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                sw.WriteLine($"# {txtTitle.Text}");
                sw.WriteLine($"BEGIN [{txtRequestDate.Text}]");
                sw.WriteLine($"     {txtWorking.Text.Replace(Environment.NewLine, Environment.NewLine + @"    ")}");
                foreach (WorkDailyItem ctrl in flpWorkDaily.Controls)
                {
                    ctrl.DataFlush();
                    sw.WriteLine($"     - [{ctrl.Data.State}] [{ctrl.Data.CompliteDate}] {ctrl.Data.Comment}");
                }

                foreach (var grp in Data.Menus.GroupBy(g => g.GroupName))
                {
                    sw.WriteLine($"     - @{grp.Key}");
                    foreach (var mnu in Data.Menus.Where(w => w.GroupName == grp.Key))
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
