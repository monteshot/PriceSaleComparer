using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PriceSaleComparer.Models;

namespace PriceSaleComparer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            //ZXing.Result itemData;
            // object itemData=new object();


            Item = new Item
            {
                Code = "Code",
                Price = "Price"
            };

            BindingContext = this;
        }
        public NewItemPage(ZXing.Result result)
        {
            InitializeComponent();
            Item = new Item
            {
                Code = result.Text,
                Price = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            // await Navigation.PushAsync(new ItemsPage());
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}