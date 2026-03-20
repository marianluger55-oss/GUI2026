

namespace FourtyControlesDemo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            lSwitch.Text = "eingeschaltet";
            dpMaintenance.MinimumDate = new DateTime(2024, 1, 1); 
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true) {
                lSwitch.Text = "eingeschaltet"; 
            }
            else
            {
                lSwitch.Text = "ausgeschaltet"; 
            }
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lFuel != null)
            {
                lFuel.Text = $"Kraftstoffmenge: {e.NewValue}";
            }
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lVolume.Text = $"Lautstärke: {(int)e.NewValue}"; 
        }

        private void TimePicker_TimeSelected(object sender, TimeChangedEventArgs e)
        {
            lWorkingStart.Text = e.NewTime.ToString(); 
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            lMaintenance.Text = e.NewDate.ToLongDateString(); 
        }

        private void pTractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = pTractor.SelectedIndex; //ausgewählter Index der Liste
            if(idx != -1)
            {
                string selectedTractor = pTractor.Items[idx];
                lTractor.Text = $"Auswahl:{selectedTractor}"; 
            }
        }
    }
}
