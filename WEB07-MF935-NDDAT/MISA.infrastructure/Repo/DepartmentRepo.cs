using MISA.Core.Entities;
using MISA.Core.Interfaces.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.infrastructure.Repo
{
    class DepartmentRepo : IDepartmentRepo
    {
        public int Add(Department misaEntity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid misaEntityId)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetByCode(string misaEntityCode)
        {
            throw new NotImplementedException();
        }

        public Department GetById(Guid misaEntityID)
        {
            throw new NotImplementedException();
        }

        public int Update(Department misaEntity, Guid misaEntityId)
        {
            throw new NotImplementedException();
        }
    }
}
