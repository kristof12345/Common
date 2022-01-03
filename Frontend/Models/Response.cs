namespace Common.Web
{
    public class Response
    {
        public static readonly Response Success = new Response(true);

        public string Content { get; init; }

        public bool IsSuccess { get; init; }

        public Response()
        {
            IsSuccess = false;
        }

        public Response(string content)
        {
            Content = content;
            IsSuccess = false;
        }

        public Response(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
