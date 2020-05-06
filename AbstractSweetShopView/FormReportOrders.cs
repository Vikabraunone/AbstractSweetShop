using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.BusinessLogics;
using System;
using System.Linq;
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
            dataGridView.Columns[0].Width = 250;
            dataGridView.Columns[1].Width = 250;
            dataGridView.Columns[2].Width = 250;
            textBoxResult.Text = "0";
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
                    string shortDate = dataSource[0].DateCreate.ToShortDateString();
                    decimal? sum = 0;
                    // вставка строки для первой даты
                    dataGridView.Rows.Add(new object[] { shortDate, string.Empty, string.Empty });
                    for (int i = 0; i < dataSource.Count; i++)
                    {
                        if (dataSource[i].DateCreate.ToShortDateString().Equals(shortDate))
                        {
                            sum += dataSource[i].Sum;
                            dataGridView.Rows.Add(new object[] { string.Empty, dataSource[i].ProductName, dataSource[i].Sum });
                        }
                        else
                        {
                            dataGridView.Rows.Add(new object[] { "Итого:", string.Empty, sum });
                            sum = 0;
                            shortDate = dataSource[i].DateCreate.Date.ToShortDateString();
                            dataGridView.Rows.Add(new object[] { shortDate, string.Empty, string.Empty });
                            dataGridView.Rows.Add(new object[] { string.Empty, dataSource[i].ProductName, dataSource[i].Sum });
                            sum += dataSource[i].Sum;
                        }
                    }
                    // вставка итоговой строки для последней даты
                    dataGridView.Rows.Add(new object[] { "Итого:", string.Empty, sum });
                    textBoxResult.Text = (dataSource.Sum(x => x.Sum)).ToString();
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
    }
}
