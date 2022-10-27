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
    public partial class FileItemControl : UserControl
    {
        public FileData Data { get; set; }

        public Action<string> DataChanged = null;

        public FileItemControl()
        {
            InitializeComponent();
            this.Disposed += FileItemControl_Disposed;
        }

        bool IsViewMode = false;
        public FileItemControl(bool isView = false) : this()
        {
            IsViewMode = isView;

            if (IsViewMode)
            {
                btnDel.Visible = false; 
            }
        }

        private void FileItemControl_Disposed(object sender, EventArgs e)
        {
            Data = null;
        }

        internal void SetData(FileData filedata)
        {
            Data = filedata; 
            DataBinding();
        }

        private void DataBinding()
        {
            if (Data != null)
            {
                txtFileName.Text = Path.GetFileName(Data.OriginalFilePath);
                if (!string.IsNullOrWhiteSpace(Data.Alias))
                {
                    txtFileName.Text = Data.Alias;
                }
                txtFileName.ReadOnly = true;
                txtFileName.Modified = false;
                txtFileName.Font = new Font(txtFileName.Font, FontStyle.Strikeout);
                txtFileName.Font = new Font("굴림", 9f);
                if (Data.IsDelete)
                {
                    txtFileName.Font = new Font(txtFileName.Font, FontStyle.Strikeout);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string confirm = Data.IsDelete ? "복원" : "삭제";

            if (MessageBox.Show($"{confirm}?", $"{confirm}", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Data.IsDelete = !Data.IsDelete; 
                txtFileName.Font = new Font("굴림", 9f);
                if (Data.IsDelete)
                {
                    txtFileName.Font = new Font(txtFileName.Font, FontStyle.Strikeout);
                }
                else
                {
                    txtFileName.Font = new Font(txtFileName.Font, FontStyle.Regular);
                }
                Saving("Working");
            }
        }

        private void Saving(string propName)
        {
            if (IsViewMode) return;

            if (DataChanged != null) this.DoInvoke(t => DataChanged(propName));
        }

        private void lbFileName_DoubleClick(object sender, EventArgs e)
        {
            if ( txtFileName.ReadOnly && Data.HasFileExists() && Data.IsDelete == false)
            {
                System.Diagnostics.Process.Start(Data.GetFilePath());
            }
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtFileName_KeyDown(object sender, KeyEventArgs e)
        { 
            if (IsViewMode == false && e.KeyCode == Keys.F2)
            {
                txtFileName.Modified = false;                                
                txtFileName.ReadOnly = false;
                txtFileName.Focus();
                txtFileName.SelectAll();
            }
            else if (IsViewMode == false && 
                     e.KeyCode == Keys.Escape && 
                     txtFileName.ReadOnly == false)
            {
                txtFileName.ReadOnly = true;
                if (txtFileName.Modified)
                {
                    Data.Alias = txtFileName.Text;
                    if (string.IsNullOrWhiteSpace(Data.Alias))
                    {
                        txtFileName.Text = Path.GetFileName(Data.OriginalFilePath);
                    }
                    Saving("Working");
                }
            }
        }

        private void txtFileName_Leave(object sender, EventArgs e)
        {
            if (txtFileName.ReadOnly) return;

            if (txtFileName.Modified)
            {
                Data.Alias = txtFileName.Text; 
                if (string.IsNullOrWhiteSpace(Data.Alias))
                {
                    txtFileName.Text = Path.GetFileName(Data.OriginalFilePath);
                }
                Saving("Working");

                txtFileName.Modified = false;
                txtFileName.ReadOnly = true;
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (Data.IsDelete) return;

            // 파일 내보내기!
            if (Data != null )                
            {
                if (!File.Exists(Data.GetFilePath()))
                {
                    MessageBox.Show("파일이 존재하지 않음!");
                    return;
                }

                if (MessageBox.Show("내보내기?", "내보내기", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExportToFile(Data);
                }
            }
        }

        private void ExportToFile(FileData data)
        {
            using( FolderBrowserDialog fbd = new  FolderBrowserDialog())
            {                
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(data.OriginalFilePath);
                    string fileName = Path.GetFileNameWithoutExtension(data.OriginalFilePath);
                    string targetFileName = fileName;
                    if (!string.IsNullOrWhiteSpace( data.Alias ))
                    {
                        targetFileName = data.Alias;
                    }

                    string targetFile = $"{fbd.SelectedPath}\\{targetFileName}{extension}";
                     
                    int i = 1;
                    while (File.Exists(targetFile))
                    {
                        targetFile = $"{fbd.SelectedPath}\\{targetFileName}({i++}){extension}";
                    } 
                    File.Copy(data.GetFilePath(), targetFile); 
                }
            }
        }
    }
}
