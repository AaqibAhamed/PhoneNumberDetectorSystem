using PhoneNumberDetectorSystem.Entities;
using PhoneNumberDetectorSystem.Services;

namespace PhoneNumberDetectorSystem
{
    //IInputHandler inputHandler = new InputHandler();
    //IInputHandler fileInputHandler = new FileInputHandler("");
    //IOutputFormatter outputFormatter = new OutputFormatter();

    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Press 1 for Manual Input ");
                Console.WriteLine("Press 2 for Input from a File");

                string? option = Console.ReadLine();

                PhoneNumberDetector phoneNumberDetector = new PhoneNumberDetector();

                PhoneNumberFormatter phoneNumberFormatter = new PhoneNumberFormatter();

                PhoneNumberOutput phoneNumberOutput = new PhoneNumberOutput();


                if (option == "1")
                {
                    Console.WriteLine("Enter your input:");
                    string? input = Console.ReadLine();

                    Console.WriteLine("User Input " + input);

                    List<PhoneNumber> detectedNumbers = phoneNumberDetector.DetectPhoneNumbers(input ?? "");

                    Console.WriteLine("Detected Phone Numbers Count " + detectedNumbers.Count());

                    var output = phoneNumberFormatter.FormatPhoneNumbers(detectedNumbers);

                    phoneNumberOutput.DisplayOutput(output);
                }


                else if (option == "2")
                {
                   
                    //provide correct filePath if you are reading from different file
                    string filePath = "phoneNumbers.txt";

                    FileInputHandler reader = new FileInputHandler();
                    
                    List<string> phoneNumbers = reader.ReadPhoneNumbersFromFile(filePath);

                    foreach (string phoneNumber in phoneNumbers)
                    {
                        Console.WriteLine("User Input " + phoneNumber);

                        List<PhoneNumber> detectedNumbers = phoneNumberDetector.DetectPhoneNumbers(phoneNumber);

                        var output = phoneNumberFormatter.FormatPhoneNumbers(detectedNumbers);

                        phoneNumberOutput.DisplayOutput(output);

                    }


                }

                else
                {
                    Console.WriteLine("Invalid Input. Try again !");
                }

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                ErrorHandler.Handle(ex);
            }
        }
    }
}