namespace Mango.Web.Models
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; } = true;
        public object  Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
