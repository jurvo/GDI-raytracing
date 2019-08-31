using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
	class Camera
	{
		private Vector3 eyePoint;
		private Vector3 direction;
		private Ray[][] rays;

		public Vector3 EyePoint
		{
			get { return eyePoint; }
			set { eyePoint = value; }
		}

		public Vector3 Direction
		{
			get { return direction; }
			set { direction = value; }
		}

		public Ray[][] Rays
		{
			get { return rays; }
			set { rays = value; }
		}

		public Camera(Vector3 eyePoint, Vector3 direction, double distance, Vector3 cameraHorizontalAlignment, int width, int height, double angle)
		{
			this.eyePoint = eyePoint;
			if (direction.GetLength() != 1)
				direction.Normalize();
			this.direction = direction * distance;
			rays = new Ray[width][];
			for (int i = 0; i < width; i++)
			{
				rays[i] = new Ray[height];
			}

			if (Vector3.ScalarProduct(cameraHorizontalAlignment, direction) != 0) throw new ArgumentException("Alignment has to be orthogonal to the direction.", nameof(cameraHorizontalAlignment));
			Vector3 planePoint = this.eyePoint + this.direction;
			cameraHorizontalAlignment.Normalize();
			Vector3 cameraVerticalAlignment = Vector3.CrossProduct(this.direction, cameraHorizontalAlignment);
			cameraVerticalAlignment.Normalize();

			for (int x = 0; x < width; x++)
			{
				//double w = x - (width / 2D);
				double w = -angle / 2D + x * (angle / width);
				for (int y = 0; y < height; y++)
				{
					//double h = y - (height / 2D);
					double h = -angle / 2D + y * (angle / height);
					Vector3 imgPlanePoint = planePoint + (cameraHorizontalAlignment * w) + (cameraVerticalAlignment * h);
					rays[x][y] = new Ray(eyePoint, imgPlanePoint - eyePoint);
				}
			}
		}
	}
}
