using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberDetectorSystem.Services
{
    public class Converter : IConverter
    {
        private Dictionary<string, string> _englishNumberMap = new Dictionary<string, string>
        {
            {"zero", "0"},
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"},
            { "ZERO", "0" }, { "ONE", "1" }, { "TWO", "2" }, { "THREE", "3" },
            { "FOUR", "4" }, { "FIVE", "5" }, { "SIX", "6" }, { "SEVEN", "7" },
            { "EIGHT", "8" }, { "NINE", "9" }
        };

        private Dictionary<string, string> _hindiNumberMap = new Dictionary<string, string>
        {
            {"एक", "1"},
            {"दो", "2"},
            {"तीन", "3"},
            {"चार", "4"},
            {"पांच", "5"},
            {"छह", "6"},
            {"सात", "7"},
            {"आठ", "8"},
            {"नौ", "9"},
            {"शून्य", "0"}
        };

        public (string, string) ConvertWordsToNumbers(string phoneNumber)
        {
            string? englishPhoneNumber = null;
            string? hindiPhoneNumber = null;
            string language = "";

            foreach (string word in phoneNumber.Split(' '))
            {
                if (_englishNumberMap.ContainsKey(word))
                {
                    englishPhoneNumber += _englishNumberMap[word];
                    language = "English";
                }
                else if (_hindiNumberMap.ContainsKey(word))
                {
                    hindiPhoneNumber += _hindiNumberMap[word];
                    language = "Hindi";
                }
            }

            if (englishPhoneNumber != null)
            {
                return (englishPhoneNumber, language);
            }
            else if (hindiPhoneNumber != null)
            {
                return (hindiPhoneNumber, language);
            }
            else
            {
                return (phoneNumber, "");
            }
        }
    }
}
