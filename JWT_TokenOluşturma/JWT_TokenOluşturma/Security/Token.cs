namespace JWT_TokenOluşturma.Security
{
    public class Token
    {

        public string AccsessToken { get; set; }
        public string RefreshToken { get; set; } //Uygulamayı kullanann birinin süresi bitmişse uygulamanın yeniden devam etmesi için tekrar token oluşturur. 

        public DateTime Expiration { get; set; }
    }
}
