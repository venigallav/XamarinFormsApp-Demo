using System;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace ProductBestBuy
{
	public class App
	{
		public static Page GetMainPage()
		{
			var mainnav = new NavigationPage (new SearchPage());

			return mainnav;
			/*	{
				Content = new Label
				{
					Text = "Hello, Forms !",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};*/
		}
	}




}