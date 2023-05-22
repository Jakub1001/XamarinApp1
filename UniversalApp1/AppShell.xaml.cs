using UniversalApp1.Views;
using Xamarin.Forms;

namespace UniversalApp1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoEntryPage), typeof(TodoEntryPage));
            Routing.RegisterRoute(nameof(RoutineEntryPage), typeof(RoutineEntryPage));
        }

    }
}
