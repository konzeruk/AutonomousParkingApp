using AutonomousParkingApp.Client.Forms.Helpers;

namespace AutonomousParkingApp.Client.Forms.Extensions
{
    public static class ActiveFormExtension
    {
        public static void ShowActiveForm(this ActiveForm activeForm)
        {
            if (!activeForm.IsShow)
            {
                activeForm.InitForm.Show();
                activeForm.IsShow = true;
            }
        }

        public static void CloseActiveForm(this ActiveForm activeForm)
        {
            if (activeForm.IsShow)
            {
                activeForm.InitForm.Hide();
                activeForm.IsShow = false;
            }
        }
    }
}
