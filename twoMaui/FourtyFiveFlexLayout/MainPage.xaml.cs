namespace FourtyFiveFlexLayout
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_clicked(object sender, EventArgs e)
        {
            DisplayAlert("Information", "Aktualisiert!", "OK"); 
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Bestätigung", "Speicher überschreibt", "Ja", "Nein");
            // await und async --> vorerst verwenden, auch ohne Hintergrundwissen 
            if(answer)
            {
                //Benutzer hat ja gewählt
            }
            else
            {
                // Benutzer hat nein gewählt 
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
           string action = await DisplayActionSheet("Wähle ein Essen: Menü", "Abbrechen", null, "Standart", "XL", "XXL", "Freundin will nix: Standart + extra fries und 2 chicken wings");
            lMenu.Text = action; 
            if(action == abbrechen)
            {

            }
            else
            {

            }
        }
    }
}
