using MISA.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Employee : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính      
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [MISARequire, MISACode]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        [MISARequire]
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính (int)
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Email cá nhân
        /// </summary>
        [MISAEmail]
        public String? Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public String? PhoneNumber { get; set; }
        /// <summary>
        /// CMND/CCCD
        /// </summary>
        public string? IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string? IdentityPlace { get; set; }
        /// <summary>
        /// Điện thoại cố định
        /// </summary>
        public string? ConstantNumber { get; set; }
        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        public string? BankAccount { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }
        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string? BankAddress { get; set; }
        /// <summary>
        /// ID phòng ban
        /// </summary>
        [MISARequire]
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Vị trí
        /// </summary>
        public string? PositionName { get; set; }
        #endregion
    }
}
