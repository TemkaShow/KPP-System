using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class PassService
        : IPassService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        public PassService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<PassDTO> GetPasses(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            var id = user.Id;
            var passEntities =
                _database
                .Passes
                .Find(z => z.UserId == id, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Pass, PassDTO>()
                    ).CreateMapper();
            var passDto =
                mapper
                    .Map<IEnumerable<Pass>, List<PassDTO>>(
                        passEntities);
            return passDto;
        }
    }

}
