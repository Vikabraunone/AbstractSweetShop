using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AbstractSweetShopView
{
    public partial class FormCreateOrUpdateStoreHouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStoreHouseLogic logic;

        public int? Id { set { id = value; } }

        private int? id;

        public FormCreateOrUpdateStoreHouse(IStoreHouseLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxStoreHouseName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                StoreHouseViewModel view = logic.Read(new StoreHouseBindingModel { Id = id.Value })?[0];
                if (view != null)
                    logic.CreateOrUpdate(new StoreHouseBindingModel
                    {
                        Id = id,
                        StoreHouseName = textBoxStoreHouseName.Text,
                        StoreHouseIngredients = view.StoreHouseIngredients
                    });
                else
                    logic.CreateOrUpdate(new StoreHouseBindingModel
                    {
                        StoreHouseName = textBoxStoreHouseName.Text,
                        StoreHouseIngredients = new Dictionary<int, (string, int)>()
                    });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormCreateOrUpdateStoreHouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                var storeHouse = logic.Read(new StoreHouseBindingModel { Id = id })?[0];
                if (storeHouse != null)
                    textBoxStoreHouseName.Text = storeHouse.StoreHouseName;
            }
        }
    }
}