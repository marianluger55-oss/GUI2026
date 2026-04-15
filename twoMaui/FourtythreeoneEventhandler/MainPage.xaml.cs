namespace FourtythreeoneEventhandler
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CounterBtn.Clicked += OnCounterClicked;
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

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value)
            {
                // fast mode
                CounterBtn.Clicked -= OnCounterClicked; // Eventhandler entfernen, damit die Methode nicht mehr aufgerufen wird, wenn der Button geklickt wird
                CounterBtn.Clicked += OnCounterClickedFast; // neuen Eventhandler hinzufügen, damit die neue Methode aufgerufen wird, wenn der Button geklickt wird

            }
            else
            {
                CounterBtn.Clicked -= OnCounterClickedFast;
                CounterBtn.Clicked += OnCounterClicked; 
            }
        }

        private void CounterBtn_Clicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCounterClickedFast(object? sender, EventArgs e)
        {
            count += 10;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
