namespace Crypto
{
    public class Password
    {
        public string hint { get; set; }
        public string password { get; set; }

        public Password(string h, string p)
        {
            hint = h;
            password = p;
        }
    }
}