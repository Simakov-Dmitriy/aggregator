using Aggregator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Interfaces
{
    public interface IСustomersRepository : IBaseRepository<Сustomer>, IBasePaggination<Сustomer>
    {
        Сustomer GetByEmailOrPhone( string email, string phone );
        Сustomer GetByEmail(string email);
        List<Сustomer> FindByEmail(string email);
        List<Сustomer> FindByPhone(string phone);
        List<Сustomer> FindByName(string name);
        List<Сustomer> FindBySurname(string surname);
    }
}
