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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelIngredient = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelStoreHouse = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxIngredient = new System.Windows.Forms.ComboBox();
            this.comboBoxStoreHouse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(198, 111);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(83, 25);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(98, 111);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(83, 25);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelIngredient
            // 
            this.labelIngredient.AutoSize = true;
            this.labelIngredient.Location = new System.Drawing.Point(20, 48);
            this.labelIngredient.Name = "labelIngredient";
            this.labelIngredient.Size = new System.Drawing.Size(70, 13);
            this.labelIngredient.TabIndex = 16;
            this.labelIngredient.Text = "Ингредиент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(20, 78);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 15;
            this.labelCount.Text = "Количество:";
            // 
            // labelStoreHouse
            // 
            this.labelStoreHouse.AutoSize = true;
            this.labelStoreHouse.Location = new System.Drawing.Point(20, 15);
            this.labelStoreHouse.Name = "labelStoreHouse";
            this.labelStoreHouse.Size = new System.Drawing.Size(41, 13);
            this.labelStoreHouse.TabIndex = 14;
            this.labelStoreHouse.Text = "Склад:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(115, 75);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(187, 20);
            this.textBoxCount.TabIndex = 13;
            // 
            // comboBoxIngredient
            // 
            this.comboBoxIngredient.FormattingEnabled = true;
            this.comboBoxIngredient.Location = new System.Drawing.Point(115, 45);
            this.comboBoxIngredient.Name = "comboBoxIngredient";
            this.comboBoxIngredient.Size = new System.Drawing.Size(187, 21);
            this.comboBoxIngredient.TabIndex = 12;
            // 
            // comboBoxStoreHouse
            // 
            this.comboBoxStoreHouse.FormattingEnabled = true;
            this.comboBoxStoreHouse.Location = new System.Drawing.Point(115, 12);
            this.comboBoxStoreHouse.Name = "comboBoxStoreHouse";
            this.comboBoxStoreHouse.Size = new System.Drawing.Size(187, 21);
            this.comboBoxStoreHouse.TabIndex = 11;
            // 
            // FormAppendStoreHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 155);
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

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelIngredient;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelStoreHouse;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxIngredient;
        private System.Windows.Forms.ComboBox comboBoxStoreHouse;
    }
}