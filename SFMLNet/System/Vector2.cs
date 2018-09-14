using System;
using System.Runtime.InteropServices;

namespace SFML
{
    namespace System
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Vector2f is an utility class for manipulating 2 dimensional
        /// vectors with float components
        /// </summary>
        ////////////////////////////////////////////////////////////
        [StructLayout(LayoutKind.Sequential)]
        public struct Vector2f : IEquatable<Vector2f>
        {
            /// <summary>
            /// Returns a vector with components 0, 0.
            /// </summary>
            public static readonly Vector2f Zero = new Vector2f(0, 0);

            /// <summary>
            /// Returns a vector with components 1, 1.
            /// </summary>
            public static readonly Vector2f One = new Vector2f(1, 1);

            /// <summary>
            /// Returns a vector with components 0.5, 0.5.
            /// </summary>
            public static readonly Vector2f Half = new Vector2f(0.5f, 0.5f);

            /// <summary>
            /// Returns a vector with components 0, -1.
            /// </summary>
            public static readonly Vector2f North = new Vector2f(0, -1);

            /// <summary>
            /// Returns a vector with components 0, 1.
            /// </summary>
            public static readonly Vector2f South = new Vector2f(0, 1);

            /// <summary>
            /// Returns a vector with components 1, 0.
            /// </summary>
            public static readonly Vector2f East = new Vector2f(1, 0);

            /// <summary>
            /// Returns a vector with components -1, 0.
            /// </summary>
            public static readonly Vector2f West = new Vector2f(-1, 0);

            /// <summary>
            /// Returns a vector with components -1, 1.
            /// </summary>
            public static readonly Vector2f SouthWest = new Vector2f(-1, 1);

            /// <summary>
            /// Returns a vector with components 1, 1.
            /// </summary>
            public static readonly Vector2f SouthEast = Vector2f.One;

            /// <summary>
            /// Returns a vector with components 1, -1.
            /// </summary>
            public static readonly Vector2f NorthEast = new Vector2f(1, -1);

            /// <summary>
            /// Returns a vector with components -1, -1.
            /// </summary>
            public static readonly Vector2f NorthWest = new Vector2f(-1, -1);

            /// <summary>
            /// Returns a vector with components Infinity, Infinity.
            /// </summary>
            public static readonly Vector2f PositiveInfinity = new Vector2f(float.PositiveInfinity, float.PositiveInfinity);

            /// <summary>
            /// Returns a vector with components -Infinity, -Infinity.
            /// </summary>
            public static readonly Vector2f NegativeInfinity = new Vector2f(float.NegativeInfinity, float.NegativeInfinity);

            /// <summary>
            /// Returns a vector with components 0, -1.
            /// </summary>
            public static readonly Vector2f Up = new Vector2f(0, -1);

            /// <summary>
            /// Returns a vector with components 0, 1.
            /// </summary>
            public static readonly Vector2f Down = new Vector2f(0, 1);

            /// <summary>
            /// Returns a vector with components -1, 0.
            /// </summary>
            public static readonly Vector2f Left = new Vector2f(-1, 0);

