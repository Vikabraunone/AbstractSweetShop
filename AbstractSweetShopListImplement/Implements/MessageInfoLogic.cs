using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace AbstractSweetShopListImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly DataListSingleton source;

        public MessageInfoLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Create(MessageInfoBindingModel model)
        {
            foreach (var messageInfo in source.MessageInfoes)
                if (messageInfo.MessageId == model.MessageId)
                    throw new Exception("Уже есть письмо с таким идентификатором");
            int? clientId = null;
            foreach (var client in source.Clients)
                if (client.Email == model.FromMailAddress)
                {
                    clientId = client.Id;
                    break;
                }
            source.MessageInfoes.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = clientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body
            });
        }

        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var messageInfo in source.MessageInfoes)
            {
                if (model != null)
                {
                    if (messageInfo.MessageId == model.MessageId)
                    {
                        result.Add(CreateViewModel(messageInfo));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(messageInfo));
            }
            return result;
        }

        private MessageInfoViewModel CreateViewModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                DateDelivery = messageInfo.DateDelivery,
                Body = messageInfo.Body,
                SenderName = messageInfo.SenderName,
                Subject = messageInfo.Subject
            };
        }
    }
}
