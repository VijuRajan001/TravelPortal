using DataAccessRepository.Base;
using DataAccessRepository.Entities;
using DataAccessRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessRepository.Implementation
{
    public class HotelRepository: Repository<HotelInfo>,IHotelRepository
    {

        public HotelRepository(TravDeskDbcontext context) : base(context)
        {


        }
      
        

        public void AddHotelOptions(List<HotelInfo> hotelItems)
        {
            TravDeskDbcontext.HotelInfo.AddRange(hotelItems);
        }

        List<HotelInfo> IHotelRepository.GetHotelsForRequest(int id)
        {
            List<HotelInfo> HotelInfo = new List<HotelInfo>();
            HotelInfo = TravDeskDbcontext.HotelInfo.Where(f => f.RequestInfoId == id).ToList();

            return HotelInfo;
        }

        public TravDeskDbcontext TravDeskDbcontext
        {
            get { return Context as TravDeskDbcontext; }
        }
    }
}
