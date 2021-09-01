using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repo
{
    public interface IBaseRepo<MisaEntity>
    {   /// <summary>
        /// Lấy tất cả 
        /// </summary>
        /// <returns>Toàn bộ dữ liệu</returns>
        List<MisaEntity> GetAll();
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="misaEntity"></param>
        /// <returns></returns>
        int Add(MisaEntity misaEntity);
        /// <summary>
        /// Chỉnh sửa
        /// </summary>
        /// <param name="misaEntity"></param>
        /// <param name="misaEntityId"></param>
        /// <returns></returns>
        int Update(MisaEntity misaEntity, Guid misaEntityId);
        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="misaEntityId"></param>
        /// <returns></returns>
        int Delete(Guid misaEntityId);
        /// <summary>
        /// Tìm kiếm bằng ID
        /// </summary>
        /// <param name="misaEntityID"></param>
        /// <returns>Thông tin bản ghi</returns>
        MisaEntity GetById(Guid misaEntityID);
        /// <summary>
        /// Tìm kiếm nhân viên theo CODE
        /// </summary>
        /// <param name="misaEntityCode"></param>
        /// <returns>Thông tin nhân viên</returns>
        MisaEntity GetByCode(string misaEntityCode);
    }
}
