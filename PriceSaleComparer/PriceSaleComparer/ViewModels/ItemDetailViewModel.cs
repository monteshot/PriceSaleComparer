using System;

using PriceSaleComparer.Models;

namespace PriceSaleComparer.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Code;
            Item = item;
        }
    }
}
