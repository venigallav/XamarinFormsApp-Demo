using System;
using ProductBestBuy;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProductBestBuy
{
	public class SearchPage : ContentPage
	{
		public List<ProductView> pl;
		Button b = new Button ();
		Entry e = new Entry ();
		RootObject r = new RootObject();
		BestBuyAPI o = new BestBuyAPI();
		String url = "";


		public SearchPage ()
		{
			e.Text = "Enter Item";
			e.Focused += SearchFocused;
			e.TextColor = Color.Black;
			b.Text = "Search";
			b.BackgroundColor = Color.Blue;
			//b.WidthRequest = 130;
			b.HorizontalOptions = LayoutOptions.Center;

			b.Clicked += HandleBClick;	
			BackgroundColor = Color.White;
			Content = new StackLayout { 
				Children = { 
					new Label { Text = "Welcome!!", TextColor = Color.Red,   
						HorizontalOptions = LayoutOptions.Center, FontSize = 50 },
					e,b
				}

			};
		}

		void SearchFocused(object sender, EventArgs ea)
		{
			e.Text = "";
		}


		async void HandleBClick(object sender, EventArgs ea)
		{

			url = "http://api.remix.bestbuy.com/v1/products(name=" + e.Text + "*)?show=name,addToCartUrl,largeImage,salePrice,preowned,url&page=1&format=json&apiKey=hxabspnkhtm9tsqnzmnn7mvz";

			r = await o.GetData (url);
			pl = o.ParseProducts (r);

			await Navigation.PushAsync (new ProductsPage (pl));
		}


	}
}