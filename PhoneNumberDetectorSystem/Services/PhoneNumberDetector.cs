using PhoneNumberDetectorSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneNumberDetectorSystem.Services
{
    public class PhoneNumberDetector : IPhoneNumbersDetector
    {
        readonly Converter converter = new Converter();
      
        private readonly string[] _phoneNumberFormats = new string[]
        {
            @"(\d{3}-\d{3}-\d{4})", // 10-digit numbers with dashes
            @"(\+\d{1,2}-\d{3}-\d{3}-\d{4})", // Numbers with country codes
            @"(\(\d{3}\) \d{3}-\d{4})", // Numbers with parentheses for area codes
            @"(\d{3} \d{3} \d{4})", // Numbers with spaces as separators
            @"(\d{10})", // 10-digit numbers
            @"(\+\d{1,2}\d{10})", // Numbers with country codes
            @"(\(\d{3}\) \d{3} \d{4})", // Numbers with parentheses for area codes
            @"\b(?:\D|ZERO|ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|शू|एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ|zero|one|two|three|four|five|six|seven|eight|nine){10,}\b",
           // @"\b(?:\D|ZERO|ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|zero|one|two|three|four|five|six|seven|eight|nine){10,}\b",
           // @"\b(?:\D|ZERO|ONE|TWO|THREE|FOUR|FIVE|SIX|SEVEN|EIGHT|NINE|शू|एक|दो|तीन|चार|पांच|छह|सात|आठ|नौ){10,}\b",

        };

        public List<PhoneNumber> DetectPhoneNumbers(string inputText)
        {
            List<PhoneNumber> detectedPhoneNumbers = new List<PhoneNumber>();

            foreach (string format in _phoneNumberFormats)
            {
                Match match = Regex.Match(inputText, format, RegexOptions.IgnoreCase);

                while (match.Success)
                {
                    string phoneNumber = match.Value.Trim();

                    // Convert words to numbers for comparison
                    var (phoneNumberinDigit, language) = converter.ConvertWordsToNumbers(phoneNumber);


                    if (phoneNumberinDigit != null)
                    {
                        detectedPhoneNumbers.Add(new PhoneNumber(inputText, language, phoneNumberinDigit));
                    }

                    else
                    {
                        detectedPhoneNumbers.Add(new PhoneNumber(inputText, language, ""));
                    }

                    match = match.NextMatch();
                }
            }

            return detectedPhoneNumbers;
        }

    }
}
