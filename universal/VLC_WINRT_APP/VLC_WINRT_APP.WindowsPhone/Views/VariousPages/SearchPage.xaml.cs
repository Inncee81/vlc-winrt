﻿using System;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VLC_WINRT_APP.Helpers;
using VLC_WINRT_APP.ViewModels;


namespace VLC_WINRT_APP.Views.VariousPages
{
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            StatusBarHelper.Default();
            HardwareButtons.BackPressed += HardwareButtonsOnBackPressed;
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            HardwareButtons.BackPressed -= HardwareButtonsOnBackPressed;
        }

        private void HardwareButtonsOnBackPressed(object sender, BackPressedEventArgs backPressedEventArgs)
        {
            backPressedEventArgs.Handled = true;
            if (App.ApplicationFrame.CanGoBack)
                App.ApplicationFrame.GoBack();
        }

        private void SearchBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Locator.MainVM.SearchTag = SearchBox.Text;
        }
    }
}
