using System.ComponentModel.Design;

namespace FourtysixsixSmartHome
{
    public partial class MainPage : ContentPage
    {

        private bool alarmEnabled = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void lSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true) {
                lightStatusLabel.Text = "Ein";
            }
            else
            {
                lightStatusLabel.Text = "Aus";
            }
                 
        }
          

        private void Button_Clicked(object sender, EventArgs e)
        {
            alarmEnabled = !alarmEnabled;
            if (alarmEnabled)
            {
                status.Text = "Alarm ist scharf";
                Alarm.Text = "Alarm aktiv";
            }
            else
            {
                status.Text = "Alles Normal";
                Alarm.Text = "Alarm Inaktiv";
            }
            
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lLautstärke.Text = $"{(int)e.NewValue}%";
        }

        private void Slider_ValueChanged_1(object sender, ValueChangedEventArgs e)
        {
            lTemperatur.Text = $"{(int)e.NewValue} °C";
        }
    }
}
