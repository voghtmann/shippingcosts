using System;

namespace Parcel2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n;
            int total = 0;
            string response = "";
            do
               {
               Console.Write("Please enter the size(cm) of parcel: ");

               string[] answer = new string[100];
               for (int i = 0; i < answer.Length; i++)
               {
                   answer[i] = (Console.ReadLine());
               }
               
               Console.WriteLine("Do you have another parcel to send? (y/n)");
               response = Console.ReadLine();

               } while (response != "n");

            Console.Write("Parcel {0} is: ", i);

        }
    }
}


