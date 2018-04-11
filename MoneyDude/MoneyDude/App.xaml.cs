using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.Ioc;
using MoneyDude.ViewModels;
using MoneyDude.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoneyDude
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }


        protected override void OnStart()
        {
            AppCenter.Start(
                "android=55b0c113-691e-4478-8a90-abd12d212dc7;ios=f54df965-0774-434a-a443-7cca728d7fd9",
                typeof(Crashes));
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<NewAccountPage>();
            containerRegistry.RegisterForNavigation<AddTransactionPage>();
            containerRegistry.RegisterForNavigation<OpenReportsPage>();
        }
    }
}
