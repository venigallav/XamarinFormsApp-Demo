using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace ProductBestBuy
{
	public class BestBuyAPI
	{
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
	}
}

