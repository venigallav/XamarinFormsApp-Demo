using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Diagnostics;

namespace ProductBestBuy
{
	class ProductsPage : ContentPage
	{
		Button next = new Button();
		Button prev = new Button ();
		ListView listView = new ListView ();
		List<ProductView> pv = new List<ProductView> ();

		void OnItemSelect (object sender, SelectedItemChangedEventArgs e)
		{
			var product = (ProductView)e.SelectedItem;
			var viewProduct = new ProductOverview ();
			viewProduct.BindingContext = product;
			Navigation.PushAsync (viewProduct);

		}

		public ProductsPage (List<ProductView> p)
		{
			Debug.WriteLine ("HI");
			listView.ItemSelected += OnItemSelect;
			pv = p;

			// Create the ListView.
			listView.RowHeight = 120;
			listView.VerticalOptions = LayoutOptions.FillAndExpand;
			listView.ItemsSource = pv;
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

			StackLayout footer = new StackLayout (){Children = {prev,next},
				Orientation = StackOrientation.Horizontal};

			next.Text = "Next";
			next.HorizontalOptions = LayoutOptions.EndAndExpand;

			prev.Text = "Previous";
			prev.HorizontalOptions = LayoutOptions.Start;


			// Build the page.

			this.Content = new StackLayout {
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

