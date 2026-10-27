
using Collections.src;

namespace Collections;

internal class Program
{
    static void Main(string[] args)
    {
        // Dictionary
        Console.WriteLine("Dictionary ::");

        Dictionary<string, int> dict = new Dictionary<string, int>();

        dict.Add("one", 1);
        dict.Add("ten", 10);
        dict.Add("four", 4);

        foreach (var item in dict)
        {
            Console.WriteLine(item);
        }

        // IReadOnlyDictionary
        Console.WriteLine("\nIReadOnlyDictionary ::");

        IReadOnlyDictionary<string, int> readOnlyDict =
            new Dictionary<string, int>
            {
                { "one", 1 },
                { "ten", 10 },
                { "four", 4 }
            };

        foreach (var item in readOnlyDict)
        {
            Console.WriteLine(item);
        }

        // SortedDictionary: sort elements by key
        Console.WriteLine("\nSortedDictionary ::");

        SortedDictionary<int, string> sortedDict =
            new SortedDictionary<int, string>();

        sortedDict.Add(9, "nine");
        sortedDict.Add(11, "eleven");
        sortedDict.Add(0, "zero");

        foreach (var item in sortedDict)
        {
            Console.WriteLine(item);
        }

        // Extension Methods: Egyptian Phone
        Console.WriteLine("\nEgyptian Phone Validation ::");
        Console.Write("Enter phone number: ");

        string phone = Console.ReadLine() ?? "";

        if (phone.IsValidEgyptianPhone())
        {
            Console.WriteLine("Valid Egyptian phone number.");
        }
        else
        {
            Console.WriteLine(GetPhoneError(phone));
        }

        // Extension Methods: Egyptian National ID
        Console.WriteLine("\nEgyptian National ID Validation ::");
        Console.Write("Enter national ID: ");

        string nationalId = Console.ReadLine() ?? "";

        if (nationalId.IsValidEgyptianNationalId())
        {
            Console.WriteLine("Valid Egyptian national ID.");
        }
        else
        {
            Console.WriteLine(GetNationalIdError(nationalId));
        }
    }

    static string GetPhoneError(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return "Invalid: Phone number cannot be empty.";

        bool isInternational = phone.StartsWith("+20");
        string digits = isInternational ? phone.Substring(3) : phone;

        if (digits.Any(char.IsLetter))
            return "Invalid: Phone number contains a letter.";

        if (digits.Any(c => !char.IsDigit(c)))
            return "Invalid: Phone number contains invalid characters.";

        if (isInternational && digits.Length != 10)
            return $"Invalid: Expected 10 digits after +20, but found {digits.Length} digits.";

        if (!isInternational && digits.Length != 11)
            return $"Invalid: Expected 11 digits, but found {digits.Length} digits.";

        string prefix = isInternational
            ? digits.Substring(0, 2)
            : digits.Substring(0, 3);

        bool validPrefix = isInternational
            ? prefix == "10" || prefix == "11" ||
              prefix == "12" || prefix == "15"
            : prefix == "010" || prefix == "011" ||
              prefix == "012" || prefix == "015";

        if (!validPrefix)
            return $"Invalid: {prefix} is not a valid Egyptian mobile prefix.";

        return "Invalid phone number.";
    }

    static string GetNationalIdError(string nationalId)
    {
        if (string.IsNullOrWhiteSpace(nationalId))
            return "Invalid: National ID cannot be empty.";

        if (nationalId.Any(c => !char.IsDigit(c)))
            return "Invalid: National ID must contain digits only.";

        if (nationalId.Length != 14)
            return $"Invalid: Expected 14 digits, but found {nationalId.Length} digits.";

        if (nationalId[0] != '2' && nationalId[0] != '3')
            return "Invalid: National ID must start with 2 or 3.";

        return "Invalid national ID.";
    }
}
