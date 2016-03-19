//-----------------------------------------------------------------------
// <copyright file="Utility.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Epic.Vectors.Utility
{
    using System;
    using System.Collections.Generic;
    using Epic.Vectors;

    /// <summary>
    /// Utility methods.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Gets the angle between two points.
        /// </summary>
        /// <param name="source">The source <see cref="Vector2"/>.</param>
        /// <param name="other">The other <see cref="Vector2"/>.</param>
        /// <returns>The angle in degrees.</returns>
        public static double Angle(this Vector2<int> source, Vector2<int> other)
        {
            return Math.Atan2(source.Y - other.Y, other.X - source.X) * (180.0 / Math.PI);
        }

        /// <summary>
        /// Gets a <see cref="Vector2{double}"/> from the specified angle.
        /// </summary>
        /// <param name="angle">The angle in degrees.</param>
        /// <returns>The <see cref="Vector2{double}"/>.</returns>
        public static Vector2<double> FromAngle(double angle)
        {
            // convert angle to radians
            angle = Math.PI * angle / 180.0;

            return Vector2.Create(Math.Cos(angle), -Math.Sin(angle));
        }

        /// <summary>
        /// Gets the distance between two points.
        /// </summary>
        /// <param name="source">The source <see cref="Vector2"/>.</param>
        /// <param name="other">The other <see cref="Vector2"/>.</param>
        /// <returns>The distance.</returns>
        public static double Distance(this Vector2<int> source, Vector2<int> other)
        {
            // d = √ (x2-x1)^2 + (y2-y1)^2
            return Math.Sqrt(Math.Pow(other.X - source.X, 2) + Math.Pow(other.Y - source.Y, 2));
        }

        /// <summary>
        /// Swaps the values from the specified variables.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/>.</typeparam>
        /// <param name="left">Left-hand variable.</param>
        /// <param name="right">Right-hand variable.</param>
        private static void Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }

        /// <summary>
        /// Creates a line to the specified point.
        /// </summary>
        /// <param name="source">Starting <see cref="Vector2{int}"/></param>
        /// <param name="end">Ending <see cref="Vector2{int}"/>,</param>
        /// <returns>The list of points.</returns>
        public static List<Vector2<int>> Line(this Vector2<int> source, Vector2<int> end)
        {
            var result = new List<Vector2<int>>();

            // split the vectors into their components
            var sourceX = source.X;
            var sourceY = source.Y;
            var endX = end.X;
            var endY = end.Y;

            var steep = Math.Abs(sourceY - endY) > Math.Abs(endX - sourceX);

            if (steep)
            {
                Swap(ref sourceX, ref sourceY);
                Swap(ref endX, ref endY);
            }

            if (source.X > end.X)
            {
                Swap(ref sourceX, ref endX);
                Swap(ref sourceY, ref endY);
            }

            var diff = Vector2.Create(end.X - source.X, Math.Abs(end.Y - source.Y));
            var err = (diff.X / 2);
            var ystep = (source.Y < end.Y ? 1 : -1);
            var y = source.Y;

            for (int x = source.X; x <= end.X; ++x)
            {
                if (steep)
                    result.Add(Vector2.Create(y, x));
                else
                    result.Add(Vector2.Create(x, y));

                err = err - diff.Y;

                if (err < 0)
                {
                    y += ystep;
                    err += diff.X;
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the specified Vector2s.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        public static Vector2<int> Multiply(this Vector2<int> source, int value)
        {
            return Vector2.Create(source.X * value, source.Y * value);
        }

        /// <summary>
        /// Multiplies the specified Vector2s.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        public static Vector2<int> Multiply(this Vector2<int> source, float value)
        {
            return Vector2.Create((int)(source.X * value), (int)(source.Y * value));
        }
    }
}