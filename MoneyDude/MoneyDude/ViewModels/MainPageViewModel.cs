using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyDude.ViewModels
{

    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Money Dude";

            NewAccount = new DelegateCommand(async () => await NewAccountExecute());
            AddTransaction = new DelegateCommand(async () => await AddTransactionExecute());
            OpenReports = new DelegateCommand(async () => await OpenReportsExecute());
        }

        public ICommand NewAccount { get; }
        public ICommand AddTransaction { get; }
        public ICommand OpenReports { get; }

        private async Task NewAccountExecute()
        {
            await NavigationService.NavigateAsync("NewAccountPage");
        }

        private async Task AddTransactionExecute()
        {
            await NavigationService.NavigateAsync("AddTransactionPage");
        }

        private async Task OpenReportsExecute()
        {
            await NavigationService.NavigateAsync("OpenReportsPage");
        }
    }

}
