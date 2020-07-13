namespace WSMS_MASTER.views.Settings
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tbReportFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.lbbrandname = new System.Windows.Forms.Label();
            this.btnBrowseReportFolder = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // tbReportFolder
            // 
            this.tbReportFolder.Location = new System.Drawing.Point(28, 156);
            this.tbReportFolder.Margin = new System.Windows.Forms.Padding(4);
            this.tbReportFolder.Name = "tbReportFolder";
            this.tbReportFolder.ReadOnly = true;
            this.tbReportFolder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReportFolder.Size = new System.Drawing.Size(347, 20);
            this.tbReportFolder.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Report Folder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbConnectionString.Location = new System.Drawing.Point(28, 49);
            this.tbConnectionString.Margin = new System.Windows.Forms.Padding(4);
            this.tbConnectionString.Multiline = true;
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConnectionString.Size = new System.Drawing.Size(435, 64);
            this.tbConnectionString.TabIndex = 19;
            // 
            // lbbrandname
            // 
            this.lbbrandname.AutoSize = true;
            this.lbbrandname.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbrandname.Location = new System.Drawing.Point(28, 25);
            this.lbbrandname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbbrandname.Name = "lbbrandname";
            this.lbbrandname.Size = new System.Drawing.Size(156, 17);
            this.lbbrandname.TabIndex = 23;
            this.lbbrandname.Text = "DB Connection String";
            // 
            // btnBrowseReportFolder
            // 
            this.btnBrowseReportFolder.BackColor = System.Drawing.Color.Gray;
            this.btnBrowseReportFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseReportFolder.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnBrowseReportFolder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseReportFolder.Location = new System.Drawing.Point(395, 149);
            this.btnBrowseReportFolder.Name = "btnBrowseReportFolder";
            this.btnBrowseReportFolder.Size = new System.Drawing.Size(68, 31);
            this.btnBrowseReportFolder.TabIndex = 20;
            this.btnBrowseReportFolder.Text = "Browse";
            this.btnBrowseReportFolder.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(280, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 49);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Simpan";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 290);
            this.Controls.Add(this.tbReportFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbConnectionString);
            this.Controls.Add(this.lbbrandname);
            this.Controls.Add(this.btnBrowseReportFolder);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbReportFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.Label lbbrandname;
        private System.Windows.Forms.Button btnBrowseReportFolder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}