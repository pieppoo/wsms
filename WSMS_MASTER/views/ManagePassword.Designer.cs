namespace WSMS_MASTER.views
{
    partial class ManagePassword
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
            this.btchange = new System.Windows.Forms.Button();
            this.tbnewpswdconfirm = new System.Windows.Forms.TextBox();
            this.lbnewpswdconfirm = new System.Windows.Forms.Label();
            this.lbname = new System.Windows.Forms.Label();
            this.tbnewpswd = new System.Windows.Forms.TextBox();
            this.lbnewpswd = new System.Windows.Forms.Label();
            this.lbnote = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btchange
            // 
            this.btchange.BackColor = System.Drawing.Color.DodgerBlue;
            this.btchange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btchange.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btchange.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btchange.Location = new System.Drawing.Point(280, 295);
            this.btchange.Name = "btchange";
            this.btchange.Size = new System.Drawing.Size(255, 60);
            this.btchange.TabIndex = 23;
            this.btchange.Text = "GANTI";
            this.btchange.UseVisualStyleBackColor = false;
            this.btchange.Click += new System.EventHandler(this.btchange_Click);
            // 
            // tbnewpswdconfirm
            // 
            this.tbnewpswdconfirm.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnewpswdconfirm.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tbnewpswdconfirm.Location = new System.Drawing.Point(280, 241);
            this.tbnewpswdconfirm.MaxLength = 12;
            this.tbnewpswdconfirm.Name = "tbnewpswdconfirm";
            this.tbnewpswdconfirm.PasswordChar = '*';
            this.tbnewpswdconfirm.Size = new System.Drawing.Size(255, 36);
            this.tbnewpswdconfirm.TabIndex = 21;
            this.tbnewpswdconfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbnewpswdconfirm_KeyDown);
            // 
            // lbnewpswdconfirm
            // 
            this.lbnewpswdconfirm.AutoSize = true;
            this.lbnewpswdconfirm.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnewpswdconfirm.Location = new System.Drawing.Point(275, 213);
            this.lbnewpswdconfirm.Name = "lbnewpswdconfirm";
            this.lbnewpswdconfirm.Size = new System.Drawing.Size(211, 25);
            this.lbnewpswdconfirm.TabIndex = 22;
            this.lbnewpswdconfirm.Text = "Konfirmasi Kata Sandi";
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbname.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbname.Location = new System.Drawing.Point(42, 101);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(108, 25);
            this.lbname.TabIndex = 20;
            this.lbname.Text = "Nama user";
            // 
            // tbnewpswd
            // 
            this.tbnewpswd.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnewpswd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tbnewpswd.Location = new System.Drawing.Point(280, 165);
            this.tbnewpswd.MaxLength = 12;
            this.tbnewpswd.Name = "tbnewpswd";
            this.tbnewpswd.PasswordChar = '*';
            this.tbnewpswd.Size = new System.Drawing.Size(255, 36);
            this.tbnewpswd.TabIndex = 18;
            this.tbnewpswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbnewpswdconfirm_KeyDown);
            // 
            // lbnewpswd
            // 
            this.lbnewpswd.AutoSize = true;
            this.lbnewpswd.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnewpswd.Location = new System.Drawing.Point(275, 137);
            this.lbnewpswd.Name = "lbnewpswd";
            this.lbnewpswd.Size = new System.Drawing.Size(156, 25);
            this.lbnewpswd.TabIndex = 19;
            this.lbnewpswd.Text = "Kata Sandi Baru";
            // 
            // lbnote
            // 
            this.lbnote.AutoSize = true;
            this.lbnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnote.ForeColor = System.Drawing.Color.Red;
            this.lbnote.Location = new System.Drawing.Point(277, 358);
            this.lbnote.Name = "lbnote";
            this.lbnote.Size = new System.Drawing.Size(258, 13);
            this.lbnote.TabIndex = 24;
            this.lbnote.Text = "panjang kata sandi maksimal hanya 12 huruf / angka";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WSMS_MASTER.Properties.Resources.login01;
            this.pictureBox1.Location = new System.Drawing.Point(31, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // ManagePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 405);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbnote);
            this.Controls.Add(this.btchange);
            this.Controls.Add(this.tbnewpswdconfirm);
            this.Controls.Add(this.lbnewpswdconfirm);
            this.Controls.Add(this.lbname);
            this.Controls.Add(this.tbnewpswd);
            this.Controls.Add(this.lbnewpswd);
            this.Name = "ManagePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "managePassword";
            this.Title = "GANTI KATA SANDI";
            this.Load += new System.EventHandler(this.ManagePassword_Load);
            this.Controls.SetChildIndex(this.lbnewpswd, 0);
            this.Controls.SetChildIndex(this.tbnewpswd, 0);
            this.Controls.SetChildIndex(this.lbname, 0);
            this.Controls.SetChildIndex(this.lbnewpswdconfirm, 0);
            this.Controls.SetChildIndex(this.tbnewpswdconfirm, 0);
            this.Controls.SetChildIndex(this.btchange, 0);
            this.Controls.SetChildIndex(this.lbnote, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btchange;
        private System.Windows.Forms.TextBox tbnewpswdconfirm;
        private System.Windows.Forms.Label lbnewpswdconfirm;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.TextBox tbnewpswd;
        private System.Windows.Forms.Label lbnewpswd;
        private System.Windows.Forms.Label lbnote;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}