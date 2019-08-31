using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
	class RayHit
	{
		public double Distance;
		public Vector3 IntersectionPoint;
		public System.Drawing.Color Color;

		public RayHit(double distance, Vector3 intersectionPoint, System.Drawing.Color color)
		{
			Distance = distance;
			IntersectionPoint = intersectionPoint;
			Color = color;
		}
	}
}
