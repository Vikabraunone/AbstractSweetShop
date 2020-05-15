﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в кондитерской
    /// </summary>
    [DataContract]
    public class ProductViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название кондитерского изделия")]
        public string ProductName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> ProductIngredients { get; set; }
    }
}