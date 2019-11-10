using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PriceSaleComparer.Models;
using PriceSaleComparer.Services;

namespace PriceSaleComparer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //  MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            var IPageItemResolver = typeof(IPageItem);
            var IPageItemResolverList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => IPageItemResolver.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract).ToList();
            if (!MenuPages.ContainsKey(id))
            {
                foreach (var IPageItemResolverItem in IPageItemResolverList)
                {
                    MenuPages.Add(IPageItemResolverList.IndexOf(IPageItemResolverItem), new NavigationPage((Page)Activator.CreateInstance(IPageItemResolverItem)));
                }
            }
            //if (!MenuPages.ContainsKey(id))
            //{
            //    switch (id)
            //    {
            //        case (int)MenuItemType.Browse:
            //            MenuPages.Add(id, new NavigationPage(new ItemsPage()));
            //            break;
            //        case (int)MenuItemType.About:
            //            MenuPages.Add(id, new NavigationPage(new AboutPage()));
            //            break;
            //    }
            //}

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}