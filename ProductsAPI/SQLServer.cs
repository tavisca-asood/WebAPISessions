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
            products.ActivityProducts.ToList().Find(x => x.ID == id).Book();
            products.SaveChanges();
        }
        public void SaveActivity(int id)
        {
            products.ActivityProducts.ToList().Find(x => x.ID == id).Save();
            products.SaveChanges();
        }
        public void BookPlane(int id)
        {
            products.AirProducts.ToList().Find(x => x.ID == id).Book();
            products.SaveChanges();
        }
        public void SavePlane(int id)
        {
            products.AirProducts.ToList().Find(x => x.ID == id).Save();
            products.SaveChanges();
        }
        public void BookCar(int id)
        {
            products.CarProducts.ToList().Find(x => x.ID == id).Book();
            products.SaveChanges();
        }
        public void SaveCar(int id)
        {
            products.CarProducts.ToList().Find(x => x.ID == id).Save();
            products.SaveChanges();
        }
        public void BookHotel(int id)
        {
            products.HotelProducts.ToList().Find(x => x.ID == id).Book();
            products.SaveChanges();
        }
        public void SaveHotel(int id)
        {
            products.HotelProducts.ToList().Find(x => x.ID == id).Save();
            products.SaveChanges();
        }
    }
}