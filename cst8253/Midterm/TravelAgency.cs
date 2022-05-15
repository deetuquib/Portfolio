using System;
using System.Collections.Generic;

namespace Midterm
{
    class TravelAgency
    {
        static void Main(string[] args)
        {
            // index
            int index = 0;
            bool repeat = true;

            List<Itinerary> itineraries = new List<Itinerary>();

            Console.WriteLine("Welcome to Algonquin College Student Travel Agency!");

            do
            {
                Console.Write("\nV - to view all itineraries,\n" +
                    "A - to add a new itinerary. \n" +
                    "C - to change an existing itinerary,\n" +
                    "E - to exit \n\n" +
                    "Please enter choice: ");
                string action = Console.ReadLine().ToUpper();

                // chosing action
                switch (action)
                {
                    case "V":
                        {
                            if (index == 0) // if no itinerary exists in the system
                            {
                                Console.WriteLine("\nNo itinerary exists in the system! Plesae choose 'A' to add a new itinerary.");
                            }
                            else // populate exisiting itinerary
                            {
                                foreach (Itinerary itinerary in itineraries)
                                {
                                    // #TODO: figure out how to index properly
                                    Console.WriteLine($" - {itinerary.PassengerName}, Departure: {itinerary.DepartureCity}, Arrival: {itinerary.ArrivingCity}, Cost: {itinerary.Cost}");
                                }
                            }
                            break;
                        }

                    case "A":
                        {
                            try
                            {
                                // prompt user to add itinerary
                                Console.Write("\nEnter passenger name: ");
                                string addPassengerName = Console.ReadLine();
                                Console.Write("Enter new departure city: ");
                                string addDepartureCity = Console.ReadLine();
                                Console.Write("Enter new arrival city: ");
                                string addArrivalCity = Console.ReadLine();
                                itineraries.Add(new Itinerary(addPassengerName, addDepartureCity, addArrivalCity));
                                // confirm successfully added to itinerary
                                Console.WriteLine($"\n{addPassengerName}'s itinerary has been added to the system. Total cost: {Itinerary.TicketFee}");
                                index++;
                                break;
                            } catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }

                    case "C":
                        {
                            if (itineraries.Count > 0)
                            {
                                Console.Write("Enter the index of itinerary you want to change: (0 to " + (itineraries.Count - 1) + ")");
                                int i = int.Parse(Console.ReadLine());

                                Console.Write("Enter passenger name: ");
                                string changePassengerName = Console.ReadLine();
                                //foreach ()
                                Console.Write("Enter new departure city: ");
                                string newDepartureCity = Console.ReadLine();
                                Console.Write("Enter new arrival city: ");
                                string newArrivalCity = Console.ReadLine();

                                itineraries[i].ChangeItinerary(newDepartureCity, newArrivalCity);
                                Console.Write(itineraries[i].PassengerName + "'s itinerary has been changed. $" + Itinerary.ChangeFee + " change fee was applied.");
                            } else
                            {
                                Console.WriteLine("No itineraries changed."); 
                            }
                            break;
                        }

                    case "E":
                        {
                            Console.WriteLine("\nThank you for using Algonquin College Student Travel Agency!");
                            Console.WriteLine("Press return key to complete the application");
                            repeat = false;
                            break;
                        }
                    default:
                        Console.WriteLine("\nERROR: You entered an invalid choice. Please choose from any of the options below.");
                        break;
                } 
            } while (repeat == true);

            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
