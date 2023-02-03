namespace MobileBankingWebApi.Services
{
    public class StaticData
    {
        public StaticData(Decrypter decrypter, IConfiguration configuration)
        {
            string password = decrypter.DecryptAes("bf4cab898a4eh136bb6e23a2r15ab916", "Ku51I4GbD8TheurfFkaI2g==");
            ConnectionString = configuration.GetConnectionString("DefaultConnection").Replace("##", password);
        }
        public string ConnectionString { get; set; }
    }
}
