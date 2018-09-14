using System;
using System.Runtime.InteropServices;

namespace SFML
{
    namespace Graphics
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Utility class for manipulating 32-bits RGBA colors
        /// </summary>
        ////////////////////////////////////////////////////////////
        [StructLayout(LayoutKind.Sequential)]
        public struct Color : IEquatable<Color>
        {
            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the color from its red, green and blue components
            /// </summary>
            /// <param name="red">Red component</param>
            /// <param name="green">Green component</param>
            /// <param name="blue">Blue component</param>
            ////////////////////////////////////////////////////////////
            public Color(byte red, byte green, byte blue) :
                this(red, green, blue, 255)
            {
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the color from its red, green, blue and alpha components
            /// </summary>
            /// <param name="red">Red component</param>
            /// <param name="green">Green component</param>
            /// <param name="blue">Blue component</param>
            /// <param name="alpha">Alpha (transparency) component</param>
            ////////////////////////////////////////////////////////////
            public Color(byte red, byte green, byte blue, byte alpha)
            {
                R = red;
                G = green;
                B = blue;
                A = alpha;
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Construct the color from another
            /// </summary>
            /// <param name="color">Color to copy</param>
            ////////////////////////////////////////////////////////////
            public Color(Color color) :
                this(color.R, color.G, color.B, color.A)
            {
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Provide a string describing the object
            /// </summary>
            /// <returns>String description of the object</returns>
            ////////////////////////////////////////////////////////////
            public override string ToString()
            {
                return "[Color]" +
                       " R(" + R + ")" +
                       " G(" + G + ")" +
                       " B(" + B + ")" +
                       " A(" + A + ")";
            }
            
            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Compare color and object and checks if they are equal
            /// </summary>
            /// <param name="obj">Object to check</param>
            /// <returns>Object and color are equal</returns>
            ////////////////////////////////////////////////////////////
            public override bool Equals(object obj)
            {
                return (obj is Color) && obj.Equals(this);
            }
            
            ///////////////////////////////////////////////////////////
            /// <summary>
            /// Compare two colors and checks if they are equal
            /// </summary>
            /// <param name="other">Color to check</param>
            /// <returns>Colors are equal</returns>
            ////////////////////////////////////////////////////////////
            public bool Equals(Color other)
            {
                return (R == other.R) &&
                       (G == other.G) &&
                       (B == other.B) &&
                       (A == other.A);
            }
            
            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Provide a integer describing the object
            /// </summary>
            /// <returns>Integer description of the object</returns>
            ////////////////////////////////////////////////////////////
            public override int GetHashCode()
            {
                return (int)(R << 24) |
                       (int)(G << 16) |
                       (int)(B << 8)  |
                       (int)A;
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Compare two colors and checks if they are equal
            /// </summary>
            /// <returns>Colors are equal</returns>
            ////////////////////////////////////////////////////////////
            public static bool operator ==(Color left, Color right)
            {
                return left.Equals(right);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// Compare two colors and checks if they are not equal
            /// </summary>
            /// <returns>Colors are not equal</returns>
            ////////////////////////////////////////////////////////////
            public static bool operator !=(Color left, Color right)
            {
                return !left.Equals(right);
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// This operator returns the component-wise sum of two colors.
            /// Components that exceed 255 are clamped to 255.
            /// </summary>
            /// <returns>Result of left + right</returns>
            ////////////////////////////////////////////////////////////
            public static Color operator +(Color left, Color right)
            {
                return new Color((byte)Math.Min(left.R + right.R, 255),
                                 (byte)Math.Min(left.G + right.G, 255),
                                 (byte)Math.Min(left.B + right.B, 255),
                                 (byte)Math.Min(left.A + right.A, 255));
            }

            ////////////////////////////////////////////////////////////
            /// <summary>
            /// This operator returns the component-wise subtraction of two colors.
            /// Components below 0 are clamped to 0.
            /// </summary>
            /// <returns>Result of left - right</returns>
            ////////////////////////////////////////////////////////////
            public static Color operator -(Color left, Color right)
            {
                return new Color((byte)Math.Max(left.R - right.R, 0),
                                 (byte)Math.Max(left.G - right.G, 0),
                                 (byte)Math.Max(left.B - right.B, 0),
                                 (byte)Math.Max(left.A - right.A, 0));
            }
            
            ////////////////////////////////////////////////////////////
            /// <summary>
            /// This operator returns the component-wise multiplication of two colors.
            /// Components above 255 are clamped to 255.
            /// </summary>
            /// <returns>Result of left * right</returns>
            ////////////////////////////////////////////////////////////
            public static Color operator *(Color left, Color right)
            {
                return new Color((byte)Math.Min(left.R * right.R, 255),
                                 (byte)Math.Min(left.G * right.G, 255),
                                 (byte)Math.Min(left.B * right.B, 255),
                                 (byte)Math.Min(left.A * right.A, 255));
            }

            /// <summary>Red component of the color</summary>
            public byte R;

            /// <summary>Green component of the color</summary>
            public byte G;

            /// <summary>Blue component of the color</summary>
            public byte B;

            /// <summary>Alpha (transparent) component of the color</summary>
            public byte A;


            /// <summary>Predefined black color</summary>
            public static readonly Color Black = new Color(0, 0, 0);

            /// <summary>Predefined white color</summary>
            public static readonly Color White = new Color(255, 255, 255);

            /// <summary>Predefined gray color</summary>
            public static readonly Color Gray = new Color(128, 128, 128);

            /// <summary>Predefined dark gray color</summary>
            public static readonly Color DarkGray = new Color(64, 64, 64);

            /// <summary>Predefined red color</summary>
            public static readonly Color Red = new Color(255, 0, 0);

            /// <summary>Predefined orange color</summary>
            public static readonly Color Orange = new Color(255, 128, 0);

            /// <summary>Predefined green color</summary>
            public static readonly Color Green = new Color(0, 255, 0);

            /// <summary>Predefined blue color</summary>
            public static readonly Color Blue = new Color(0, 0, 255);

            /// <summary>Predefined yellow color</summary>
            public static readonly Color Yellow = new Color(255, 255, 0);

            /// <summary>Predefined magenta color</summary>
            public static readonly Color Magenta = new Color(255, 0, 255);

            /// <summary>Predefined cyan color</summary>
            public static readonly Color Cyan = new Color(0, 255, 255);

            /// <summary>Predefined transparent(black) color</summary>
            public static readonly Color Transparent = new Color(255, 255, 255, 0);

            /// <summary>Predefined zero color</summary>
            public static readonly Color Zero = new Color(0, 0, 0, 0);
        }
    }
}