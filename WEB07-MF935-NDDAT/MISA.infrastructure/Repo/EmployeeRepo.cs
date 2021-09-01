using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repo;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.infrastructure.Repo
{
    public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
    {
        public string GetNewCode()
        {
            
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = Resource.connectionStringDb;

            // khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnetion = new MySqlConnection(connectionString))
            {

                // Lấy dữ liệu
                var sqlCommand = "CALL Proc_GetNewEmployeeCode";
                var newCode = dbConnetion.QueryFirstOrDefault<String>(sqlCommand);
                return newCode;
            }
        }

        public List<Employee> Pagination(int pageIndex, int pageSize, string searchFilter)
        {   /*var totalRecord = 0 ;
            var totalPage = 0 ;*/

            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = Resource.connectionStringDb;

            // khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnetion = new MySqlConnection(connectionString))
            {

                // Lấy dữ liệu
                var sqlCommand = $"CALL Proc_GetEmployeesFilterPaging('{searchFilter}',{pageIndex},{pageSize},@totalRecord,@totalPage)";
                var employees = dbConnetion.Query<Employee>(sqlCommand);
                return employees.ToList();
            }
        }
    }
}
