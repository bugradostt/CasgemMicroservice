using CasgemMicroservice.Services.Cargo.DataAccessLayer.Abstract;
using CasgemMicroservice.Services.Cargo.DataAccessLayer.Concrete;
using CasgemMicroservice.Services.Cargo.DataAccessLayer.Repository;
using CasgemMicroservice.Services.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoStateDal : GenericRepository<CargoState>, ICargoStateDal
    {
        public EfCargoStateDal(CargoContext cargoContext) : base(cargoContext)
        {
        }
    }
}
