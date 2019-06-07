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
            //items.ItemsSource = GetAll();

            //funds.ForEach(item =>
            //{
            //    total += Convert.ToDouble(item.Value);
            //});
            //FundTotal.Text = "R$ " + System.Math.Round(total, 2).ToString();
            //FundsView.ItemsSource = funds;
        }

        private async Task<Fund> GetAll()
        {
            using (var client = new HttpClient())
            {
                var uri = Constants.Constants.baseUrl + "funds/1";
                var result = await client.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<Fund>(result);
            }
        }
    }
}
