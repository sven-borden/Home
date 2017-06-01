using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
			return;
			HttpClient Client = new HttpClient();
			await Client.GetAsync($"{ip}:{port}/{Led.Get()}");
		}

		public TerrasseInteraction() : this("192.168.1.100", "80"){	}

		public TerrasseInteraction(string _ip) : this(_ip, "80"){ }

		public TerrasseInteraction(string _ip, string _port)
		{
			ip = _ip;
			port = _port;
			SetLights();
		}
	}
}
