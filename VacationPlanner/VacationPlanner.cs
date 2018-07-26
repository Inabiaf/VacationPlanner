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
            int Venues = AskForVenues();

            //Makes an array for the number of Venues, accessed with Venue[i] where i=venue number
            Vacation[] Venue = new Vacation[Venues];

            for (int i = 0; i < Venues; i++)
            {
                
                Venue[i] = new Vacation();
                Console.WriteLine("Venue #{0}", i + 1);
                //How do I save DescribeVenues into the array as an object?
                //Venue[i] = DescribeVenues(); - the next line is a modification if this to accommodate my adjustment of your method with the input "out" parameter
                DescribeVenues(out Venue[i]);
            }

            EndMenu(Venue, Venues);





            //I am not sure how to resize the array here.
            /*I would check this link for the info on how to resize, but you are on the right track. A very good article with an example: https://msdn.microsoft.com/en-us/library/bb348051(v=vs.110).aspx  
Now, you need to also think on when you are calling this. I see multiple ways, one of which is to look into organizing some kind of do...while, so you can ask your user if more  vacation plans are needed after all the rest of the spots are taken, You would need to draw out this logic to decide what structure and how to use it... :) I am very happy to see you going beyond the course coverage! */
            


        }

        public static void DescribeVenues(out Vacation v) // I would use this type of parameters instead of parameter by value, this would allow you to fill in the values and use them outside of the method
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
            if (int.TryParse(inputWhatNow, out d))
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
            foreach (string test in addOptions)
                if (inputWhatNow.Equals(test))
                {

                    int newVenues = AskForVenues();
                    Array.Resize(ref Venue, Venue.Length + newVenues);
                    for (int i = 0; i < newVenues; i++)
                    {
                        Venue[i + Venues] = new Vacation();
                        Console.WriteLine("Venue #{0}", i + 1 + Venues);
                        DescribeVenues(out Venue[i + Venues]);
                    }
                Venues = Venues + newVenues;
                EndMenu(Venue, Venues);
                }

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
