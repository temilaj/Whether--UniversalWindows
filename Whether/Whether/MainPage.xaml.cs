using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Whether.BusinessLogic;
using Whether.Model;
using Whether.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Whether
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            GoHome();
            HomeIcon.IsSelected = true;
        }
        private void IconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeIcon.IsSelected)
            {
                GoHome();
            }
        }

        private void GoHome()
        {
            BackButton.Visibility = Visibility.Collapsed;
            PageFrame.Navigate(typeof(HomePage));
            TitleTB.Text = "Home";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (PageFrame.CanGoBack)
            {
                PageFrame.GoBack();
                HomeIcon.IsSelected = true;

            }
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

    }
}
