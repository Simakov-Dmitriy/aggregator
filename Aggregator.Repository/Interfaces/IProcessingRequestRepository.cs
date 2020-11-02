using Aggregator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Repository.Interfaces
{
    public interface IProcessingRequestRepository : IBaseRepository<ProcessingRequest>, IBasePaggination<ProcessingRequest>
    {
        List<ProcessingRequest> TakeNotMatchingUsers();
        void ImportRange(List<ProcessingRequest> requests);
        void RemoveReps();
        void RemoveAll();

        List<ProcessingRequest> FindByEmail(string email);
        List<ProcessingRequest> FindByPhone(string phone);
        List<ProcessingRequest> FindByName(string name);
        List<ProcessingRequest> FindBySurname(string surname);
    }
}
