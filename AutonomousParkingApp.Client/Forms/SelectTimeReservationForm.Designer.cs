namespace AutonomousParkingApp.Client.Forms
{
    partial class SelectTimeReservationForm
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
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.dateTimePickerCheckInTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // bOk
            // 
            this.bOk.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOk.ForeColor = System.Drawing.Color.White;
            this.bOk.Location = new System.Drawing.Point(12, 54);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(128, 25);
            this.bOk.TabIndex = 22;
            this.bOk.Text = "ОК";
            this.bOk.UseVisualStyleBackColor = false;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.ForeColor = System.Drawing.Color.White;
            this.bCancel.Location = new System.Drawing.Point(187, 54);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(128, 25);
            this.bCancel.TabIndex = 23;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = false;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // dateTimePickerCheckInTime
            // 
            this.dateTimePickerCheckInTime.CustomFormat = "MM.dd.yyyy  hh:mm";
            this.dateTimePickerCheckInTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerCheckInTime.Location = new System.Drawing.Point(12, 12);
            this.dateTimePickerCheckInTime.MinDate = new System.DateTime(2024, 6, 5, 0, 0, 0, 0);
            this.dateTimePickerCheckInTime.Name = "dateTimePickerCheckInTime";
            this.dateTimePickerCheckInTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerCheckInTime.Size = new System.Drawing.Size(303, 22);
            this.dateTimePickerCheckInTime.TabIndex = 24;
            this.dateTimePickerCheckInTime.Value = new System.DateTime(2024, 6, 5, 19, 41, 41, 0);
            // 
            // SelectTimeReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(325, 91);
            this.ControlBox = false;
            this.Controls.Add(this.dateTimePickerCheckInTime);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Name = "SelectTimeReservationForm";
            this.Text = "Время заезда";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckInTime;
    }
}