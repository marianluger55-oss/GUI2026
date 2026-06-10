using CommunityToolkit.Maui.Storage;

namespace HerbariumLearnApp
{
    public partial class MainPage : ContentPage
    {
        private List<Plant> plantData;
        private int indexOfCurrentPlant;
        private string pathToPlants; 

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Verzeichnisauswählen(object sender, EventArgs e)
        {
            //FolderPicker aus dem Nuget Package CommunityToolkit.Maui.Storage verwenden
            FolderPickerResult result = await FolderPicker.Default.PickAsync();
            if (result != null && result.Folder != null)
            {
                eFolderContent.Text = result.Folder.Path; 
                ReadMetadata(result.Folder.Path);
            }
        }



        private void ReadMetadata(string path)
        {
            string fileName = Path.Combine(path, "metadaten.txt");
            plantData = File.ReadAllLines(fileName);
            pathToPlants = path; 
            LoadAndDisplayPlant();
        }

        private void LoadAndDisplayPlant()
        {
            string plant = plantData[indexOfCurrentPlant];
            string[] plantPars = plant.Split(';'); // 0 --> Nr, 1 -- Dt. Name, 2 -- Lat.Name,...


            // hier fehlt noch was

            List<ImageSource> source = new List<ImageSource>();

            for (int i = 1; i < 10; i++)
            {
                string plantImagePath = Path.Combine(pathToPlants, $"{plantPars[0]}_{i}.jpg");
                if (Path.Exists(plantImagePath))
                {
                    ImageSource imgSource = ImageSource.FromFile(plantImagePath);
                    source.Add(imgSource);
                }
            }

            cvPlants.ItemsSource = source;
        }

        private void naechstepflanze(object sender, EventArgs e)
        {
            indexOfCurrentPlant++;
            indexOfCurrentPlant = indexOfCurrentPlant % plantData.Length; 
            LoadAndDisplayPlant();

        }

        private void BtnHelpGerName_Clicked(object sender, EventArgs e)
        {
            Plant p = plantData[indexOfCurrentPlant];
            //schauen welcher Text bereits eingegeben wurde und diesen mit dem deutschen Namen vergleichen und den nächsten Buchstaben des deutschen Namens anzeigen
            string currentInput = eGerName.Text;
            string gerName = p.GerName;
            if (currentInput.Length < gerName.Length)
            {
                char nextLetter = gerName[currentInput.Length];
                eGerName.Text += nextLetter;
            }

        }

        private void BtnHelpLat_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnGerFam_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnLatFam_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnCheck_Clicked(object sender, EventArgs e)
        {

        }

        private void FalschMakieren_Clicked(object sender, EventArgs e)
        {

        }


        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
