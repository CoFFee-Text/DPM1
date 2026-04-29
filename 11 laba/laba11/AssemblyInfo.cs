using laba11.Services;
using laba11.ViewModels;
using laba11.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace laba11
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // Сервисы (Singleton)
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ContactsListViewModel>();

            // ViewModels (Transient)
            services.AddTransient<AboutProgramViewModel>();
            services.AddTransient<ContactEditViewModel>();

            // Shell ViewModel (Singleton)
            services.AddSingleton<MainWindowViewModel>();

            // Главное окно (Singleton)
            services.AddSingleton<MainWindow>(sp =>
            {
                var window = new MainWindow();
                window.DataContext = sp.GetRequiredService<MainWindowViewModel>();
                return window;
            });

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }

}
