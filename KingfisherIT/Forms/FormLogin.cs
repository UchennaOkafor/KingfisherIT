using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using System.Threading.Tasks;
using KingfisherIT.Service.Api;

namespace KingfisherIT.Forms
{
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Username or password field cannot be empty");
                return;
            }

            btnLogin.Enabled = false;
            SetStatus("Logging in..");

            if (await Task.Run(() => KingfisherApi.Instance.Authenticate(txtUsername.Text, txtPassword.Text)))
            {
                this.Hide();
                new FormSelectTask().Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }

            SetStatus("Idle..");
            btnLogin.Enabled = true;
        }

        private void SetStatus(string newStatus)
        {
            lblStatus.Text = "Status: " + newStatus;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnLogin.PerformClick();
            }
        }
    }
}