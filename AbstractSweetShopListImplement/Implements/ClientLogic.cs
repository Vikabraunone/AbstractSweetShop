using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace AbstractSweetShopListImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly DataListSingleton source;

        public ClientLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client tempClient = model.Id.HasValue ? null : new Client { Id = 1 };
            foreach (var client in source.Clients)
            {
                if (client.Email == model.Email && client.Id != model.Id)
                    throw new Exception("Уже есть клиент с таким email!");
                if (!model.Id.HasValue && client.Id >= tempClient.Id)
                    tempClient.Id = client.Id + 1;
                else if (model.Id.HasValue && client.Id == model.Id)
                    tempClient = client;
            }
            if (model.Id.HasValue)
            {
                if (tempClient == null)
                    throw new Exception("Элемент не найден");
                CreateModel(model, tempClient);
            }
            else
            {
                model.Id = source.Clients.Count + 1;
                source.Clients.Add(CreateModel(model, tempClient));
            }
        }

        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
                if (source.Orders[i].ClientId == model.Id)
                    source.Orders.RemoveAt(i--);
            for (int i = 0; i < source.Clients.Count; ++i)
                if (source.Clients[i].Id == model.Id.Value)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            throw new Exception("Элемент не найден");
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                if (model != null)
                {
                    if (client.Email.Equals(model.Email) && client.Password.Equals(model.Password))
                    {
                        result.Add(CreateViewModel(client));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(client));
            }
            return result;
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }

        private ClientViewModel CreateViewModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO,
                Email = client.Email,
                Password = client.Password
            };
        }
    }
}
