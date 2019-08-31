using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raytracing
{
	public partial class Form1 : Form
	{
		Scene mainScene;
		Sphere selectedSphere;
		Vector3 centerLight;
		bool lightEnabled;

		public Form1()
		{
			InitializeComponent();
			KeyDown += Form1_KeyUp;
			DoubleBuffered = true;

			mainScene = new Scene(new Camera(new Vector3(0, 0, 10), new Vector3(0, 1, 0), 200, new Vector3(1, 0, 0), ClientSize.Width, ClientSize.Height, 90));
			mainScene.Primitives.Add(new Sphere(new Vector3(-20, 230, 0), 10, Color.Red));
			mainScene.Primitives.Add(new Sphere(new Vector3(25, 180, 0), 10, Color.Gray));
			mainScene.Primitives.Add(new Sphere(new Vector3(0, 190, 50), 5, Color.Yellow, true)); // light bulb
			mainScene.Primitives.Add(new Plane(new Vector3(0, 200, -10), new Vector3(0, 0, 1), Color.DarkGray)); // floor
			mainScene.Primitives.Add(new Plane(new Vector3(-40, 0, 0), new Vector3(1, 0, 0), Color.Orange)); // right wall
			mainScene.Primitives.Add(new Plane(new Vector3(40, 0, 0), new Vector3(1, 0, 0), Color.LightBlue)); // left wall
			mainScene.Primitives.Add(new Plane(new Vector3(0, 300, 0), new Vector3(0, 1, 0), Color.LightGray)); // bot wall
			mainScene.Primitives.Add(new Plane(new Vector3(0, 200, 50), new Vector3(0, 0, 1), Color.Gray)); // top

			centerLight = new Vector3(0, 190, 45);

			lightEnabled = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DateTime t = DateTime.Now;
			Bitmap b = new Bitmap(mainScene.Camera.Rays.Length, mainScene.Camera.Rays[0].Length);
			for (int x = 0; x < mainScene.Camera.Rays.Length; x++)
			{
				for (int y = 0; y < mainScene.Camera.Rays[0].Length; y++)
				{
					RayHit nearestHit = new RayHit(double.MaxValue, new Vector3(), Color.White);
					bool ignoreLight = false;
					// intersection calc
					foreach (Primitive p in mainScene.Primitives)
					{
						if (p.Intersect(mainScene.Camera.Rays[x][y], out RayHit hit))
						{
							if (hit.Distance < nearestHit.Distance)
							{
								nearestHit = hit;
								ignoreLight = p.IgnoreLight;
							}
						}
					}
					if (lightEnabled && !ignoreLight && nearestHit.Distance != double.MaxValue)
					{
						Ray lightRay = new Ray(nearestHit.IntersectionPoint, Vector3.Subtract(centerLight, nearestHit.IntersectionPoint));
						double maxDistance = Vector3.Subtract(centerLight, nearestHit.IntersectionPoint).GetLength();
						foreach (Primitive p in mainScene.Primitives)
						{
							if (!p.IgnoreLight && p.Intersect(lightRay, out RayHit hit) && hit.Distance < maxDistance/* && hit.IntersectionPoint != nearestHit.IntersectionPoint*/)
							{
								nearestHit.Color = Color.Black;
								break;
							}
						}
					}
					b.SetPixel(x, y, nearestHit.Color);
				}
			}
			e.Graphics.DrawImage(b, new Point(0, 0));
			e.Graphics.DrawString(centerLight.ToString(), Font, Brushes.Black, 0, 0);

			this.Text = mainScene.Camera.Rays.Length * mainScene.Camera.Rays[0].Length + " Rays in " + (DateTime.Now - t).TotalMilliseconds.ToString() + " ms";
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					centerLight.Add(new Vector3(-5, 0, 0));
					break;
				case Keys.Up:
					centerLight.Add(new Vector3(0, 0, 5));
					break;
				case Keys.Right:
					centerLight.Add(new Vector3(5, 0, 0));
					break;
				case Keys.Down:
					centerLight.Add(new Vector3(0, 0, -5));
					break;
				case Keys.PageUp:
					centerLight.Add(new Vector3(0, 5, 0));
					break;
				case Keys.PageDown:
					centerLight.Add(new Vector3(0, -5, 0));
					break;
				case Keys.R:
					centerLight = new Vector3(0, 190, 45);
					break;
				case Keys.W:
					break;
				case Keys.A:
					break;
				case Keys.S:
					break;
				case Keys.D:
					break;
				case Keys.Escape:
					Application.Exit();
					break;
				case Keys.L:
					lightEnabled = !lightEnabled;
					break;
				default:
					return;
			}
			if (selectedSphere != null)
				selectedSphere.Center = centerLight;
			Invalidate();
		}
	}
}
