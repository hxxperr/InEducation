using InEducation.View.Windows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace InEducation.Navigation
{
    public static class Navigation
    {
        private static NavigationService _instance = (Application.Current.MainWindow as MainWindow).GlobalFrame.NavigationService;

        // public static void SetInstance(NavigationService navigationService) => _instance = navigationService;

        public static bool GoTo(Page page) => _instance == null ? throw new InvalidOperationException("Can't go, instance is null") : _instance.Navigate(page);

        public static void GoBack()
        {
            if (_instance.CanGoBack)
            {
                _instance?.GoBack();
            }
        }

        public static NavigationService GetInstance() => _instance;
    }
}
