namespace MomokoBlog.Web.Models
{
    public class UploadSuccess
    {
        public int Uploaded { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
