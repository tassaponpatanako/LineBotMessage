using CommonServices;
using DataServices.Models;
using DataServices.Repository;
using MongoDB.Driver;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace LineMessage.Services
{
    public class NotifyService
    {
        private readonly MongoDBServices _mongoDBService;
        public NotifyService(MongoDBServices mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public async Task SendMessageNotify(string message)
        {
            try
            {
                var lineNotifyConfigs = await _mongoDBService.GetAllDocumentsAsync<LineNotifyConfig>();
                var config = lineNotifyConfigs.Where(c => c.Remaining > 10).FirstOrDefault();
                if (config == null)
                    config = lineNotifyConfigs.Where(c => c.ResetAt >= DateTime.UtcNow).FirstOrDefault();
                if (config == null)
                    config = lineNotifyConfigs.FirstOrDefault();
                if (config == null)
                    throw new Exception("ไม่พบข้อมูล LineNotify Config");
                LineNotifyExtension lineNotifyExtension = new(config?.AccessToken ?? "");
                var lineResponse = await lineNotifyExtension.SendMessageAsync(message, config?.NotificationDisabled.ToString() ?? "false");
                if (lineResponse.IsSuccessStatusCode)
                {
                    await updateNotify(config ?? new LineNotifyConfig(), lineResponse);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private async Task updateNotify(LineNotifyConfig lineNotifyConfig, HttpResponseMessage response)
        {
            try
            {
                var rateLimitRemaining = response.Headers.GetValues("X-RateLimit-Remaining").FirstOrDefault();
                var rateLimitReset = response.Headers.GetValues("X-RateLimit-Reset").FirstOrDefault();
                if (long.TryParse(rateLimitReset, out var unixTimestamp))
                {
                    var resetDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
                    var resetDateTime = resetDateTimeOffset.Date;
                    lineNotifyConfig.ResetAt = resetDateTime;
                }
                var filter = Builders<LineNotifyConfig>.Filter.Eq("Id", lineNotifyConfig.Id);
                var update = Builders<LineNotifyConfig>.Update.Set(x => x.Remaining, int.Parse(rateLimitRemaining ?? "0"))
                                                                     .Set(x => x.UpdateBy, "system")
                                                                     .Set(x => x.UpdateAt, DateTime.Now)
                                                                     .Set(x => x.ResetAt, lineNotifyConfig.ResetAt);
                await _mongoDBService.UpdateDocumentAsync<LineNotifyConfig>(filter, update);
            }
            catch
            {
                throw new Exception("ไม่สามารถอัพเดทข้อมูล LineNotify Config");
            }

        }
    }
}
