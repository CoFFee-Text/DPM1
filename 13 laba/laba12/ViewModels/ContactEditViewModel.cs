using laba13.Models;
using laba13.Models.DB;
using laba13.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace laba13.ViewModels
{
    public class ContactEditViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly PhoneBookDbContext _context;

        private ContactModel _contact = null!;

        private string _editContactName = string.Empty;
        private string _editContactPhone = string.Empty;
        private Contact? _editingContact;
        //private bool _newContact;
        public string EditContactName
        {
            get => _editContactName;
            set => Set(ref _editContactName, value);
        }
        public string EditContactPhone
        {
            get => _editContactPhone;
            set => Set(ref _editContactPhone, value);
        }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ContactEditViewModel(IDialogService dialogService, INavigationService navigation, PhoneBookDbContext context)
        {
            _context = context;
            _dialogService = dialogService;
            _navigationService = navigation;

            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }
        public void OnNavigatedTo(object? parameter)
        {
            //if (parameter is ContactModel c)
            //{
            //    _contact = c;
            //    EditContactName = c.ContactName;
            //    EditContactPhone = c.ContactPhoneNum;
            //}

            if (parameter is Contact contact)
            {
                _editingContact = contact;
                EditContactName = contact.Name;
                EditContactPhone = contact.Phone;
            }
            //if (parameter is Contact contact)
            //{
            //    // Редактирование существующего контакта
            //    _editingContact = contact;
            //    _newContact = false;
            //    EditContactName = contact.Name;
            //    EditContactPhone = contact.Phone;
            //}
            //else
            //{
            //    // Создание нового контакта
            //    _editingContact = null;
            //    _newContact = true;
            //    EditContactName = string.Empty;
            //    EditContactPhone = string.Empty;
            //}
        }
        private void Save()
        {
            //_contact.ContactName = EditContactName;
            //_contact.ContactPhoneNum = EditContactPhone;

            //_dialogService.ShowInfo("Контакт успешно обновлён");

            //_navigationService.NavigateTo<ContactsListViewModel>();
            // Проверка на null в самом начале
            //if (_editingContact == null && !_newContact)
            //{
            //    _dialogService.ShowError("Ошибка: контакт не найден");
            //    Cancel();
            //    return;
            //}

            //try
            //{
            //    if (_newContact)
            //    {
            //        // CREATE: Новый контакт
            //        var newContact = new Contact
            //        {
            //            Name = EditContactName,
            //            Phone = EditContactPhone
            //        };

            //        _context.Contacts.Add(newContact);
            //        _context.SaveChanges();

            //        _dialogService.ShowInfo("Контакт добавлен");
            //    }
            //    else
            //    {
            //        // UPDATE: Редактирование существующего
            //        // ВАЖНО: Проверяем что _editingContact не null
            //        if (_editingContact != null)
            //        {
            //            _editingContact.Name = EditContactName;
            //            _editingContact.Phone = EditContactPhone;

            //            // Можно НЕ вызывать Entry(...).State, 
            //            // потому что объект уже отслеживается контекстом
            //            // Достаточно просто SaveChanges()
            //            _context.SaveChanges();

            //            _dialogService.ShowInfo("Contact has been updated");
            //        }
            //    }

            //    // Возвращаемся к списку
            //    _navigationService.NavigateTo<ContactsListViewModel>();
            //}
            //catch (Exception ex)
            //{
            //    _dialogService.ShowError($"Error when saving: {ex.Message}");
            //}

            // Дополнительная проверка
            if (_editingContact == null)
            {
                _dialogService.ShowError("Error: the contact was not found");
                Cancel();
                return;
            }

            if (!CanSave())
            {
                _dialogService.ShowWarning("Fill in all fields correctly");
                return;
            }

            try
            {
                // Обновляем свойства
                _editingContact.Name = EditContactName;
                _editingContact.Phone = EditContactPhone;

                // Сохраняем изменения в БД
                // (объект уже отслеживается, так как получен из того же контекста)
                _context.SaveChanges();

                _dialogService.ShowInfo("Contact has been updated");

                // Возвращаемся к списку
                _navigationService.NavigateTo<ContactsListViewModel>();
            }
            catch (Exception ex)
            {
                _dialogService.ShowError($"Error when saving: {ex.Message}");
            }
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