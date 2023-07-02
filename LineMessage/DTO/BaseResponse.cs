namespace LineMessage.DTO
{
    public class BaseResponse
    {
        public int Status { get; set; } = 200;
        public string? StatusText { get; set; } = "success";
        public string? RequestID { get; set; } = Guid.NewGuid().ToString();
    }
}
