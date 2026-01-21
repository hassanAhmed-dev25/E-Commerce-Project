
namespace ECommerceProject.Application.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IStripeService _stripeService;
        public PaymentService(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }



        public async Task<Response<bool>> StartPaymentAsync(decimal amount)
        {
            try
            {

                var clientSecret = await _stripeService.CreatePaymentIntentAsync(amount);


                return new Response<bool>(true, null, true);
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
