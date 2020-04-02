using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AbstractSweetShopView
{
    public partial class FormStoreHouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStoreHouseLogic logicS;

        private Dictionary<int, (string, int)> storeHouseIngredients;
        public int? Id { set { id = value; } }

        private int? id;

        public FormStoreHouse(IStoreHouseLogic logicS)
        {
            InitializeComponent();
            this.logicS = logicS;
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("Ingredients", "Ингредиенты");
            dataGridView.Columns.Add("Count", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FormStoreHouse_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (id.HasValue)
            {
                try
                {
                    StoreHouseViewModel view = logicS.Read(new StoreHouseBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        storeHouseIngredients = view.StoreHouseIngredients;
                        if (storeHouseIngredients != null)
                        {
                            dataGridView.Rows.Clear();
                            foreach (var si in storeHouseIngredients)
                                dataGridView.Rows.Add(new object[] { si.Key, si.Value.Item1, si.Value.Item2 });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                storeHouseIngredients = new Dictionary<int, (string, int)>();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int ingredientId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                logicS.DeleteIngredient(id, ingredientId);
                LoadData();
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}