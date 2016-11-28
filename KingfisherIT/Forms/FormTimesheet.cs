using System;
using MaterialSkin;
using MaterialSkin.Controls;
using KingfisherIT.Service.Api;
using KingfisherIT.Service.Models;

using System.Windows.Forms;

namespace KingfisherIT.Forms
{
    public partial class FormTimesheet : MaterialForm
    {
        private object task;
        private KingfisherApi api;

        public FormTimesheet(Project project, object task)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            txtProjectName.Text = project.Name;
            txtName.Text = task.ToString();
            this.task = task;
            api = KingfisherApi.Instance;

            dateTimePicker1.MaxDate = DateTime.Today;
        }

        private void btnSubmitTimesheet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to submit this timesheet?", "Kingfisher", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (api.SubmitTimesheet(task, dateTimePicker1.Value, nudHoursWorked.Value))
                {
                    MessageBox.Show("Timesheet successfully submitted", "Kingfisher");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Timesheet failed to submit", "Kingfisher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }
    }
}