using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("The subtotal of your order is: £{0} ", totalCost);



                //Discounts for muliple parcels (Part 5)

                //Small  parcel discount)
                int smallDiscount = 0;
                int[] smallArray = array.Where(item => item > 0).ToArray();


                int[] everyfourth = smallArray.Where((value, index) => index % 4 == 0)
                    .ToArray();

                smallDiscount = 3 * (everyfourth.Count() -1);

                //Medium parcel discount
                int mediumDiscount = 0;
                int[] mediumArray = array.Where(item => item > 0).ToArray();


                int[] everythird = mediumArray.Where((value, index) => index % 3 == 0)
                    .ToArray();

                mediumDiscount = 8 * (everythird.Count() - 1);

                //Mixed parcel discount
                int mixedDiscount = 0;
                int[] everyfifth = array.Where((value, index) => index % 5 == 0)
                    .ToArray();
                int[] smallfifth = everyfifth.Where((value, index) => index % 3 == 0)
                    .ToArray();








                mixedDiscount = 8 * (everyfifth.Count() - 1);


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
                        if (!Char.TryParse(Console.ReadLine(), out answerOption)||(answerOption != 'y' || answerOption != 'n'))
                        {
                            Console.WriteLine("Invalid response");
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
                        //    else
                        //    {
                        //        Console.WriteLine("Invalid response. Please enter 'y' or 'n'");
                        //    }
                } while (contiune == false);
            
                Console.WriteLine("-------------");
                Console.WriteLine("The total cost for shipping your {0} parcels is £{1}", number, totalCost);

            }
            Console.ReadLine();
        }

        private static void ToArray()
        {
            throw new NotImplementedException();
        }
    }

}


