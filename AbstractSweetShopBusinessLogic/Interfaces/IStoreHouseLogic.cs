using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.Interfaces
{
    public interface IStoreHouseLogic
    {
        List<StoreHouseViewModel> Read(StoreHouseBindingModel model);

        void CreateOrUpdate(StoreHouseBindingModel model);

        void Delete(StoreHouseBindingModel model);

        void AddIngredient(StoreHouseIngredientBindingModel model);

        StoreHouseViewModel ReadStoreHouse(int id);
    }
}
