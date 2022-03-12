﻿using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deletedHotel = GetHotelById(id);
                hotelDbContext.Hotels.Remove(deletedHotel);
                hotelDbContext.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotels()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id) 
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel GetHotelByName(string name) 
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            }
        }

        //public Hotel GetotelByIdWithName(int id, string name)
        //{
        //    using (var hotelDbContext = new HotelDbContext())
        //    {
        //        return hotelDbContext.Hotels.
        //    }
        //}

        //id ve name ile aramada kullanılacak bir fonksiyon yazılabilir ama query string ile kullanmak daha iyidir

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                return hotel;
            }
        }
    }
}
