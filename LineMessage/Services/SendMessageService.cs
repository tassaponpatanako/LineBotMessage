using CommonServices;

namespace LineMessage.Services
{
    public class SendMessageService
    {
        private readonly LineNotifyExtension _lineNotifyExtension;
        public SendMessageService()
        {
            _lineNotifyExtension = new LineNotifyExtension("s8Ul8IAkKP3isG5eNimzyIzTrKHHBuxdd9xdJOSOhT7");
        }
    }
}
