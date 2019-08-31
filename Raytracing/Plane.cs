using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
	class Plane : Primitive
	{
		private Vector3 origin;
		private Vector3 normal;
		private double d;

		public Vector3 Origin
		{
			get { return origin; }
			set { origin = value; }
		}

		public Vector3 NormalVector
		{
			get { return normal; }
			set { normal = value; }
		}

		public double D
		{
			get { return d; }
		}

		public Plane(Vector3 origin, Vector3 normal, System.Drawing.Color color, bool ignoreLight)
		{
			this.origin = origin;
			this.normal = normal;
			this.color = color;
			this.ignoreLight = ignoreLight;
			d = normal.X * origin.X + normal.Y * origin.Y + normal.Z * origin.Z;
		}

		public Plane(Vector3 origin, Vector3 normal, System.Drawing.Color color) : this(origin, normal, color, false)
		{
		}

		public override bool Intersect(Ray ray, out RayHit hit)
		{
			hit = null;
			double distance = 0;
			if (this.normal * ray.Direction == 0)
				return false;
			distance = (this.d - (this.normal.X * ray.Origin.X) - (this.normal.Y * ray.Origin.Y) - (this.normal.Z * ray.Origin.Z)) / ((this.normal.X * ray.Direction.X) + (this.normal.Y * ray.Direction.Y) + (this.normal.Z * ray.Direction.Z));
			if (distance <= 0)
				return false;
			hit = new RayHit(distance, ray.Origin + distance * ray.Direction, this.color);
			return true;
		}
	}
}
