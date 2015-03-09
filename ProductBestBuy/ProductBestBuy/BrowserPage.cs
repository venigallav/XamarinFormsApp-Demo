using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProductBestBuy
{
	public class BrowserPage : ContentPage
	{
		public BrowserPage (string url)
		{
			var browser = new WebView();
			browser.Source = url;

			Content = browser;
		}
	}
}


