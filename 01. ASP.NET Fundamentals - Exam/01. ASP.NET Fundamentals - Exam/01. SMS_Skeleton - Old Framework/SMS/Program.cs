namespace SMS
{
    using System.Threading.Tasks;
    using SMS.Data;
    using SUS.MvcFramework;

    public static class Program
    {
        public static async Task Main(string[] args)
        {
           
            await Host.CreateHostAsync(new Startup());
        }
    }
}