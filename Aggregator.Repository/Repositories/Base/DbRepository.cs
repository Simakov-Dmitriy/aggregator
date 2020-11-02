using Aggregator.Domain.Models;
using Aggregator.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Repositories.Base
{
    public class DbRepository
    {
        private readonly string _connectionString;
        public DbRepository()
        {
            _connectionString = Configuration.AppConfiguration.ConectionString;
        }

        private ChicagoTiketRepository _chicagoTiketsRepository;
        private AugistineTiketRepository _augistineTiketsRepository;
        private SelectedTicketRepository _selectedTicketRepository;
        private CouponRepository _couponsRepository;
        private SpecialPropositionRepository _specialPropositionsRepository;
        private СustomersRepository _customersRepository;
        private TransactionsRepository _transactionsRepository;
        private CustomerTiketRepository _customerTiketsRepository;
        private BaseRepository<Museum> _museumsRepository;
        private ProcessingRequestRepository _processingRequestsRepository;
        private NotSpamUserRepository _notSpamUsersRepository;
        private lockedIpsRepository _lockedIpsRepository;
        
        public IChicagoTiketRepository ChicagoTikets
        {
            get
            {
                if(_chicagoTiketsRepository == null )
                {
                    _chicagoTiketsRepository = new ChicagoTiketRepository("ChicagoTikets", _connectionString);
                }
                return _chicagoTiketsRepository;
            }
        }

        public IAugistineTiketRepository AugistineTikets
        {
            get
            {
                if (_augistineTiketsRepository == null)
                {
                    _augistineTiketsRepository = new AugistineTiketRepository("AugistineTikets", _connectionString);
                }
                return _augistineTiketsRepository;
            }
        }

        public ISelectedTicketRepository SelectedTickets
        {
            get
            {
                if(_selectedTicketRepository == null)
                {
                    _selectedTicketRepository = new SelectedTicketRepository("SelectedTickets", _connectionString);
                }
                return _selectedTicketRepository;
            }
        }

        public ICouponRepository Coupons
        {
            get
            {
                if( _couponsRepository == null )
                {
                    _couponsRepository = new CouponRepository("Coupons", _connectionString);
                }
                return _couponsRepository;
            }
        }
        public ISpecialPropositionRepository SpecialPropositions
        {
            get
            {
                if( _specialPropositionsRepository == null )
                {
                    _specialPropositionsRepository = new SpecialPropositionRepository("SpecialPropositions", _connectionString);
                }
                return _specialPropositionsRepository;
            }
        }
        public IСustomersRepository Сustomers
        {
            get
            {
                if( _customersRepository == null )
                {
                    _customersRepository = new СustomersRepository("Сustomer", _connectionString);
                }
                return _customersRepository;
            }
        }
        public ITransactionsRepository Transactions
        {
            get
            {
                if( _transactionsRepository == null )
                {
                    _transactionsRepository = new TransactionsRepository("Transactions", _connectionString);
                }
                return _transactionsRepository;
            }
        }
        public ICustomerTiketRepository CustomerTikets
        {
            get
            {
                if( _customerTiketsRepository == null )
                {
                    _customerTiketsRepository = new CustomerTiketRepository("CustomerTikets", _connectionString);
                }
                return _customerTiketsRepository;
            }
        }
        public IBaseRepository<Museum> Museums
        {
            get
            {
                if (_museumsRepository == null)
                {
                    _museumsRepository = new BaseRepository<Museum>("Museums", _connectionString);
                }
                return _museumsRepository;
            }
        }
        public IProcessingRequestRepository ProcessingRequests
        {
            get
            {
                if (_processingRequestsRepository == null)
                {
                    _processingRequestsRepository = new ProcessingRequestRepository("ProcessingRequests", _connectionString);
                }
                return _processingRequestsRepository;
            }
        }
        public INotSpamUserRepository NotSpamUsers
        {
            get
            {
                if (_notSpamUsersRepository == null)
                {
                    _notSpamUsersRepository = new NotSpamUserRepository("NotSpamUsers", _connectionString);
                }
                return _notSpamUsersRepository;
            }
        }
         public IlockedIpsRepository lockedIps
        {
            get
            {
                if (_lockedIpsRepository == null)
                {
                    _lockedIpsRepository = new lockedIpsRepository("lockedIps", _connectionString);
                }
                return _lockedIpsRepository;
            }
        }



    }
}
