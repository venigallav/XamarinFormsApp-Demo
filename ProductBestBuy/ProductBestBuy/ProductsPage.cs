using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System;

namespace ProductBestBuy
{
	class ProductsPage : ContentPage
	{
		Button next = new Button ();
		Button prev = new Button ();
		ListView listView = new ListView ();
		BestBuyAPI o = new BestBuyAPI();
		static int page = 1;
		static int totalPages = 0;

		void OnItemSelect (object sender, SelectedItemChangedEventArgs e)
		{
			var product = (ProductView)e.SelectedItem;
			var viewProduct = new ProductOverview ();
			viewProduct.BindingContext = product;
			Navigation.PushAsync (viewProduct);

		}

		async void OnNextClick(object sender, EventArgs e)
		{
			page += 1;
			string uri = "http://api.remix.bestbuy.com/v1/products(name=" + SearchPage.searchItem + "*)?show=name,addToCartUrl,largeImage,salePrice,preowned,url&page="+page+"&format=json&apiKey=API";
			RootObject r = await o.GetData (uri);
			List<ProductView> pl = o.ParseProducts (r);

			await Navigation.PushAsync (new ProductsPage (pl));
		}

		async void OnPrevClick(object sender, EventArgs e)
		{
			page -= 1;
			string uri = "http://api.remix.bestbuy.com/v1/products(name=" + SearchPage.searchItem + "*)?show=name,addToCartUrl,largeImage,salePrice,preowned,url&page="+page+"&format=json&apiKey=API";
			RootObject r = await o.GetData (uri);
			List<ProductView> pl = o.ParseProducts (r);

			await Navigation.PushAsync (new ProductsPage (pl));
		}

		public ProductsPage (List<ProductView> p)
		{
			Debug.WriteLine ("HI");
			listView.ItemSelected += OnItemSelect;
			next.Clicked += OnNextClick;
			prev.Clicked += OnPrevClick;


			// Create the ListView.
			listView.RowHeight = 120;
			listView.VerticalOptions = LayoutOptions.FillAndExpand;
			listView.ItemsSource = p;
			listView.BackgroundColor = Color.White;
			listView.ItemTemplate = new DataTemplate (() => {

				Label nameLabel = new Label ();
				nameLabel.SetBinding (Label.TextProperty, "name");
				nameLabel.FontSize = 20;
				nameLabel.TextColor = Color.Black;


				Label salePriceLabel = new Label ();
				salePriceLabel.SetBinding (Label.TextProperty, "salePrice");
				salePriceLabel.FontSize = 20;
				salePriceLabel.TextColor = Color.Red;

				Label preOwnedLabel = new Label ();
				preOwnedLabel.SetBinding (Label.TextProperty, "preowned");
				preOwnedLabel.FontSize = 20;
				preOwnedLabel.TextColor = Color.Blue;

			
				return new ViewCell {
					View = new StackLayout {
						Orientation = StackOrientation.Vertical,
						VerticalOptions = LayoutOptions.FillAndExpand,

						Children = {
							nameLabel,
							salePriceLabel,
							preOwnedLabel
						}

					}
				};


			});




			Label header = new Label {
				Text = "Products",
				Font = Font.SystemFontOfSize (50),
				HorizontalOptions = LayoutOptions.Center
			};

			StackLayout footer = new StackLayout {Children = { prev, next },
				Orientation = StackOrientation.Horizontal
			};

			if (page == 1) {
				totalPages = SearchPage.totalPages;
			}

			next.Text = "Next";
			next.HorizontalOptions = LayoutOptions.EndAndExpand;

			if (page == totalPages) {
				next.IsVisible = false;
			}

			 prev.Text = "Previous";
			prev.HorizontalOptions = LayoutOptions.Start;

			if (page == 1) {
				prev.IsVisible = false;
			}

			// Build the page.

			Content = new StackLayout {
				Children = {
					header,
					listView,
					footer
				},
				VerticalOptions = LayoutOptions.FillAndExpand

			};


		}
	}
}

