

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
    public class RequestController : Controller
    {
        private IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public RequestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitOfWork;
        }

        [HttpPost("AddRequest")]
        public void AddRequest([FromBody]RequestItem requestData)
        {

            RequestInfo newRequest = new RequestInfo();
            newRequest=_mapper.Map<RequestItem, RequestInfo>(requestData);
            
            _unitofWork.RequestRepository.Add(newRequest);
            int i = _unitofWork.Complete();

        }

        [HttpGet("GetRequestList")]
        public List<RequestItem> GetRequestList()
        {

            List<RequestItem> requestDataList = _mapper.Map<List<RequestInfo>, List<RequestItem>>(_unitofWork.RequestRepository.GetAll().ToList());
            return requestDataList.OrderByDescending(x=>x.RequestId).ToList();



        }

        [HttpGet("GetRequestById")]
        public RequestItem GetRequestById(int Id)
        {
            RequestItem requestData = _mapper.Map<RequestInfo, RequestItem>(_unitofWork.RequestRepository.Get(Id));
            return requestData;
        }

        [HttpPost("UpdateRequest")]
        public void UpdateRequest([FromBody]RequestItem requestData)
        {
            RequestInfo newRequest = _unitofWork.RequestRepository.Get(requestData.RequestId);
            newRequest.ProjectId = requestData.Project_Code;
            newRequest.TravelCountry = requestData.Country;
            newRequest.TravelStart = requestData.TravelDate;
            newRequest.TravelReturn = requestData.ReturnDate;
            newRequest.RequestStatus = requestData.RequestStatus;
            int i = _unitofWork.Complete();
            
            
        }

    }
}
