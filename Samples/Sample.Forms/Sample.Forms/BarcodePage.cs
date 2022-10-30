using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

namespace Sample.Forms
{
	public class BarcodePage : ContentPage
	{
		
		public BarcodePage(string Link)
		{
			var stackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};


			var browser = new WebView 
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "browser",
            };

            //var htmlSource = new HtmlWebViewSource();
            //htmlSource.Html = @"<html><body>
            //  <h1>Xamarin.Forms</h1>
            //  <p>Welcome to WebView.</p>
            //  </body></html>";
            //browser.Source = htmlSource;
            var url = "https://ateri.smartmed.info/" + Link;
            browser.Source = url;
            browser.Navigating += (s, e) =>
            {
                if (!e.Url.Contains(url))
                {
                    try
                    {
                        //отменяем загрузку
                        //e.Cancel = true;
                    }
                    catch (Exception ex)
                    {
                        var err = ex.Message;
                    }
                }
            };
            //stackLayout.Children.Add(barcode);
            stackLayout.Children.Add(browser);
            stackLayout.IsVisible = true;

            Content = stackLayout;
            this.Barcode = Barcode;
        }

        public string Barcode { get; }



        //	barcode = new ZXingBarcodeImageView
        //		{
        //			HorizontalOptions = LayoutOptions.FillAndExpand,
        //			VerticalOptions = LayoutOptions.FillAndExpand,
        //			AutomationId = "zxingBarcodeImageView",
        //		};
        //barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
        //		barcode.BarcodeOptions.Width = 300;
        //		barcode.BarcodeOptions.Height = 300;
        //		barcode.BarcodeOptions.Margin = 10;
        //		barcode.BarcodeValue = "ZXing.Net.Mobile";

        //		var text = new Entry
        //		{
        //			HorizontalOptions = LayoutOptions.FillAndExpand,
        //			Text = "ZXing Sample"
        //		};
        //text.TextChanged += Text_TextChanged;



        //	void Text_TextChanged(object sender, TextChangedEventArgs e)
        //		=> barcode.BarcodeValue = e.NewTextValue;
    }
}

