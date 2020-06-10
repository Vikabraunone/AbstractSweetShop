using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.BusinessLogics;
using AbstractSweetShopBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractSweetShopView
{
    public partial class FormAppendStoreHouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStoreHouseLogic logicS;

        private readonly IIngredientLogic logicI;

        private readonly MainLogic logicM;

        public FormAppendStoreHouse(IStoreHouseLogic logicS, IIngredientLogic logicI, MainLogic logicM)
        {
            InitializeComponent();
            this.logicS = logicS;
            this.logicI = logicI;
            this.logicM = logicM;
        }

        private void FormStoreHouse_Load(object sender, EventArgs e)
        {
            try
            {
                var storeHouseList = logicS.Read(null);
                var ingredientList = logicI.Read(null);
                if (storeHouseList != null && ingredientList != null)
                {
                    comboBoxStoreHouse.DataSource = storeHouseList;
                    comboBoxStoreHouse.DisplayMember = "StoreHouseName";
                    comboBoxStoreHouse.ValueMember = "Id";
                    comboBoxIngredient.DataSource = ingredientList;
                    comboBoxIngredient.DisplayMember = "IngredientName";
                    comboBoxIngredient.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxStoreHouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxIngredient.SelectedValue == null)
            {
                MessageBox.Show("Выберите ингредиент", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxCount.Text, out int count))
            {
                MessageBox.Show("Неккоректно заполнено поле количество", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int storeHouseId = Convert.ToInt32(comboBoxStoreHouse.SelectedValue);
                int ingredientId = Convert.ToInt32(comboBoxIngredient.SelectedValue);
                logicM.AddIngredientInStoreHouse(new StoreHouseIngredientBindingModel
                {
                    StoreHouseId = storeHouseId,
                    IngredientId = ingredientId,
                    Count = count
                });
                MessageBox.Show("Склад пополнен успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}