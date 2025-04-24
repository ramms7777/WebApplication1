namespace WebApplication1.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }



    public class home
    {
        public string homeparam { get; set; }
        public string autoparam { get; set; }
    }
}
