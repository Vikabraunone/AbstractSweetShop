using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Enums;
using AbstractSweetShopBusinessLogic.Interfaces;
using System;

namespace AbstractSweetShopBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;

        private readonly IStoreHouseLogic storeHouseLogic;

        public MainLogic(IOrderLogic orderLogic, IStoreHouseLogic storeHouseLogic)
        {
            this.orderLogic = orderLogic;
            this.storeHouseLogic = storeHouseLogic;
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                ProductId = model.ProductId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
                throw new Exception("Не найден заказ");
            if (order.Status != OrderStatus.Принят)
                throw new Exception("Заказ не в статусе \"Принят\"");
            if (storeHouseLogic.IsIngredientsAvailable(order.ProductId, order.Count))
            {
                storeHouseLogic.SubtractIngredients(order.ProductId, order.Count);
                orderLogic.CreateOrUpdate(new OrderBindingModel
                {
                    Id = order.Id,
                    ProductId = order.ProductId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = DateTime.Now,
                    Status = OrderStatus.Выполняется
                });
            }
            else
                throw new Exception("Для выполнения заказа не хватает ингредиентов");
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
                throw new Exception("Не найден заказ");
            if (order.Status != OrderStatus.Выполняется)
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
                throw new Exception("Не найден заказ");
            if (order.Status != OrderStatus.Готов)
                throw new Exception("Заказ не в статусе \"Готов\"");
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }

        public void AddIngredientInStoreHouse(StoreHouseIngredientBindingModel model)
        {
            storeHouseLogic.AddIngredient(model);
        }
    }
}