using PhoneNumberDetectorSystem.Entities;
using PhoneNumberDetectorSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberDetectorTests
{
    public class PhoneNumberDetectorTests
    {

        [Fact]
        public void Detect_PhoneNumbers_Count()
        {
            // Arrange
            string inputText = "+1-123-456-7890";
            PhoneNumberDetector phoneNumberDetection = new PhoneNumberDetector();

            // Act
            List<PhoneNumber> detectedPhoneNumbers = phoneNumberDetection.DetectPhoneNumbers(inputText);

            // Assert
            Assert.True(detectedPhoneNumbers.Count > 0);
        }

        [Fact]
        public void Detect_PhoneNumbers_WithCountryCodes()
        {
            // Arrange
            string input = "+1-123-456-7890";
            string expected = "123-456-7890";
            PhoneNumberDetector phoneNumberDetection = new PhoneNumberDetector();

            // Act
            List<PhoneNumber> result = phoneNumberDetection.DetectPhoneNumbers(input);

            // Assert
            Assert.Equal(expected, result[0].PhoneNumberInDigit);
        }
        [Fact]
        public void Detect_PhoneNumbers_InHindi()
        {
            // Arrange
            string input = "शून्य शू एक दो तीन चार पांच छह सात आठ नौ शू ";
            string expected = "0123456789";
            PhoneNumberDetector phoneNumberDetection = new PhoneNumberDetector();

            // Act
            List<PhoneNumber> result = phoneNumberDetection.DetectPhoneNumbers(input);

            // Assert
            Assert.Equal(expected, result[0].PhoneNumberInDigit);
        }


    }
}
