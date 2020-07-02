namespace AbstractSweetShopView
{
    partial class FormReportProductIngredient
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
            this.ReportProductIngredientViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonToPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportProductIngredientViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportProductIngredientViewModelBindingSource
            // 
            this.ReportProductIngredientViewModelBindingSource.DataSource = typeof(AbstractSweetShopBusinessLogic.ViewModels.ReportProductIngredientViewModel);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractSweetShopView.ReportProductIngredient.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(2, 49);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(825, 400);
            this.reportViewer.TabIndex = 0;
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(692, 12);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(81, 31);
            this.buttonToPdf.TabIndex = 1;
            this.buttonToPdf.Text = "В Pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // FormReportProductIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 450);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonToPdf);
            this.Name = "FormReportProductIngredient";
            this.Text = "Кондитерские изделия по ингредиентам";
            this.Load += new System.EventHandler(this.FormReportProductIngredient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportProductIngredientViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportProductIngredientViewModelBindingSource;
        private System.Windows.Forms.Button buttonToPdf;
    }
}