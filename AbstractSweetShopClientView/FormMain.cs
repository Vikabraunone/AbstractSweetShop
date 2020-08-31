using AbstractSweetShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbstractSweetShopClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIClient.GetRequest<List<OrderViewModel>>(
                        $"api/main/getorders?clientId={Program.Client.Id}");
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].Width = 100;
                dataGridView.Columns[8].Width = 100;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;
                dataGridView.Columns[11].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUpdateData();
            form.ShowDialog();
        }

        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void RefreshOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void GetMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMessages();
            form.ShowDialog();
        }
    }
}
