using laba9.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace laba9.Models
{
    public class ContactModel : ObservableObject // Model
    {
        private string _contactName = string.Empty;
        private string _contactPhoneNum = string.Empty;

        public string ContactName
        {
            get { return _contactName; }
            set => Set(ref _contactName, value);
        }
        // (\+380\d{2})?\-?(\d{3}\-\d{2}\-\d{2}) - + 380ХХ-ХХХ-ХХ-ХХ
        // (\+7\d{10})? - +7XXXXXXXXXX
        public string ContactPhoneNum
        {
            get { return _contactPhoneNum; }
            set => Set(ref _contactPhoneNum, value);
        }
        public ContactModel(string name, string phone)
        {
            if (!Validate(name, phone))
            {
                throw new ArgumentException("Incorrect contact data");
            }

            _contactName = name;
            _contactPhoneNum = phone;
        }
        public static bool Validate(string name, string phoneNum)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNum) || !Regex.IsMatch(phoneNum, @"^(\+7\d{10}|\d{10})$"))
            {               
                return false;
            }

            return true;
        }
    }
}
