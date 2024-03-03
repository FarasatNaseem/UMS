namespace UMS.Api.DTOs
{
    public class Response
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Error? Error { get; set; }
    }
}