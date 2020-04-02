namespace AbstractSweetShopView
{
    partial class FormAppendStoreHouse
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
            this.comboBoxStoreHouse = new System.Windows.Forms.ComboBox();
            this.comboBoxIngredient = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelStoreHouse = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelIngredient = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxStoreHouse
            // 
            this.comboBoxStoreHouse.FormattingEnabled = true;
            this.comboBoxStoreHouse.Location = new System.Drawing.Point(107, 17);
            this.comboBoxStoreHouse.Name = "comboBoxStoreHouse";
            this.comboBoxStoreHouse.Size = new System.Drawing.Size(187, 21);
            this.comboBoxStoreHouse.TabIndex = 0;
            // 
            // comboBoxIngredient
            // 
            this.comboBoxIngredient.FormattingEnabled = true;
            this.comboBoxIngredient.Location = new System.Drawing.Point(107, 50);
            this.comboBoxIngredient.Name = "comboBoxIngredient";
            this.comboBoxIngredient.Size = new System.Drawing.Size(187, 21);
            this.comboBoxIngredient.TabIndex = 3;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(107, 80);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(187, 20);
            this.textBoxCount.TabIndex = 5;
            // 
            // labelStoreHouse
            // 
            this.labelStoreHouse.AutoSize = true;
            this.labelStoreHouse.Location = new System.Drawing.Point(12, 20);
            this.labelStoreHouse.Name = "labelStoreHouse";
            this.labelStoreHouse.Size = new System.Drawing.Size(41, 13);
            this.labelStoreHouse.TabIndex = 6;
            this.labelStoreHouse.Text = "Склад:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 83);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 7;
            this.labelCount.Text = "Количество:";
            // 
            // labelIngredient
            // 
            this.labelIngredient.AutoSize = true;
            this.labelIngredient.Location = new System.Drawing.Point(12, 53);
            this.labelIngredient.Name = "labelIngredient";
            this.labelIngredient.Size = new System.Drawing.Size(70, 13);
            this.labelIngredient.TabIndex = 8;
            this.labelIngredient.Text = "Ингредиент:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(80, 116);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(83, 25);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(169, 116);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(83, 25);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormAppendStoreHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 162);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelIngredient);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelStoreHouse);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxIngredient);
            this.Controls.Add(this.comboBoxStoreHouse);
            this.Name = "FormAppendStoreHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пополнить склад";
            this.Load += new System.EventHandler(this.FormStoreHouse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStoreHouse;
        private System.Windows.Forms.ComboBox comboBoxIngredient;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelStoreHouse;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelIngredient;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}