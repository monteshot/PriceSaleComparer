using PriceSaleComparer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PriceSaleComparer.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceSaleComparer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            var IPageItemResolver = typeof(IPageItem);
            var IPageItemResolverList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => IPageItemResolver.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract).ToList();
            menuItems = new List<HomeMenuItem>();
            foreach (var IPageItemResolverItem in IPageItemResolverList)
            {
                menuItems.Add(new HomeMenuItem
                {
                    Id = IPageItemResolverList.IndexOf(IPageItemResolverItem),
                    Title = (string)IPageItemResolverItem.GetProperty("Title").GetValue(Activator.CreateInstance(IPageItemResolverItem), null)
            });



        }

        ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async(sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
        await RootPage.NavigateFromMenu(id);
    };
}
    }
}