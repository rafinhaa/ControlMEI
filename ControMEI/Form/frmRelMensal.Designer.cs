
namespace ControMEI
{
    partial class frmRelMensal
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.EmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ControlMEI_DS = new ControMEI.ControlMEI_DS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EmpresaTableAdapter = new ControMEI.ControlMEI_DSTableAdapters.EmpresaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlMEI_DS)).BeginInit();
            this.SuspendLayout();
            // 
            // EmpresaBindingSource
            // 
            this.EmpresaBindingSource.DataMember = "Empresa";
            this.EmpresaBindingSource.DataSource = this.ControlMEI_DS;
            // 
            // ControlMEI_DS
            // 
            this.ControlMEI_DS.DataSetName = "ControlMEI_DS";
            this.ControlMEI_DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.EmpresaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ControMEI.RelMensal.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 87);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(762, 292);
            this.reportViewer1.TabIndex = 0;
            // 
            // EmpresaTableAdapter
            // 
            this.EmpresaTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelMensal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 377);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRelMensal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRelMensal";
            this.Load += new System.EventHandler(this.frmRelMensal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlMEI_DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EmpresaBindingSource;
        private ControlMEI_DS ControlMEI_DS;
        private ControlMEI_DSTableAdapters.EmpresaTableAdapter EmpresaTableAdapter;
    }
}