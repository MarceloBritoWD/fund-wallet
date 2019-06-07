using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FundWallet.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FundWallet.Views
{
    public partial class AddFund : ContentPage
    {
        public AddFund()
        {
            InitializeComponent();
        }


        async void addFund(object sender, EventArgs e)
        {

            using (var client = new HttpClient())
            {

                Fund fund = new Fund
                {
                    Name = entFund.Text,
                    Quantity = entQuantity.Text,
                    UnitPrice = entUnitPrice.Text,
                    PurchaseDate = new DateTime()
                };

                var result = await client.PostAsync(
                    Constants.Constants.baseUrl + "funds",
                    new StringContent(JsonConvert.SerializeObject(fund), Encoding.UTF8, "application/json")
                );

                if (result.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success!", "Fund added with success", "OK");
                }
                else
                {
                    await DisplayAlert("Error! ;(", "Something went work, try again later!", "OK");
                }
            }
        }
    }
}
