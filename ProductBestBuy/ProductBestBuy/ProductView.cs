using System;

namespace ProductBestBuy
{
	public class ProductView
	{
		public string name { get; set; }
		public string salePrice { get; set; }
		public string preowned { get; set; }
		public string mobileUrl { get; set; }
		public override string ToString()
		{
			return "Item: " + "Name =" + name + ", " + "SalePrice =" + salePrice + ", " + "PreOwned =" + preowned + ", "
				+ "MobileUrl =" + mobileUrl;
		}
	}
}

