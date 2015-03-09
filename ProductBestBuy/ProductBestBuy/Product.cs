using System;

namespace ProductBestBuy
{
	public class Product
	{
		public string name { get; set; }
		public float salePrice { get; set; }
		public bool preowned { get; set; }
		public string mobileUrl { get; set; }
		public override string ToString()
		{
			return "Item: " + "Name =" + name + ", " + "SalePrice =" + salePrice + ", " + "PreOwned =" + preowned + ", "
				+ "MobileUrl =" + mobileUrl;
		}
	}
}

