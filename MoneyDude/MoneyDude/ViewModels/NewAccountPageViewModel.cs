using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism.Navigation;

namespace MoneyDude.ViewModels
{
    public class NewAccountPageViewModel : ViewModelBase
    {
        public NewAccountPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Creat a new Account";
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Analytics.TrackEvent("New Account");

            try
            {
                throw new ArgumentNullException("Error in new account");
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
            }
        }

    }
}
