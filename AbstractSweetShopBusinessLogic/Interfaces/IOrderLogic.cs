using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
