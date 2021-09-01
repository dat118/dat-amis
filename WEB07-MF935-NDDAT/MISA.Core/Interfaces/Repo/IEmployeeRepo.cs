using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repo
{
    public interface IEmployeeRepo :IBaseRepo<Employee>
    {   
        /// <summary>
        /// Phân trang, tìm kiếm
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchFilter"></param>
        /// <returns>Các nhân viên thỏa mãn</returns>
        List<Employee> Pagination(int pageIndex, int pageSize, string searchFilter);
        /// <summary>
        /// lấy mã code tự động mới
        /// </summary>
        /// <returns>Mã code mới</returns>
        string GetNewCode();
    }
}
