using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace hue12
{
    public partial class AppShell : Shell
    {
        private const string PreferencesKey = "hue12_savedDates";
        private List<DateTime> savedDates = new();

        public AppShell()
        {
            InitializeComponent();
            LoadSavedDates();
            UpdateEditor();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var selectedDate = Date?.Date ?? DateTime.Now.Date;
            // Eintrag hinzufügen (Duplikate erlauben; bei Bedarf ändern)
            savedDates.Add(selectedDate);
            SaveSavedDates();

            var dateString = selectedDate.ToString("dd.MM.yyyy");
            lsaved.Text = $"Gespeichert: {dateString} ({savedDates.Count} Einträge)";

            // Editor sofort aktualisieren, falls geöffnet
            UpdateEditor();
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            UpdateEditor();
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            savedDates.Clear();
            SaveSavedDates();
            UpdateEditor();
            lsaved.Text = "Alle Einträge wurden gelöscht.";
        }

        private void LoadSavedDates()
        {
            try
            {
                var json = Preferences.Get(PreferencesKey, "[]");
                var list = JsonSerializer.Deserialize<List<DateTime>>(json);
                savedDates = list ?? new List<DateTime>();
            }
            catch
            {
                savedDates = new List<DateTime>();
            }
        }

        private void SaveSavedDates()
        {
            try
            {
                var json = JsonSerializer.Serialize(savedDates);
                Preferences.Set(PreferencesKey, json);
            }
            catch
            {
                // Fehler beim Speichern ignorieren; bei Bedarf Logging ergänzen
            }
        }

        private void UpdateEditor()
        {
            if (SavedEditor == null)
                return;

            if (savedDates == null || savedDates.Count == 0)
            {
                SavedEditor.Text = "Keine gespeicherten Daten.";
                return;
            }

            var today = DateTime.Today;
            var lines = savedDates.Select(d =>
            {
                var dateText = d.ToString("dd.MM.yyyy");
                var days = (d.Date - today).Days;
                return days switch
                {
                    > 0 => $"{days} Tage bis zum {dateText}",
                    0 => $"Heute: {dateText}",
                    < 0 => $"{Math.Abs(days)} Tage seit dem {dateText}"
                };
            });

            SavedEditor.Text = string.Join(Environment.NewLine, lines);
        }
    }
}
