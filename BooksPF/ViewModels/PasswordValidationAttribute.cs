using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksPF.ViewModels
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        private HashSet<char> allowedCharsHash;
        public override bool IsValid(object value)
        {
            string s = value.ToString();
            if (s.Length > 15)
            {
                this.ErrorMessage = "Password must be no longer than 15 characters.";
                return false;
            }
            if (s.Length < 4)
            {
                this.ErrorMessage = "Password must be at least 4 characters.";
                return false;
            }
            HashSet<char> inputString = new HashSet<char>(s.ToCharArray());
            if (!inputString.IsSubsetOf(allowedCharsHash))
            {
                this.ErrorMessage = "Unacceptable symbols in password.";
                return false;
            }
            return true;
        }

        public PasswordValidationAttribute()
        {
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890._-";
            allowedCharsHash = new HashSet<char>(allowedCharacters.ToCharArray());
        }
    }
}
