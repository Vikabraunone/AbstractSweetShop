using AbstractSweetShopBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractSweetShopView
{
    public partial class FormMessages : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMessageInfoLogic messageLogic;

        public FormMessages(IMessageInfoLogic messageLogic)
        {
            InitializeComponent();
            this.messageLogic = messageLogic;
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            var list = messageLogic.Read(null);
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Width = 100;
                dataGridView.Columns[2].Width = 100;
                dataGridView.Columns[3].Width = 100;
                dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
