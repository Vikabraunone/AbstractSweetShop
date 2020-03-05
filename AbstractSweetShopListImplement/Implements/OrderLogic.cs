using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace AbstractSweetShopListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;

        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order { Id = 1 };
            foreach (var order in source.Orders)
            {
                if (!model.Id.HasValue && order.Id >= tempOrder.Id)
                    tempOrder.Id = order.Id + 1;
                else if (model.Id.HasValue && order.Id == model.Id)
                    tempOrder = order;
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                    throw new Exception("Элемент не найден");
                CreateModel(model, tempOrder);
            }
            else
                source.Orders.Add(CreateModel(model, tempOrder));
        }

        public void Delete(OrderBindingModel model)
        {
            // удаляем записи по ингредиентам и изделиям при удалении заказа
            for (int i = 0; i < source.ProductIngredients.Count; ++i)
                if (source.ProductIngredients[i].ProductId == model.Id)
                    source.ProductIngredients.RemoveAt(i--);
            for (int i = 0; i < source.Products.Count; ++i)
                if (source.Products[i].Id == model.Id)
                    source.Products.RemoveAt(i--);
            for (int i = 0; i < source.Products.Count; ++i)
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (model != null)
                {
                    if (order.Id == model.Id)
                    {
                        result.Add(CreateViewModel(order));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(order));
            }
            return result;
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ProductId = model.ProductId;
            order.Sum = model.Sum;
            order.DateCreate = model.DateCreate;
            order.Count = model.Count;
            order.DateImplement = model.DateImplement;
            order.Status = model.Status;
            return order;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            string productName = "";
            foreach (var product in source.Products)
                if (product.Id == order.ProductId)
                    productName = product.ProductName;
            return new OrderViewModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                ProductName = productName,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}