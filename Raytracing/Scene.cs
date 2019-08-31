using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
	class Scene
	{
		private Camera camera;
		

		private List<Primitive> primitives;

		public Camera Camera
		{
			get { return camera; }
			set { camera = value; }
		}

		public List<Primitive> Primitives
		{
			get { return primitives; }
			set { primitives = value; }
		}

		public Scene(Camera camera)
		{
			this.camera = camera;
			primitives = new List<Primitive>();
		}
	}
}
