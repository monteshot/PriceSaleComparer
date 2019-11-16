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
        public async Task CreateScannerPage()
        {
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    Console.WriteLine(result.Text);               
                });
            };
            await Navigation.PushAsync(scanPage);
        }
    }
}