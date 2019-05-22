using System;
using System.Collections.Generic;
using System.Linq;

namespace Parcel3
{
    class Program
    {
        static bool again = true;

        static void Main(string[] args)
        {
            while (again)
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

                        string input = Console.ReadLine();
                        int indexNumber = 0;
                        int weight = 0;

                        if (!int.TryParse(input, out indexNumber))
                        {
                            Console.WriteLine("Your entry must be an intger");
                        }
                        else
                        {
                            Console.WriteLine("");
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
                                        cost = 25 + ((weight - 10) * 2);
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

                            Console.WriteLine("This parcel belongs to the {1} " +
                                                             "category with a shipping cost of £{2}  ", number, result, cost);
                        }
                        totalCost = totalCost += cost;
                    };
                    Console.WriteLine("The subtotal of your order is: £{0} ", totalCost);


                    //Discounts for muliple parcels (Part 5)

                    //Small  parcel discount)
                    int smallDiscount = 0;
                    int[] smallArray = array.Where(item => item > 0).ToArray();


                    int[] everyfourth = smallArray.Where((value, index) => index % 4 == 0)
                        .ToArray();

                    smallDiscount = 3 * Math.Max(0, 3 * (everyfourth.Count() - 1));

                    //Medium parcel discount
                    int mediumDiscount = 0;
                    int[] mediumArray = array.Where(item => item > 0).ToArray();


                    int[] everythird = mediumArray.Where((value, index) => index % 3 == 0)
                        .ToArray();

                    mediumDiscount = Math.Max(0, 8 * (everythird.Count() - 1));

                    //Mixed parcel discount
                    int mixedDiscount = 0;
                    int smallMixer = 0;
                    int mediumMixer = 0;
                    int largeMixer = 0;
                    int XLMixer = 0;

                    int[] everyfifth = array.Where((value, index) => index % 5 == 0)
                        .ToArray();

                    int[] smallMix = everyfifth.Where(item => item > 0 && item <= 10).ToArray();
                    smallMixer = Math.Max(0, 3 * (smallMix.Count() - 1));

                    int[] mediumMix = everyfifth.Where(item => item > 10 && item < 50).ToArray();
                    mediumMixer = Math.Max(0, 8 * (mediumMix.Count() - 1));

                    int[] largeMix = everyfifth.Where(item => item > 50 && item < 100).ToArray();
                    largeMixer = Math.Max(0, 15 * (largeMix.Count() - 1));

                    int[] XLMix = everyfifth.Where(item => item > 100).ToArray();
                    XLMixer = Math.Max(0, 25 * XLMix.Count() - 1);

                    mixedDiscount = smallMixer + mediumMixer + largeMixer + XLMixer;


                    //Console.WriteLine("The mixed discount is " + mixedDiscount);
                    //Console.WriteLine("The smallDiscount discount is " + smallDiscount);
                    //Console.WriteLine("The mediumDiscount discount is " + mediumDiscount);

                    //Finding the cheap combination
                    int subDiscount = Math.Max(smallDiscount, mediumDiscount);
                    int discount = Math.Max(subDiscount, mixedDiscount);

                    totalCost = totalCost - discount;

                    //Display discount
                    Console.WriteLine("The discount on your order reduces your subtotal by £{0} to: £{1}", discount, totalCost);


                    //Part 3 - This doubles the totalCost
                    Console.WriteLine("Would you like to use our Speedy shipping service?");


                    bool contiune = false;

                    do
                    {
                        Console.WriteLine("Enter 'y' for Yes, 'n' for No");
                        char answerOption;
                        if (!Char.TryParse(Console.ReadLine(), out answerOption) || (answerOption != 'y' || answerOption != 'n'))
                        {
                            Console.WriteLine("");
                        }

                        //char answerOption = Convert.ToChar(Console.ReadLine());

                        if (answerOption == 'y' || answerOption == 'n')
                        {
                            contiune = true;
                            switch (answerOption)
                            {
                                case 'y': totalCost = totalCost * 2; break;
                                case 'n': totalCost = totalCost * 1; ; break;//Unchanged
                            }
                        }

                    } while (contiune == false);

                    Console.WriteLine("-------------");
                    Console.WriteLine("The total cost for shipping your {0} parcel(s) is £{1}", number, totalCost);
                    Console.WriteLine("-------------");
                    Console.WriteLine("Enter any key to place a new order or 'q' to quit");
                    ConsoleKeyInfo cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Q)
                        again = false;
                }
                Console.ReadLine();
    
            }
            
        }

    }
}





