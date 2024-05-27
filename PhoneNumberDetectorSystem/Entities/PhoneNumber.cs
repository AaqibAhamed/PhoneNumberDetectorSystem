using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberDetectorSystem.Entities
{
    public class PhoneNumber
    {
        public string PhoneNumberInDigit { get; set; }
        public string Language { get; set; }
        public string Format { get; set; }

        //public string HindiPhoneNumber { get; set; }

        public PhoneNumber(string input, string language, string phoneNumberinDigit)
        {
            PhoneNumberInDigit = phoneNumberinDigit;
            Language = language;

            // EnglishPhoneNumber = englishPhoneNumber;
            //  HindiPhoneNumber = hindiPhoneNumber;

            // Determine the format of the phone number
            if (input.StartsWith('+'))
            {
                Format = "Numbers with country codes";
            }
            else if (input.StartsWith('('))
            {
                Format = "Numbers with parentheses for area codes";
            }
            else if (input.Any(c => Char.IsLetter(c)))
            {
                Format = "Numbers given in letters ";
            }
            else if (input.Contains('-'))
            {
                Format = "10-digit numbers with dashes as separators";

            }
            else if (input.Contains(' '))
            {
                Format = "10-digit numbers with spaces as separators";

            }
            else
            {
                Format = "10-digit numbers";
            }
        }
    }
}
