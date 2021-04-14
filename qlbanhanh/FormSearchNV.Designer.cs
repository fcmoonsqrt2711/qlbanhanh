
namespace qlbanhanh
{
    partial class FormSearchNV
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
            this.dgvSearchNV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchNV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSearchNV
            // 
            this.dgvSearchNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchNV.Location = new System.Drawing.Point(116, 48);
            this.dgvSearchNV.Name = "dgvSearchNV";
            this.dgvSearchNV.RowHeadersWidth = 51;
            this.dgvSearchNV.RowTemplate.Height = 24;
            this.dgvSearchNV.Size = new System.Drawing.Size(592, 361);
            this.dgvSearchNV.TabIndex = 0;
            // 
            // FormSearchNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSearchNV);
            this.Name = "FormSearchNV";
            this.Text = "FormSearchNV";
            this.Load += new System.EventHandler(this.FormSearchNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSearchNV;
    }
}