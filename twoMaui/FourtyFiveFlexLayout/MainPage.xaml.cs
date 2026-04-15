namespace FourtyFiveFlexLayout
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Information", "Aktualisiert!", "OK"); 
        }
    }
}
