using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace PriceSaleComparer.ViewModels
{
    public class ScanBarcodeViewModel : BaseViewModel
    {
        public ScanBarcodeViewModel()
        {
            ScanBarcodeCommand = new Command(async () => await CreateScannerPage());
        }
        public INavigation Navigation { get; set; }
        public string Title { get; set; } = "Scan Barcode";
        public ICommand ScanBarcodeCommand { get; }
        protected async Task CreateScannerPage()
        {
            var scanPage = new ZXingScannerPage();
            await Navigation.PushAsync(scanPage);
        }
    }
}