using Stripe;

namespace ECommerceProject.Infrastructure.Services
{
    public class StripeService : IStripeService
    {
        private readonly IConfiguration _configuration;

        public StripeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreatePaymentIntentAsync(decimal amount)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            

            var service = new PaymentIntentService();

            var intent = await service.CreateAsync(new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = "usd"
            });

            return intent.ClientSecret;

        }
    }
}
