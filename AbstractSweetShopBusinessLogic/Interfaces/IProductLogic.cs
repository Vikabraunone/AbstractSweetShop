using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> Read(ProductBindingModel model);
        void CreateOrUpdate(ProductBindingModel model);
        void Delete(ProductBindingModel model);
    }
}
