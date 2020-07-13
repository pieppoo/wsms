namespace WSMS_MASTER.views
{
    partial class MainPageCashier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPageCashier));
            this.btchangepass = new System.Windows.Forms.Button();
            this.btdebt = new System.Windows.Forms.Button();
            this.btsale = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbuser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btchangepass
            // 
            this.btchangepass.BackColor = System.Drawing.Color.DodgerBlue;
            this.btchangepass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btchangepass.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btchangepass.ForeColor = System.Drawing.Color.White;
            this.btchangepass.Location = new System.Drawing.Point(90, 256);
            this.btchangepass.Name = "btchangepass";
            this.btchangepass.Size = new System.Drawing.Size(282, 58);
            this.btchangepass.TabIndex = 1;
            this.btchangepass.Text = "GANTI KATA SANDI";
            this.btchangepass.UseVisualStyleBackColor = false;
            this.btchangepass.Click += new System.EventHandler(this.btchangepass_Click);
            // 
            // btdebt
            // 
            this.btdebt.BackColor = System.Drawing.Color.DodgerBlue;
            this.btdebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btdebt.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdebt.ForeColor = System.Drawing.Color.White;
            this.btdebt.Location = new System.Drawing.Point(90, 404);
            this.btdebt.Name = "btdebt";
            this.btdebt.Size = new System.Drawing.Size(282, 58);
            this.btdebt.TabIndex = 3;
            this.btdebt.Text = "HUTANG";
            this.btdebt.UseVisualStyleBackColor = false;
            this.btdebt.Click += new System.EventHandler(this.btdebt_Click);
            // 
            // btsale
            // 
            this.btsale.BackColor = System.Drawing.Color.DodgerBlue;
            this.btsale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btsale.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsale.ForeColor = System.Drawing.Color.White;
            this.btsale.Location = new System.Drawing.Point(90, 330);
            this.btsale.Name = "btsale";
            this.btsale.Size = new System.Drawing.Size(282, 58);
            this.btsale.TabIndex = 2;
            this.btsale.Text = "PENJUALAN";
            this.btsale.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(93, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "F1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(94, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "F2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(93, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "F3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WSMS_MASTER.Properties.Resources.wsms02;
            this.pictureBox1.Location = new System.Drawing.Point(90, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbuser
            // 
            this.lbuser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbuser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbuser.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbuser.Location = new System.Drawing.Point(-1, 0);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(465, 29);
            this.lbuser.TabIndex = 16;
            this.lbuser.Text = "Halo, Admin";
            this.lbuser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainPageCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 497);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btsale);
            this.Controls.Add(this.btdebt);
            this.Controls.Add(this.btchangepass);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPageCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HaskaTech WSMS";
            this.Load += new System.EventHandler(this.MainPageCashier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btchangepass;
        private System.Windows.Forms.Button btdebt;
        private System.Windows.Forms.Button btsale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbuser;
    }
}