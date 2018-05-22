

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
    public class PerDiemController : Controller
    {
        private IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public PerDiemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitOfWork;
        }

        [HttpPost("AddPerDiem")]
        public void AddPerDiem([FromBody] PerDiemViewModel perDiemViewModel)
        {
            List<PerDiemInfo> _perDiemItems = _mapper.Map<List<PerDiemItem>, List<PerDiemInfo>>(perDiemViewModel.perDiemItems);
            _unitofWork.PerDiemRepository.AddPerDiemOptions(_perDiemItems);
            _unitofWork.Complete();

        }

        [HttpGet("GetPerDiemForRequest")]
        public PerDiemViewModel GetPerDiemForRequest(int id)
        {
            PerDiemViewModel perDiemOptions = new PerDiemViewModel();
            perDiemOptions.perDiemItems = _mapper.Map<List<PerDiemInfo>, List<PerDiemItem>>(_unitofWork.PerDiemRepository.GetPerDiemForRequest(id));

            return perDiemOptions;

        }

        [HttpPost("DeletePerDiem")]
        public void DeletePerDiem([FromBody]List<int> deletedIDs)
        {
           foreach(var id in deletedIDs)
            {
                _unitofWork.PerDiemRepository.Remove(_unitofWork.PerDiemRepository.Get(id));
                

            }
            _unitofWork.Complete();
        }

        [HttpPost("UpdatePerDiem")]
        public void UpdatePerDiem([FromBody]PerDiemViewModel perDiemData)
        {
            List<PerDiemItem> perDiemItems = new List<PerDiemItem>();
            perDiemItems.AddRange(perDiemData.perDiemItems);
            
            
            List<PerDiemInfo> perDiemDataList = (_unitofWork.PerDiemRepository.GetPerDiemForRequest(perDiemItems.First().ReimbursementInfoId));
            
            foreach(var item in perDiemItems)
            {
                var refItem = perDiemDataList.FirstOrDefault(i => i.ReimbursementInfoId == item.ReimbursementInfoId);
                if(refItem!=null)
                {
                    refItem.ArrivalDate = item.ArrivalDate;
                    refItem.DepartureDate = item.DepartureDate;
                    refItem.Currency = item.Currency;
                    refItem.Eligibility = item.Eligibility;
                    refItem.TotalDays = item.TotalDays;
                    refItem.TotalAmount = item.TotalAmount;
                    refItem.Remarks = item.Remarks;

                }
            }

            _unitofWork.Complete();

        }

    }
}
