using laba11.Models;
using laba11.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace laba11.ViewModels
{
    public class ContactEditViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        private ContactModel _contact = null!;

        private string _editContactName = string.Empty;
        private string _editContactPhone = string.Empty;
        public string EditContactName
        {
            get => _editContactName;
            //set { _contact.ContactName = value; OnPropertyChanged(); }
            set => Set(ref _editContactName, value);
        }
        public string EditContactPhone
        {
            get => _editContactPhone;
            //set { _contact.ContactPhoneNum = value; OnPropertyChanged(); }
            set => Set(ref _editContactPhone, value);
        }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ContactEditViewModel(IDialogService dialogService, INavigationService navigation)
        {
            _dialogService = dialogService;
            _navigationService = navigation;

            //SaveCommand = new RelayCommand(() => _navigationService.NavigateTo<ContactsListViewModel>());
            //CancelCommand = new RelayCommand(() => _navigationService.NavigateTo<ContactsListViewModel>());
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }
        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is ContactModel c)
            {
                _contact = c;
                EditContactName = c.ContactName;
                EditContactPhone = c.ContactPhoneNum;
            }
        }
        private void Save()
        {
            _contact.ContactName = EditContactName;
            _contact.ContactPhoneNum = EditContactPhone;

            _dialogService.ShowInfo("Контакт успешно обновлён");

            _navigationService.NavigateTo<ContactsListViewModel>();
        }
        private bool CanSave()
        {
            return ContactModel.Validate(EditContactName, EditContactPhone);
        }
        private void Cancel()
        {
            _navigationService.NavigateTo<ContactsListViewModel>();
        }
    }
}
