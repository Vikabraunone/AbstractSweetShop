using AbstractSweetShopBusinessLogic.Attributes;
using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    public class ImplementerViewModel : BaseViewModel
    {
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }

        [Column(title: "Время работы", gridViewAutoSize: GridViewAutoSize.AllCells)]
        public int WorkingTime { get; set; }

        [Column(title: "Перерыв", gridViewAutoSize: GridViewAutoSize.AllCells)]
        public int PauseTime { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ImplementerFIO", "WorkingTime",
            "PauseTime"};
    }
}
