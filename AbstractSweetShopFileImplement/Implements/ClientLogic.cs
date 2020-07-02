using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopFileImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly FileDataListSingleton source;

        public ClientLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client element = source.Clients.FirstOrDefault(rec =>
                rec.Email == model.Email && rec.Id != model.Id);
            if (element != null)
                throw new Exception("Уже есть клиент с таким Email");
            if (model.Id.HasValue)
            {
                element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                    throw new Exception("Элемент не найден");
            }
            else
            {
                int maxId = source.Clients.Count > 0 ? source.Clients.Max(rec => rec.Id) : 0;
                element = new Client { Id = maxId + 1 };
                source.Clients.Add(element);
            }
            element.ClientFIO = model.ClientFIO;
            element.Email = model.Email;
            element.Password = model.Password;
        }

        public void Delete(ClientBindingModel model)
        {
            source.Orders.RemoveAll(rec => rec.ClientId == model.Id);
            Client element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
                source.Clients.Remove(element);
            else
                throw new Exception("Элемент не найден");
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            var clients = source.Clients
                .Where(rec => model == null || rec.Email.Equals(model.Email) && rec.Password.Equals(model.Password))
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    ClientFIO = rec.ClientFIO,
                    Email = rec.Email,
                    Password = rec.Password
                });
            if (clients.Count() == 0)
                return null;
            else
                return clients.ToList();
        }
    }
}
