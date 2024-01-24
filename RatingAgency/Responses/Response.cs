namespace RatingAgency.Responses
{
    public class Response
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public int Status { get; set; } = StatusCodes.Status200OK;
    }
}
