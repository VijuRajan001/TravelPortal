using DataAccessRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessRepository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRequestRepository RequestRepository { get; }
        IFlightRepository FlightRepository { get; }
        IHotelRepository HotelRepository { get; }
        IPassportRepository PassportRepository { get; }
        IForexRepository ForexRepository { get; }
        IReimbursementRepository ReimbursementRepository { get; }
        IFareRepository FareRepository { get; }
        IPerDiemRepository PerDiemRepository { get; }
        IBoardingLodgingRepository BoardingLodgingRepository { get; }
        ITravelExpensesWithVoucherRepository TravelExpensesWithVoucherRepository { get; }
        ITravelExpensesWithoutVoucherRepository TravelExpensesWithoutVoucherRepository { get; }
        IOtherExpensesRepository OtherExpensesRepository { get; }
        int Complete();
    }
}
