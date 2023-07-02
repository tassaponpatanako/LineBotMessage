using Amazon.Runtime.Internal;
using DataServices.Repository;
using LineMessage.DTO;

namespace LineMessage.Services
{
    public class ReplyService
    {
        private readonly MongoDBServices _mongoDBService;
        public ReplyService(MongoDBServices mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }
        //public async Task ReplyMessage(WebHookRequset requset)
        //{
        //    requset.Events?.ForEach(c =>
        //    {
        //        if (c?.Message?.Text == "ตอบกลับหน่อย")
        //        {
        //            _notifyService.SendMessageNotify("ตอบแล้วน้า").GetAwaiter().GetResult();
        //        }
        //    });
        //}
    }
}
