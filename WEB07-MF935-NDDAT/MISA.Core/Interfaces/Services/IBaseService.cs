using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<MisaEntity>
    {   /// <summary>
    ///Kiểm tra dữ liệu khi thêm mới
    /// </summary>
    /// <param name="misaEntity"></param>
    /// <returns></returns>
        ServiceResult Add(MisaEntity misaEntity);
        /// <summary>
        ///Kiểm tra dữ liệu khi thay đổi
        /// </summary>
        /// <param name="misaEntity"></param>
        /// <param name="misaEntityId"></param>
        /// <returns></returns>
        ServiceResult Update(MisaEntity misaEntity, Guid misaEntityId);
    }
}
