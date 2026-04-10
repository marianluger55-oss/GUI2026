namespace Event
{
    public partial class MainPage : ContentPage
    {
        private string selectedLocation = "(nicht ausgewählt)";

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


        private void Button_Clicked(object sender, EventArgs e)
        {
            string title = lTitle.Text ?? "Kein Titel";
            string time = lTime.Text ?? "Keine Uhrzeit gewählt";
            string date = lDate.Text ?? "Kein Datum gewählt";
            string guests = lPersonen.Text ?? "Keine Gästeanzahl";
            string location = lLocation.Text ?? "Keine Location";
            string catering = lSwitch.Text ?? "Kein Catering gewählt";
            string tables = lFuel
                .Text ?? "Keine Tische";

            lSummary.Text =
                $"--- Geburtstagsfeier ---\n" +
                $"Titel: {title}\n" +
                $"{date}\n" +
                $"{time}\n" +
                $"{guests}\n" +
                $"{location}\n" +
                $"{catering}\n" +
                $"{tables}";
        }
    }
}
