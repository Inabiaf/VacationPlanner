/*  George Fox
    7/17/2018
    Assignment 4
*/
using System;

namespace Assignment4
{
    class VacationPlanner
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will help you plan your vacation!");
            Console.WriteLine("First, you will input the number of places you would like to go,");
            Console.WriteLine("then input information about each.");
            Console.WriteLine("");
            int Venues = AskForVenues();

            Vacation[] Venue = new Vacation[Venues];

            for (int i = 0; i < Venues; i++)
            {
                Console.WriteLine("Venue #{0}", i + 1);

                Venue[i] = new Vacation();
                Venue[i].LocationName = AskForLocationName();
                Venue[i].LocationAddress = AskForLocationAddress(Venue[i].LocationName);
                Venue[i].Memo = AskForMemo(Venue[i].LocationName);
                Venue[i].ArrivalDate = AskForArrivalDate(Venue[i].LocationName);
                Venue[i].DepartureDate = AskForDepartureDate(Venue[i].LocationName);
                Venue[i].ExpectedCost = AskForExpectedCost();

                Console.WriteLine("");
            }

            String inputWhatNow;
            int d;

            Console.Write("Type A to add more venues, or enter the venue number to display it's information");
            inputWhatNow = Console.ReadLine();
            if (int.TryParse(inputWhatNow, out d))
            {
                d = d - 1;
                Console.WriteLine(Venue[d].ToString());
            }
            //if (inputWhatNow.Equals("A" or "a","add","Add"))
            int newVenues = AskForVenues();
            Array.Resize(ref Venue, Venue.Length + newVenues);

        }

        public static int AskForVenues()
        {
            string inValue;
            int Venues;
            Console.WriteLine("How many venues would you like to plan for? ");
            inValue = Console.ReadLine();
            if (int.TryParse(inValue, out Venues))
            {
                return Venues;
            }
            Console.Write("Please enter an integer amount\n");
            Venues = AskForVenues();
            return Venues;
        }

        public static double AskForExpectedCost()
        {
            string inValue;
            double theExpectedCost;
            Console.Write("Enter Expected Cost: ");
            inValue = Console.ReadLine();
            if (double.TryParse(inValue, out theExpectedCost))
            {
                return theExpectedCost;
            }
            Console.Write("Please enter a numeric amount in USD\n");
            AskForExpectedCost();
            return theExpectedCost;

        }

        public static string AskForLocationName()
        {
            string inValue;
            Console.Write("Enter Location Name: ");
            inValue = Console.ReadLine();
            return inValue;
        }
        public static string AskForLocationAddress(string name)
        {
            string inValue;
            Console.Write("Enter the adress of {0}: ", name);
            inValue = Console.ReadLine();
            return inValue;
        }
        public static string AskForMemo(string name)
        {
            string inValue;
            Console.Write("What will you be doing at {0}? ", name);
            inValue = Console.ReadLine();
            return inValue;
        }
        public static string AskForArrivalDate(string name)
        {
            string inValue;
            Console.Write("Enter arrival date at {0}: ", name);
            inValue = Console.ReadLine();
            return inValue;
        }
        public static string AskForDepartureDate(string name)
        {
            string inValue;
            Console.Write("Enter departure date from {0}: ", name);
            inValue = Console.ReadLine();
            return inValue;
        }
    }
}
