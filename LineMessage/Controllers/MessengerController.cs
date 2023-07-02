using DataServices;
using DataServices.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using DataServices.Repository;
using AutoMapper;
using LineMessage.DTO;
using LineMessage.Services;

namespace LineMessage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessengerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MongoDBServices _mongoDBService;
        private readonly NotifyService _notifyService;
        public MessengerController(IMapper mapper, MongoDBServices mongoDBService)
        {
            _mapper = mapper;
            _mongoDBService = mongoDBService;
            _notifyService = new NotifyService(mongoDBService);
        }
        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook(WebHookRequset request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                await _mongoDBService.InsertDocumentAsync<WebHookMessage>(_mapper.Map<WebHookMessage>(request));

            }
            catch (Exception ex)
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.StatusText = ex.ToString();
            }
            return StatusCode(response.Status, response);
        }
        [HttpPost("sendnotifymessage")]
        public async Task<IActionResult> SendNotifyMessage(string message)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                await _notifyService.SendMessageNotify(message);
            }
            catch (Exception ex)
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.StatusText = ex.ToString();
            }
            return StatusCode(response.Status, response);
        }
    }
}
