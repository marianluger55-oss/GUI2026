namespace FourtyControlesDemo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            lSwitch.Text = "eingeschaltet"; 
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
    }
}
