using laba13.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace laba13.ViewModels
{
    public class MainWindowViewModel
    {
        public INavigationService _navigationService;

        public INavigationService NavigationService => _navigationService;

        public MainWindowViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            ShowContactsCommand = new RelayCommand(() => _navigationService.NavigateTo<ContactsListViewModel>());
            ShowAboutCommand = new RelayCommand(() => _navigationService.NavigateTo<AboutProgramViewModel>());
            _navigationService.NavigateTo<ContactsListViewModel>();
        }
        public ICommand ShowContactsCommand { get; }
        public ICommand ShowAboutCommand { get; }

    }
}