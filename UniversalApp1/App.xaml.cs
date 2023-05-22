using System;
using System.IO;
using UniversalApp1.Data;
using Xamarin.Forms;

namespace UniversalApp1
{
    public partial class App : Application
    {
        static TodoDatabase database;
        static RoutineDatabase rdatabase;

        public static TodoDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }
        public static RoutineDatabase RDatabase
        {
            get
            {
                if (rdatabase == null)
                {
                    rdatabase = new RoutineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "rNotes.db3"));
                }
                return rdatabase;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
