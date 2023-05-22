using System;
using System.Linq;
using UniversalApp1.Models;
using Xamarin.Forms;

namespace UniversalApp1.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoPage : ContentPage
    {
        public TodoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Todo note = (Todo)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(TodoEntryPage)}?{nameof(TodoEntryPage.ItemId)}={note.ID}");
            }
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(TodoEntryPage));
        }


    }
}