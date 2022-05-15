using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    public class Itinerary
    {
        public static double ChangeFee { get; } = 50.0;
        public static double TicketFee { get; } = 500.0;
        public string PassengerName { get; }

        private string departureCity;
        public string DepartureCity 
        { get { return departureCity; } 
          private set { departureCity = string.IsNullOrWhiteSpace(value) ? throw new Exception("Departure city can not be empty!") : value.Trim(); }
        }

        private string arrivingCity;
        public string ArrivingCity
        {
            get { return arrivingCity; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Arriving city can not be empty!");
                if (value.ToUpper() == departureCity.ToUpper()) throw new Exception("Arriving city can not be the same as departure city!");

                arrivingCity = value.Trim();
            }
        }

        public double Cost { get; private set; }

        public Itinerary(string passengerName, string departureCity, string arrivingCity)
        {
            this.PassengerName = string.IsNullOrWhiteSpace(passengerName) ? throw new Exception("Passenger name can not be empty!") : passengerName;
            this.DepartureCity =  departureCity;
            this.ArrivingCity =  arrivingCity;

            Cost = TicketFee;
        }

        public void ChangeItinerary(string newDepartureCity, string newArrivingCity)
        {
            if (newDepartureCity.Trim().ToUpper() == DepartureCity.ToUpper() 
                && newArrivingCity.Trim().ToUpper() == ArrivingCity.ToUpper())
            {
                throw new Exception("New itinerary is the same as old itinerary, no change made!");
            }

            //save current itinerary in case something goes wrong.
            string oldDepartureCity = DepartureCity;
            string oldArrivingCity = ArrivingCity;

            try
            {
                DepartureCity = newDepartureCity;
                ArrivingCity = newArrivingCity;

                Cost += ChangeFee;
            }
            catch(Exception e)
            {
                //Unable to save the new itineary, restore the current itinerary.
                DepartureCity = oldDepartureCity;
                ArrivingCity = oldArrivingCity;

                throw e;   
            }
        }

    }
}
