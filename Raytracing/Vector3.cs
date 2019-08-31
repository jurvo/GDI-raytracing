using System;

namespace Raytracing
{
	public struct Vector3
	{
		public double X, Y, Z;

		public Vector3(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		#region Addition
		public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		public static Vector3 Add(Vector3 a, Vector3 b) => a + b;
		public void Add(Vector3 value) => this += value;
		#endregion

		#region Subtraction
		public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		public static Vector3 Subtract(Vector3 a, Vector3 b) => a - b;
		public void Subtract(Vector3 value) => this += value;
		#endregion

		#region Multiplication
		public static Vector3 operator *(Vector3 a, double factor) => new Vector3(a.X * factor, a.Y * factor, a.Z * factor);
		public static Vector3 operator *(double factor, Vector3 a) => new Vector3(a.X * factor, a.Y * factor, a.Z * factor);
		/// <summary>
		/// Multiplies this vector with i.
		/// </summary>
		/// <param name="factor">The multiplication factor.</param>
		public void Multiply(double factor) => this *= factor;
		/// <summary>
		/// Returns the vector which is the product from Vector a and double factor.
		/// </summary>
		/// <param name="a">The vector.</param>
		/// <param name="factor">The factor.</param>
		/// <returns>Product of vector and double.</returns>
		public static Vector3 Multiply(Vector3 a, double factor) => a * factor;
		#endregion

		#region Division
		public static Vector3 operator /(Vector3 a, double factor) => new Vector3(a.X / factor, a.Y / factor, a.Z / factor);
	//	public static Vector3 operator /(Vector3 a, double factor) => new Vector3(a.X / factor, a.X / factor, a.X / factor);
		public void Divide(double factor) => this /= factor;

		public static Vector3 Divide(Vector3 a, double factor) => a / factor;
		#endregion

		#region Scalar Product
		public static double operator *(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
		public static double ScalarProduct(Vector3 a, Vector3 b) => a * b;
		public double ScalarProduct(Vector3 b) => this * b;
		#endregion

		#region Cross Product
		public static Vector3 CrossProduct(Vector3 a, Vector3 b) => new Vector3(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
		public void CrossProduct(Vector3 v) => this = Vector3.CrossProduct(this, v);
		#endregion

		/*		public double GetLength()
				{
					return Math.Sqrt((double)((X * X) + (Y * Y) + (Z * Z)));
				}*/

		public double GetLength()
		{
			return Math.Sqrt(((X * X) + (Y * Y) + (Z * Z)));
		}

		public void Normalize()
		{
			this /= this.GetLength();
		}

		public static Vector3 Normalize(Vector3 v)
		{
			double l = v.GetLength();
			if (l != 1)
				return v / l;
			else
				return v;
		}

		public static bool operator ==(Vector3 a, Vector3 b) => (a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z);
		public static bool operator !=(Vector3 a, Vector3 b) => !(a == b);

		public override bool Equals(object obj)
		{
			return obj is Vector3 vector && X == vector.X && Y == vector.Y && Z == vector.Z;
		}

		public override int GetHashCode()
		{
			var hashCode = -307843816;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			hashCode = hashCode * -1521134295 + Z.GetHashCode();
			return hashCode;
		}

		public override string ToString()
		{
			return "{X:" + X.ToString() + ";Y:" + Y.ToString() + ";Z:" + Z.ToString() + "}";
		}
	}
}
