using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.Interfaces
{
    public interface IIngredientLogic
    {
        List<IngredientViewModel> Read(IngredientBindingModel model);
        void CreateOrUpdate(IngredientBindingModel model);
        void Delete(IngredientBindingModel model);
    }
}