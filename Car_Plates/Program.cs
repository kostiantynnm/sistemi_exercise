using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Plates
{
    internal class Program //Naftulovych Kostiantyn
    {
        static void Main()
        {
            Console.Write("Enter an Italian car plate number (example: AA111CC ): ");
            string plateInput = Console.ReadLine();

                    // Check if the entered string has the correct format
            if (IsValidCarNumber(plateInput))
            {
                        // Format the car number
                string Plate = FormatCarNumber(plateInput);
                //Console.WriteLine("Formatted number: " + Plate);

                        // Convert the formatted number into an array of integers
                int[] PlateInt = ConvertToNumber(Plate);

                        // Calculate the position of the car number
                Console.WriteLine("Position: " + Multiplication(PlateInt));
            }
            else
            {
                Console.WriteLine("Entered number does not match the Italian car plate format (example: AA111CC ).");
            }
            Console.ReadLine();
        }

                // Check if the input string has a valid Italian car plate format
        static bool IsValidCarNumber(string input)
        {
            if (input.Length != 7)
                return false;

            for (int i = 0; i < 7; i++)
            {
                if ((i < 2 || (i > 4 && i < 7)) && !char.IsLetter(input[i]))
                {
                    return false;
                }
                else if ((i == 2 || i == 3 || i == 4) && !char.IsDigit(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

                // Format the car number by rearranging letters and digits
        static string FormatCarNumber(string input)
        {
            string Number = input.Substring(0, 2) + input.Substring(5, 2) + input.Substring(2, 3);
            return Number;
        }

                // Convert letters and digits in the formatted number into integers
        static int[] ConvertToNumber(string input)
        {
            int[] output = new int[input.Length];

            for (int i = 0; i < output.Length; i++)
            {
                char letter = input[i];
                if (Char.IsLetter(letter))
                {
                    int position = Char.ToUpper(letter) - 'A';
                    output[i] = position;
                }
                else
                {
                    int number = input[i] - '1' + 1;
                    output[i] = number;
                }
            }

                    // Display the converted array
            //for (int i = 0; i < output.Length; i++)
            //{
            //    Console.Write(output[i] + " ");
            //}
            //Console.WriteLine();
            return output;
        }

                // Calculate the position of the car number
        static int Multiplication(int[] plate)
        {
            Array.Reverse(plate);
            double result = 0;

            for (int i = 0; i < 4; i++)
            {
                result += plate[i] * Math.Pow(10, i);
            }
            for (int i = 4; i < 7; i++)
            {
                result += plate[i] * Math.Pow(10, 3) * Math.Pow(26, i - 3);
            }
            return Convert.ToInt32(result);
        }
    }
}
