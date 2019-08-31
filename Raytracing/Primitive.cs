using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
	abstract class Primitive
	{
		protected System.Drawing.Color color;
		protected bool ignoreLight;
		public System.Drawing.Color Color
		{
			get { return color; }
			set { color = value; }
		}

		public bool IgnoreLight
		{
			get { return ignoreLight; }
			set { ignoreLight = value; }
		}

		public abstract bool Intersect(Ray ray, out RayHit hit);
	}
}
