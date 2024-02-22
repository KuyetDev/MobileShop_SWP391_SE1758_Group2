using MobileShop.Entity.DTOs.OrderDTO;
using MobileShop.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Service
{

    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order? GetOrderById(int id);
        CreateOrderResponse AddOrder(CreateOrderRequest order);
        UpdateOrderResponse UpdateOrder(UpdateOrderRequest order);
        bool UpdateDeleteStatusOrder(int id);
        Order? GetOrderByCustomerId(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly FstoreContext _context;

        public OrderService(FstoreContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                var orders = _context.Orders.Where(o => o.IsDeleted == false)
                     .ToList();
                return orders;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Order? GetOrderById(int id)
        {
            try
            {
                var orders = _context.Orders.FirstOrDefault(o => o.IsDeleted == false && o.OrderId == id);
                if (orders != null)
                {
                    return orders;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Order? GetOrderByCustomerId(int id)
        {
            try
            {
                /*status
                 * 0: add to cart
                 * 1: checkout
                 * 2: shipping
                 * 3: complete
                 */
                var orders = _context.Orders.FirstOrDefault(o => o.IsDeleted == false
                                                            && o.CustomerId == id
                                                            && o.Status == 0
                                                            && o.ShippingDate == null
                                                            && o.RequiredDate == null);
                if (orders != null)
                {
                    return orders;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CreateOrderResponse AddOrder(CreateOrderRequest order)
        {
            try
            {
                var requestOrder = new Order
                {
                    CustomerId = order.CustomerId,
                    Address = order.Address,
                    CreateDate = order.CreateDate,
                    ShippingDate = order.ShippingDate,
                    RequiredDate = order.RequiredDate,
                    Status = order.Status,
                    PaymentId = order.PaymentId,
                    CouponId = order.CouponId,
                    IsDeleted = order.IsDeleted
                };
                _context.Orders.Add(requestOrder);
                _context.SaveChanges();
                return new CreateOrderResponse { IsSuccess = true, Message = "Add order complete" };
            }
            catch (Exception e)
            {
                return new CreateOrderResponse { IsSuccess = false, Message = $"Add order failed {e.Message}" };

            }
        }

        public UpdateOrderResponse UpdateOrder(UpdateOrderRequest order)
        {
            try
            {
                var requestOrder = new Order
                {
                    OrderId = order.OrderId,
                    CustomerId = order.CustomerId,
                    Address = order.Address,
                    CreateDate = order.CreateDate,
                    ShippingDate = order.ShippingDate,
                    RequiredDate = order.RequiredDate,
                    Status = order.Status,
                    PaymentId = order.PaymentId,
                    CouponId = order.CouponId,
                    IsDeleted = order.IsDeleted
                };
                _context.Update(requestOrder);
                _context.SaveChanges();
                return new UpdateOrderResponse { IsSuccess = true, Message = "Update order complete" };
            }
            catch (Exception e)
            {
                return new UpdateOrderResponse { IsSuccess = false, Message = $"Update order failed {e.Message}" };
            }
        }

        public bool UpdateDeleteStatusOrder(int id)
        {
            try
            {
                var order = GetOrderById(id);
                if (order == null)
                {
                    return false;
                }
                order.IsDeleted = true;
                _context.Update(order);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
    }
