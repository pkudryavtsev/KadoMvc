using AutoMapper;
using DAL;
using DAL.Repository.Boxes;
using DAL.Repository.Orders;
using DAL.Repository.Products;
using OrderDb.DataClasses;
using ProductDb.DataClasses;
using Services.Dtos;
using Services.Dtos.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService
    {
        private readonly Repo _repo;
        private readonly IMapper _mapper;
        private readonly ShoppingCartService _shoppingCartService;

        public OrderService(Repo repo, IMapper mapper, ShoppingCartService shoppingCartService)
        {
            _repo = repo;
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<bool> AddOrder(OrderDto orderToCreate, string email)
        {
            var address = _mapper.Map<AddressDto, Address>(orderToCreate.UserAddress);

            var shoppingCart = await _shoppingCartService.GetShoppingCartAsync(orderToCreate.ShoppingCartId);

            var orderItems = new List<OrderItem>();
            foreach (var item in shoppingCart.Items)
            {
                if (item.IsCustom is true)
                {
                    var orderProducts = new List<OrderProduct>();
                    foreach (var productId in item.ProductIds)
                    {
                        var product = await _repo.GetProductById(productId);
                        var orderProduct = new OrderProduct { Name = product.Name, PictureUrl = product.PictureUrl, ProductId = product.Id };
                        orderProducts.Add(orderProduct);
                    }
                    var orderItem = new OrderItem { BoxId = item.Id, BoxName = item.BoxName, OrderProducts = orderProducts, Quantity = item.Quantity, Price = item.Price };
                    orderItems.Add(orderItem);
                }
                else
                {
                    var orderProducts = (await _repo.GetProductsByBoxId(item.Id)).Select(p => new OrderProduct { ProductId = p.Id, Name = p.Name, PictureUrl = p.PictureUrl}).ToList();
                    var orderItem = new OrderItem {  BoxId = item.Id, BoxName = item.BoxName , OrderProducts = orderProducts, Quantity = item.Quantity, Price = item.Price };
                    orderItems.Add(orderItem);
                }
            }

            var total = orderItems.Sum(item => item.Price * item.Quantity);

            var order = new Order { OrderItems = orderItems, UserAddress = address, UserEmail = email, Total = total, Status = OrderStatus.Pending };

            var isAdded = await _repo.CreateOrder(order);

            await _shoppingCartService.DeleteShoppingCartAsync(orderToCreate.ShoppingCartId);

            return isAdded;
        }

        public async Task<IReadOnlyList<OrdersForUserDto>> GetOrdersForUser(string userEmail)
        {
            var orders = await _repo.GetOrdersForUser(userEmail);

            var ordersForUser = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrdersForUserDto>>(orders);

            return ordersForUser;
        }

        public async Task<OrderDetailsToReturnDto> GetOrderDetailsForUser(int id)
        {
            var order = await _repo.GetOrderById(id);

            var orderToReturn = _mapper.Map<Order, OrderDetailsToReturnDto>(order);

            return orderToReturn;
        }
    }
}
