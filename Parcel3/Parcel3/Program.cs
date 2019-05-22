using System;
using System.Collections.Generic;

namespace Parcel3
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            int number = 0;
            Console.WriteLine("Enter the number of parcels you would like to send: ");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                int[] array = new int[number + 1];
                for (int i = 1; i < number + 1; i++)
                {
                    Console.WriteLine("Enter a size for parcel {0} in (cm). ",
                        i.ToString(), (number - (i)).ToString());
                    Console.WriteLine("Enter a weigth for parcel {0} in (kg). ",
                        i.ToString(), (number - (i)).ToString());

                    int indexNumber = 0;
                    int weight = 0;

                    if (int.TryParse(Console.ReadLine(), out indexNumber))
                    {
                        array[i] = indexNumber;
                        if (indexNumber >= 100)
                        {
                            result = "XL";
                        }
                        else if (indexNumber >= 50)
                        {
                            result = "Large";
                        }
                        else if (indexNumber >= 10)
                        {
                            result = "Medium";
                        }
                        else if (indexNumber > 0)
                        {
                            result = "Small";
                        }
                        else
                        {
                            result = "size cannot be negative";
                        }

                        Console.WriteLine(result);
                        
                    }
                };

                Console.WriteLine("-------------");
                Console.WriteLine("Here is the total cost for shipping your {0} parcels", number);
                //foreach (int item in array)
                //    Console.WriteLine("Parcel {0} is {1}cm and belongs in the {2} category with shipping cost of £{3} ",number, item, cat, cost);
            }
            Console.ReadLine();

        }
    }
}


