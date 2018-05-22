using DataAccessRepository.Base;
using DataAccessRepository.Implementation;
using DataAccessRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessRepository.Core
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly TravDeskDbcontext _context;
        private IRequestRepository _requestRepository;
        private IFlightRepository _flightRepository;
        private IHotelRepository _hotelRepository;
        private IPassportRepository _passportRepository;
        private IForexRepository _forexRepository;
        private IReimbursementRepository _reimbursementRepository;
        private IFareRepository _fareRepository;
        private IPerDiemRepository _perDiemRepository;
        private IBoardingLodgingRepository _boardingLodgingRepository;
        private ITravelExpensesWithVoucherRepository _travelExpensesWithVoucherRepository;
        private ITravelExpensesWithoutVoucherRepository _travelExpensesWithoutVoucherRepository;
        private IOtherExpensesRepository _otherExpensesRepository;
        public UnitOfWork(TravDeskDbcontext context)
        {
            _context = context;
            
        }

        public IRequestRepository RequestRepository
        {
            get
            {
                return _requestRepository = _requestRepository ?? new RequestRepository(_context);
            }
        }

        public IFlightRepository FlightRepository
        {
            get
            {
                return _flightRepository = _flightRepository ?? new FlightRepository(_context);
            }

        }


        public IHotelRepository HotelRepository
        {
            get
            {
                return _hotelRepository = _hotelRepository ?? new HotelRepository(_context);
            }

        }

        public IPassportRepository PassportRepository
        {
            get
            {
                return _passportRepository = _passportRepository ?? new PassportRepository(_context);
            }

        }

        public IForexRepository ForexRepository
        {
            get
            {
                return _forexRepository = _forexRepository ?? new ForexRepository(_context);
            }

        }

        public IReimbursementRepository ReimbursementRepository
        {
            get
            {
                return _reimbursementRepository = _reimbursementRepository ?? new ReimbursementRepository(_context);
            }
        }


        public IFareRepository FareRepository
        {
            get
            {
                return _fareRepository = _fareRepository ?? new FareRepository(_context);
            }

        }

        public IPerDiemRepository PerDiemRepository
        {
            get
            {
                return _perDiemRepository = _perDiemRepository ?? new PerDiemRepository(_context);
            }

        }

       
        public ITravelExpensesWithVoucherRepository TravelExpensesWithVoucherRepository
        {
            get
            {
                return _travelExpensesWithVoucherRepository = _travelExpensesWithVoucherRepository ?? new TravelExpensesWithVoucherRepository(_context);
            }

        }

        public ITravelExpensesWithoutVoucherRepository TravelExpensesWithoutVoucherRepository
        {
            get
            {
                return _travelExpensesWithoutVoucherRepository = _travelExpensesWithoutVoucherRepository ?? new TravelExpensesWithoutVoucherRepository(_context);
            }

        }

        public IOtherExpensesRepository OtherExpensesRepository
        {
            get
            {
                return _otherExpensesRepository = _otherExpensesRepository ?? new OtherExpensesRepository(_context);
            }

        }

        public IBoardingLodgingRepository BoardingLodgingRepository {
            get
            {
                return _boardingLodgingRepository = _boardingLodgingRepository ?? new BoardingLodgingRepository(_context);
            }
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();

        }
    }
}
