using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractSweetShopView
{
    public partial class FormReportOrders : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportOrders(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            dataGridView.Columns.Add("DateCreate", "Дата создания");
            dataGridView.Columns.Add("ProductName", "Кондитерское изделие");
            dataGridView.Columns.Add("Sum", "Сумма");
            dataGridView.Columns[0].Width = 150;
            dataGridView.Columns[1].Width = 250;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonForm_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = logic.GetOrders(new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                });
                if (dataSource.Count != 0)
                {
                    dataGridView.Rows.Clear();
                    foreach (var group in dataSource)
                    {
                        decimal sum = 0;
                        // вставка даты
                        dataGridView.Rows.Add(new object[] { group.Key.ToShortDateString(),
                            string.Empty, string.Empty });
                        foreach (var order in group)
                        {
                            dataGridView.Rows.Add(new object[] { string.Empty, order.ProductName,
                                order.Sum });
                            sum += order.Sum;
                        }
                        // вставка итоговой строки
                        dataGridView.Rows.Add(new object[] { "Итого:", string.Empty, sum });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToExcel_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveOrdersToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            DateFrom = dateTimePickerFrom.Value,
                            DateTo = dateTimePickerTo.Value
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
