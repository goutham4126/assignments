using System.Text.RegularExpressions;

namespace Requirement_3
{
    public class Program
    {
        // Method to validate the registration number of a vehicle
        static bool ValidateRegistrationNumber(string registrationNo)
        {
            if (string.IsNullOrWhiteSpace(registrationNo))
                return false;

            string[] details = registrationNo.Split(' ');
            int number = Convert.ToInt32(details[details.Length - 1]);

            if (number == 0)
                return false;
            string pattern = @"^[A-Z]{2}\s[0-9]{1,2}(?:\s[A-Z]{1,2})?\s[0-9]{1,4}$";

            return Regex.IsMatch(registrationNo, pattern);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the registration number of the vehicle :");

            try
            {
                string registrationNumber = Console.ReadLine();

                // Check if the entered registration number is valid or not
                if (ValidateRegistrationNumber(registrationNumber))
                {
                    Console.WriteLine("Registration number is valid");
                }
                else
                {
                    Console.WriteLine("Registration number is invalid");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid registration number.");
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Input cannot be null. Please enter a valid registration number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }
    }
}
