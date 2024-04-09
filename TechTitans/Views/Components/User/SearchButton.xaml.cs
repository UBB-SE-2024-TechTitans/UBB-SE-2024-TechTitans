using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTitans.Views.Components.User
{
    public partial class SearchSongsButton : ContentView
    {
        public SearchSongsButton()
        {
            InitializeComponent();
        }

        private void OnSearchClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }
    }
}
