using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.BusinessLogics;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractSweetShopView
{
    /// <summary>
    /// Ингредиенты по складам
    /// </summary>
    public partial class FormReportIngredientStoreHouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportIngredientStoreHouse(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormReportIngredientStoreHouse_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetIngredientStoreHouse();
                ReportDataSource source = new ReportDataSource("DataSetIngredientStoreHouse", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveIngredientStoreHouseToPdfFile(new ReportBindingModel
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
