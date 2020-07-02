namespace AbstractSweetShopView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ингредиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кондитерскиеИзделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productIngredientToPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonOrderRef = new System.Windows.Forms.Button();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1291, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ингредиентыToolStripMenuItem,
            this.кондитерскиеИзделияToolStripMenuItem,
            this.исполнителиToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // ингредиентыToolStripMenuItem
            // 
            this.ингредиентыToolStripMenuItem.Name = "ингредиентыToolStripMenuItem";
            this.ингредиентыToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.ингредиентыToolStripMenuItem.Text = "Ингредиенты";
            this.ингредиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // кондитерскиеИзделияToolStripMenuItem
            // 
            this.кондитерскиеИзделияToolStripMenuItem.Name = "кондитерскиеИзделияToolStripMenuItem";
            this.кондитерскиеИзделияToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.кондитерскиеИзделияToolStripMenuItem.Text = "Кондитерские изделия";
            this.кондитерскиеИзделияToolStripMenuItem.Click += new System.EventHandler(this.кондитерскиеИзделияToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToWordToolStripMenuItem,
            this.ordersToExcelToolStripMenuItem,
            this.productIngredientToPdfToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // productToWordToolStripMenuItem
            // 
            this.productToWordToolStripMenuItem.Name = "productToWordToolStripMenuItem";
            this.productToWordToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.productToWordToolStripMenuItem.Text = "Список кондитерских изделий";
            this.productToWordToolStripMenuItem.Click += new System.EventHandler(this.productToWordToolStripMenuItem_Click);
            // 
            // ordersToExcelToolStripMenuItem
            // 
            this.ordersToExcelToolStripMenuItem.Name = "ordersToExcelToolStripMenuItem";
            this.ordersToExcelToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.ordersToExcelToolStripMenuItem.Text = "Список заказов";
            this.ordersToExcelToolStripMenuItem.Click += new System.EventHandler(this.ordersToExcelToolStripMenuItem_Click);
            // 
            // productIngredientToPdfToolStripMenuItem
            // 
            this.productIngredientToPdfToolStripMenuItem.Name = "productIngredientToPdfToolStripMenuItem";
            this.productIngredientToPdfToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.productIngredientToPdfToolStripMenuItem.Text = "Кондитерские изделия по ингредиентам";
            this.productIngredientToPdfToolStripMenuItem.Click += new System.EventHandler(this.productIngredientToPdfToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(16, 35);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1118, 259);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateOrder.Location = new System.Drawing.Point(1140, 35);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(140, 36);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPayOrder.Location = new System.Drawing.Point(1140, 153);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(140, 36);
            this.buttonPayOrder.TabIndex = 5;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // buttonOrderRef
            // 
            this.buttonOrderRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOrderRef.Location = new System.Drawing.Point(1140, 195);
            this.buttonOrderRef.Name = "buttonOrderRef";
            this.buttonOrderRef.Size = new System.Drawing.Size(140, 36);
            this.buttonOrderRef.TabIndex = 6;
            this.buttonOrderRef.Text = "Обновить список";
            this.buttonOrderRef.UseVisualStyleBackColor = true;
            this.buttonOrderRef.Click += new System.EventHandler(this.buttonOrderRef_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 301);
            this.Controls.Add(this.buttonOrderRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Абстрактная кондитерская";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonOrderRef;
        private System.Windows.Forms.ToolStripMenuItem ингредиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кондитерскиеИзделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productIngredientToPdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
    }
}