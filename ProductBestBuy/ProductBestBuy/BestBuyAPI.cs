using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace ProductBestBuy
{
	public class BestBuyAPI
	{
		List<ProductView> ProductsView = new List<ProductView>();

		public async Task<String> GetJson(string Url)
		{
			try
			{
				var client = new HttpClient();
				var json = await client.GetStringAsync(Url);
				return json;
			}
			catch (System.Exception exception)
			{
				return null;
			}
		}

		public async Task<RootObject> GetData(string Url)
		{
			String json = await GetJson (Url);
			return JsonConvert.DeserializeObject<RootObject> (json.ToString ());

		}

		public List<ProductView> ParseProducts(RootObject r)
		{
			foreach(Product p in r.products)
			{
				ProductsView.Add (new ProductView {name="Name : "+p.name, salePrice = "SalePrice : "+p.salePrice,
					preowned = "PreOwned : " + p.preowned, mobileUrl = p.url, largeImage = p.largeImage, addToCartUrl = p.addToCartUrl});
			}
			return ProductsView;
		}

		public int GetTotalPages(RootObject r)
		{
			return r.totalPages;
		}
	}
}

