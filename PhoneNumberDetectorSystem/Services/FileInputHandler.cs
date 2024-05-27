using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberDetectorSystem.Services
{
    public class FileInputHandler : IFileInputHandler
    {
        public List<string> ReadPhoneNumbersFromFile(string filePath)
        {
            List<string> phoneNumbers = new List<string>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] numbers = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string number in numbers)
                    {
                        phoneNumbers.Add(number);
                        //if (number.Length == 10 && number.All(c => char.IsDigit(c)))
                        //{
                        //    phoneNumbers.Add(number);
                        //}
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            return phoneNumbers;
        }
    }
}
