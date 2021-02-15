namespace DataBaseDates.View
{
    partial class CheckPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckPassword));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.visible = new System.Windows.Forms.CheckBox();
            this.password = new System.Windows.Forms.TextBox();
            this.no = new System.Windows.Forms.Button();
            this.yes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(227)))));
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPanel.Controls.Add(this.visible);
            this.MainPanel.Controls.Add(this.password);
            this.MainPanel.Controls.Add(this.no);
            this.MainPanel.Controls.Add(this.yes);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(593, 346);
            this.MainPanel.TabIndex = 2;
            // 
            // visible
            // 
            this.visible.AutoSize = true;
            this.visible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.visible.Location = new System.Drawing.Point(24, 195);
            this.visible.Name = "visible";
            this.visible.Size = new System.Drawing.Size(167, 24);
            this.visible.TabIndex = 12;
            this.visible.Text = "Показать пароль";
            this.visible.UseVisualStyleBackColor = true;
            this.visible.CheckedChanged += new System.EventHandler(this.visible_CheckedChanged);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(204)))));
            this.password.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold);
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.password.Location = new System.Drawing.Point(24, 105);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(547, 67);
            this.password.TabIndex = 11;
            this.password.UseSystemPasswordChar = true;
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(204)))));
            this.no.Cursor = System.Windows.Forms.Cursors.Hand;
            this.no.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.no.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(0)))), ((int)(((byte)(36)))));
            this.no.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(50)))), ((int)(((byte)(107)))));
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.no.Location = new System.Drawing.Point(302, 242);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(195, 69);
            this.no.TabIndex = 10;
            this.no.Text = "Відміна";
            this.no.UseVisualStyleBackColor = false;
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // yes
            // 
            this.yes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(204)))));
            this.yes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.yes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(0)))), ((int)(((byte)(36)))));
            this.yes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(50)))), ((int)(((byte)(107)))));
            this.yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yes.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.yes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.yes.Location = new System.Drawing.Point(86, 242);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(195, 69);
            this.yes.TabIndex = 9;
            this.yes.Text = "Ок";
            this.yes.UseVisualStyleBackColor = false;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.label1.Location = new System.Drawing.Point(27, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 95);
            this.label1.TabIndex = 1;
            this.label1.Text = "Для зміни параметрів введіть пароль";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 346);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckPassword";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button no;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox visible;
        private System.Windows.Forms.TextBox password;
    }
}