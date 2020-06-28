using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Enums;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                        throw new Exception("Элемент не найден");
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.ClientId = model.ClientId.Value;
                element.ProductId = model.ProductId;
                element.ImplementerId = model.ImplementerId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id); ;
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                    throw new Exception("Элемент не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                return context.Orders
                    .Where(rec => model == null || rec.Id == model.Id ||
                        rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo
                        || rec.ClientId == model.ClientId
                        || model.FreeOrders.HasValue && model.FreeOrders.Value && !rec.ImplementerId.HasValue
                        || model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId
                        && rec.Status == OrderStatus.Выполняется)
                    .Include(rec => rec.Product)
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        ClientId = rec.ClientId,
                        ClientFIO = rec.Client.ClientFIO,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        ProductId = rec.ProductId,
                        ProductName = rec.Product.ProductName,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                        ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                        ImplementerId = rec.ImplementerId
                    })
                    .ToList();
            }
        }
    }
}