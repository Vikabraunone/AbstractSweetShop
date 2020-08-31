using AbstractSweetShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbstractSweetShopClientView
{
    public partial class FormMessages : Form
    {
        public FormMessages()
        {
            InitializeComponent();
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                var source = APIClient.GetRequest<List<MessageInfoViewModel>>(
                        $"api/client/GetMessages?clientId={Program.Client.Id}");
                dataGridView.DataSource = source;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Width = 100;
                dataGridView.Columns[2].Width = 100;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
