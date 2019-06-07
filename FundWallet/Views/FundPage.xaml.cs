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
            totalSum.Text = "R$ 121,21";

            InicializeList();

            //funds.ForEach(item =>
            //{
            //    total += Convert.ToDouble(item.Value);
            //});
            //FundTotal.Text = "R$ " + System.Math.Round(total, 2).ToString();
            //FundsView.ItemsSource = funds;
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
                var uri = Constants.Constants.baseUrl + "funds/name/" + title.Text;
                var result = await client.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<List<Fund>>(result);
            }
        }
    }
}
