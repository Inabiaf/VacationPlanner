/*  George Fox
    7/26/2018
    Vacation Planner Assignment
*/
using System;

namespace Assignment4
{
    class VacationPlanner
    {
        static void Main(string[] args)
        {
            //Tells the user how to use the program
            Console.WriteLine("This program will help you plan your vacation!");
            Console.WriteLine("First, you will input the number of places you would like to go,");
            Console.WriteLine("then input information about each.");
            int Venues = AskForVenues();

            //Makes an array for the number of venues, accessed with Venue[i] where i=venue number
            Vacation[] Venue = new Vacation[Venues];

            //The user inputs descriptions for venues 0 through i
            for (int i = 0; i < Venues; i++)
            {
                Venue[i] = new Vacation();
                Console.WriteLine("Venue #{0}", i + 1);
                DescribeVenues(out Venue[i]);
            }

            //Takes the array and current number of venues to the end menu
            EndMenu(Venue, Venues);
        }

        public static void DescribeVenues(out Vacation v) //Thanks to Dr. Olson for the out parameter to bring the array in and out of this method!
        {
            v = new Vacation();
            v.LocationName = AskForLocationName();
            v.LocationAddress = AskForLocationAddress(v.LocationName);
            v.Memo = AskForMemo(v.LocationName);
            v.ArrivalDate = AskForArrivalDate(v.LocationName);
            v.DepartureDate = AskForDepartureDate(v.LocationName);
            v.ExpectedCost = AskForExpectedCost();

            Console.WriteLine("");
        }

        public static void EndMenu(Vacation[] Venue, int Venues)
        {
            String inputWhatNow;
            int d;
            string[] addOptions = { "A", "a", "Add", "add" };

            Console.Write("Type A to add more venues, or enter the venue number to display it's information\n");
            inputWhatNow = Console.ReadLine();
            if (int.TryParse(inputWhatNow, out d)) //if the user puts in a number, they will get back information on that venue, assuming the number is with the range of existing venues.
            {
                if (d > 0 && d <= Venues)
                {
                    d = d - 1;
                    Console.WriteLine("");
                    Console.WriteLine(Venue[d].ToString());
                    Console.WriteLine("");
                    EndMenu(Venue, Venues);
                }
                else
                {
                    Console.Write("Venue out of range!\n");
                }
            }
            foreach (string test in addOptions) //tests input against a number of options so the user can type out "Add", or simply "a"
                if (inputWhatNow.Equals(test))
                {
                    int newVenues = AskForVenues();
                    Array.Resize(ref Venue, Venue.Length + newVenues);
                    for (int i = 0; i < newVenues; i++) //a loop that adds new venues without overwriting old ones
                    {
                        Venue[i + Venues] = new Vacation();
                        Console.WriteLine("Venue #{0}", i + 1 + Venues);
                        DescribeVenues(out Venue[i + Venues]);
                    }
                //Cleans up, adds new venues to the running total and reruns this method.
                Venues = Venues + newVenues;
                EndMenu(Venue, Venues);
                }
            //Assuming none of the if conditions were met, input is considered invalid and this method restarts.
            Console.Write("Invalid input.\n");
            EndMenu(Venue, Venues);
        }

        public static int AskForVenues()
        {
            string inValue;
            int Venues;
            Console.WriteLine("\nHow many venues would you like to plan for? ");
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
            theExpectedCost = AskForExpectedCost();
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
