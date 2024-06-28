namespace API.Model
{
    public class DeleteUserResponse
    {
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public bool Succeeded { get; set; }
    }
}
