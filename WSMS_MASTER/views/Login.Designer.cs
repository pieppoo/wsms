namespace WSMS_MASTER.views
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btmasuk = new System.Windows.Forms.Button();
            this.lbpass = new System.Windows.Forms.Label();
            this.tbpass = new System.Windows.Forms.TextBox();
            this.lbname = new System.Windows.Forms.Label();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.logintitle = new System.Windows.Forms.Label();
            this.llblSettings = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btmasuk
            // 
            this.btmasuk.BackColor = System.Drawing.Color.DodgerBlue;
            this.btmasuk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmasuk.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmasuk.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btmasuk.Location = new System.Drawing.Point(298, 277);
            this.btmasuk.Name = "btmasuk";
            this.btmasuk.Size = new System.Drawing.Size(247, 47);
            this.btmasuk.TabIndex = 14;
            this.btmasuk.Text = "MASUK";
            this.btmasuk.UseVisualStyleBackColor = false;
            this.btmasuk.Click += new System.EventHandler(this.btmasuk_Click);
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpass.Location = new System.Drawing.Point(293, 187);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(121, 28);
            this.lbpass.TabIndex = 13;
            this.lbpass.Text = "Kata Sandi";
            // 
            // tbpass
            // 
            this.tbpass.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpass.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tbpass.Location = new System.Drawing.Point(298, 218);
            this.tbpass.Name = "tbpass";
            this.tbpass.PasswordChar = '*';
            this.tbpass.Size = new System.Drawing.Size(247, 26);
            this.tbpass.TabIndex = 12;
            this.tbpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbname.Location = new System.Drawing.Point(293, 116);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(72, 28);
            this.lbname.TabIndex = 11;
            this.lbname.Text = "Nama";
            // 
            // tbusername
            // 
            this.tbusername.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbusername.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tbusername.Location = new System.Drawing.Point(298, 147);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(247, 26);
            this.tbusername.TabIndex = 10;
            this.tbusername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // logintitle
            // 
            this.logintitle.AutoSize = true;
            this.logintitle.BackColor = System.Drawing.Color.White;
            this.logintitle.Font = new System.Drawing.Font("Cambria", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logintitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.logintitle.Location = new System.Drawing.Point(310, 25);
            this.logintitle.Name = "logintitle";
            this.logintitle.Size = new System.Drawing.Size(207, 75);
            this.logintitle.TabIndex = 9;
            this.logintitle.Text = "WSMS";
            // 
            // llblSettings
            // 
            this.llblSettings.AutoSize = true;
            this.llblSettings.LinkColor = System.Drawing.Color.SteelBlue;
            this.llblSettings.Location = new System.Drawing.Point(484, 339);
            this.llblSettings.Name = "llblSettings";
            this.llblSettings.Size = new System.Drawing.Size(61, 13);
            this.llblSettings.TabIndex = 15;
            this.llblSettings.TabStop = true;
            this.llblSettings.Text = "SETTINGS";
            this.llblSettings.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.llblSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSettings_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WSMS_MASTER.Properties.Resources.pc01;
            this.pictureBox1.Location = new System.Drawing.Point(26, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 374);
            this.Controls.Add(this.llblSettings);
            this.Controls.Add(this.btmasuk);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.tbpass);
            this.Controls.Add(this.lbname);
            this.Controls.Add(this.tbusername);
            this.Controls.Add(this.logintitle);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HaskaTech WSMS";
            this.Activated += new System.EventHandler(this.Login_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btmasuk;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.TextBox tbpass;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.Label logintitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llblSettings;
    }
}