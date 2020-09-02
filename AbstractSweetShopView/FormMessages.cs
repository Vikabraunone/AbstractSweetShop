﻿using AbstractSweetShopBusinessLogic.Interfaces;
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
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(messageLogic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
