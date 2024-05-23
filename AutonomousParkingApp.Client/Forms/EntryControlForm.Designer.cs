namespace AutonomousParkingApp.Client.Forms
{
    partial class EntryControlForm
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
            this.bReg = new System.Windows.Forms.Button();
            this.bAuth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bReg
            // 
            this.bReg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bReg.ForeColor = System.Drawing.Color.White;
            this.bReg.Location = new System.Drawing.Point(40, 130);
            this.bReg.Name = "bReg";
            this.bReg.Size = new System.Drawing.Size(128, 25);
            this.bReg.TabIndex = 0;
            this.bReg.Text = "Регистрация";
            this.bReg.UseVisualStyleBackColor = false;
            this.bReg.Click += new System.EventHandler(this.bReg_Click);
            // 
            // bAuth
            // 
            this.bAuth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bAuth.ForeColor = System.Drawing.Color.White;
            this.bAuth.Location = new System.Drawing.Point(40, 90);
            this.bAuth.Name = "bAuth";
            this.bAuth.Size = new System.Drawing.Size(128, 25);
            this.bAuth.TabIndex = 1;
            this.bAuth.Text = "Авторизация";
            this.bAuth.UseVisualStyleBackColor = false;
            this.bAuth.Click += new System.EventHandler(this.bAuth_Click);
            // 
            // EntryControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(180, 283);
            this.ControlBox = false;
            this.Controls.Add(this.bAuth);
            this.Controls.Add(this.bReg);
            this.Name = "EntryControlForm";
            this.Text = "EntryControlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bReg;
        private System.Windows.Forms.Button bAuth;
    }
}