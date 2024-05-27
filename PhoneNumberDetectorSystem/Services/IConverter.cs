﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberDetectorSystem.Services
{
    public interface IConverter
    {
        (string, string) ConvertWordsToNumbers(string phoneNumber);
    }
}
