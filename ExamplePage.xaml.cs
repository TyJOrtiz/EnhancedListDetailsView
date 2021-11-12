using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App (replace namespace with your app name)
{
    public sealed partial class ExamplePage : Page 
    {
        public ExamplePage()
        {
            this.InitializeComponent();
        }
        private void LDV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] != null)
            {
                //Get object from selected item
                parameter = e.AddedItems[0] as object;

                //Get the page that you want to navigate to
                var page = GetPage;
                
                //Have the ListDetailsView DetailsFrame Navigate to the page and pass the parameter (transition optional)
                LDV.DetailsFrame.Navigate(page, parameter, new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());
            }
        }
    }
}
