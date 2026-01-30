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
        
        private static bool _IsEmpty(Control tb)
        {
            return (tb == null || string.IsNullOrEmpty(tb.Text));
            
        }
        public static bool _IsNumber(TextBox tb)
        {
            return (_IsEmpty(tb) || !int.TryParse(tb.Text.Trim(), out int value)) ;
            
        }
        public static bool IsEmpty(ErrorProvider ep , TextBox tb , string ErrorMessage)
        {
            if(_IsEmpty(tb))
            {
                ep.SetError(tb, ErrorMessage);
                return true;
            }
            return false;
        }
        public static bool IsNumber(ErrorProvider ep, TextBox tb, string ErrorMessage)
        {
            if (!_IsNumber(tb))
            {
                ep?.SetError(tb, ErrorMessage);
                return false;
            }
            return true;
        }
        public static bool IsValidEmail(ErrorProvider ep, TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ep?.SetError(tb, "Enter a valid email.");
                return false;
            }
            return true;
        }
        public static bool IsValidPhoneNumber(ErrorProvider ep, TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^09\d{8}$"))
            {
                ep?.SetError(tb, "Enter a valid Phone Number.");
                return false;
            }
            return true;
        }
        public static bool IsValidAddress(ErrorProvider ep, TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^(?:[a-zA-Z]+|[\u0600-\u06FF]+)$") )
            {
                ep?.SetError(tb, "Enter a valid Address.");
                return false;
            }
            return true;
        }
        public static bool IsValidWord(ErrorProvider ep, TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^(?:[a-zA-Z]+|[\u0600-\u06FF]+)$"))
            {
                ep?.SetError(tb, "Enter a valid Name.");
                return false;
            }
            return true;
        }
        public static bool IsValidNationalNo(ErrorProvider ep, TextBox tb)
        {
            if (_IsEmpty(tb) || !Regex.IsMatch(tb.Text, @"^[1-2]\d{11}$"))
            {
                ep?.SetError(tb, "Enter a valid National No.");
                return false;
            }
            return true;
        }

        public static bool IsValidDateOfBirth(ErrorProvider ep, DateTimePicker dtp)
        {
            if (_IsEmpty(dtp) || clsBLHelper.CalculateAge(dtp.Value) < 18)
            {
                ep?.SetError(dtp, "Enter a valid Date.");
                return false;
            }
            return true;
        }
    }
}
