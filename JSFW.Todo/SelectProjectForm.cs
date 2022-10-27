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
    public partial class SelectProjectForm : Form
    {
        public string SelectedProjectName { get { return comboBox1.Text; } }

        public SelectProjectForm()
        {
            InitializeComponent();
        }

        public SelectProjectForm(string[] projects) : this()
        {
            comboBox1.Items.AddRange(projects);
            comboBox1.SelectedIndex = 0 < projects.Length ? 0 : -1;

            Properties.Settings.Default.Reload();
            if (1 < comboBox1.Items.Count)
            {
                int idx = 0;
                foreach (string prj in projects)
                {
                    if (prj.ToUpper() == Properties.Settings.Default.LastProject.ToUpper())
                    {
                        comboBox1.SelectedIndex = idx;
                        break;
                    }
                    idx++;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e); 
            e.Cancel = string.IsNullOrWhiteSpace(SelectedProjectName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectedProjectName))
            {
                MessageBox.Show("프로젝트 선택 필수!");
                return;
            }

            this.Close();
        }
    }
}
