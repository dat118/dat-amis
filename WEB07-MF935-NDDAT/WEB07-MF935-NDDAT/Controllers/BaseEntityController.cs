using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repo;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB07_MF935_NDDAT.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<MisaEntity> : ControllerBase
    {

        IBaseRepo<MisaEntity> _baseRepo;
        IBaseService<MisaEntity> _baseService;

        public BaseEntityController(IBaseRepo<MisaEntity> baseRepo, IBaseService<MisaEntity> baseService)
        {
            _baseRepo = baseRepo;
            _baseService = baseService;
        }
        #region Methods
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var entities = _baseRepo.GetAll();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.error_userMsg,
                    errorCode = Properties.Resources.error_code,
                    moreInfor = Properties.Resources.more_information,
                };
                return StatusCode(500, errorObj);
            }
        }

        [HttpGet("{misaEntityId}")]
        public IActionResult GetById(Guid misaEntityId)
        {
            try
            {
                var entity = _baseRepo.GetById(misaEntityId);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.error_userMsg,
                    errorCode = Properties.Resources.error_code,
                    moreInfor = Properties.Resources.more_information,
                };
                return StatusCode(500, errorObj);
            }
        }

        [HttpPost]
        public virtual IActionResult Add(MisaEntity misaEntity)
        {
            try
            {
                ServiceResult _serviceResult = _baseService.Add(misaEntity);
                if (_serviceResult.IsValid == true)
                {
                    var rowEffect = _baseRepo.Add(misaEntity);
                    return StatusCode(201);
                }
                else
                {
                    var errorObj = new
                    {

                        userMsg = _serviceResult.Message,
                        errorCode = Properties.Resources.error_code,
                        moreInfor = Properties.Resources.more_information,
                    };
                    return StatusCode(400, errorObj);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.error_userMsg,
                    errorCode = Properties.Resources.error_code,
                    moreInfor = Properties.Resources.more_information,
                };
                return StatusCode(500, errorObj);
            }
        }

        [HttpPut("{misaEntityId}")]
        public virtual IActionResult Update(MisaEntity misaEntity, Guid misaEntityId)
        {
            try
            {
                ServiceResult _serviceResult = _baseService.Update(misaEntity, misaEntityId);
                if (_serviceResult.IsValid == true)
                {
                    var rowEffect = _baseRepo.Update(misaEntity, misaEntityId);
                    return StatusCode(200);
                }
                else
                {
                    var errorObj = new
                    {

                        userMsg = _serviceResult.Message,
                        errorCode = Properties.Resources.error_code,
                        moreInfor = Properties.Resources.more_information,
                    };
                    return StatusCode(400, errorObj);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.error_userMsg,
                    errorCode = Properties.Resources.error_code,
                    moreInfor = Properties.Resources.more_information,
                };
                return StatusCode(500, errorObj);
            }
        }

        [HttpDelete("{misaEntityId}")]
        public IActionResult Delete(Guid misaEntityId)
        {
            try
            {
                var entity = _baseRepo.Delete(misaEntityId);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.error_userMsg,
                    errorCode = Properties.Resources.error_code,
                    moreInfor = Properties.Resources.more_information,
                };
                return StatusCode(500, errorObj);
            }
        }
        #endregion
    }
}
