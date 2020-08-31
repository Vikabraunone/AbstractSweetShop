using AbstractSweetShopBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;

namespace AbstractSweetShopClientView
{
    public partial class FormEnter : Form
    {
        public FormEnter()
        {
            InitializeComponent();
            Program.Client = null;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                try
                {
                    Program.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={textBoxEmail.Text}&password={textBoxPassword.Text}");
                    if (Program.Client == null)
                    {
                        MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.ShowDialog();
        }
    }
}
