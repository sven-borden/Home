using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeUWP.Models.Terrasse
{
	public class TerrasseInteraction
	{
		private string ip;
		private string port;

		public Light Led = new Light();

		public async void SetLights()
		{
			HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, new Uri($"http://{ip}/{Led.Get()}"));
			HttpClient Client = new HttpClient();
			try
			{
				await Client.SendRequestAsync(message);
			}
			catch(Exception e)
			{

			}
		}

		public TerrasseInteraction() : this("192.168.1.143", "80"){	}

		public TerrasseInteraction(string _ip) : this(_ip, "80"){ }

		public TerrasseInteraction(string _ip, string _port)
		{
			ip = _ip;
			port = _port;
			SetLights();
		}
	}
}
