using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FundWallet.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FundWallet.Views
{
    public partial class FundPage : ContentPage
    {

        public FundPage(Fund fund)
        {
            InitializeComponent();
            title.Text = fund.Name;

            InicializeList();
            GetTotalValue();
        }

        private async void InicializeList()
        {
            List<Fund> funds = await GetAll();
            items.ItemsSource = funds;
        }

        private async void GetTotalValue()
        {
            totalSum.Text = "R$ " + await this.GetTotalInevestedByName(title.Text);
        }

        private async Task<List<Fund>> GetAll()
        {
            using (var client = new HttpClient())
            {
                var uri = Constants.Constants.baseUrl + "funds/name/" + title.Text;
                var result = await client.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<List<Fund>>(result);
            }
        }

        private async Task<Double> GetTotalInevestedByName(string name)
        {
            using (var client = new HttpClient())
            {
                var uri = Constants.Constants.baseUrl + "funds/total/" + title.Text;
                var result = await client.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<Double>(result);
            }
        }
    }
}
