using Aggregator.Domain.Models;
using Aggregator.Repository.Repositories.Base;
using Aggregator.Services.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class UserInfoService
    {
        private readonly DbRepository _db;
        public UserInfoService()
        {
            _db = new DbRepository();
        }

        public void CreateСustomer( Сustomer customer )
        {
            _db.Сustomers.Add(customer);
        }

        public Сustomer GetCustomerByEmail( string email )
        {
            return _db.Сustomers.GetByEmailOrPhone(email, string.Empty);
        }

        public Сustomer GetOrCreateCustomer(UserInfoDto userInfo )
        {
            Сustomer customer = _db.Сustomers.GetByEmail(userInfo.Email);
            if( customer == null )
            {
                customer = new Сustomer();
                customer.Email = userInfo.Email;
                customer.Phone = userInfo.Phone;
                customer.Name = userInfo.Name;
                customer.Surname = userInfo.Surname;
                _db.Сustomers.Add(customer);
            }
            return customer;
        }

      

        public void AddTransaction(Transaction transaction )
        {
            _db.Transactions.Add(transaction);
        }





        public List<Museum> GetMuseums()
        {
            return _db.Museums.GetAll();
        }

        public List<ProcessingRequest> GetProcessingRequests()
        {
            return _db.ProcessingRequests.GetAll();
        }

        public void GenereteProcessingRequest()
        {
            var processingRequests = new List<ProcessingRequest>();
         
            //for (int i = 0; i < 9043; i++)
            //{
            //    var tmp = new ProcessingRequest();

            //    tmp.Email = $"test{i}@email.com";
            //    tmp.Name = $"NameTest{i}";
            //    tmp.Phone = $"543-{i}";
            //    tmp.Surname = $"SurnameTest{i}";

            //    processingRequests.Add(tmp);
            //}
            //int count = processingRequests.Count;

            //for(int now =0; now <= count ; now+= 1000)
            //{
            //    int next = now + 1000;
            //    var tmp = processingRequests.GetRange(now, next);
            //   // _db.ProcessingRequests.AddRange();
            //}


        }

        public List<ProcessingRequest> GetProcessingRequestsOrder()
        {
           return _db.ProcessingRequests.TakeNotMatchingUsers();
        }

        public void ImportProcessingRequest(List<ProcessingRequest> requests)
        {

            _db.ProcessingRequests.ImportRange(requests);
        }

        public void RemoveAllReps()
        {
            _db.ProcessingRequests.RemoveReps();
        }


        public List<NotSpamUser> GetNotSpamUsers()
        {
            return _db.NotSpamUsers.GetAll();
        }

        public void ImportNotSpamUsers(List<NotSpamUser> requests)
        {
            _db.NotSpamUsers.AddRange(requests);
        }

        public void NotSpamUsersRemoveAllReps()
        {
            _db.NotSpamUsers.RemoveReps();
        }

        public void ProcessingRequestsClear()
        {
            _db.ProcessingRequests.RemoveAll();
        }

        public void NotSpamUsersClear()
        {
            _db.NotSpamUsers.RemoveAll();
        }

        public List<NotSpamUser> GetNotSpamUsersByEmail(string email)
        {
            return _db.NotSpamUsers.FindByEmail(email);
        }

        public List<NotSpamUser> GetNotSpamUsersByPhone(string phone)
        {
            return _db.NotSpamUsers.FindByPhone(phone);
        }

        public List<NotSpamUser> GetNotSpamUsersByName(string name)
        {
            return _db.NotSpamUsers.FindByName(name);
        }

        public List<NotSpamUser> GetNotSpamUsersBySurname(string surname)
        {
            return _db.NotSpamUsers.FindBySurname(surname);
        }


        public List<ProcessingRequest> GetProcessingRequestByEmail(string email)
        {
            return _db.ProcessingRequests.FindByEmail(email);
        }

        public List<ProcessingRequest> GetProcessingRequestByPhone(string phone)
        {
            return _db.ProcessingRequests.FindByPhone(phone);
        }

        public List<ProcessingRequest> GetProcessingRequestByName(string name)
        {
            return _db.ProcessingRequests.FindByName(name);
        }
        public List<ProcessingRequest> GetProcessingRequestBySurname(string surname)
        {
            return _db.ProcessingRequests.FindBySurname(surname);
        }

        public List<ProcessingRequest> GetProcessingRequestPagination(int start, int step)
        {
            return _db.ProcessingRequests.GetPagination(start, step);
        }

        public int ProcessingRequestCount()
        {
            return _db.ProcessingRequests.GetCount();
        }

        public List<NotSpamUser> GetNotSpamUserPagination(int start, int step)
        {
            return _db.NotSpamUsers.GetPagination(start, step);
        }

        public int NotSpamUsersCount()
        {
            return _db.NotSpamUsers.GetCount();
        }

        public Aggregator.Domain.Models.Сustomer GetCustomerById(string customerId)
        {
            return _db.Сustomers.FindById(customerId);
        }
    }
}
