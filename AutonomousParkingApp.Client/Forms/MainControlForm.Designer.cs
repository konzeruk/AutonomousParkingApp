namespace AutonomousParkingApp.Client.Forms
{
    partial class MainControlForm
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
            this.bExit = new System.Windows.Forms.Button();
            this.bMap = new System.Windows.Forms.Button();
            this.bMyRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bExit
            // 
            this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bExit.ForeColor = System.Drawing.Color.White;
            this.bExit.Location = new System.Drawing.Point(40, 246);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(128, 25);
            this.bExit.TabIndex = 7;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bMap
            // 
            this.bMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bMap.ForeColor = System.Drawing.Color.White;
            this.bMap.Location = new System.Drawing.Point(40, 130);
            this.bMap.Name = "bMap";
            this.bMap.Size = new System.Drawing.Size(128, 25);
            this.bMap.TabIndex = 6;
            this.bMap.Text = "Карта";
            this.bMap.UseVisualStyleBackColor = false;
            this.bMap.Click += new System.EventHandler(this.bMap_Click);
            // 
            // bMyRoom
            // 
            this.bMyRoom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bMyRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bMyRoom.ForeColor = System.Drawing.Color.White;
            this.bMyRoom.Location = new System.Drawing.Point(40, 90);
            this.bMyRoom.Name = "bMyRoom";
            this.bMyRoom.Size = new System.Drawing.Size(128, 25);
            this.bMyRoom.TabIndex = 5;
            this.bMyRoom.Text = "Личный кабинет";
            this.bMyRoom.UseVisualStyleBackColor = false;
            this.bMyRoom.Click += new System.EventHandler(this.bMyRoom_Click);
            // 
            // MainControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(180, 283);
            this.ControlBox = false;
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bMap);
            this.Controls.Add(this.bMyRoom);
            this.Name = "MainControlForm";
            this.Text = "MainControlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bMap;
        private System.Windows.Forms.Button bMyRoom;
    }
}