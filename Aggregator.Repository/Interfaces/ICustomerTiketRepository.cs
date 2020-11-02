using Aggregator.Domain.Models;
using Aggregator.Domain.ModelsToView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Interfaces
{
    public interface ICustomerTiketRepository : IBaseRepository<CustomerTiket>
    {
        List<BuyerTicket> GetBuyerTikets();
        List<CustomerTiket> GetAllPurchased();
        List<CustomerTiket> GetByUserId(string id);
    }
}
