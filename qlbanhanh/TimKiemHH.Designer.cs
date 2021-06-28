
namespace qlbanhanh
{
    partial class TimKiemHH
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
            this.dgvSearchHH = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchHH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSearchHH
            // 
            this.dgvSearchHH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchHH.Location = new System.Drawing.Point(41, 27);
            this.dgvSearchHH.Name = "dgvSearchHH";
            this.dgvSearchHH.Size = new System.Drawing.Size(723, 382);
            this.dgvSearchHH.TabIndex = 0;
            // 
            // TimKiemHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSearchHH);
            this.Name = "TimKiemHH";
            this.Text = "TimKiemHH";
            this.Load += new System.EventHandler(this.TimKiemHH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchHH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSearchHH;
    }
}