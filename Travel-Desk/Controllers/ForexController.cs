

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
    public class ForexController : Controller
    {
        private IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public ForexController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitOfWork;
        }

        [HttpPost("AddForex")]
        public void AddForex([FromBody]ForexItem forexData)
        {


            ForexInfo forexCard =_mapper.Map<ForexItem, ForexInfo>(forexData);
            
            _unitofWork.ForexRepository.Add(forexCard);
            int i = _unitofWork.Complete();

        }

       
        
        [HttpGet("GetForexDetails")]
        public ForexItem GetForexDetails(int id)
        {
            ForexItem passportData = new ForexItem();
            passportData = _mapper.Map<ForexInfo, ForexItem>(_unitofWork.ForexRepository.GetForexDetails(id));
            return passportData;
        }

        [HttpPost("UpdateForex")]
        public void UpdateForex([FromBody]ForexItem forexItem)
        {
            ForexInfo forexinfo = _unitofWork.ForexRepository.Get(forexItem.RequestInfoId);
            forexinfo.CardNumber = forexItem.CardNumber;
            forexinfo.CardType = forexItem.CardType;
            forexinfo.CardExpiryDate = forexItem.CardExpiryDate;            
            
            int i = _unitofWork.Complete();
            
            
        }

    }
}
