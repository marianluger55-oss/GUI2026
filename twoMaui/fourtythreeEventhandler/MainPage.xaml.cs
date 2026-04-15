namespace fourtythreeEventhandler
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent(); // erstellt die Controles und initialisiert sie, damit sie in der Klasse verwendet werden können
            CounterBtn.Clicked += OnCounterClicked; // Eventhandler hinzufügen, damit die Methode aufgerufen wird, wenn der Button geklickt wird
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
