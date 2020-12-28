using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValidPassword = IsBetween6and10Chars(password) && IsLetersAndDigits(password) && Atleast2Digits(password);

            if (isValidPassword)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!IsBetween6and10Chars(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!IsLetersAndDigits(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!Atleast2Digits(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }

        }

        static bool IsBetween6and10Chars(string password)
        {
            int passLength = password.Length;
            if (passLength >= 6 && passLength <= 10)
            {
                return true;
            }
            return false;
        }

        static bool IsLetersAndDigits(string password)
        {
            int wrongChar = 0;
            foreach (char c in password)
            {
                
                if (!char.IsLetterOrDigit(c))
                {
                    wrongChar++;
                    if (wrongChar >= 1)
                    {
                        return false;
                    }
                }
                
            }
           
            return true;
        }

        static bool Atleast2Digits(string password)
        {
            int digits = 0;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    digits++;
                    if (digits >= 2)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
