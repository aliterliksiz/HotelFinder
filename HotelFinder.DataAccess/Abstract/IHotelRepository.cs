using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelRepository
    {
        List<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        Hotel GetHotelByName(string name);

        //Hotel GetotelByIdWithName(int id, string name); //id ve name ile aramada kullanılacak bir fonksiyon yazılabilir ama query string ile kullanmak daha iyidir
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
    }
}
