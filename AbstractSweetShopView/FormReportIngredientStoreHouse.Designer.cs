namespace AbstractSweetShopView
{
    partial class FormReportIngredientStoreHouse
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
            this.components = new System.ComponentModel.Container();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportStoreHouseIngredientViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportStoreHouseIngredientViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(682, 12);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(81, 31);
            this.buttonToPdf.TabIndex = 2;
            this.buttonToPdf.Text = "В Pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractSweetShopView.ReportIngredientStoreHouse.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 49);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(798, 400);
            this.reportViewer.TabIndex = 3;
            // 
            // ReportStoreHouseIngredientViewModelBindingSource
            // 
            this.ReportStoreHouseIngredientViewModelBindingSource.DataSource = typeof(AbstractSweetShopBusinessLogic.ViewModels.ReportStoreHouseIngredientViewModel);
            // 
            // FormReportIngredientStoreHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 450);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonToPdf);
            this.Name = "FormReportIngredientStoreHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ингредиенты на складах";
            this.Load += new System.EventHandler(this.FormReportIngredientStoreHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportStoreHouseIngredientViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportStoreHouseIngredientViewModelBindingSource;
    }
}