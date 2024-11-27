using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private KPPContext db;
        private UserRepository userRepository;
        private ZoneRepository zoneRepository;
        private PassRepository passRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new KPPContext(options);
        }
        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IZoneRepository Zones
        {
            get
            {
                if (zoneRepository == null)
                    zoneRepository = new ZoneRepository(db);
                return zoneRepository;
            }
        }
        public IPassRepository Passes
        {
            get
            {
                if (passRepository == null)
                    passRepository = new PassRepository(db);
                return passRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
