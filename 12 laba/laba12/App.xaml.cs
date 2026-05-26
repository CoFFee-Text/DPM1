using laba12.Services;
using laba12.ViewModels;
using laba12.Views;
using laba12.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace laba12
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            string connectionString = "Data Source=DESKTOP-A8I9H82\\MSSQLSERVER1;Initial Catalog=PhoneBookDB;Integrated Security=True;Trust Server Certificate=True";

            services.AddDbContext<PhoneBookDbContext>(options => options.UseSqlServer(connectionString));

            // Сервисы (Singleton)
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // ViewModels (ContactsListViewModel - Singleton, чтобы сохранять данные)
            services.AddTransient<ContactsListViewModel>();
            services.AddTransient<AboutProgramViewModel>();
            services.AddTransient<ContactEditViewModel>();

            // Shell ViewModel (Singleton)
            services.AddSingleton<MainWindowViewModel>();

            // Главное окно
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
