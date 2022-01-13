namespace Crypto
{
    public class Password
    {
        public string hint { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Password(string h, string u, string p)
        {
            hint = h;
            username = u;
            password = p;
        }
    }
}