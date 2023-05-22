using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalApp1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversalApp1.Views
{
   
    public partial class RoutinePage : ContentPage
    {
        public RoutinePage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            rcollectionView.ItemsSource = await App.RDatabase.GetNotesAsync();
        }
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Routine rnote = (Routine)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(RoutineEntryPage)}?{nameof(RoutineEntryPage.ItemIdr)}={rnote.ID}");
            }
        }
        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(RoutineEntryPage));
        }
    }
}