using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeUWP.Models.Terrasse
{
	public class TerrasseInteraction
	{
		private string ip;
		private string port;

		public TerrasseInteraction() : this("192.168.1.100", "80")
		{

		}

		public TerrasseInteraction(string _ip) : this(_ip, "80")
		{

		}

		public TerrasseInteraction(string _ip, string _port)
		{
			ip = _ip;
			port = _port;
		}
	}
}
