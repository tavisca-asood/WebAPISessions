using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAPI
{
    public class SQLServer
    {
        InventoryDatabaseEntities products = new InventoryDatabaseEntities();
        private static SQLServer _instance;
        private SQLServer() { }

        public static SQLServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLServer();
                }
                return _instance;
            }
        }
        public List<ActivityProduct> GetActivities()
        {
            return products.ActivityProducts.ToList();
        }
        public List<AirProduct> GetPlanes()
        {
            return products.AirProducts.ToList();
        }
        public List<CarProduct> GetCars()
        {
            return products.CarProducts.ToList();
        }
        public List<HotelProduct> GetHotels()
        {
            return products.HotelProducts.ToList();
        }
        public void AddActivity(ActivityProduct activity)
        {
            products.ActivityProducts.Add(activity);
            products.SaveChanges();
        }
        public void AddPlane(AirProduct airProduct)
        {
            products.AirProducts.Add(airProduct);
            products.SaveChanges();
        }
        public void AddCar(CarProduct car)
        {
            products.CarProducts.Add(car);
            products.SaveChanges();
        }
        public void AddHotel(HotelProduct hotel)
        {
            products.HotelProducts.Add(hotel);
            products.SaveChanges();
        }
        public void BookActivity(int id)
        {
            ActivityProduct current = products.ActivityProducts.ToList().Find(x => x.ID == id);
            if (current.Book())
            {
                products.Bookeds.Add(new Booked()
                {
                    Name = current.Name,
                    Price = current.Price,
                    Date = current.Date
                });
            }
            else
            {
                Booked booked = products.Bookeds.ToList().Find(x => x.Name == current.Name && x.Date == current.Date);
                products.Bookeds.Remove(booked);
            }
            products.SaveChanges();
        }
        public void SaveActivity(int id)
        {
            ActivityProduct current = products.ActivityProducts.ToList().Find(x => x.ID == id);
            if (current.Save())
            {
                products.Saveds.Add(new Saved()
                {
                    Name = current.Name,
                    Price = current.Price,
                    Date = current.Date
                });
            }
            else
            {
                Saved saved = products.Saveds.ToList().Find(x => x.Name.Equals(current.Name) && x.Date == current.Date);
                products.Saveds.Remove(saved);
            }
            products.SaveChanges();
        }
        public void BookPlane(int id)
        {
            AirProduct current = products.AirProducts.ToList().Find(x => x.ID == id);
            if (current.Book())
            {
                products.Bookeds.Add(new Booked()
                {
                    Name = current.Name,
                    Price = current.Price,
                    Date = current.Departure
                });
            }
            else
            {
                Booked booked = products.Bookeds.ToList().Find(x => x.Name == current.Name && x.Date == current.Departure);
                products.Bookeds.Remove(booked);
            }
            products.SaveChanges();
        }
        public void SavePlane(int id)
        {
            AirProduct current = products.AirProducts.ToList().Find(x => x.ID == id);
            if (current.Save())
            {
                products.Saveds.Add(new Saved()
                {
                    Name = current.Name,
                    Price = current.Price,
                    Date = current.Departure
                });
            }
            else
            {
                Saved saved = products.Saveds.ToList().Find(x => x.Name==current.Name && x.Date == current.Departure );
                products.Saveds.Remove(saved);
            }
            products.SaveChanges();
        }
        public void BookCar(int id)
        {
            CarProduct current = products.CarProducts.ToList().Find(x => x.ID == id);
            if (current.Book())
            {
                products.Bookeds.Add(new Booked()
                {
                    Name = current.Name,
                    Price = current.Price,
                    Date = current.Date
                });
            }
            else
            {
                Booked booked = products.Bookeds.ToList().Find(x => x.Name == current.Name && x.Date == current.Date);
                products.Bookeds.Remove(booked);
            }
            products.SaveChanges();
        }
        public void SaveCar(int id)
        {
            CarProduct current = products.CarProducts.ToList().Find(x => x.ID == id);
            if (current.Save())
            {
                products.Saveds.Add(new Saved()
                {
                    Name = current.Name,
                    Price = current.Price,
                    Date = current.Date
                });
            }
            else
            {
                Saved saved = products.Saveds.ToList().Find(x => x.Name.Equals(current.Name) && x.Date == current.Date);
                products.Saveds.Remove(saved);
            }
            products.SaveChanges();
        }
        public void BookHotel(int id)
        {
            HotelProduct current = products.HotelProducts.ToList().Find(x => x.ID == id);
            if (current.Book())
            {
                products.Bookeds.Add(new Booked()
                {
                    Name = current.Name,
                    Price = current.Price,
                    Date = current.Date
                });
            }
            else
            {
                Booked booked = products.Bookeds.ToList().Find(x => x.Name == current.Name && x.Date == current.Date);
                products.Bookeds.Remove(booked);
            }
            products.SaveChanges();
        }
        public void SaveHotel(int id)
        {
            HotelProduct current = products.HotelProducts.ToList().Find(x => x.ID == id);
            if (current.Save())
            {
                products.Saveds.Add(new Saved()
                {
                    Name = current.Name,
                    Price = current.Price,
                    Date = current.Date
                });
            }
            else
            {
                Saved saved = products.Saveds.ToList().Find(x => x.Name.Equals(current.Name) && x.Date == current.Date);
                products.Saveds.Remove(saved);
            }
            products.SaveChanges();
        }
        public IEnumerable<Saved> GetSaved()
        {
            return products.Saveds.ToList();
        }
        public IEnumerable<Booked> GetBooked()
        {
            return products.Bookeds.ToList();
        }
    }
}