using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Product
    {
        public string Current { get; set; }
        public Product(IProduct selected)
        {
            Current = selected.GetType().Name;
        }
        public void DisplayList()
        {
            switch(Current)
            {
                case "ActivityProduct":
                    foreach(ActivityProduct activity in SQLServer.Activities())
                    {
                        Console.WriteLine("ID = {0}\tName = {1}\tPrice = {2}\tStart Time = {3}",activity.ID,activity.Name,activity.Price,activity.StartTime.ToString());
                    }
                    break;
                case "AirProduct":
                    foreach (AirProduct plane in SQLServer.Planes())
                    {
                        Console.WriteLine("ID = {0}\tName = {1}\tPrice = {2}\tDeparture = {3}\tArrival = {4}",plane.ID,plane.Name,plane.Price,plane.Departure.ToString(),plane.Arrival.ToString());
                    }
                    break;
                case "CarProduct":
                    foreach(CarProduct car in SQLServer.Cars())
                    {
                        Console.WriteLine("ID = {0}\tName = {1}\tPrice = {2}",car.ID,car.Name,car.Price);
                    }
                    break;
                case "HotelProduct":
                    foreach(HotelProduct hotel in SQLServer.Hotels())
                    {
                        Console.WriteLine("ID = {0}\tName = {1}\tLocation = {2}\tRating = {3}\tPrice = {4}",hotel.ID,hotel.Name,hotel.Location,hotel.Rating,hotel.Price);
                    }
                    break;
            }
        }
    }
}
