namespace Event
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lFuel != null)
            {
                lFuel.Text = $"Anzahl der Tische: {e.NewValue}";
            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                lSwitch.Text = "Catering";
            }
            else
            {
                lSwitch.Text = "Kein Catering";
            }
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lPersonen.Text = $"Anzahl der Personen: {(int)e.NewValue}";
        }
    }
}
