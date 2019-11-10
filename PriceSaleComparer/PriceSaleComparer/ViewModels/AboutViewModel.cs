using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace PriceSaleComparer.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            //Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }
        public string Title { get; set; } = "About123";
        public ICommand OpenWebCommand { get; }
    }
}