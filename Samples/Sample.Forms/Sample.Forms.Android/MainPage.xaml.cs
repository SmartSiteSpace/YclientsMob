using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        string url = "https://ateri.smartmed.info";

        public MainPage(string result)
        {
            InitializeComponent();
            //задаем ширину и высоту webview
            webView.HeightRequest = DeviceDisplay.MainDisplayInfo.Height;
            webView.WidthRequest = DeviceDisplay.MainDisplayInfo.Width;
            //грузим контент
            url = url + "/?id=" + result;
            LoadUrl();
        }

        public void LoadUrl()
        {
            //открываем в webview ресурс
            webView.Source = url;
            //показываем webview
            webView.IsVisible = true;
            //скрываем кнопку buttonConnect
            buttonConnect.IsVisible = true;

        }

        //нажатие кнопки
        void ButtonConnect_Clicked(object sender, EventArgs e)
        {
            //грузим контент
            LoadUrl();
        }

        //загрузка url через webview
        void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
          //если видим, что загружаемый адрес не содержит нашего исходного адреса (происходит загрузка стороннего ресурса)            
            if (!e.Url.Contains(url))
            {
                try
                {
                    //отменяем загрузку
                    e.Cancel = true;
                    //открываем этот ресурс через обычный браузер  
                    Browser.OpenAsync(e.Url, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception ex)
                {
                    var err = ex.Message;
                }
            }
            //отслеживаем наличие соединение с сетью Интернет с помощью Xam.Plugin.Connectivity
            if (!CrossConnectivity.Current.IsConnected)
            {
                //если нет соединения, а webview при этом видимый, то отменяем загрузку, прячем webview и показываем кнопку buttonConnect
                if (webView.IsVisible == true)
                {
                    e.Cancel = true;
                    webView.IsVisible = false;
                    buttonConnect.IsVisible = true;
                }
            }
            else
            {
                //если соединение есть, а webview при этом скрыт, то прячем кнопку buttonConnect и показываем webview 
                if (webView.IsVisible == false)
                {
                    webView.IsVisible = true;
                    buttonConnect.IsVisible = false;
                }
            }


        }

        public void WebView_Navigating_1(object sender, WebNavigatingEventArgs e)
        {
            //если видим, что загружаемый адрес не содержит нашего исходного адреса (происходит загрузка стороннего ресурса)            
            if (!e.Url.Contains(url))
            {
                try
                {
                    //отменяем загрузку
                    e.Cancel = true;
                    //открываем этот ресурс через обычный браузер  
                    Browser.OpenAsync(e.Url, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception ex)
                {
                    var err = ex.Message;
                }
            }
            //отслеживаем наличие соединение с сетью Интернет с помощью Xam.Plugin.Connectivity
            if (!CrossConnectivity.Current.IsConnected)
            {
                //если нет соединения, а webview при этом видимый, то отменяем загрузку, прячем webview и показываем кнопку buttonConnect
                if (webView.IsVisible == true)
                {
                    e.Cancel = true;
                    webView.IsVisible = false;
                    buttonConnect.IsVisible = true;
                }
            }
            else
            {
                //если соединение есть, а webview при этом скрыт, то прячем кнопку buttonConnect и показываем webview 
                if (webView.IsVisible == false)
                {
                    webView.IsVisible = true;
                    buttonConnect.IsVisible = false;
                }
            }

        }
    }
}