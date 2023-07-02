using AutoMapper;
using DataServices.Models;
using DataServices.Repository;
using LineMessage.DTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LineMessage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MongoDBServices _mongoDBService;
        public ConfigsController(IMapper mapper, MongoDBServices mongoDBService)
        {
            _mapper = mapper;
            _mongoDBService = mongoDBService;
        }
        [HttpPost("notify")]
        public async Task<IActionResult> InsertNotify(LineNotifyConfigRequest request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                await _mongoDBService.InsertDocumentAsync<LineNotifyConfig>(_mapper.Map<LineNotifyConfig>(request));
            }
            catch (Exception ex)
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.StatusText = ex.Message;
            }
            return StatusCode(response.Status, response);
        }
        [HttpPut("notify/{id}")]
        public async Task<IActionResult> UpdateNotify(string id, LineNotifyConfigRequestUpdate request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var filter = Builders<LineNotifyConfig>.Filter.Eq("Id", id);
                var update = Builders<LineNotifyConfig>.Update.Set(x => x.AccessToken, request.AccessToken)
                                                              .Set(x => x.NotifyName, request.NotifyName)
                                                              .Set(x => x.UpdateBy, "system")
                                                              .Set(x => x.UpdateAt, DateTime.Now)
                                                              .Set(x => x.NotificationDisabled, request.NotificationDisabled);
                var date = await _mongoDBService.FindOneAndUpdateDocumentAsync<LineNotifyConfig>(filter, update);
                if (date == null)
                {
                    response.Status = StatusCodes.Status404NotFound;
                    response.StatusText = "ไม่พบข้อมูลในระบบ";
                }
            }
            catch (Exception ex)
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.StatusText = ex.Message;
            }
            return StatusCode(response.Status, response);
        }
        [HttpDelete("notify/{id}")]
        public async Task<IActionResult> DeleteNotify(string id)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                var filter = Builders<LineNotifyConfig>.Filter.Eq("Id", id);
                await _mongoDBService.DeleteDocumentAsync<LineNotifyConfig>(filter);
            }
            catch (Exception ex)
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.StatusText = ex.Message;
            }
            return StatusCode(response.Status, response);
        }
    }
}
