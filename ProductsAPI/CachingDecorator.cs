using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsAPI.Models;
using System.Runtime.Caching;

namespace ProductsAPI
{
    public class CachingDecorator : IProduct
    {
        private static MemoryCache _cache = new MemoryCache("Cache");
        public bool Book()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
        public static List<IProduct> Get(string product)
        {
            switch (product)
            {
                case "Activities":
                    if (_cache["Activities"] == null || _cache["Activities"] == "")
                    {
                        _cache["Activities"] = SQLServer.Instance.GetActivities().Cast<IProduct>().ToList();
                    }
                    return (List<IProduct>)(_cache["Activities"]);
                case "Air":
                    if (_cache["Air"] == null || _cache["Air"] == "")
                    {
                        _cache["Air"] = SQLServer.Instance.GetPlanes().Cast<IProduct>().ToList();
                    }
                    return (List<IProduct>)(_cache["Air"]);
                case "Cars":
                    if (_cache["Cars"] == null || _cache["Cars"] == "")
                    {
                        _cache["Cars"] = SQLServer.Instance.GetCars().Cast<IProduct>().ToList();
                    }
                    return (List<IProduct>)(_cache["Cars"]);
                case "Hotels":
                    if (_cache["Hotels"] == null || _cache["Hotels"] == "")
                    {
                        _cache["Hotels"] = SQLServer.Instance.GetHotels().Cast<IProduct>().ToList();
                    }
                    return (List<IProduct>)(_cache["Hotels"]);
            }
            return null;
        }
        public static void Update(string product)
        {
            switch (product)
            {
                case "Activities":
                    _cache["Activities"] = "";
                    break;
                case "Air":
                    _cache["Air"] = "";
                    break;
                case "Cars":
                    _cache["Cars"] = "";
                    break;
                case "Hotels":
                    _cache["Hotels"] = "";
                    break;
            }
        }
    }
}