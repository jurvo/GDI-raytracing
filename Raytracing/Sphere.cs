using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
	class Sphere : Primitive
	{
		private Vector3 center;
		private double radius;

		public Vector3 Center
		{
			get { return center; }
			set { center = value; }
		}

		public double Radius
		{
			get { return radius; }
			set { radius = value; }
		}

		public Sphere(Vector3 center, double radius, System.Drawing.Color color) : this(center, radius, color, false) { }

		public Sphere(Vector3 center, double radius, System.Drawing.Color color, bool ignoreLight)
		{
			this.center = center;
			this.radius = radius;
			this.color = color;
			this.ignoreLight = ignoreLight;
		}

		public override bool Intersect(Ray ray, out RayHit hit)
		{
			hit = null;

			double alpha = (this.center - ray.Origin).ScalarProduct(ray.Direction);
			double distanceToCenter = ((ray.Origin + (ray.Direction * alpha)) - this.center).GetLength();
			if (distanceToCenter > this.radius)
				return false;
			double x = Math.Sqrt(this.radius * this.radius - distanceToCenter * distanceToCenter);

			double distance = 0;
			if (alpha >= x)
				distance = alpha - x;
			else if (alpha + x > 0)
				distance = alpha + x;
			else
				return false;
//			if (distance <= 1e-16) return false;
			hit = new RayHit(distance, ray.Origin + ray.Direction * distance, this.color);
			return true;
		}

		/*
		
		public bool Intersect(Sphere s, out Vector3 intersectionPoint, out double distance)
		{
			intersectionPoint = new Vector3();
			if (Intersect(s, out distance))
			{
				intersectionPoint = origin + direction * distance;
				return true;
			}
			return false;
		}

		public bool Intersect(Sphere s, out double distance)
		{
			distance = 0;
			double alpha = (s.Center - this.origin).ScalarProduct(direction);
			double distanceToCenter = ((this.origin + (this.direction * alpha)) - s.Center).GetLength();
			if (distanceToCenter > s.Radius)
				return false;
			double x = Math.Sqrt(s.Radius * s.Radius - distanceToCenter * distanceToCenter);
			if (alpha >= x)
				distance = alpha - x;
			else if (alpha + x > 0)
				distance = alpha + x;
			else
				return false;
			return true;
		}
		
		*/
	}
}
