using laba13.Models;
using laba13.Models.DB;
using laba13.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace laba13.ViewModels
{
    public class ContactsListViewModel : ObservableObject // ViewModel
    {
        // Коллекция контактов
        private readonly PhoneBookDbContext _context;
        public ObservableCollection<Contact> Contacts { get; }

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

        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }
        // Команды
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }

        public ContactsListViewModel(INavigationService navigation, IDialogService dialogService, PhoneBookDbContext context)
        {
            _navigationService = navigation;
            _dialogService = dialogService;
            _context = context;

            //Contacts = new ObservableCollection<ContactModel>();
            Contacts = new ObservableCollection<Contact>(_context.Contacts.ToList()); 
            AddCommand = new RelayCommand(AddContact, () => CanAddContact());
            DeleteCommand = new RelayCommand(DeleteContact, () => CanDeleteContact());
            EditCommand = new RelayCommand(EditContact, () => CanEditContact());
        }

        // методы
        private void AddContact()
        {
            // Проверка на дубликат по номеру телефона
            if (Contacts.Any(c => c.Phone == ContactPhoneNum))
            {
                _dialogService.ShowWarning("A contact with this number already exists!");
                return;
            }

            if (ContactModel.Validate(ContactName, ContactPhoneNum))
            {
                //Contacts.Add(new Contact());//(Name, ContactPhoneNum));
                try
                {
                    var newContact = new Contact
                    {
                        Name = ContactName,
                        Phone = ContactPhoneNum
                    };
                    // 1. Помечаем объект как добавленный
                    _context.Contacts.Add(newContact);
                    // 2. Сохраняем изменения в БД (генерирует INSERT)
                    _context.SaveChanges();

                    Contacts.Add(newContact);

                    ContactName = string.Empty;
                    ContactPhoneNum = string.Empty;

                    _dialogService.ShowInfo("Contact added");
                }
                catch (Exception ex)
                {
                    _dialogService?.ShowError($"Error when adding: {ex.Message}");
                }
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

            bool confirmed = _dialogService.ShowConfirmation($"Do you really want to delete the contact\"{SelectedContact.Name}\"?");

            if (confirmed)
            {
                try
                {                    //Contacts.Remove(SelectedContact);
                    if (SelectedContact == null) return;
                    // 1. Помечаем объект как удалённый
                    _context.Contacts.Remove(SelectedContact);
                    // 2. Сохраняем изменения (генерирует DELETE)
                    _context.SaveChanges();
                    // 3. Обновляем UI коллекцию
                    Contacts.Remove(SelectedContact);

                    _dialogService.ShowInfo("Contact successfully deleted");
                }
                catch (Exception ex)
                {
                    _dialogService.ShowError($"Error when deleting{ex.Message}");
                }
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

        public void RefreshContacts()
        {
            // Перезагружаем коллекцию из БД
            var updatedContacts = _context.Contacts.ToList();
            Contacts.Clear();
            foreach (var contact in updatedContacts)
            {
                Contacts.Add(contact);
            }
        }
    }
}