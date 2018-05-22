

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessRepository.Core;
using DataAccessRepository.Entities;
using Microsoft.AspNetCore.Mvc;
using TravelDesk.Models;
using TravelDesk.ViewModels;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : Controller
    {
        private IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public FlightController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitOfWork;
        }

        [HttpPost("AddFlights")]
        public void AddFlights([FromBody]FlightOptionsViewModel flightData)
        {
            List<FlightInfo> _onwardflightItems = _mapper.Map<List<FlightItem>, List<FlightInfo>>(flightData.OnwardFlightItems);
            List<FlightInfo> _returnflightItems = _mapper.Map<List<FlightItem>, List<FlightInfo>>(flightData.ReturnFlightItems);
            _unitofWork.FlightRepository.AddOnwardFlightOptions(_onwardflightItems);
            _unitofWork.FlightRepository.AddReturnFlightOptions(_returnflightItems);

            _unitofWork.Complete();

        }

        [HttpGet("GetFlightsForRequest")]
        public FlightOptionsViewModel GetFlightsForRequest(int id)
        {
            FlightOptionsViewModel vm = new FlightOptionsViewModel();
            List<FlightItem> flightDataList = _mapper.Map<List<FlightInfo>, List<FlightItem>>(_unitofWork.FlightRepository.GetFlightsForRequest(id));
            vm.OnwardFlightItems=flightDataList.FindAll(item => item.FlightDirection == "Onward");
            vm.ReturnFlightItems = flightDataList.FindAll(item => item.FlightDirection == "Return");
            return vm;



        }

        [HttpPost("DeleteFlights")]
        public void DeleteFlights([FromBody]List<int> deletedIDs)
        {
           foreach(var id in deletedIDs)
            {
                _unitofWork.FlightRepository.Remove(_unitofWork.FlightRepository.Get(id));
                _unitofWork.Complete();

            }
        }

        [HttpPost("UpdateFlights")]
        public void UpdateFlights([FromBody]FlightOptionsViewModel flightData)
        {
            List<FlightItem> flightItems = new List<FlightItem>();
            flightItems.AddRange(flightData.OnwardFlightItems);
            flightItems.AddRange(flightData.ReturnFlightItems);
            
            List<FlightInfo> flightDataList = (_unitofWork.FlightRepository.GetFlightsForRequest(flightItems.First().RequestInfoId));
            
            foreach(var item in flightItems)
            {
                var refItem = flightDataList.FirstOrDefault(i => i.Id == item.Id);
                if(refItem!=null)
                {
                    refItem.FlightFrom = item.FlightFrom;
                    refItem.FlightTo = item.FlightTo;
                    refItem.FlightName = item.FlightName;
                    refItem.FlightItemId = item.FlightItemId;
    
                }
            }

            _unitofWork.Complete();

        }

    }
}
