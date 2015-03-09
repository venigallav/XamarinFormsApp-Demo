using System;
using ProductBestBuy;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ProductBestBuy
{
	public class SearchPage : ContentPage
	{
		public List<ProductView> pl;
		Button b = new Button ();
		Entry e = new Entry ();
		RootObject r = new RootObject();
		BestBuyAPI o = new BestBuyAPI();
		String Url = "";


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

			Url = "http://api.remix.bestbuy.com/v1/products(name=" + e.Text + "*)?show=name,salePrice,preowned,mobileUrl&format=json&apiKey=API";

			r = await o.GetData (Url);
			pl = new List<ProductView> ();

			foreach(Product p in r.products)
			{
				pl.Add (new ProductView {name="Name : "+p.name, salePrice = "SalePrice : "+p.salePrice,
					preowned = "PreOwned : " + p.preowned, mobileUrl = "URL : "+p.mobileUrl});
			}

			await Navigation.PushAsync (new ProductsPage (pl));
		}


	}
}


