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
                dataGridView.Columns[0].Visible = false; // id
                dataGridView.Columns[1].Visible = false; // id клиента
                dataGridView.Columns[2].Visible = false; // фио клиента
                dataGridView.Columns[3].Visible = false; // id изделия
                dataGridView.Columns[4].Width = 200; // изделие
                dataGridView.Columns[5].Visible = false; // id исполнителя
                dataGridView.Columns[6].Visible = false; // фио исполнителя
                dataGridView.Columns[7].Width = 100; // количество
                dataGridView.Columns[8].Width = 100; // сумма
                dataGridView.Columns[9].Width = 100; // статус заказа
                dataGridView.Columns[10].Width = 100; // дата создания
                dataGridView.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // дата выполнения
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
    }
}