            /// <summary>
            /// Returns a vector with components 1, 0.
            /// </summary>
            public static readonly Vector2f Right = new Vector2f(1, 0);

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the vector from its coordinates
            /// </summary>
            /// <param name="x">X coordinate</param>
            /// <param name="y">Y coordinate</param>
            ////////////////////////////////////////////////////////////
            public Vector2f(float x, float y)
            {
                X = x;
                Y = y;
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the vector from its coordinates
            /// </summary>
            /// <param name="xy">X and Y coordinate</param>
            ////////////////////////////////////////////////////////////
            public Vector2f(float xy)
            {
                X = xy;
                Y = xy;
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator - overload ; returns the opposite of a vector
            /// </summary>
            /// <param name="v">Vector to negate</param>
            /// <returns>-v</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2f operator -(Vector2f v)
            {
                return new Vector2f(-v.X, -v.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator - overload ; subtracts two vectors
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 - v2</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2f operator -(Vector2f v1, Vector2f v2)
            {
                return new Vector2f(v1.X - v2.X, v1.Y - v2.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator + overload ; add two vectors
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 + v2</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2f operator +(Vector2f v1, Vector2f v2)
            {
                return new Vector2f(v1.X + v2.X, v1.Y + v2.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator * overload ; multiply a vector by a scalar value
            /// </summary>
            /// <param name="v">Vector</param>
            /// <param name="x">Scalar value</param>
            /// <returns>v * x</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2f operator *(Vector2f v, float x)
            {
                return new Vector2f(v.X * x, v.Y * x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator * overload ; multiply a scalar value by a vector
            /// </summary>
            /// <param name="x">Scalar value</param>
            /// <param name="v">Vector</param>
            /// <returns>x * v</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2f operator *(float x, Vector2f v)
            {
                return new Vector2f(v.X * x, v.Y * x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator / overload ; divide a vector by a scalar value
            /// </summary>
            /// <param name="v">Vector</param>
            /// <param name="x">Scalar value</param>
            /// <returns>v / x</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2f operator /(Vector2f v, float x)
            {
                return new Vector2f(v.X / x, v.Y / x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator == overload ; check vector equality
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 == v2</returns>
            ////////////////////////////////////////////////////////////
            public static bool operator ==(Vector2f v1, Vector2f v2)
            {
                return v1.Equals(v2);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator != overload ; check vector inequality
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 != v2</returns>
            ////////////////////////////////////////////////////////////
            public static bool operator !=(Vector2f v1, Vector2f v2)
            {
                return !v1.Equals(v2);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Provide a string describing the object
            /// </summary>
            /// <returns>String description of the object</returns>
            ////////////////////////////////////////////////////////////
            public override string ToString()
            {
                return "[Vector2f]" +
                       " X(" + X + ")" +
                       " Y(" + Y + ")";
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Compare vector and object and checks if they are equal
            /// </summary>
            /// <param name="obj">Object to check</param>
            /// <returns>Object and vector are equal</returns>
            ////////////////////////////////////////////////////////////
            public override bool Equals(object obj)
            {
                return (obj is Vector2f) && obj.Equals(this);
            }

            ///////////////////////////////////////////////////////////
            /// <summary>
            /// Compare two vectors and checks if they are equal
            /// </summary>
            /// <param name="other">Vector to check</param>
            /// <returns>Vectors are equal</returns>
            ////////////////////////////////////////////////////////////
            public bool Equals(Vector2f other)
            {
                return (X == other.X) &&
                       (Y == other.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Provide a integer describing the object
            /// </summary>
            /// <returns>Integer description of the object</returns>
            ////////////////////////////////////////////////////////////
            public override int GetHashCode()
            {
                return X.GetHashCode() ^
                       Y.GetHashCode();
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Explicit casting to another vector type
            /// </summary>
            /// <param name="v">Vector being casted</param>
            /// <returns>Casting result</returns>
            ////////////////////////////////////////////////////////////
            public static explicit operator Vector2i(Vector2f v)
            {
                return new Vector2i((int)v.X, (int)v.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Explicit casting to another vector type
            /// </summary>
            /// <param name="v">Vector being casted</param>
            /// <returns>Casting result</returns>
            ////////////////////////////////////////////////////////////
            public static explicit operator Vector2u(Vector2f v)
            {
                return new Vector2u((uint)v.X, (uint)v.Y);
            }

            /// <summary>X (horizontal) component of the vector</summary>
            public float X;

            /// <summary>Y (vertical) component of the vector</summary>
            public float Y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Vector2i is an utility class for manipulating 2 dimensional
        /// vectors with integer components
        /// </summary>
        ////////////////////////////////////////////////////////////
        [StructLayout(LayoutKind.Sequential)]
        public struct Vector2i : IEquatable<Vector2i>
        {
            /// <summary>
            /// Returns a vector with components 0, 0.
            /// </summary>
            public static readonly Vector2i Zero = new Vector2i(0, 0);

            /// <summary>
            /// Returns a vector with components 1, 1.
            /// </summary>
            public static readonly Vector2i One = new Vector2i(1, 1);

            /// <summary>
            /// Returns a vector with components 0, -1.
            /// </summary>
            public static readonly Vector2i North = new Vector2i(0, -1);

            /// <summary>
            /// Returns a vector with components 0, 1.
            /// </summary>
            public static readonly Vector2i South = new Vector2i(0, 1);

            /// <summary>
            /// Returns a vector with components 1, 0.
            /// </summary>
            public static readonly Vector2i East = new Vector2i(1, 0);

            /// <summary>
            /// Returns a vector with components -1, 0.
            /// </summary>
            public static readonly Vector2i West = new Vector2i(-1, 0);

            /// <summary>
            /// Returns a vector with components -1, 1.
            /// </summary>
            public static readonly Vector2i SouthWest = new Vector2i(-1, 1);

            /// <summary>
            /// Returns a vector with components 1, 1.
            /// </summary>
            public static readonly Vector2i SouthEast = Vector2i.One;

            /// <summary>
            /// Returns a vector with components 1, -1.
            /// </summary>
            public static readonly Vector2i NorthEast = new Vector2i(1, -1);

            /// <summary>
            /// Returns a vector with components -1, -1.
            /// </summary>
            public static readonly Vector2i NorthWest = new Vector2i(-1, -1);

            /// <summary>
            /// Returns a vector with components 0, -1.
            /// </summary>
            public static readonly Vector2i Up = new Vector2i(0, -1);

            /// <summary>
            /// Returns a vector with components 0, 1.
            /// </summary>
            public static readonly Vector2i Down = new Vector2i(0, 1);

            /// <summary>
            /// Returns a vector with components -1, 0.
            /// </summary>
            public static readonly Vector2i Left = new Vector2i(-1, 0);

            /// <summary>
            /// Returns a vector with components 1, 0.
            /// </summary>
            public static readonly Vector2i Right = new Vector2i(1, 0);

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the vector from its coordinates
            /// </summary>
            /// <param name="x">X coordinate</param>
            /// <param name="y">Y coordinate</param>
            ////////////////////////////////////////////////////////////
            public Vector2i(int x, int y)
            {
                X = x;
                Y = y;
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the vector from its coordinates
            /// </summary>
            /// <param name="xy">X and Y coordinate</param>
            ////////////////////////////////////////////////////////////
            public Vector2i(int xy)
            {
                X = xy;
                Y = xy;
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator - overload ; returns the opposite of a vector
            /// </summary>
            /// <param name="v">Vector to negate</param>
            /// <returns>-v</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2i operator -(Vector2i v)
            {
                return new Vector2i(-v.X, -v.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator - overload ; subtracts two vectors
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 - v2</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2i operator -(Vector2i v1, Vector2i v2)
            {
                return new Vector2i(v1.X - v2.X, v1.Y - v2.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator + overload ; add two vectors
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 + v2</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2i operator +(Vector2i v1, Vector2i v2)
            {
                return new Vector2i(v1.X + v2.X, v1.Y + v2.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator * overload ; multiply a vector by a scalar value
            /// </summary>
            /// <param name="v">Vector</param>
            /// <param name="x">Scalar value</param>
            /// <returns>v * x</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2i operator *(Vector2i v, int x)
            {
                return new Vector2i(v.X * x, v.Y * x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator * overload ; multiply a scalar value by a vector
            /// </summary>
            /// <param name="x">Scalar value</param>
            /// <param name="v">Vector</param>
            /// <returns>x * v</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2i operator *(int x, Vector2i v)
            {
                return new Vector2i(v.X * x, v.Y * x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator / overload ; divide a vector by a scalar value
            /// </summary>
            /// <param name="v">Vector</param>
            /// <param name="x">Scalar value</param>
            /// <returns>v / x</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2i operator /(Vector2i v, int x)
            {
                return new Vector2i(v.X / x, v.Y / x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator == overload ; check vector equality
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 == v2</returns>
            ////////////////////////////////////////////////////////////
            public static bool operator ==(Vector2i v1, Vector2i v2)
            {
                return v1.Equals(v2);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator != overload ; check vector inequality
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 != v2</returns>
            ////////////////////////////////////////////////////////////
            public static bool operator !=(Vector2i v1, Vector2i v2)
            {
                return !v1.Equals(v2);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Provide a string describing the object
            /// </summary>
            /// <returns>String description of the object</returns>
            ////////////////////////////////////////////////////////////
            public override string ToString()
            {
                return "[Vector2i]" +
                       " X(" + X + ")" +
                       " Y(" + Y + ")";
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Compare vector and object and checks if they are equal
            /// </summary>
            /// <param name="obj">Object to check</param>
            /// <returns>Object and vector are equal</returns>
            ////////////////////////////////////////////////////////////
            public override bool Equals(object obj)
            {
                return (obj is Vector2i) && obj.Equals(this);
            }

            ///////////////////////////////////////////////////////////
            /// <summary>
            /// Compare two vectors and checks if they are equal
            /// </summary>
            /// <param name="other">Vector to check</param>
            /// <returns>Vectors are equal</returns>
            ////////////////////////////////////////////////////////////
            public bool Equals(Vector2i other)
            {
                return (X == other.X) &&
                       (Y == other.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Provide a integer describing the object
            /// </summary>
            /// <returns>Integer description of the object</returns>
            ////////////////////////////////////////////////////////////
            public override int GetHashCode()
            {
                return X.GetHashCode() ^
                       Y.GetHashCode();
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Explicit casting to another vector type
            /// </summary>
            /// <param name="v">Vector being casted</param>
            /// <returns>Casting result</returns>
            ////////////////////////////////////////////////////////////
            public static explicit operator Vector2f(Vector2i v)
            {
                return new Vector2f(v.X, v.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Explicit casting to another vector type
            /// </summary>
            /// <param name="v">Vector being casted</param>
            /// <returns>Casting result</returns>
            ////////////////////////////////////////////////////////////
            public static explicit operator Vector2u(Vector2i v)
            {
                return new Vector2u((uint)v.X, (uint)v.Y);
            }

            /// <summary>X (horizontal) component of the vector</summary>
            public int X;

            /// <summary>Y (vertical) component of the vector</summary>
            public int Y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Vector2u is an utility class for manipulating 2 dimensional
        /// vectors with unsigned integer components
        /// </summary>
        ////////////////////////////////////////////////////////////
        [StructLayout(LayoutKind.Sequential)]
        public struct Vector2u : IEquatable<Vector2u>
        {
            /// <summary>
            /// Returns a vector with components 0, 0.
            /// </summary>
            public static readonly Vector2u Zero = new Vector2u(0, 0);

            /// <summary>
            /// Returns a vector with components 1, 1.
            /// </summary>
            public static readonly Vector2u One = new Vector2u(1, 1);

            /// <summary>
            /// Returns a vector with components 0, 1.
            /// </summary>
            public static readonly Vector2u South = new Vector2u(0, 1);

            /// <summary>
            /// Returns a vector with components 1, 0.
            /// </summary>
            public static readonly Vector2u East = new Vector2u(1, 0);

            /// <summary>
            /// Returns a vector with components 1, 1.
            /// </summary>
            public static readonly Vector2u SouthEast = Vector2u.One;

            /// <summary>
            /// Returns a vector with components 0, 1.
            /// </summary>
            public static readonly Vector2u Down = new Vector2u(0, 1);

            /// <summary>
            /// Returns a vector with components 1, 0.
            /// </summary>
            public static readonly Vector2u Right = new Vector2u(1, 0);

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the vector from its coordinates
            /// </summary>
            /// <param name="x">X coordinate</param>
            /// <param name="y">Y coordinate</param>
            ////////////////////////////////////////////////////////////
            public Vector2u(uint x, uint y)
            {
                X = x;
                Y = y;
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the vector from its coordinates
            /// </summary>
            /// <param name="xy">X and Y coordinate</param>
            ////////////////////////////////////////////////////////////
            public Vector2u(uint xy)
            {
                X = xy;
                Y = xy;
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator - overload ; subtracts two vectors
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 - v2</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2u operator -(Vector2u v1, Vector2u v2)
            {
                return new Vector2u(v1.X - v2.X, v1.Y - v2.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator + overload ; add two vectors
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 + v2</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2u operator +(Vector2u v1, Vector2u v2)
            {
                return new Vector2u(v1.X + v2.X, v1.Y + v2.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator * overload ; multiply a vector by a scalar value
            /// </summary>
            /// <param name="v">Vector</param>
            /// <param name="x">Scalar value</param>
            /// <returns>v * x</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2u operator *(Vector2u v, uint x)
            {
                return new Vector2u(v.X * x, v.Y * x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator * overload ; multiply a scalar value by a vector
            /// </summary>
            /// <param name="x">Scalar value</param>
            /// <param name="v">Vector</param>
            /// <returns>x * v</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2u operator *(uint x, Vector2u v)
            {
                return new Vector2u(v.X * x, v.Y * x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator / overload ; divide a vector by a scalar value
            /// </summary>
            /// <param name="v">Vector</param>
            /// <param name="x">Scalar value</param>
            /// <returns>v / x</returns>
            ////////////////////////////////////////////////////////////
            public static Vector2u operator /(Vector2u v, uint x)
            {
                return new Vector2u(v.X / x, v.Y / x);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator == overload ; check vector equality
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 == v2</returns>
            ////////////////////////////////////////////////////////////
            public static bool operator ==(Vector2u v1, Vector2u v2)
            {
                return v1.Equals(v2);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Operator != overload ; check vector inequality
            /// </summary>
            /// <param name="v1">First vector</param>
            /// <param name="v2">Second vector</param>
            /// <returns>v1 != v2</returns>
            ////////////////////////////////////////////////////////////
            public static bool operator !=(Vector2u v1, Vector2u v2)
            {
                return !v1.Equals(v2);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Provide a string describing the object
            /// </summary>
            /// <returns>String description of the object</returns>
            ////////////////////////////////////////////////////////////
            public override string ToString()
            {
                return "[Vector2u]" +
                       " X(" + X + ")" +
                       " Y(" + Y + ")";
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Compare vector and object and checks if they are equal
            /// </summary>
            /// <param name="obj">Object to check</param>
            /// <returns>Object and vector are equal</returns>
            ////////////////////////////////////////////////////////////
            public override bool Equals(object obj)
            {
                return (obj is Vector2u) && obj.Equals(this);
            }

            ///////////////////////////////////////////////////////////
            /// <summary>
            /// Compare two vectors and checks if they are equal
            /// </summary>
            /// <param name="other">Vector to check</param>
            /// <returns>Vectors are equal</returns>
            ////////////////////////////////////////////////////////////
            public bool Equals(Vector2u other)
            {
                return (X == other.X) &&
                       (Y == other.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Provide a integer describing the object
            /// </summary>
            /// <returns>Integer description of the object</returns>
            ////////////////////////////////////////////////////////////
            public override int GetHashCode()
            {
                return X.GetHashCode() ^
                       Y.GetHashCode();
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Explicit casting to another vector type
            /// </summary>
            /// <param name="v">Vector being casted</param>
            /// <returns>Casting result</returns>
            ////////////////////////////////////////////////////////////
            public static explicit operator Vector2i(Vector2u v)
            {
                return new Vector2i((int)v.X, (int)v.Y);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Explicit casting to another vector type
            /// </summary>
            /// <param name="v">Vector being casted</param>
            /// <returns>Casting result</returns>
            ////////////////////////////////////////////////////////////
            public static explicit operator Vector2f(Vector2u v)
            {
                return new Vector2f(v.X, v.Y);
            }

            /// <summary>X (horizontal) component of the vector</summary>
            public uint X;

            /// <summary>Y (vertical) component of the vector</summary>
            public uint Y;
        }
    }
}
