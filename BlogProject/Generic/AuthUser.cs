namespace BlogProject.Generic
{
    public class AuthUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public List<string> Roles { get; set; }
        public AuthUser()
        {
            Roles = new List<string>();
        }
    }
}
