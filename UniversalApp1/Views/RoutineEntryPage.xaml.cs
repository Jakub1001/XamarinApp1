using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniversalApp1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversalApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
  
    [QueryProperty(nameof(ItemIdr), nameof(ItemIdr))]
    public partial class RoutineEntryPage : ContentPage
    {
        public string ItemIdr
        {
            set
            {
                LoadRoutine(value);
            }
        }
        public RoutineEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Routine();
        }
        async void LoadRoutine(string itemIdr)
        {
            try
            {
                int idr = Convert.ToInt32(itemIdr);
                // Retrieve the note and set it as the BindingContext of the page.
                Routine rnote = await App.RDatabase.GetNoteAsync(idr);
                BindingContext = rnote;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var rnote = (Routine)BindingContext;

            rnote.From.Add(TimeSpan.FromMinutes(1));
            rnote.To.Add(TimeSpan.FromMinutes(1));

            // rnote.From = TimeSpan.Zero;
            // rnote.To = TimeSpan.Zero;
            if (!string.IsNullOrWhiteSpace(rnote.RoutineText))
            {
                await App.RDatabase.SaveNoteAsync(rnote);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var rnote = (Routine)BindingContext;
            await App.RDatabase.DeleteNoteAsync(rnote);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}