//-----------------------------------------------------------------------
// <copyright file="VectorJsonConverter.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Epic.Vectors.Utility
{
    using System;
    using Epic.Vectors;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts a <see cref="Vector2"/> to json.
    /// </summary>
    public class VectorJsonConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Whether the specified type can be converted.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector2);
        }

        /// <summary>
        /// Reads the json.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns>The object.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // read the x and y components
            var x = (int)reader.ReadAsInt32();
            var y = (int)reader.ReadAsInt32();

            // finish reading the array
            reader.Read();

            return Vector2.Create(x, y);
        }

        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}