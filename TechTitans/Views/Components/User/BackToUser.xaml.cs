using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Views.Components.User
{
    public partial class BackToUserButton : ContentView
    {
        public BackToUserButton()
        {
            InitializeComponent();
        }

        private void OnBackClick(object sender, EventArgs e) => Application.Current.MainPage = new NavigationPage(new UserPage());
    }
}
