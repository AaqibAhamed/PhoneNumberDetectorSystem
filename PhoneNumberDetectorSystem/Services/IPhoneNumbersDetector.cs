using PhoneNumberDetectorSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberDetectorSystem.Services
{
    public interface IPhoneNumbersDetector
    {
        List<PhoneNumber> DetectPhoneNumbers(string input);
    }
}
