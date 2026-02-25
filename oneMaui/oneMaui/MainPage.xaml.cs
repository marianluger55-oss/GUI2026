namespace oneMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
            lWelcome.Text = $"Herzlich Willkommen, {eName.Text}!";

        }
    }
}
