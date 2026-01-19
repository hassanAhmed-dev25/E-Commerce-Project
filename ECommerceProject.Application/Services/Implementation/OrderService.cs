using ECommerceProject.Application.DTOs.CartItem;
using ECommerceProject.Application.DTOs.Order;
using ECommerceProject.Domain.Entities;
using ECommerceProject.Domain.Enums;
using System.Security.Claims;

namespace ECommerceProject.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        private async Task<int> CreateOrder(PlaceOrderDto order)
        {
            // Calculate Total Price
            decimal totalPrice = 0m;
            foreach (var item in order.CartItemsDto)
            {
                var product = await _unitOfWork.Products.GetAsync(x => x.Id == item.ProductId);
                totalPrice += product.Price * item.Quantity;
            }

            var newOrder = new Order
            {
                TotalAmount = totalPrice,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UserId = order.UserId,
            };

            // Create Order
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.SaveChangesAsync();

            // Get Order ID

            return newOrder.Id;
        }
        private async Task CreateOrderItems(IEnumerable<CartItemDto> cartItems, int newOrderId)
        {
            // Get IDs all products in cart
            var productIds = cartItems.Select(ci => ci.ProductId).ToList();

            // Get all products in cart
            var products = await _unitOfWork.Products.GetAllAsync(p => productIds.Contains(p.Id));



            var newOrderItems = cartItems.Select( ci =>
            {
                var product = products.FirstOrDefault(p => p.Id == ci.ProductId);

                return new OrderItem
                {
                    Quantity = ci.Quantity,
                    UnitPrice = product.Price,

                    OrderId = newOrderId,
                    ProductId = product.Id,
                    SellerId = product.CreatedBy,

                };

            }).ToList();

            // Create OrderItems
            await _unitOfWork.OrderItems.AddRangeAsync(newOrderItems);

        }
        private async Task CreateShippingAddress(ShippingAddressDto shippingAddress, int newOrderId)
        {
            var entity = new ShippingAddress
            {
                Address = shippingAddress.Address,
                Apartment = shippingAddress.Apartment,
                City = shippingAddress.City,
                Street = shippingAddress.Street,
                OrderId = newOrderId

            };

            await _unitOfWork.ShippingAddresses.AddAsync(entity);

        }


        public async Task PlaceOrderAsync(PlaceOrderDto order)
        {

            try
            {

                // 1) Create Order
                int newOrderId = await CreateOrder(order);



                // 2) Create Order Items
                await CreateOrderItems(order.CartItemsDto, newOrderId);



                // 3) Create ShippingAddress
                await CreateShippingAddress(order.ShippingAddressDto, newOrderId);

                // Save
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }


        public Task<GetOrderDto> GetOrderAsync(int orderId)
        {
            
        }

        public Task CancelOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }


        
    }
}
