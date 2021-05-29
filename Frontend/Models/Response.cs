namespace Common.Web
{
    public class Response
    {
        public static readonly Response Success = new Response();

        public string Content { get; set; }

        public Response(string content = null)
        {
            Content = content;
        }

        public bool IsSuccess { get { return Content == null; } }
    }
}
