using KingfisherIT.Service.Api;
using KingfisherIT.Service.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace KingfisherIT.Forms
{
    public partial class FormSelectTask : MaterialForm
    {
        private KingfisherApi api;
        private Activity[] activities;

        public FormSelectTask()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            api = KingfisherApi.Instance;
            activities = api.GetActivities();
            cboProjects.Items.AddRange(api.GetUserProjects());
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cboTasks.SelectedIndex == -1 || cboProjects.SelectedIndex == -1)
            {
                MessageBox.Show("You must either select a project or task");
                return;
            }

            //This means the selected item is the sequence of dashes.
            if (cboTasks.SelectedItem is string)
            {
                return;
            }

            var selectedProject = (Project)cboProjects.SelectedItem;
            new FormTimesheet(selectedProject, cboTasks.SelectedItem).ShowDialog();
        }

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When a project is selected, it task combobox changes to reflect all the tasks associated with the specific project
            cboTasks.Items.Clear();
            Project selectedProject = (Project)cboProjects.SelectedItem;
            cboTasks.Items.AddRange(selectedProject.Tasks.ToArray());
            cboTasks.Items.Add("---------------------------");
            cboTasks.Items.AddRange(activities);
        }

        private void SelectTaskForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}