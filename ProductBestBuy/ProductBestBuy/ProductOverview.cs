using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductBestBuy
{
	public partial class ProductOverview : ContentPage
	{

		public ProductOverview ()
		{
			InitializeComponent ();

		}

		void ViewProduct(object sender, EventArgs e)
		{
			Navigation.PushAsync (new BrowserPage (mobile.Text));
		}

		void AddToCart(object sender, EventArgs e)
		{
			Navigation.PushAsync (new BrowserPage (add.Text));
		}
	}
}

