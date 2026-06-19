using CommunityToolkit.Maui.Storage;

namespace HerbariumLearnApp;

public partial class MainPage : ContentPage
{
    private List<Plant> plantData = new();

    private int indexOfCurrentPlant = 0;
    private string pathToPlants = string.Empty;

    private int correctCount = 0;
    private int wrongCount = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void Verzeichnisauswählen(object sender, EventArgs e)
    {
        try
        {
            var result = await FolderPicker.Default.PickAsync();

            if (result?.Folder == null)
                return;

            pathToPlants = result.Folder.Path;
            eFolderContent.Text = pathToPlants;

            ReadMetadata(pathToPlants);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fehler", ex.Message, "OK");
        }
    }

    private void ReadMetadata(string path)
    {
        string fileName = Path.Combine(path, "metadaten.txt");

        if (!File.Exists(fileName))
        {
            DisplayAlert("Fehler", "metadaten.txt nicht gefunden", "OK");
            return;
        }

        plantData.Clear();

        foreach (var line in File.ReadAllLines(fileName))
        {
            var p = line.Split(';');

            if (p.Length < 5)
                continue;

            plantData.Add(new Plant
            {
                Id = p[0],
                GerName = p[1],
                LatName = p[2],
                GerFamily = p[3],
                LatFamily = p[4]
            });
        }

        if (plantData.Count == 0)
        {
            DisplayAlert("Fehler", "Keine Daten gefunden", "OK");
            return;
        }

        indexOfCurrentPlant = 0;
        LoadAndDisplayPlant();
    }

    private void LoadAndDisplayPlant()
    {
        if (plantData.Count == 0)
            return;

        var plant = plantData[indexOfCurrentPlant];

        eGerName.Text = "";
        eLatName.Text = "";
        eGerFamily.Text = "";
        eLatFamily.Text = "";

        eGerName.BackgroundColor = Colors.White;
        eLatName.BackgroundColor = Colors.White;
        eGerFamily.BackgroundColor = Colors.White;
        eLatFamily.BackgroundColor = Colors.White;

        List<ImageSource> images = new();

        for (int i = 1; i <= 10; i++)
        {
            string path = Path.Combine(pathToPlants, $"{plant.Id}_{i}.jpg");

            if (File.Exists(path))
                images.Add(ImageSource.FromFile(path));
        }

        cvPlants.ItemsSource = images;

        UpdateProgress();
    }

    private void UpdateProgress()
    {
        if (plantData.Count == 0)
            return;

        lblProgress.Text = $"{indexOfCurrentPlant + 1} / {plantData.Count}";
        pbProgress.Progress = (double)(indexOfCurrentPlant + 1) / plantData.Count;
    }

    private void naechstepflanze(object sender, EventArgs e)
    {
        if (plantData.Count == 0)
            return;

        indexOfCurrentPlant++;

        if (indexOfCurrentPlant >= plantData.Count)
            indexOfCurrentPlant = 0;

        LoadAndDisplayPlant();
    }

    private void GiveHint(Entry entry, string solution)
    {
        if (string.IsNullOrEmpty(solution))
            return;

        string current = entry.Text ?? "";

        if (current.Length < solution.Length)
            entry.Text += solution[current.Length];
    }

    private void BtnHelpGerName_Clicked(object sender, EventArgs e)
    {
        GiveHint(eGerName, plantData[indexOfCurrentPlant].GerName);
    }

    private void BtnHelpLat_Clicked(object sender, EventArgs e)
    {
        GiveHint(eLatName, plantData[indexOfCurrentPlant].LatName);
    }

    private void BtnGerFam_Clicked(object sender, EventArgs e)
    {
        GiveHint(eGerFamily, plantData[indexOfCurrentPlant].GerFamily);
    }

    private void BtnLatFam_Clicked(object sender, EventArgs e)
    {
        GiveHint(eLatFamily, plantData[indexOfCurrentPlant].LatFamily);
    }

    private async void BtnCheck_Clicked(object sender, EventArgs e)
    {
        if (plantData.Count == 0)
            return;

        var p = plantData[indexOfCurrentPlant];

        bool g1 = string.Equals(eGerName.Text?.Trim(), p.GerName, StringComparison.OrdinalIgnoreCase);
        bool g2 = string.Equals(eLatName.Text?.Trim(), p.LatName, StringComparison.OrdinalIgnoreCase);
        bool g3 = string.Equals(eGerFamily.Text?.Trim(), p.GerFamily, StringComparison.OrdinalIgnoreCase);
        bool g4 = string.Equals(eLatFamily.Text?.Trim(), p.LatFamily, StringComparison.OrdinalIgnoreCase);

        eGerName.BackgroundColor = g1 ? Colors.LightGreen : Colors.LightPink;
        eLatName.BackgroundColor = g2 ? Colors.LightGreen : Colors.LightPink;
        eGerFamily.BackgroundColor = g3 ? Colors.LightGreen : Colors.LightPink;
        eLatFamily.BackgroundColor = g4 ? Colors.LightGreen : Colors.LightPink;

        bool allCorrect = g1 && g2 && g3 && g4;

        if (allCorrect)
        {
            correctCount++;
            await DisplayAlert("Richtig", "Alles korrekt!", "OK");
        }
        else
        {
            wrongCount++;
            await DisplayAlert("Falsch", "Mindestens ein Feld ist falsch", "OK");
        }

        UpdateStats();
    }

    private void UpdateStats()
    {
        lblCorrect.Text = $"✓ {correctCount}";
        lblWrong.Text = $"✗ {wrongCount}";
    }

    private void RichtigMarkieren_Clicked(object sender, EventArgs e)
    {
        correctCount++;
        UpdateStats();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        wrongCount++;
        UpdateStats();
    }
}