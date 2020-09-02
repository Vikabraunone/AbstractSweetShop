using AbstractSweetShopBusinessLogic.Attributes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ClientFIO { get; set; }

        [Column(title: "Email", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ClientFIO", "Email",
            "Password"};
    }
}
