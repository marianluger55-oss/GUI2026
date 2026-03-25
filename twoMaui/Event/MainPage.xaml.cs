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
    }
}
