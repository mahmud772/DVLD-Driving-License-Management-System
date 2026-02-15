using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{
    public static class clsValidation
    {
        public static ErrorProvider ep { get; } = new ErrorProvider()
        {
            BlinkStyle = ErrorBlinkStyle.NeverBlink
        };

        private static bool _IsEmpty(Control tb)
        {
            return (tb == null || string.IsNullOrEmpty(tb.Text));
            
        }
        public static bool _IsNumber(TextBox tb)
        {
            return (_IsEmpty(tb) || !int.TryParse(tb.Text.Trim(), out int value)) ;
            
        }
        public static bool IsEmpty(TextBox tb , string ErrorMessage)
        {
            if(_IsEmpty(tb))
            {
                ep.SetError(tb, ErrorMessage);
                return true;
            }
            return false;
        }
        public static bool IsNumber(TextBox tb, string ErrorMessage)
        {
            if (!_IsNumber(tb))
            {
                ep?.SetError(tb, ErrorMessage);
                return false;
            }
            return true;
        }
        public static bool IsValidEmail(TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ep?.SetError(tb, "Enter a valid email.");
                return false;
            }
            return true;
        }
        public static bool IsValidPhoneNumber(TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^09\d{8}$"))
            {
                ep?.SetError(tb, "Enter a valid Phone Number.");
                return false;
            }
            return true;
        }
        public static bool IsValidAddress(TextBox tb)
        {
            string pattern = @"^[a-zA-Z\u0600-\u06FF\s,]+$";

            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, pattern))
            {
                ep?.SetError(tb, "Enter a valid Address (Letters, spaces, and commas only).");
                return false;
            }
            return true;
        }
        public static bool IsValidWord(TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^(?:[a-zA-Z]+|[\u0600-\u06FF]+)$"))
            {
                ep?.SetError(tb, "Enter a valid Name.");
                return false;
            }
            return true;
        }
        public static bool IsValidWord(TextBox tb , string ErrorMessage)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^(?:[a-zA-Z]+|[\u0600-\u06FF]+)$"))
            {
                ep?.SetError(tb, ErrorMessage);
                return false;
            }
            return true;
        }

        public static bool IsValidNationalNo(TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^[1-2]\d{11}$"))
            {
                ep?.SetError(tb, "Enter a valid National No.");
                return false;
            }
            return true;
        }

        public static bool IsValidDateOfBirth(DateTimePicker dtp)
        {
            if (_IsEmpty(dtp) || clsUtil.CalculateAge(dtp.Value) < 18)
            {
                ep?.SetError(dtp, "Enter a valid Date.");
                return false;
            }
            return true;
        }
        public static bool IsValidUserName(TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^[A-Za-z][A-Za-z0-9]{0,29}$"))
            {
                ep?.SetError(tb, "Enter a valid User Name.");
                return false;
            }
            return true;
        }

        public static bool IsValidPassword(TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^\S{8,}$"))
            {
                ep?.SetError(tb, "Enter a valid User Name.");
                return false;
            }
            return true;
        }
    }
}
