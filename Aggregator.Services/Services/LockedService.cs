using Aggregator.Domain.Models;
using Aggregator.Repository.Repositories.Base;
using System;

namespace Aggregator.Services
{
    public class LockedService
    {
        private readonly DbRepository _db;
        public LockedService()
        {
            _db = new DbRepository();
        }

        public lockedIp GetLockedByIp(string ip)
        {
            return _db.lockedIps.FindByIp(ip);
        }

       
        public void RemoveLockedById(string id)
        {
            _db.lockedIps.RemoveById(id);
        }

        public lockedIp GetOrCreate(string ip)
        {
            lockedIp locked = _db.lockedIps.FindByIp(ip);
            // create
            if (locked == null)
            {

                locked = new lockedIp();
                locked.IpAddress = ip;
                locked.Counter = 1;
                locked.LokedTime = DateTime.Now.AddDays(1);
                _db.lockedIps.Add(locked);
            }
            return locked;
        }

        public lockedIp UpdateLoked(string ip)
        {
            lockedIp locked = _db.lockedIps.FindByIp(ip);
            // create
            if(locked == null)
            {

                locked = new lockedIp();
                locked.IpAddress = ip;
                locked.Counter = 1;
                locked.LokedTime = DateTime.Now.AddDays(1);
                _db.lockedIps.Add(locked);
                return locked;
            }

            //update
            if(locked.Counter < 3)
            {
                locked.Counter ++;
                _db.lockedIps.Update(locked);
                return locked;
            }

            // 
            if(locked.Counter >= 3 )
            {
                if(locked.LokedTime < DateTime.Now)
                {
                    locked.Counter = 1;
                    locked.LokedTime = DateTime.Now.AddDays(1);
                }
                if(locked.LokedTime >= DateTime.Now)
                {
                    locked.Counter ++;
                }
                _db.lockedIps.Update(locked);
            }

            return locked;
        }


    }
}
