using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace MoneyDude.ViewModels
{
    public class AddTransactionPageViewModel : ViewModelBase
    {
        public AddTransactionPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Add new Transaction to Account";
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            throw new ArgumentNullException("parameters should not be null");
        }
    }
}
