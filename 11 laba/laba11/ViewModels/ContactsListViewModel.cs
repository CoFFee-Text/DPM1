using laba11.Models;
using laba11.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace laba11.ViewModels
{
    public class ContactsListViewModel : ObservableObject // ViewModel
    {
        // Коллекция контактов
        public ObservableCollection<ContactModel> Contacts { get; }

        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        private string _contactName = string.Empty;
        private string _contactPhoneNum = string.Empty;
        public string ContactName
        {
            get => _contactName;
            set => Set(ref _contactName, value);
        }
        public string ContactPhoneNum
        {
            get => _contactPhoneNum;
            set => Set(ref _contactPhoneNum, value);
        }

        private ContactModel? _selectedContact;
        public ContactModel? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }
        // Команды
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }

        public ContactsListViewModel(INavigationService navigation, IDialogService dialogService)
        {
            Contacts = new ObservableCollection<ContactModel>();
            AddCommand = new RelayCommand(AddContact, () => CanAddContact());
            DeleteCommand = new RelayCommand(DeleteContact, () => CanDeleteContact());
            EditCommand = new RelayCommand(EditContact, () => CanEditContact());

            _navigationService = navigation;
            _dialogService = dialogService;
        }

        // методы
        private void AddContact()
        {
            // Проверка на дубликат по номеру телефона
            if (Contacts.Any(c => c.ContactPhoneNum == ContactPhoneNum))
            {
                _dialogService.ShowWarning("A contact with this number already exists!");
                return;
            }

            if (ContactModel.Validate(ContactName, ContactPhoneNum))
            {
                Contacts.Add(new ContactModel(ContactName, ContactPhoneNum));
                _dialogService.ShowInfo("Contact added");

                ContactName = string.Empty;
                ContactPhoneNum = string.Empty;
            }
        }
        private bool CanAddContact()
        {
            return ContactModel.Validate(ContactName, ContactPhoneNum);
        }
        private void DeleteContact()
        {
            if (SelectedContact == null)
                return;

            bool confirmed = _dialogService.ShowConfirmation($"Do you really want to delete the contact\"{SelectedContact.ContactName}\"?");

            if (confirmed)
            {
                Contacts.Remove(SelectedContact);
                _dialogService.ShowInfo("Contact successfully deleted");
            }
        }
        private bool CanDeleteContact()
        {
            return SelectedContact != null;
        }

        private void EditContact()
        {
            if (SelectedContact != null)
            {
                _navigationService.NavigateTo<ContactEditViewModel>(SelectedContact);
            }
        }

        private bool CanEditContact()
        {
            return SelectedContact != null;
        }
    }
}