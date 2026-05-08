using System.Threading.Tasks;

namespace FiftyNineFilePicker
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           FileResult? result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                string fileName = result.FullPath;
                string content = File.ReadAllText(fileName);
                eFileContent.Text = content;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            IEnumerable <FileResult> listofResults = await FilePicker.Default.PickMultipleAsync(); 
            foreach (FileResult result in listofResults)
            {
                //alle Datein lesen und im eFileContent anzeigen 
                string content = File.ReadAllText(result.FullPath);
                eFileContent.Text += $"{content} \n"; 
            }
        }

        private async void ChooseCsFileButton_Clicked(object sender, EventArgs e)
        {
            PickOptions options = new PickOptions();
            options.PickerTitle = "Bitte .cs Datei auswählen";
            Dictionary<DevicePlatform, IEnumerable<string>> fileTypeList = new Dictionary<DevicePlatform, IEnumerable<string>>();

            fileTypeList[DevicePlatform.WinUI] = new List<string>() { ".cs" };
            fileTypeList[DevicePlatform.Android] = new List<string>() { "text/plain" };

            FilePickerFileType fileTypes = new FilePickerFileType(fileTypeList);
            options.FileTypes = fileTypes;

            FileResult? result= await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                string content = File.ReadAllText(result.FullPath);
                eFileContent.Text = content; 
            }
        }

        private void ChooseFolderButtonClicked(object sender, EventArgs e)
        {
            // FolderPicker aus dem NuGet Package ".NET MAUI Community Toolkit" verwenden
            FolderPicker
        }
    }
}
