using Dapper;
using MISA.Core.Interfaces.Repo;
using MISA.infrastructure.MISAAttributes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.infrastructure.Repo
{
    public class BaseRepo<MisaEntity> : IBaseRepo<MisaEntity>
    {
        public int Add(MisaEntity misaEntity)
        {

            var className = typeof(MisaEntity).Name;
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = Resource.connectionStringDb;

            using (IDbConnection dbConnetion = new MySqlConnection(connectionString))
            {
                // khởi tạo đối tượng kết nối với database


                // Khái báo parameters
                DynamicParameters parameters = new DynamicParameters();

                // Thêm dữ liệu vào database
                var colummsName = string.Empty;
                var colummsParam = string.Empty;

                // Đọc property của từng object
                var properties = misaEntity.GetType().GetProperties();

                // Duyệt từng property
                foreach (var prop in properties)
                {
                    // Lấy tên của property
                    var propName = prop.Name;

                    // Lấy value của prop
                    var propValue = prop.GetValue(misaEntity);

                    // Lay ID moi
                    if (propName == $"{className}Id" && prop.PropertyType == typeof(Guid))
                    {
                        propValue = Guid.NewGuid();
                    }

                    // Lấy kiểu dữ liệu
                    var propType = prop.PropertyType;

                    // Thêm dữ liệu vào parameter
                    /*var MisaNotMap = prop.GetCustomAttributes(typeof(MISANotMap), true).ToString();
                    if (propName != MisaNotMap)
                    {*/
                    parameters.Add($"@{propName}", propValue);

                    colummsName += $"{propName},";
                    colummsParam += $"@{propName},";
                /*}*/

                }
                colummsName = colummsName.Remove(colummsName.Length - 1, 1);
                colummsParam = colummsParam.Remove(colummsParam.Length - 1, 1);
                var sqlCommand = $"INSERT INTO {className} ({colummsName}) VALUES ({colummsParam})";

                var rowEffects = dbConnetion.Execute(sqlCommand, param: parameters);
                return rowEffects;

            }


        }

        public int Delete(Guid misaEntityId)
        {
            var className = typeof(MisaEntity).Name;
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = Resource.connectionStringDb;

            // khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnetion = new MySqlConnection(connectionString))
            {

                // Lấy dữ liệu
                var sqlCommand = $"DELETE from {className} WHERE {className}Id = @entityParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@entityParam", misaEntityId);
                var rowEffects = dbConnetion.Execute(sqlCommand, param: parameters);
                return rowEffects;
            }
        }

        public List<MisaEntity> GetAll()
        {
            var className = typeof(MisaEntity).Name;
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = Resource.connectionStringDb;

            // khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnetion = new MySqlConnection(connectionString))
            {

                // Lấy dữ liệu
                var sqlCommand = $"SELECT * from {className}";
                var entities = dbConnetion.Query<MisaEntity>(sqlCommand);
                return entities.ToList();
            }
        }

        public MisaEntity GetById(Guid misaEntityId)
        {
            var className = typeof(MisaEntity).Name;
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = Resource.connectionStringDb;

            // khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnetion = new MySqlConnection(connectionString))
            {

                // Lấy dữ liệu
                var sqlCommand = $"SELECT * from {className} WHERE {className}Id = @entityParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@entityParam", misaEntityId);
                MisaEntity entity = (MisaEntity)dbConnetion.QueryFirstOrDefault<MisaEntity>(sqlCommand, param: parameters);
                return entity;
            }
        }

        public int Update(MisaEntity misaEntity, Guid misaEntityId)
        {
            var className = typeof(MisaEntity).Name;
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = Resource.connectionStringDb;

            // khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnetion = new MySqlConnection(connectionString))
            {

                // Khái báo parameters
                DynamicParameters parameters = new DynamicParameters();

                // Thêm dữ liệu vào database
                /*var colummsName = string.Empty;
                var colummsParam = string.Empty;*/
                var sqlUpdate = string.Empty;

                // Đọc property của từng object
                var properties = misaEntity.GetType().GetProperties();

                // Duyệt từng property
                foreach (var prop in properties)
                {
                    // Lấy tên của property
                    var propName = prop.Name;

                    // Lấy value của prop
                    var propValue = prop.GetValue(misaEntity);

                    // Lấy kiểu dữ liệu
                    var propType = prop.PropertyType;

                    // Thêm dữ liệu vào parameter
                    /*var MisaNotMap = prop.GetCustomAttributes(typeof(MISANotMap), true).ToString();
                    if (propName != MisaNotMap)
                    {*/
                        parameters.Add($"@{propName}", propValue);
                        sqlUpdate += $"{propName} = @{propName},";

                    /*}*/

                }

                sqlUpdate = sqlUpdate.Remove(sqlUpdate.Length - 1, 1);
                var sqlCommand = $"UPDATE {className} SET {sqlUpdate} WHERE {className}Id = @entityParam";
                parameters.Add("@entityParam", misaEntityId);
                var rowEffects = dbConnetion.Execute(sqlCommand, param: parameters);
                return rowEffects;
            }
        }

        public MisaEntity GetByCode(string misaEntityCode)
        {
            var className = typeof(MisaEntity).Name;
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = Resource.connectionStringDb;

            // khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnetion = new MySqlConnection(connectionString))
            {

                // Lấy dữ liệu
                var sqlCommand = $"SELECT * from {className} WHERE {className}Code = @entityParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@entityParam", misaEntityCode);
                MisaEntity entity = (MisaEntity)dbConnetion.QueryFirstOrDefault<MisaEntity>(sqlCommand, param: parameters);
                return entity;
            }
        }

    }
}
