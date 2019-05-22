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
            int cost = 0;
            int totalCost = 0;
            
            Console.WriteLine("Enter the number of parcels you would like to send: ");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                int[] array = new int[number + 1];
                for (int i = 1; i < number + 1; i++)
                {
                    Console.WriteLine("Enter size of parcel {0} in (Centremetres). ",
                        i.ToString(), (number - (i)).ToString());

                    int indexNumber = 0;
                    int weight = 0;

                    if (int.TryParse(Console.ReadLine(), out indexNumber))
                    {
                        array[i] = indexNumber;
                        if (indexNumber >= 100)
                        {
                            Console.WriteLine("Enter weight of parcel {0} in (Kg). ",
                            i.ToString(), (number - (i)).ToString());
                            if (int.TryParse(Console.ReadLine(), out weight))
                            {
                                result = "XL";
                                if (weight >= 50)
                                {
                                    cost = 50 + (weight - 50);
                                    result = "Heavy";
                                }
                                else if (weight > 10)
                                {
                                    cost = 25 + ((weight - 10) *2);  
                                }
                                else
                                {
                                    cost = 25;
                                }  
                            }
                        }
                        else if (indexNumber >= 50)
                        {
                            Console.WriteLine("Enter weight of parcel {0} in (Kg). ",
                            i.ToString(), (number - (i)).ToString());
                            if (int.TryParse(Console.ReadLine(), out weight))
                            {
                                result = "Large";
                                if (weight >= 50)
                                {
                                    cost = 50 + (weight - 50);//Part 4 - Cost == Weight
                                    result = "Heavy";
                                }
                                else if (weight > 6)
                                {
                                    cost = 15 + ((weight - 6) * 2);
                                }
                                
                            
                                else
                                {
                                    cost = 15;
                                }
                            }
                        }
                        else if (indexNumber >= 10)
                        {
                            Console.WriteLine("Enter weight of parcel {0} in (Kg). ",
                            i.ToString(), (number - (i)).ToString());
                            if (int.TryParse(Console.ReadLine(), out weight))
                            {
                                result = "Medium";
                                if (weight >= 50)
                                {
                                    cost = 50 + (weight - 50);
                                    result = "Heavy";
                                }
                                else if (weight > 3)
                                {
                                    cost = 8 + ((weight - 3) * 2);
                                }
                                if (weight > 50)
                                {
                                    cost = 50 + (weight - 50);
                                }
                                else
                                {
                                    cost = 8;
                                }
                            }
                        }
                        else if (indexNumber > 0)
                        {
                            Console.WriteLine("Enter weight of parcel {0} in (Kg). ",
                            i.ToString(), (number - (i)).ToString());
                            if (int.TryParse(Console.ReadLine(), out weight))
                            {
                                result = "Small";
                                if (weight >= 50)
                                {
                                    cost = 50 + (weight - 50);
                                    result = "Heavy";
                                }
                                else if (weight > 1)
                                {
                                    cost = 3 + ((weight - 1) * 2);
                                }
                                if (weight > 50)
                                {
                                    cost = 50 + (weight - 50);
                                }
                                else
                                {
                                    cost = 3;
                                }
                            }
                        }
                        else
                        {
                            result = "size cannot be negative";
                        }

                        

                        Console.WriteLine("Parcel {0} belongs to the {1} " +
                                                         "category with a shipping cost of £{2}  ", number, result, cost);
                    }
                    totalCost = totalCost += cost;
                };
                int response = 0;
                //Part 3 - This doubles the totalCost
                Console.WriteLine("Would you like to use our Speedy shipping service? Press 1 for Yes, 0 for No");

                if (int.TryParse(Console.ReadLine(), out response))
                {
                    if (response == 1)
                    {
                        totalCost = totalCost * 2;
                    }

                };

                    Console.WriteLine("-------------");
                Console.WriteLine("The total cost for shipping your {0} parcels is £{1}", number, totalCost);

            }
            Console.ReadLine();
        }

    }



}


