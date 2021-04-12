
namespace qlbanhanh
{
    partial class QuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLy));
            this.picBoxSalemans = new System.Windows.Forms.PictureBox();
            this.picBoxMerchandise = new System.Windows.Forms.PictureBox();
            this.picBoxCustomer = new System.Windows.Forms.PictureBox();
            this.picBoxBill = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSalemans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMerchandise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBill)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxSalemans
            // 
            this.picBoxSalemans.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSalemans.Image")));
            this.picBoxSalemans.Location = new System.Drawing.Point(253, 45);
            this.picBoxSalemans.Name = "picBoxSalemans";
            this.picBoxSalemans.Size = new System.Drawing.Size(262, 262);
            this.picBoxSalemans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSalemans.TabIndex = 0;
            this.picBoxSalemans.TabStop = false;
            this.picBoxSalemans.Click += new System.EventHandler(this.picBoxSalemans_Click);
            this.picBoxSalemans.MouseLeave += new System.EventHandler(this.picBoxSalemans_MouseLeave);
            this.picBoxSalemans.MouseHover += new System.EventHandler(this.picBoxSalemans_MouseHover);
            // 
            // picBoxMerchandise
            // 
            this.picBoxMerchandise.Image = ((System.Drawing.Image)(resources.GetObject("picBoxMerchandise.Image")));
            this.picBoxMerchandise.Location = new System.Drawing.Point(253, 395);
            this.picBoxMerchandise.Name = "picBoxMerchandise";
            this.picBoxMerchandise.Size = new System.Drawing.Size(262, 262);
            this.picBoxMerchandise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMerchandise.TabIndex = 1;
            this.picBoxMerchandise.TabStop = false;
            this.picBoxMerchandise.Click += new System.EventHandler(this.picBoxMerchandise_Click);
            this.picBoxMerchandise.MouseLeave += new System.EventHandler(this.picBoxMerchandise_MouseLeave);
            this.picBoxMerchandise.MouseHover += new System.EventHandler(this.picBoxMerchandise_MouseHover);
            // 
            // picBoxCustomer
            // 
            this.picBoxCustomer.Image = ((System.Drawing.Image)(resources.GetObject("picBoxCustomer.Image")));
            this.picBoxCustomer.Location = new System.Drawing.Point(749, 45);
            this.picBoxCustomer.Name = "picBoxCustomer";
            this.picBoxCustomer.Size = new System.Drawing.Size(262, 262);
            this.picBoxCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxCustomer.TabIndex = 2;
            this.picBoxCustomer.TabStop = false;
            this.picBoxCustomer.Click += new System.EventHandler(this.picBoxCustomer_Click);
            this.picBoxCustomer.MouseLeave += new System.EventHandler(this.picBoxCustomer_MouseLeave);
            this.picBoxCustomer.MouseHover += new System.EventHandler(this.picBoxCustomer_MouseHover);
            // 
            // picBoxBill
            // 
            this.picBoxBill.Image = ((System.Drawing.Image)(resources.GetObject("picBoxBill.Image")));
            this.picBoxBill.Location = new System.Drawing.Point(749, 395);
            this.picBoxBill.Name = "picBoxBill";
            this.picBoxBill.Size = new System.Drawing.Size(262, 262);
            this.picBoxBill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBill.TabIndex = 3;
            this.picBoxBill.TabStop = false;
            this.picBoxBill.Click += new System.EventHandler(this.picBoxBill_Click);
            this.picBoxBill.MouseLeave += new System.EventHandler(this.picBoxBill_MouseLeave);
            this.picBoxBill.MouseHover += new System.EventHandler(this.picBoxBill_MouseHover);
            // 
            // QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 707);
            this.Controls.Add(this.picBoxBill);
            this.Controls.Add(this.picBoxCustomer);
            this.Controls.Add(this.picBoxMerchandise);
            this.Controls.Add(this.picBoxSalemans);
            this.Name = "QuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLy";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSalemans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMerchandise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxSalemans;
        private System.Windows.Forms.PictureBox picBoxMerchandise;
        private System.Windows.Forms.PictureBox picBoxCustomer;
        private System.Windows.Forms.PictureBox picBoxBill;
    }
}