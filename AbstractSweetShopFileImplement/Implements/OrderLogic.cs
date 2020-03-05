using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopFileImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly FileDataListSingleton source;

        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order element;
            if (model.Id.HasValue)
            {
                element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                    throw new Exception("Элемент не найден");
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
                element = new Order { Id = maxId + 1 };
                source.Orders.Add(element);
            }
            element.ProductId = model.ProductId == 0 ? element.ProductId : model.ProductId;
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.Status = model.Status;
            element.DateCreate = model.DateCreate;
            element.DateImplement = model.DateImplement;
        }

        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
                source.Orders.Remove(element);
            else
                throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            var products = source.Products;
            return source.Orders.Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    Count = rec.ProductId,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    ProductName = source.Products.FirstOrDefault(rec1 => rec.ProductId == rec1.Id).ProductName,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                })
                .ToList();
        }
    }
}
