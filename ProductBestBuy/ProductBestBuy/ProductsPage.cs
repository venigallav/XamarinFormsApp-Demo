using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ProductBestBuy
{
	class ProductsPage : ContentPage
	{

		ListView listView = new ListView ();

		public ProductsPage(List<ProductView> p)
		{


			// Create the ListView.
			listView.RowHeight = 140;

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

				Label mobileUrlLabel = new Label ();
				mobileUrlLabel.SetBinding (Label.TextProperty, "mobileUrl");
				mobileUrlLabel.FontSize = 20;
				mobileUrlLabel.TextColor = Color.Green;


				return new ViewCell {
					View = new StackLayout {
						Padding = new Thickness (0, 5),
						Orientation = StackOrientation.Vertical,
						Children = {
							new StackLayout {

								Children = {
									nameLabel,
									salePriceLabel,
									preOwnedLabel,
									mobileUrlLabel

								}
							}
						}
					}
				};

			});


				

				Label header = new Label {
				Text = "Products",
					Font = Font.SystemFontOfSize (50),
					HorizontalOptions = LayoutOptions.Center
				};

				// Build the page.

				this.Content = new StackLayout {
					Children = {
						header,
						listView
					}
				};


	}
}
				}




