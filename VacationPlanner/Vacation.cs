/*  George Fox
    7/17/2018
    Assignment 4
*/
using System;

namespace Assignment4
{
    class Vacation
    {
        private string locationName;
        private string locationAddress;
        private string memo;
        private string arrivalDate;
        private string departureDate;
        private double expectedCost;

        public Vacation()
        {
        }

        public Vacation(string locName, string locAddress, string TD, string ArrDate, string DepDate, double newExpectedCost)
        {
            locationName = locName;
            locationAddress = locAddress;
            memo = TD;
            arrivalDate = ArrDate;
            departureDate = DepDate;
            expectedCost = newExpectedCost;
        }

        public string LocationName
        {
            get
            {
                return locationName;
            }
            set
            {
                locationName = value;
            }
        }

        public string LocationAddress
        {
            get
            {
                return locationAddress;
            }
            set
            {
                locationAddress = value;
            }
        }

        public string Memo
        {
            get
            {
                return memo;
            }
            set
            {
                memo = value;
            }
        }

        public string ArrivalDate
        {
            get
            {
                return arrivalDate;
            }
            set
            {
                arrivalDate = value;
            }
        }

        public string DepartureDate
        {
            get
            {
                return departureDate;
            }
            set
            {
                departureDate = value;
            }
        }

        public double ExpectedCost
        {
            get
            {
                return expectedCost;

            }
            set
            {
                expectedCost = value;
            }
        }

        public override string ToString()
        {
            return  "Location: " +
                    locationName +
                    "\nAddress: " +
                    locationAddress +
                    "\nWhat to do: " +
                    memo +
                    "\nArrival Date: " +
                    arrivalDate +
                    "\nDeparture Date: " +
                    departureDate +
                    "\nExpectedCost: " +
                    expectedCost.ToString("c");
        }
    }
}
