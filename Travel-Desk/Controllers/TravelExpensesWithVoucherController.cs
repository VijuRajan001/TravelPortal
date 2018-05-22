

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
    public class TravelExpensesWithVoucherController : Controller
    {
        private IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public TravelExpensesWithVoucherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitOfWork;
        }

        [HttpPost("AddTravelExpensesWithVoucher")]
        public void AddTravelExpensesWithVoucher([FromBody] TravelExpensesWithVoucherViewModel travelExpensesWithVoucherViewModel)
        {
            List<TravelExpensesWithVoucherInfo> _travelExpensesWithVoucherItems = _mapper.Map<List<TravelExpensesWithVoucherItem>, List<TravelExpensesWithVoucherInfo>>(travelExpensesWithVoucherViewModel.travelExpensesWithVoucherItems);
            _unitofWork.TravelExpensesWithVoucherRepository.AddTravelExpensesWithVoucherOptions(_travelExpensesWithVoucherItems);
            _unitofWork.Complete();

        }

        [HttpGet("GetTravelExpensesWithVoucherForRequest")]
        public TravelExpensesWithVoucherViewModel GetTravelExpensesWithVoucherForRequest(int id)
        {
            TravelExpensesWithVoucherViewModel travelExpensesWithVoucherOptions = new TravelExpensesWithVoucherViewModel();
            travelExpensesWithVoucherOptions.travelExpensesWithVoucherItems = _mapper.Map<List<TravelExpensesWithVoucherInfo>, List<TravelExpensesWithVoucherItem>>(_unitofWork.TravelExpensesWithVoucherRepository.GetTravelExpensesWithVoucherForRequest(id));

            return travelExpensesWithVoucherOptions;

        }

        [HttpPost("DeleteTravelExpensesWithVoucher")]
        public void DeleteTravelExpensesWithVoucher([FromBody]List<int> deletedIDs)
        {
           foreach(var id in deletedIDs)
            {
                _unitofWork.TravelExpensesWithVoucherRepository.Remove(_unitofWork.TravelExpensesWithVoucherRepository.Get(id));
                

            }
            _unitofWork.Complete();
        }

        [HttpPost("UpdateTravelExpensesWithVoucher")]
        public void UpdateTravelExpensesWithVoucher([FromBody]TravelExpensesWithVoucherViewModel travelExpensesWithVoucherData)
        {
            List<TravelExpensesWithVoucherItem> travelExpensesWithVoucherItems = new List<TravelExpensesWithVoucherItem>();
            travelExpensesWithVoucherItems.AddRange(travelExpensesWithVoucherData.travelExpensesWithVoucherItems);
            
            
            List<TravelExpensesWithVoucherInfo> travelExpensesWithVoucherDataList = (_unitofWork.TravelExpensesWithVoucherRepository.GetTravelExpensesWithVoucherForRequest(travelExpensesWithVoucherItems.First().ReimbursementInfoId));
            
            foreach(var item in travelExpensesWithVoucherItems)
            {
                var refItem = travelExpensesWithVoucherDataList.FirstOrDefault(i => i.ReimbursementInfoId == item.ReimbursementInfoId);
                if(refItem!=null)
                {
                    refItem.Date = item.Date;
                    refItem.From = item.From;
                    refItem.To = item.To;
                    refItem.ModeofConveyance = item.ModeofConveyance;
                    refItem.Currency = item.Currency;
                    refItem.AmountSpent = item.AmountSpent;
                    refItem.Remarks = item.Remarks;

                }
            }

            _unitofWork.Complete();

        }

    }
}
