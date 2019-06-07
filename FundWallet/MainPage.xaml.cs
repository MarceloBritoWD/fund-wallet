using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FundWallet.Model;
using FundWallet.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FundWallet
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            title.Text = "Fund Wallet";
            InicializeList();
        }

        private async void InicializeList()
        {
            List<Fund> funds = await GetAll();
            items.ItemsSource = funds;
        }


        private async Task<List<Fund>> GetAll()
        {
            using (var client = new HttpClient())
            {
                var uri = Constants.Constants.baseUrl + "funds";
                var result = await client.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<List<Fund>>(result);
            }
        }


        private async void GoToFundPage(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Fund;
            await Navigation.PushAsync(new NavigationPage(new FundPage(content)));
        }


        async void GoToAddFund(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddFund()));
        }

    }
}
