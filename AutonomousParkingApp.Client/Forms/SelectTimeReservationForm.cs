using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class SelectTimeReservationForm : Form
    {
        public DateTime? checkInTime = null;

        public SelectTimeReservationForm()
        {
            InitializeComponent();

            dateTimePickerCheckInTime.MinDate = DateTime.Now;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            checkInTime = dateTimePickerCheckInTime.Value;

            Close();
        }

        private void bCancel_Click(object sender, EventArgs e) =>
            Close();
    }
}
