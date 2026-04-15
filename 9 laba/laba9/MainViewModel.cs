using laba9.Models;
using laba9.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace laba9.ViewModels
{
    public class MainViewModel : ObservableObject // ViewModel
    {
        // Коллекция контактов
        public ObservableCollection<ContactModel> Contacts { get; }

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

        public MainViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>();
            AddCommand = new RelayCommand(AddContact,() => CanAddContact());
            DeleteCommand = new RelayCommand(DeleteContact, () => CanDeleteContact());

            // TODO: инициализируйте DeleteCommand
            // Используйте методы DeleteContact() и
            // CanDeleteContact()
        }
        private void AddContact()
        {
            // TODO: создайте новый Contact с Name и
            // Phone, затем добавьте его в Contacts
            // После добавления очистите поля ввода

            if (ContactModel.Validate(ContactName, ContactPhoneNum))
            {
                Contacts.Add(new ContactModel(ContactName, ContactPhoneNum));

                ContactName = string.Empty;
                ContactPhoneNum = string.Empty;
            }
        }
        private bool CanAddContact()
        {
            // TODO: верните true, если Name не пуст
            // и Phone не пуст (расширенная проверка)
            //
            return ContactModel.Validate(ContactName, ContactPhoneNum);
        }
        private void DeleteContact()
        {
            if (SelectedContact != null)
            {
                Contacts.Remove(SelectedContact);
            }
        }
        private bool CanDeleteContact()
        {
            return SelectedContact != null;
        }
    }
}
