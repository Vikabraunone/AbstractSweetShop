using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.BusinessLogics;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace AbstractSweetShopView
{
    /// <summary>
    /// Загруженность складов
    /// </summary>
    public partial class FormReportStoreHouseIngredient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportStoreHouseIngredient(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            dataGridView.Columns.Add("StoreHouseName", "Склад");
            dataGridView.Columns.Add("IngredientName", "Ингредиент");
            dataGridView.Columns.Add("Count", "Количество");
            dataGridView.Columns[0].Width = 150;
            dataGridView.Columns[1].Width = 250;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FormReportStoreHouseIngredient_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetStoreHouseIngrediens();
                if (dataSource.Count != 0)
                {
                    dataGridView.Rows.Clear();
                    foreach (var row in dataSource)
                        dataGridView.Rows.Add(new object[] { row.StoreHouseName, row.IngredientName, row.Count });
                    int? sum = dataSource.Where(x => x.IngredientName != "Итого:").Sum(x => x.Count);
                    textBoxResult.Text = sum.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveStoreHouseIngredientToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
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
