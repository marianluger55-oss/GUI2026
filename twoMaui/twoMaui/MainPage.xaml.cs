using twoMaui;

namespace twoMaui
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
            string input = xnumber.Text;

            int newinput = int.Parse(input); 

           

            if(newinput % 2 == 0)
            {
                ltext.Text = "Zahl ist gerade."; 
            }
            else
            {
                ltext.Text = "Zahl ist ungerade"; 
            }
        }
    }
}
