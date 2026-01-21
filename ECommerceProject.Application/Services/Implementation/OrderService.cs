using ECommerceProject.Application.DTOs.CartItem;
using ECommerceProject.Application.DTOs.Order;
using ECommerceProject.Domain.Entities;
using ECommerceProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;
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



        private async Task<int> CreateOrder(string userId, IEnumerable<CartItem> cartItems, IEnumerable<Product> products)
        {
            // Calculate Total Price
            decimal totalPrice = 0m;
            foreach (var item in cartItems)
            {
                var product = products.First(p => p.Id == item.ProductId);
                totalPrice += product.Price * item.Quantity;
            }

            var newOrder = new Order
            {
                TotalAmount = totalPrice,
                OrderStatus = OrderStatus.Created,
                PaymentStatus = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UserId = userId,
            };

            // Create Order
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.SaveChangesAsync();


            // Get Order ID
            return newOrder.Id;
        }
        private async Task CreateOrderItems(IEnumerable<CartItem> cartItems, int newOrderId, IEnumerable<Product> products)
        {


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
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // Get cart items
                var cartItems = await _unitOfWork.CartItems.GetAllAsync(ci => order.CartItemIds.Contains(ci.Id));

                if (!cartItems.Any())
                    throw new Exception("No cart items selected");


                // Get products
                var productIds = cartItems.Select(ci => ci.ProductId).Distinct().ToList();

                var products = await _unitOfWork.Products.GetAllAsync(p => productIds.Contains(p.Id));



                // ----------------------------------------------------------------------------------------

                // 1) Create Order
                int newOrderId = await CreateOrder(order.UserId, cartItems, products);



                // 2) Create Order Items
                await CreateOrderItems(cartItems, newOrderId, products);



                // 3) Create ShippingAddress
                await CreateShippingAddress(order.ShippingAddressDto, newOrderId);

                // Save
                await _unitOfWork.SaveChangesAsync();



                // Commit
                await _unitOfWork.CommitAsync();

            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

        }


        public async Task<GetOrderDto> GetOrderAsync(int orderId)
        {
            try
            {

                var order = await _unitOfWork.Orders.GetAsync(o => o.Id == orderId, 
                                                       q => q.Include(o => o.OrderItems)
                                                                           .Include(o => o.ShippingAddress));


                if(order == null)
                    throw new Exception("Order not found");


                return new GetOrderDto
                {
                    Id = order.Id,
                    CreatedAt = order.CreatedAt,
                    Status = order.OrderStatus,
                    TotalAmount = order.TotalAmount,

                    Items = order.OrderItems.Select(oi => new GetOrderItemDto
                    {
                        ProductId = oi.ProductId,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice

                    }).ToList(),

                    ShippingAddress = new GetShippingAddressDto
                    {
                        City = order.ShippingAddress.City,
                        Street = order.ShippingAddress.Street,
                        Address = order.ShippingAddress.Address
                    }

                };

            }
            catch (Exception)
            {
                throw;
            }
            

        }


        public async Task CancelOrderAsync(int orderId)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetAsync(o => o.Id == orderId);

                if (order == null)
                    throw new Exception("Order not found");

                if (order.OrderStatus == OrderStatus.Cancelled)
                    return;

                if (order.OrderStatus == OrderStatus.Shipped)
                    throw new Exception("Cannot cancel shipped order");

                order.OrderStatus = OrderStatus.Cancelled;



                await _unitOfWork.SaveChangesAsync();

            }
            catch(Exception)
            {
                throw;
            }


        }


        
    }
}
