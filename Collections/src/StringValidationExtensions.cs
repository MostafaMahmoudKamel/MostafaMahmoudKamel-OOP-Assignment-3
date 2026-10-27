using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Collections.src;

public static class StringValidationExtensions
{
    //regex email 
    public static bool IsValidEgyptianPhone(this string phone)
    {
        string pattern = @"^(?:(?:010|011|012|015)\d{8}|\+20(?:10|11|12|15)\d{8})$";

        return !string.IsNullOrWhiteSpace(pattern) &&
            Regex.IsMatch(phone, pattern);
    }

    public static bool IsValidEgyptianNationalId(this string nationalId)
    {
        return !string.IsNullOrEmpty(nationalId) &&
          Regex.IsMatch(nationalId, @"^[23]\d{13}$");
    }
}
