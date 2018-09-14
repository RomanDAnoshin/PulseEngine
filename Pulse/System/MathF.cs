using SFML.System;
using System;

namespace Pulse.System
{
    public static class MathF
    {
        public static Random RandomGenerator = new Random();

        public const float Pi = 3.141592653f;
        public const float TwoPi = 2 * 3.141592653f;
        public const float HalfPi = 3.141592653f / 2;
        public const float DegToRad = Pi / 180;
        public const float RadToDeg = 180 / Pi;

        public static float Max(float x, float y)
        {
            return (x > y) ? x : y;
        }

        public static float Min(float x, float y)
        {
            return (x < y) ? x : y;
        }

        public static float Abs(float x)
        {
            return Math.Abs(x);
        }

        public static int Sign(float x)
        {
            return Math.Sign(x);
        }

        public static float Cos(float radians)
        {
            return (float)Math.Cos(radians);
        }

        public static float Sin(float radians)
        {
            return (float)Math.Sin(radians);
        }

        public static float Atan2(Vector2f v)
        {
            return (float)Math.Atan2(v.Y, v.X);
        }

        public static float Atan2(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        public static float Asin(float v)
        {
            return (float)Math.Asin(v);
        }

        public static float Acos(float v)
        {
            return (float)Math.Acos(v);
        }

        public static float Sqr(float x)
        {
            return x * x;
        }

        public static float Sqrt(float x)
        {
            return (float)Math.Sqrt(x);
        }

        public static float Dist2(Vector2f a, Vector2f b)
        {
            return Sqr(a.X - b.X) + Sqr(a.Y - b.Y);
        }

        public static float Log(float x)
        {
            return (float)Math.Log(x);
        }

        public static float Pow(float x, float y)
        {
            return (float)Math.Pow(x, y);
        }

        public static float RandomFloat(this Random rng, float min, float max)
        {
            return rng.RandomFloat() * (max - min) + min;
        }

        public static float RandomFloat(float min, float max)
        {
            return RandomGenerator.RandomFloat(min, max);
        }

        public static bool RandomBool(this Random rng)
        {
            return rng.RandomInt(2) == 0;
        }

        public static bool RandomBool()
        {
            return RandomGenerator.RandomBool();
        }

        public static int RandomInt(this Random rng, int min, int max)
        {
            return rng.RandomInt(max - min + 1) + min;
        }

        public static int RandomInt(int min, int max)
        {
            return RandomGenerator.RandomInt(min, max);
        }

        public static T RandomOf<T>(this Random rng, params T[] objects)
        {
            return objects[rng.RandomInt(objects.Length)];
        }

        public static T RandomOf<T>(params T[] objects)
        {
            return RandomGenerator.RandomOf(objects);
        }

        public static int RandomInt(this Random rng, int maxValue)
        {
            return rng.Next(maxValue);
        }

        public static int RandomInt(int maxValue)
        {
            return RandomGenerator.RandomInt(maxValue);
        }

        public static float RandomFloat(this Random rng)
        {
            return (float)rng.NextDouble();
        }

        public static float RandomFloat()
        {
            return RandomGenerator.RandomFloat();
        }

        public static bool InRange(float x, float upper, float lower)
        {
            return lower <= x && x <= upper;
        }

        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max ? max : value);
        }

        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max ? max : value);
        }

        public static Vector2f Clamp(Vector2f value, Vector2f min, Vector2f max)
        {
            return new Vector2f(
                Clamp(value.X, min.X, max.X),
                Clamp(value.Y, min.Y, max.Y)
            );
        }

        public static float GetVectorLength(Vector2f vector)
        {
            return Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }
    }
}
