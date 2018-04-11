using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AppCenter.Analytics;
using Prism.Navigation;

namespace MoneyDude.ViewModels
{
    public class OpenReportsPageViewModel : ViewModelBase
    {
        public OpenReportsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Open Reports";
        }


        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Analytics.TrackEvent("Open Reporst");
        }
    }
}
