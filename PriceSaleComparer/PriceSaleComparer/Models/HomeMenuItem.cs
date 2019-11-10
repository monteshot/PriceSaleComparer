using System;
using System.Collections.Generic;
using System.Text;

namespace PriceSaleComparer.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        BarcodeScreen
    }
    public class HomeMenuItem
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
