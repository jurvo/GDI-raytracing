using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
	class Ray
	{
		private Vector3 origin;
		private Vector3 direction;

		public Vector3 Origin
		{
			get { return origin; }
			set { origin = value; }
		}

		public Vector3 Direction
		{
			get { return direction; }
			set { direction = value; }
		}

		public Ray(Vector3 origin, Vector3 direction)
		{
			this.origin = origin;
			this.direction = Vector3.Normalize(direction);
		}
	}
}
