using System;

namespace ProductBestBuy
{
	public class Product
	{
		public string name { get; set; }
		public float salePrice { get; set; }
		public bool preowned { get; set; }
		public string url { get; set; }
		public string largeImage { get; set; }
		public string addToCartUrl { get; set; }

		public override string ToString()
		{
			return "Item: " + "Name =" + name + ", " + "SalePrice =" + salePrice + ", " + "PreOwned =" + preowned + ", "
				+ "MobileUrl =" + url;
		}
	}
}

