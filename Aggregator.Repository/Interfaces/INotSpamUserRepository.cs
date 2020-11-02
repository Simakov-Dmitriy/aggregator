using Aggregator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Interfaces
{
    public interface INotSpamUserRepository : IBaseRepository<NotSpamUser>, IBasePaggination<NotSpamUser>
    {
        void RemoveReps();
        void RemoveAll();

        List<NotSpamUser> FindByEmail(string email);
        List<NotSpamUser> FindByPhone(string phone);
        List<NotSpamUser> FindByName(string name);
        List<NotSpamUser> FindBySurname(string surname);
    }
}
