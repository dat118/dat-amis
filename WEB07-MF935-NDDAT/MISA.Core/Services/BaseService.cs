using MISA.Core.Attributes;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repo;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<MisaEntity> : IBaseService<MisaEntity>
    {
        IBaseRepo<MisaEntity> _baseRepo;
        ServiceResult _serviceResult;

        public BaseService(IBaseRepo<MisaEntity> baseRepo)
        {
            _baseRepo = baseRepo;
            _serviceResult = new ServiceResult();
        }
        /// <summary>
        /// Kiểm tra dữ liệu đầu vào
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Validation(MisaEntity entity)
        {
            var isValid = true;
            // Thuc hien validate
            var properties = typeof(MisaEntity).GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(entity);
                var propName = prop.Name;
                // Lấy các trường bắt buộc
                var MisaRequire = prop.GetCustomAttributes(typeof(MISARequire), true);
                // Lấy trường Email
                var MisaEmail = prop.GetCustomAttributes(typeof(MISAEmail), true);
                // Lấy trường Mã nhân viên
                var MisaCode = prop.GetCustomAttributes(typeof(MISACode), true);
                /// Thực hiện validate những trường bắt buộc
                if (MisaRequire.Length > 0)
                {
                    if (prop.PropertyType == typeof(string) && propValue.ToString() == string.Empty)
                    {
                        isValid = false;
                        _serviceResult.Message = "Những thông tin bắt buộc không được phép để trống. ";
                        /*return false;*/
                    }
                }
                // Thực hiện validate Email
                if (MisaEmail.Length > 0)
                {
                    if (propValue != null)
                    {
                        var formatEmail = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                        var isMatch = Regex.IsMatch(propValue.ToString(), formatEmail, RegexOptions.IgnoreCase);
                        if (isMatch == false)
                        {
                            isValid = false;
                            _serviceResult.Message += "Email không hợp lệ. ";
                            /*return false;*/
                        }
                    }
                }
                // Kiểm tra có trùng mã hay không
                if (MisaCode.Length > 0)
                {
                    var availableCode = _baseRepo.GetByCode(propValue.ToString());
                    if (availableCode != null)
                    {
                        isValid = false;
                        _serviceResult.Message += "Trùng mã nhân viên. ";
                    }
                }

            }
            return isValid;

        }

        public ServiceResult Add(MisaEntity misaEntity)
        {
            _serviceResult.IsValid = Validation(misaEntity);
            return _serviceResult;
        }



        public ServiceResult Update(MisaEntity misaEntity, Guid misaEntityId)
        {
            _serviceResult.IsValid = Validation(misaEntity);
            return _serviceResult;
        }

    }
}
