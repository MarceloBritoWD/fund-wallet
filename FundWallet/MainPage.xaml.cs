using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FundWallet.Model;
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

            lblMessage.Text = "Fund Wallet";

            InicializeList();
        }

        private async void InicializeList()
        {
            List<Fund> funds = await Get();
            lstItens.ItemsSource = funds;
        }


        async void addFund(object sender, EventArgs e) {
            await DisplayAlert("Success!", "Fund added with success", "OK");
        }



        private async Task<List<Fund>> Get()
        {
            using (var client = new HttpClient())
            {
                var uri = "https://41d6fb31.ngrok.io/api/funds";
                var result = await client.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<List<Fund>>(result);
            }
        }
    }
}
