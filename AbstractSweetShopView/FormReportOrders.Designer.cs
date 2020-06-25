namespace AbstractSweetShopView
{
    partial class FormReportOrders
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonToExcel = new System.Windows.Forms.Button();
            this.buttonForm = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 51);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(709, 296);
            this.dataGridView.TabIndex = 5;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonToExcel);
            this.panelMenu.Controls.Add(this.buttonForm);
            this.panelMenu.Controls.Add(this.dateTimePickerTo);
            this.panelMenu.Controls.Add(this.textBoxTo);
            this.panelMenu.Controls.Add(this.dateTimePickerFrom);
            this.panelMenu.Controls.Add(this.textBoxFrom);
            this.panelMenu.Location = new System.Drawing.Point(12, 5);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(709, 45);
            this.panelMenu.TabIndex = 4;
            // 
            // buttonToExcel
            // 
            this.buttonToExcel.Location = new System.Drawing.Point(563, 10);
            this.buttonToExcel.Name = "buttonToExcel";
            this.buttonToExcel.Size = new System.Drawing.Size(111, 28);
            this.buttonToExcel.TabIndex = 5;
            this.buttonToExcel.Text = "В Excel";
            this.buttonToExcel.UseVisualStyleBackColor = true;
            this.buttonToExcel.Click += new System.EventHandler(this.buttonToExcel_Click);
            // 
            // buttonForm
            // 
            this.buttonForm.Location = new System.Drawing.Point(384, 10);
            this.buttonForm.Name = "buttonForm";
            this.buttonForm.Size = new System.Drawing.Size(160, 28);
            this.buttonForm.TabIndex = 4;
            this.buttonForm.Text = "Сформировать";
            this.buttonForm.UseVisualStyleBackColor = true;
            this.buttonForm.Click += new System.EventHandler(this.buttonForm_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(229, 12);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // textBoxTo
            // 
            this.textBoxTo.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTo.Location = new System.Drawing.Point(200, 15);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(23, 13);
            this.textBoxTo.TabIndex = 2;
            this.textBoxTo.Text = "по";
            this.textBoxTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(54, 12);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFrom.Location = new System.Drawing.Point(11, 15);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(23, 13);
            this.textBoxFrom.TabIndex = 0;
            this.textBoxFrom.Text = "C";
            this.textBoxFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 359);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelMenu);
            this.Name = "FormReportOrders";
            this.Text = "Отчет по заказам за период";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonToExcel;
        private System.Windows.Forms.Button buttonForm;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.TextBox textBoxFrom;
    }
}