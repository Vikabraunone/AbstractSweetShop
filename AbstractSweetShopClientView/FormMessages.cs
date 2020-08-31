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
                dataGridView.DataSource = APIClient.GetRequest<List<MessageInfoViewModel>>(
                        $"api/client/GetMessages?clientId={Program.Client.Id}");
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
