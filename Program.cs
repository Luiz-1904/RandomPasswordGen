using System;
using System.Text;

class PasswordGenerator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Password Generator!");


        Console.Write("Enter the desired password length: ");
        int passwordLength;
        while (!int.TryParse(Console.ReadLine(), out passwordLength) || passwordLength <= 0)
        {
            Console.WriteLine("Please enter a valid number greater than zero.");
        }


        Console.Write("Include uppercase letters? (y/n): ");
        bool includeUppercase = Console.ReadLine()?.Trim().ToLower() == "y";

        Console.Write("Include lowercase letters? (y/n): ");
        bool includeLowercase = Console.ReadLine()?.Trim().ToLower() == "y";

        Console.Write("Include numbers? (y/n): ");
        bool includeNumbers = Console.ReadLine()?.Trim().ToLower() == "y";

        Console.Write("Include symbols? (y/n): ");
        bool includeSymbols = Console.ReadLine()?.Trim().ToLower() == "y";


        string password = GeneratePassword(passwordLength, includeUppercase, includeLowercase, includeNumbers, includeSymbols);


        Console.WriteLine($"\nGenerated Password: {password}");
    }

    static string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSymbols)
    {

        const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        const string numbers = "0123456789";
        const string symbols = "!@#$%^&*()_-+=<>?";


        StringBuilder characterSet = new StringBuilder();
        if (includeUppercase) characterSet.Append(uppercase);
        if (includeLowercase) characterSet.Append(lowercase);
        if (includeNumbers) characterSet.Append(numbers);
        if (includeSymbols) characterSet.Append(symbols);


        if (characterSet.Length == 0)
        {
            throw new ArgumentException("You must select at least one character type!");
        }


        StringBuilder password = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(characterSet.Length);
            password.Append(characterSet[index]);
        }

        return password.ToString();
    }
}
