using System;
using System.ComponentModel;
using PriceSaleComparer.Services;
using PriceSaleComparer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceSaleComparer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ScanBarcode : ContentPage//, IPageItem
    {
        ScanBarcodeViewModel vm;
        public ScanBarcode()
        {
            InitializeComponent();
            vm = (ScanBarcodeViewModel)Activator.CreateInstance(typeof(ScanBarcodeViewModel));
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}