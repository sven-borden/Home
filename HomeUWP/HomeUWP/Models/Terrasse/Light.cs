using System;

namespace HomeUWP.Models.Terrasse
{
	public class Light
	{

		#region Color
		private int r = 0;
		public int R
		{
			get { return r; }
			set
			{
				if (value < 256)
					r = value;
				else
					r = 255;
			}
		}

		private int g = 0;
		public int G
		{
			get { return g; }
			set
			{
				if (value < 256)
					g = value;
				else
					g = 255;
			}
		}

		private int b = 0;
		public int B
		{
			get { return b; }
			set
			{
				if (value < 256)
					b = value;
				else
					b = 255;
			}
		}
#endregion

		public Light() : this(0,0,0)
		{

		}

		public Light(int _r, int _g, int _b)
		{
			R = _r; G = _g; B = _b;
		}

		public string Get()
		{
			string Rstring = string.Format("{0:X}", R);
			string Gstring = string.Format("{0:X}", G);
			string Bstring = string.Format("{0:X}", B);
			if (Rstring.Length == 1)
				Rstring = "0" + Rstring;
			if (Gstring.Length == 1)
				Gstring = "0" + Gstring;
			if (Bstring.Length == 1)
				Bstring = "0" + Bstring;
			return $"?red={Rstring}&green={Gstring}&blue={Bstring}";
		}
	}
}
