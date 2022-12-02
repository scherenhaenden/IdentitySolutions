using ZXing.Net.Maui;
using System;
using System.Linq;
using Microsoft.Maui.Controls;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using BarcodeGeneratorView = ZXing.Net.Maui.Controls.BarcodeGeneratorView;

namespace IdentityService.Mobile.Maui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		barcodeView.Options = new BarcodeReaderOptions
		{
			Formats = BarcodeFormats.All,
			AutoRotate = true,
			Multiple = true
		};
	}
	
	
	protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
	{
		foreach (var barcode in e.Results)
			Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");

		var first = e.Results?.FirstOrDefault();
		if (first is not null)
		{
			Dispatcher.Dispatch(() =>
			{
				barcodeGenerator.ClearValue(BarcodeGeneratorView.ValueProperty);
				barcodeGenerator.Format = first.Format;
				barcodeGenerator.Value = first.Value;
			});
		}
	}
	
	void SwitchCameraButton_Clicked(object sender, EventArgs e)
	{
		barcodeView.CameraLocation = barcodeView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
	}

	void TorchButton_Clicked(object sender, EventArgs e)
	{
		barcodeView.IsTorchOn = !barcodeView.IsTorchOn;
	}


	private void AddBarCodeReaderOptions()
	{
		/*cameraBarcodeReaderView.Options = new BarcodeReaderOptions
		{
			Formats = BarcodeFormats.OneDimensional,
			AutoRotate = true,
			Multiple = true
		};*/
		//CameraBarcodeReaderView = cameraBarcodeReaderView;
		 
	}
	
	private async void Button_Clicked(object sender, EventArgs e)
	{
		/*var scanner = new ZXingScannerPage();
		await Navigation.PushAsync(scanner);
		scanner.OnScanResult += (result) =>
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				await Navigation.PopAsync();
				await DisplayAlert("Scanned Barcode", result.Text, "OK");
			});
		};*/
		
		//cameraBarcodeReaderView
		
		/*cameraBarcodeReaderView.Options = new BarcodeReaderOptions
		{
			Formats = BarcodeFormats.OneDimensional,
			AutoRotate = true,
			Multiple = true
		};*/
	}

	

    public void CameraBarcodeReaderView_BarcodesDetected(System.Object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		var valur = e.Results[0];
    }

  

    private void CameraBarcodeReaderView_OnBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
	    throw new NotImplementedException();
    }
}


