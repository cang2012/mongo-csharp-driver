﻿/* Copyright 2010-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;

namespace MongoDB.Bson.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializer for a <see cref="Tuple{T1}"/>.
    /// </summary>
    /// <typeparam name="T1">The type of item 1.</typeparam>
    public class TupleSerializer<T1> : SealedClassSerializerBase<Tuple<T1>>
    {
        // private fields
        private readonly IBsonSerializer<T1> _item1Serializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1}"/> class.
        /// </summary>
        public TupleSerializer()
            : this(
                BsonSerializer.LookupSerializer<T1>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1}"/> class.
        /// </summary>
        /// <param name="item1Serializer">The Item1 serializer.</param>
        public TupleSerializer(
            IBsonSerializer<T1> item1Serializer)
        {
            if (item1Serializer == null) { throw new ArgumentNullException("item1Serializer"); }

            _item1Serializer = item1Serializer;
        }

        // public properties
        /// <summary>
        /// Gets the Item1 serializer.
        /// </summary>
        public IBsonSerializer<T1> Item1Serializer
        {
            get { return _item1Serializer; }
        }

        // public methods
        /// <summary>
        /// Deserializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override Tuple<T1> DeserializeValue(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var item1 = context.DeserializeWithChildContext<T1>(_item1Serializer);
            context.Reader.ReadEndArray();

            return new Tuple<T1>(item1);
        }

        /// <summary>
        /// Serializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        protected override void SerializeValue(BsonSerializationContext context, Tuple<T1> value)
        {
            context.Writer.WriteStartArray();
            context.SerializeWithChildContext<T1>(_item1Serializer, value.Item1);
            context.Writer.WriteEndArray();
        }
    }

    /// <summary>
    /// Represents a serializer for a <see cref="Tuple{T1, T2}"/>.
    /// </summary>
    /// <typeparam name="T1">The type of item 1.</typeparam>
    /// <typeparam name="T2">The type of item 2.</typeparam>
    public class TupleSerializer<T1, T2> : SealedClassSerializerBase<Tuple<T1, T2>>
    {
        // private fields
        private readonly IBsonSerializer<T1> _item1Serializer;
        private readonly IBsonSerializer<T2> _item2Serializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2}"/> class.
        /// </summary>
        public TupleSerializer()
            : this(
                BsonSerializer.LookupSerializer<T1>(),
                BsonSerializer.LookupSerializer<T2>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2}"/> class.
        /// </summary>
        /// <param name="item1Serializer">The Item1 serializer.</param>
        /// <param name="item2Serializer">The Item2 serializer.</param>
        public TupleSerializer(
            IBsonSerializer<T1> item1Serializer,
            IBsonSerializer<T2> item2Serializer)
        {
            if (item1Serializer == null) { throw new ArgumentNullException("item1Serializer"); }
            if (item2Serializer == null) { throw new ArgumentNullException("item2Serializer"); }

            _item1Serializer = item1Serializer;
            _item2Serializer = item2Serializer;
        }

        // public properties
        /// <summary>
        /// Gets the Item1 serializer.
        /// </summary>
        public IBsonSerializer<T1> Item1Serializer
        {
            get { return _item1Serializer; }
        }

        /// <summary>
        /// Gets the Item2 serializer.
        /// </summary>
        public IBsonSerializer<T2> Item2Serializer
        {
            get { return _item2Serializer; }
        }

        // public methods
        /// <summary>
        /// Deserializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override Tuple<T1, T2> DeserializeValue(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var item1 = context.DeserializeWithChildContext<T1>(_item1Serializer);
            var item2 = context.DeserializeWithChildContext<T2>(_item2Serializer);
            context.Reader.ReadEndArray();

            return new Tuple<T1, T2>(item1, item2);
        }

        /// <summary>
        /// Serializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        protected override void SerializeValue(BsonSerializationContext context, Tuple<T1, T2> value)
        {
            context.Writer.WriteStartArray();
            context.SerializeWithChildContext<T1>(_item1Serializer, value.Item1);
            context.SerializeWithChildContext<T2>(_item2Serializer, value.Item2);
            context.Writer.WriteEndArray();
        }
    }

    /// <summary>
    /// Represents a serializer for a <see cref="Tuple{T1, T2, T3}"/>.
    /// </summary>
    /// <typeparam name="T1">The type of item 1.</typeparam>
    /// <typeparam name="T2">The type of item 2.</typeparam>
    /// <typeparam name="T3">The type of item 3.</typeparam>
    public class TupleSerializer<T1, T2, T3> : SealedClassSerializerBase<Tuple<T1, T2, T3>>
    {
        // private fields
        private readonly IBsonSerializer<T1> _item1Serializer;
        private readonly IBsonSerializer<T2> _item2Serializer;
        private readonly IBsonSerializer<T3> _item3Serializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3}"/> class.
        /// </summary>
        public TupleSerializer()
            : this(
                BsonSerializer.LookupSerializer<T1>(),
                BsonSerializer.LookupSerializer<T2>(),
                BsonSerializer.LookupSerializer<T3>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3}"/> class.
        /// </summary>
        /// <param name="item1Serializer">The Item1 serializer.</param>
        /// <param name="item2Serializer">The Item2 serializer.</param>
        /// <param name="item3Serializer">The Item3 serializer.</param>
        public TupleSerializer(
            IBsonSerializer<T1> item1Serializer,
            IBsonSerializer<T2> item2Serializer,
            IBsonSerializer<T3> item3Serializer)
        {
            if (item1Serializer == null) { throw new ArgumentNullException("item1Serializer"); }
            if (item2Serializer == null) { throw new ArgumentNullException("item2Serializer"); }
            if (item3Serializer == null) { throw new ArgumentNullException("item3Serializer"); }

            _item1Serializer = item1Serializer;
            _item2Serializer = item2Serializer;
            _item3Serializer = item3Serializer;
        }

        // public properties
        /// <summary>
        /// Gets the Item1 serializer.
        /// </summary>
        public IBsonSerializer<T1> Item1Serializer
        {
            get { return _item1Serializer; }
        }

        /// <summary>
        /// Gets the Item2 serializer.
        /// </summary>
        public IBsonSerializer<T2> Item2Serializer
        {
            get { return _item2Serializer; }
        }

        /// <summary>
        /// Gets the Item3 serializer.
        /// </summary>
        public IBsonSerializer<T3> Item3Serializer
        {
            get { return _item3Serializer; }
        }

        // public methods
        /// <summary>
        /// Deserializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override Tuple<T1, T2, T3> DeserializeValue(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var item1 = context.DeserializeWithChildContext<T1>(_item1Serializer);
            var item2 = context.DeserializeWithChildContext<T2>(_item2Serializer);
            var item3 = context.DeserializeWithChildContext<T3>(_item3Serializer);
            context.Reader.ReadEndArray();

            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }

        /// <summary>
        /// Serializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        protected override void SerializeValue(BsonSerializationContext context, Tuple<T1, T2, T3> value)
        {
            context.Writer.WriteStartArray();
            context.SerializeWithChildContext<T1>(_item1Serializer, value.Item1);
            context.SerializeWithChildContext<T2>(_item2Serializer, value.Item2);
            context.SerializeWithChildContext<T3>(_item3Serializer, value.Item3);
            context.Writer.WriteEndArray();
        }
    }

    /// <summary>
    /// Represents a serializer for a <see cref="Tuple{T1, T2, T3, T4}"/>.
    /// </summary>
    /// <typeparam name="T1">The type of item 1.</typeparam>
    /// <typeparam name="T2">The type of item 2.</typeparam>
    /// <typeparam name="T3">The type of item 3.</typeparam>
    /// <typeparam name="T4">The type of item 4.</typeparam>
    public class TupleSerializer<T1, T2, T3, T4> : SealedClassSerializerBase<Tuple<T1, T2, T3, T4>>
    {
        // private fields
        private readonly IBsonSerializer<T1> _item1Serializer;
        private readonly IBsonSerializer<T2> _item2Serializer;
        private readonly IBsonSerializer<T3> _item3Serializer;
        private readonly IBsonSerializer<T4> _item4Serializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4}"/> class.
        /// </summary>
        public TupleSerializer()
            : this(
                BsonSerializer.LookupSerializer<T1>(),
                BsonSerializer.LookupSerializer<T2>(),
                BsonSerializer.LookupSerializer<T3>(),
                BsonSerializer.LookupSerializer<T4>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4}"/> class.
        /// </summary>
        /// <param name="item1Serializer">The Item1 serializer.</param>
        /// <param name="item2Serializer">The Item2 serializer.</param>
        /// <param name="item3Serializer">The Item3 serializer.</param>
        /// <param name="item4Serializer">The Item4 serializer.</param>
        public TupleSerializer(
            IBsonSerializer<T1> item1Serializer,
            IBsonSerializer<T2> item2Serializer,
            IBsonSerializer<T3> item3Serializer,
            IBsonSerializer<T4> item4Serializer)
        {
            if (item1Serializer == null) { throw new ArgumentNullException("item1Serializer"); }
            if (item2Serializer == null) { throw new ArgumentNullException("item2Serializer"); }
            if (item3Serializer == null) { throw new ArgumentNullException("item3Serializer"); }
            if (item4Serializer == null) { throw new ArgumentNullException("item4Serializer"); }

            _item1Serializer = item1Serializer;
            _item2Serializer = item2Serializer;
            _item3Serializer = item3Serializer;
            _item4Serializer = item4Serializer;
        }

        // public properties
        /// <summary>
        /// Gets the Item1 serializer.
        /// </summary>
        public IBsonSerializer<T1> Item1Serializer
        {
            get { return _item1Serializer; }
        }

        /// <summary>
        /// Gets the Item2 serializer.
        /// </summary>
        public IBsonSerializer<T2> Item2Serializer
        {
            get { return _item2Serializer; }
        }

        /// <summary>
        /// Gets the Item3 serializer.
        /// </summary>
        public IBsonSerializer<T3> Item3Serializer
        {
            get { return _item3Serializer; }
        }

        /// <summary>
        /// Gets the Item4 serializer.
        /// </summary>
        public IBsonSerializer<T4> Item4Serializer
        {
            get { return _item4Serializer; }
        }

        // public methods
        /// <summary>
        /// Deserializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override Tuple<T1, T2, T3, T4> DeserializeValue(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var item1 = context.DeserializeWithChildContext<T1>(_item1Serializer);
            var item2 = context.DeserializeWithChildContext<T2>(_item2Serializer);
            var item3 = context.DeserializeWithChildContext<T3>(_item3Serializer);
            var item4 = context.DeserializeWithChildContext<T4>(_item4Serializer);
            context.Reader.ReadEndArray();

            return new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        }

        /// <summary>
        /// Serializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        protected override void SerializeValue(BsonSerializationContext context, Tuple<T1, T2, T3, T4> value)
        {
            context.Writer.WriteStartArray();
            context.SerializeWithChildContext<T1>(_item1Serializer, value.Item1);
            context.SerializeWithChildContext<T2>(_item2Serializer, value.Item2);
            context.SerializeWithChildContext<T3>(_item3Serializer, value.Item3);
            context.SerializeWithChildContext<T4>(_item4Serializer, value.Item4);
            context.Writer.WriteEndArray();
        }
    }

    /// <summary>
    /// Represents a serializer for a <see cref="Tuple{T1, T2, T3, T4, T5}"/>.
    /// </summary>
    /// <typeparam name="T1">The type of item 1.</typeparam>
    /// <typeparam name="T2">The type of item 2.</typeparam>
    /// <typeparam name="T3">The type of item 3.</typeparam>
    /// <typeparam name="T4">The type of item 4.</typeparam>
    /// <typeparam name="T5">The type of item 5.</typeparam>
    public class TupleSerializer<T1, T2, T3, T4, T5> : SealedClassSerializerBase<Tuple<T1, T2, T3, T4, T5>>
    {
        // private fields
        private readonly IBsonSerializer<T1> _item1Serializer;
        private readonly IBsonSerializer<T2> _item2Serializer;
        private readonly IBsonSerializer<T3> _item3Serializer;
        private readonly IBsonSerializer<T4> _item4Serializer;
        private readonly IBsonSerializer<T5> _item5Serializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4, T5}"/> class.
        /// </summary>
        public TupleSerializer()
            : this(
                BsonSerializer.LookupSerializer<T1>(),
                BsonSerializer.LookupSerializer<T2>(),
                BsonSerializer.LookupSerializer<T3>(),
                BsonSerializer.LookupSerializer<T4>(),
                BsonSerializer.LookupSerializer<T5>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4, T5}"/> class.
        /// </summary>
        /// <param name="item1Serializer">The Item1 serializer.</param>
        /// <param name="item2Serializer">The Item2 serializer.</param>
        /// <param name="item3Serializer">The Item3 serializer.</param>
        /// <param name="item4Serializer">The Item4 serializer.</param>
        /// <param name="item5Serializer">The Item5 serializer.</param>
        public TupleSerializer(
            IBsonSerializer<T1> item1Serializer,
            IBsonSerializer<T2> item2Serializer,
            IBsonSerializer<T3> item3Serializer,
            IBsonSerializer<T4> item4Serializer,
            IBsonSerializer<T5> item5Serializer)
        {
            if (item1Serializer == null) { throw new ArgumentNullException("item1Serializer"); }
            if (item2Serializer == null) { throw new ArgumentNullException("item2Serializer"); }
            if (item3Serializer == null) { throw new ArgumentNullException("item3Serializer"); }
            if (item4Serializer == null) { throw new ArgumentNullException("item4Serializer"); }
            if (item5Serializer == null) { throw new ArgumentNullException("item5Serializer"); }

            _item1Serializer = item1Serializer;
            _item2Serializer = item2Serializer;
            _item3Serializer = item3Serializer;
            _item4Serializer = item4Serializer;
            _item5Serializer = item5Serializer;
        }

        // public properties
        /// <summary>
        /// Gets the Item1 serializer.
        /// </summary>
        public IBsonSerializer<T1> Item1Serializer
        {
            get { return _item1Serializer; }
        }

        /// <summary>
        /// Gets the Item2 serializer.
        /// </summary>
        public IBsonSerializer<T2> Item2Serializer
        {
            get { return _item2Serializer; }
        }

        /// <summary>
        /// Gets the Item3 serializer.
        /// </summary>
        public IBsonSerializer<T3> Item3Serializer
        {
            get { return _item3Serializer; }
        }

        /// <summary>
        /// Gets the Item4 serializer.
        /// </summary>
        public IBsonSerializer<T4> Item4Serializer
        {
            get { return _item4Serializer; }
        }

        /// <summary>
        /// Gets the Item5 serializer.
        /// </summary>
        public IBsonSerializer<T5> Item5Serializer
        {
            get { return _item5Serializer; }
        }

        // public methods
        /// <summary>
        /// Deserializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override Tuple<T1, T2, T3, T4, T5> DeserializeValue(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var item1 = context.DeserializeWithChildContext<T1>(_item1Serializer);
            var item2 = context.DeserializeWithChildContext<T2>(_item2Serializer);
            var item3 = context.DeserializeWithChildContext<T3>(_item3Serializer);
            var item4 = context.DeserializeWithChildContext<T4>(_item4Serializer);
            var item5 = context.DeserializeWithChildContext<T5>(_item5Serializer);
            context.Reader.ReadEndArray();

            return new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        }

        /// <summary>
        /// Serializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        protected override void SerializeValue(BsonSerializationContext context, Tuple<T1, T2, T3, T4, T5> value)
        {
            context.Writer.WriteStartArray();
            context.SerializeWithChildContext<T1>(_item1Serializer, value.Item1);
            context.SerializeWithChildContext<T2>(_item2Serializer, value.Item2);
            context.SerializeWithChildContext<T3>(_item3Serializer, value.Item3);
            context.SerializeWithChildContext<T4>(_item4Serializer, value.Item4);
            context.SerializeWithChildContext<T5>(_item5Serializer, value.Item5);
            context.Writer.WriteEndArray();
        }
    }

    /// <summary>
    /// Represents a serializer for a <see cref="Tuple{T1, T2, T3, T4, T5, T6}"/>.
    /// </summary>
    /// <typeparam name="T1">The type of item 1.</typeparam>
    /// <typeparam name="T2">The type of item 2.</typeparam>
    /// <typeparam name="T3">The type of item 3.</typeparam>
    /// <typeparam name="T4">The type of item 4.</typeparam>
    /// <typeparam name="T5">The type of item 5.</typeparam>
    /// <typeparam name="T6">The type of item 6.</typeparam>
    public class TupleSerializer<T1, T2, T3, T4, T5, T6> : SealedClassSerializerBase<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        // private fields
        private readonly IBsonSerializer<T1> _item1Serializer;
        private readonly IBsonSerializer<T2> _item2Serializer;
        private readonly IBsonSerializer<T3> _item3Serializer;
        private readonly IBsonSerializer<T4> _item4Serializer;
        private readonly IBsonSerializer<T5> _item5Serializer;
        private readonly IBsonSerializer<T6> _item6Serializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4, T5, T6}"/> class.
        /// </summary>
        public TupleSerializer()
            : this(
                BsonSerializer.LookupSerializer<T1>(),
                BsonSerializer.LookupSerializer<T2>(),
                BsonSerializer.LookupSerializer<T3>(),
                BsonSerializer.LookupSerializer<T4>(),
                BsonSerializer.LookupSerializer<T5>(),
                BsonSerializer.LookupSerializer<T6>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4, T5, T6}"/> class.
        /// </summary>
        /// <param name="item1Serializer">The Item1 serializer.</param>
        /// <param name="item2Serializer">The Item2 serializer.</param>
        /// <param name="item3Serializer">The Item3 serializer.</param>
        /// <param name="item4Serializer">The Item4 serializer.</param>
        /// <param name="item5Serializer">The Item5 serializer.</param>
        /// <param name="item6Serializer">The Item6 serializer.</param>
        public TupleSerializer(
            IBsonSerializer<T1> item1Serializer,
            IBsonSerializer<T2> item2Serializer,
            IBsonSerializer<T3> item3Serializer,
            IBsonSerializer<T4> item4Serializer,
            IBsonSerializer<T5> item5Serializer,
            IBsonSerializer<T6> item6Serializer)
        {
            if (item1Serializer == null) { throw new ArgumentNullException("item1Serializer"); }
            if (item2Serializer == null) { throw new ArgumentNullException("item2Serializer"); }
            if (item3Serializer == null) { throw new ArgumentNullException("item3Serializer"); }
            if (item4Serializer == null) { throw new ArgumentNullException("item4Serializer"); }
            if (item5Serializer == null) { throw new ArgumentNullException("item5Serializer"); }
            if (item6Serializer == null) { throw new ArgumentNullException("item6Serializer"); }

            _item1Serializer = item1Serializer;
            _item2Serializer = item2Serializer;
            _item3Serializer = item3Serializer;
            _item4Serializer = item4Serializer;
            _item5Serializer = item5Serializer;
            _item6Serializer = item6Serializer;
        }

        // public properties
        /// <summary>
        /// Gets the Item1 serializer.
        /// </summary>
        public IBsonSerializer<T1> Item1Serializer
        {
            get { return _item1Serializer; }
        }

        /// <summary>
        /// Gets the Item2 serializer.
        /// </summary>
        public IBsonSerializer<T2> Item2Serializer
        {
            get { return _item2Serializer; }
        }

        /// <summary>
        /// Gets the Item3 serializer.
        /// </summary>
        public IBsonSerializer<T3> Item3Serializer
        {
            get { return _item3Serializer; }
        }

        /// <summary>
        /// Gets the Item4 serializer.
        /// </summary>
        public IBsonSerializer<T4> Item4Serializer
        {
            get { return _item4Serializer; }
        }

        /// <summary>
        /// Gets the Item5 serializer.
        /// </summary>
        public IBsonSerializer<T5> Item5Serializer
        {
            get { return _item5Serializer; }
        }

        /// <summary>
        /// Gets the Item6 serializer.
        /// </summary>
        public IBsonSerializer<T6> Item6Serializer
        {
            get { return _item6Serializer; }
        }

        // public methods
        /// <summary>
        /// Deserializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override Tuple<T1, T2, T3, T4, T5, T6> DeserializeValue(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var item1 = context.DeserializeWithChildContext<T1>(_item1Serializer);
            var item2 = context.DeserializeWithChildContext<T2>(_item2Serializer);
            var item3 = context.DeserializeWithChildContext<T3>(_item3Serializer);
            var item4 = context.DeserializeWithChildContext<T4>(_item4Serializer);
            var item5 = context.DeserializeWithChildContext<T5>(_item5Serializer);
            var item6 = context.DeserializeWithChildContext<T6>(_item6Serializer);
            context.Reader.ReadEndArray();

            return new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        }

        /// <summary>
        /// Serializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        protected override void SerializeValue(BsonSerializationContext context, Tuple<T1, T2, T3, T4, T5, T6> value)
        {
            context.Writer.WriteStartArray();
            context.SerializeWithChildContext<T1>(_item1Serializer, value.Item1);
            context.SerializeWithChildContext<T2>(_item2Serializer, value.Item2);
            context.SerializeWithChildContext<T3>(_item3Serializer, value.Item3);
            context.SerializeWithChildContext<T4>(_item4Serializer, value.Item4);
            context.SerializeWithChildContext<T5>(_item5Serializer, value.Item5);
            context.SerializeWithChildContext<T6>(_item6Serializer, value.Item6);
            context.Writer.WriteEndArray();
        }
    }

    /// <summary>
    /// Represents a serializer for a <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7}"/>.
    /// </summary>
    /// <typeparam name="T1">The type of item 1.</typeparam>
    /// <typeparam name="T2">The type of item 2.</typeparam>
    /// <typeparam name="T3">The type of item 3.</typeparam>
    /// <typeparam name="T4">The type of item 4.</typeparam>
    /// <typeparam name="T5">The type of item 5.</typeparam>
    /// <typeparam name="T6">The type of item 6.</typeparam>
    /// <typeparam name="T7">The type of item 7.</typeparam>
    public class TupleSerializer<T1, T2, T3, T4, T5, T6, T7> : SealedClassSerializerBase<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        // private fields
        private readonly IBsonSerializer<T1> _item1Serializer;
        private readonly IBsonSerializer<T2> _item2Serializer;
        private readonly IBsonSerializer<T3> _item3Serializer;
        private readonly IBsonSerializer<T4> _item4Serializer;
        private readonly IBsonSerializer<T5> _item5Serializer;
        private readonly IBsonSerializer<T6> _item6Serializer;
        private readonly IBsonSerializer<T7> _item7Serializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4, T5, T6, T7}"/> class.
        /// </summary>
        public TupleSerializer()
            : this(
                BsonSerializer.LookupSerializer<T1>(),
                BsonSerializer.LookupSerializer<T2>(),
                BsonSerializer.LookupSerializer<T3>(),
                BsonSerializer.LookupSerializer<T4>(),
                BsonSerializer.LookupSerializer<T5>(),
                BsonSerializer.LookupSerializer<T6>(),
                BsonSerializer.LookupSerializer<T7>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4, T5, T6, T7}"/> class.
        /// </summary>
        /// <param name="item1Serializer">The Item1 serializer.</param>
        /// <param name="item2Serializer">The Item2 serializer.</param>
        /// <param name="item3Serializer">The Item3 serializer.</param>
        /// <param name="item4Serializer">The Item4 serializer.</param>
        /// <param name="item5Serializer">The Item5 serializer.</param>
        /// <param name="item6Serializer">The Item6 serializer.</param>
        /// <param name="item7Serializer">The Item7 serializer.</param>
        public TupleSerializer(
            IBsonSerializer<T1> item1Serializer,
            IBsonSerializer<T2> item2Serializer,
            IBsonSerializer<T3> item3Serializer,
            IBsonSerializer<T4> item4Serializer,
            IBsonSerializer<T5> item5Serializer,
            IBsonSerializer<T6> item6Serializer,
            IBsonSerializer<T7> item7Serializer)
        {
            if (item1Serializer == null) { throw new ArgumentNullException("item1Serializer"); }
            if (item2Serializer == null) { throw new ArgumentNullException("item2Serializer"); }
            if (item3Serializer == null) { throw new ArgumentNullException("item3Serializer"); }
            if (item4Serializer == null) { throw new ArgumentNullException("item4Serializer"); }
            if (item5Serializer == null) { throw new ArgumentNullException("item5Serializer"); }
            if (item6Serializer == null) { throw new ArgumentNullException("item6Serializer"); }
            if (item7Serializer == null) { throw new ArgumentNullException("item7Serializer"); }

            _item1Serializer = item1Serializer;
            _item2Serializer = item2Serializer;
            _item3Serializer = item3Serializer;
            _item4Serializer = item4Serializer;
            _item5Serializer = item5Serializer;
            _item6Serializer = item6Serializer;
            _item7Serializer = item7Serializer;
        }

        // public properties
        /// <summary>
        /// Gets the Item1 serializer.
        /// </summary>
        public IBsonSerializer<T1> Item1Serializer
        {
            get { return _item1Serializer; }
        }

        /// <summary>
        /// Gets the Item2 serializer.
        /// </summary>
        public IBsonSerializer<T2> Item2Serializer
        {
            get { return _item2Serializer; }
        }

        /// <summary>
        /// Gets the Item3 serializer.
        /// </summary>
        public IBsonSerializer<T3> Item3Serializer
        {
            get { return _item3Serializer; }
        }

        /// <summary>
        /// Gets the Item4 serializer.
        /// </summary>
        public IBsonSerializer<T4> Item4Serializer
        {
            get { return _item4Serializer; }
        }

        /// <summary>
        /// Gets the Item5 serializer.
        /// </summary>
        public IBsonSerializer<T5> Item5Serializer
        {
            get { return _item5Serializer; }
        }

        /// <summary>
        /// Gets the Item6 serializer.
        /// </summary>
        public IBsonSerializer<T6> Item6Serializer
        {
            get { return _item6Serializer; }
        }

        /// <summary>
        /// Gets the Item7 serializer.
        /// </summary>
        public IBsonSerializer<T7> Item7Serializer
        {
            get { return _item7Serializer; }
        }

        // public methods
        /// <summary>
        /// Deserializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override Tuple<T1, T2, T3, T4, T5, T6, T7> DeserializeValue(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var item1 = context.DeserializeWithChildContext<T1>(_item1Serializer);
            var item2 = context.DeserializeWithChildContext<T2>(_item2Serializer);
            var item3 = context.DeserializeWithChildContext<T3>(_item3Serializer);
            var item4 = context.DeserializeWithChildContext<T4>(_item4Serializer);
            var item5 = context.DeserializeWithChildContext<T5>(_item5Serializer);
            var item6 = context.DeserializeWithChildContext<T6>(_item6Serializer);
            var item7 = context.DeserializeWithChildContext<T7>(_item7Serializer);
            context.Reader.ReadEndArray();

            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        }

        /// <summary>
        /// Serializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        protected override void SerializeValue(BsonSerializationContext context, Tuple<T1, T2, T3, T4, T5, T6, T7> value)
        {
            context.Writer.WriteStartArray();
            context.SerializeWithChildContext<T1>(_item1Serializer, value.Item1);
            context.SerializeWithChildContext<T2>(_item2Serializer, value.Item2);
            context.SerializeWithChildContext<T3>(_item3Serializer, value.Item3);
            context.SerializeWithChildContext<T4>(_item4Serializer, value.Item4);
            context.SerializeWithChildContext<T5>(_item5Serializer, value.Item5);
            context.SerializeWithChildContext<T6>(_item6Serializer, value.Item6);
            context.SerializeWithChildContext<T7>(_item7Serializer, value.Item7);
            context.Writer.WriteEndArray();
        }
    }

    /// <summary>
    /// Represents a serializer for a <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, TRest}"/>.
    /// </summary>
    /// <typeparam name="T1">The type of item 1.</typeparam>
    /// <typeparam name="T2">The type of item 2.</typeparam>
    /// <typeparam name="T3">The type of item 3.</typeparam>
    /// <typeparam name="T4">The type of item 4.</typeparam>
    /// <typeparam name="T5">The type of item 5.</typeparam>
    /// <typeparam name="T6">The type of item 6.</typeparam>
    /// <typeparam name="T7">The type of item 7.</typeparam>
    /// <typeparam name="TRest">The type of the rest item.</typeparam>
    public class TupleSerializer<T1, T2, T3, T4, T5, T6, T7, TRest> : SealedClassSerializerBase<Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>>
    {
        // private fields
        private readonly IBsonSerializer<T1> _item1Serializer;
        private readonly IBsonSerializer<T2> _item2Serializer;
        private readonly IBsonSerializer<T3> _item3Serializer;
        private readonly IBsonSerializer<T4> _item4Serializer;
        private readonly IBsonSerializer<T5> _item5Serializer;
        private readonly IBsonSerializer<T6> _item6Serializer;
        private readonly IBsonSerializer<T7> _item7Serializer;
        private readonly IBsonSerializer<TRest> _restSerializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4, T5, T6, T7, TRest}"/> class.
        /// </summary>
        public TupleSerializer()
            : this(
                BsonSerializer.LookupSerializer<T1>(),
                BsonSerializer.LookupSerializer<T2>(),
                BsonSerializer.LookupSerializer<T3>(),
                BsonSerializer.LookupSerializer<T4>(),
                BsonSerializer.LookupSerializer<T5>(),
                BsonSerializer.LookupSerializer<T6>(),
                BsonSerializer.LookupSerializer<T7>(),
                BsonSerializer.LookupSerializer<TRest>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleSerializer{T1, T2, T3, T4, T5, T6, T7, TRest}"/> class.
        /// </summary>
        /// <param name="item1Serializer">The Item1 serializer.</param>
        /// <param name="item2Serializer">The Item2 serializer.</param>
        /// <param name="item3Serializer">The Item3 serializer.</param>
        /// <param name="item4Serializer">The Item4 serializer.</param>
        /// <param name="item5Serializer">The Item5 serializer.</param>
        /// <param name="item6Serializer">The Item6 serializer.</param>
        /// <param name="item7Serializer">The Item7 serializer.</param>
        /// <param name="restSerializer">The Rest serializer.</param>
        public TupleSerializer(
            IBsonSerializer<T1> item1Serializer,
            IBsonSerializer<T2> item2Serializer,
            IBsonSerializer<T3> item3Serializer,
            IBsonSerializer<T4> item4Serializer,
            IBsonSerializer<T5> item5Serializer,
            IBsonSerializer<T6> item6Serializer,
            IBsonSerializer<T7> item7Serializer,
            IBsonSerializer<TRest> restSerializer)
        {
            if (item1Serializer == null) { throw new ArgumentNullException("item1Serializer"); }
            if (item2Serializer == null) { throw new ArgumentNullException("item2Serializer"); }
            if (item3Serializer == null) { throw new ArgumentNullException("item3Serializer"); }
            if (item4Serializer == null) { throw new ArgumentNullException("item4Serializer"); }
            if (item5Serializer == null) { throw new ArgumentNullException("item5Serializer"); }
            if (item6Serializer == null) { throw new ArgumentNullException("item6Serializer"); }
            if (item7Serializer == null) { throw new ArgumentNullException("item7Serializer"); }
            if (restSerializer == null) { throw new ArgumentNullException("restSerializer"); }

            _item1Serializer = item1Serializer;
            _item2Serializer = item2Serializer;
            _item3Serializer = item3Serializer;
            _item4Serializer = item4Serializer;
            _item5Serializer = item5Serializer;
            _item6Serializer = item6Serializer;
            _item7Serializer = item7Serializer;
            _restSerializer = restSerializer;
        }

        // public properties
        /// <summary>
        /// Gets the Item1 serializer.
        /// </summary>
        public IBsonSerializer<T1> Item1Serializer
        {
            get { return _item1Serializer; }
        }

        /// <summary>
        /// Gets the Item2 serializer.
        /// </summary>
        public IBsonSerializer<T2> Item2Serializer
        {
            get { return _item2Serializer; }
        }

        /// <summary>
        /// Gets the Item3 serializer.
        /// </summary>
        public IBsonSerializer<T3> Item3Serializer
        {
            get { return _item3Serializer; }
        }

        /// <summary>
        /// Gets the Item4 serializer.
        /// </summary>
        public IBsonSerializer<T4> Item4Serializer
        {
            get { return _item4Serializer; }
        }

        /// <summary>
        /// Gets the Item5 serializer.
        /// </summary>
        public IBsonSerializer<T5> Item5Serializer
        {
            get { return _item5Serializer; }
        }

        /// <summary>
        /// Gets the Item6 serializer.
        /// </summary>
        public IBsonSerializer<T6> Item6Serializer
        {
            get { return _item6Serializer; }
        }

        /// <summary>
        /// Gets the Item7 serializer.
        /// </summary>
        public IBsonSerializer<T7> Item7Serializer
        {
            get { return _item7Serializer; }
        }

        /// <summary>
        /// Gets the Rest serializer.
        /// </summary>
        public IBsonSerializer<TRest> RestSerializer
        {
            get { return _restSerializer; }
        }

        // public methods
        /// <summary>
        /// Deserializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> DeserializeValue(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var item1 = context.DeserializeWithChildContext<T1>(_item1Serializer);
            var item2 = context.DeserializeWithChildContext<T2>(_item2Serializer);
            var item3 = context.DeserializeWithChildContext<T3>(_item3Serializer);
            var item4 = context.DeserializeWithChildContext<T4>(_item4Serializer);
            var item5 = context.DeserializeWithChildContext<T5>(_item5Serializer);
            var item6 = context.DeserializeWithChildContext<T6>(_item6Serializer);
            var item7 = context.DeserializeWithChildContext<T7>(_item7Serializer);
            var rest = context.DeserializeWithChildContext<TRest>(_restSerializer);
            context.Reader.ReadEndArray();

            return new Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>(item1, item2, item3, item4, item5, item6, item7, rest);
        }

        /// <summary>
        /// Serializes the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        protected override void SerializeValue(BsonSerializationContext context, Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> value)
        {
            context.Writer.WriteStartArray();
            context.SerializeWithChildContext<T1>(_item1Serializer, value.Item1);
            context.SerializeWithChildContext<T2>(_item2Serializer, value.Item2);
            context.SerializeWithChildContext<T3>(_item3Serializer, value.Item3);
            context.SerializeWithChildContext<T4>(_item4Serializer, value.Item4);
            context.SerializeWithChildContext<T5>(_item5Serializer, value.Item5);
            context.SerializeWithChildContext<T6>(_item6Serializer, value.Item6);
            context.SerializeWithChildContext<T7>(_item7Serializer, value.Item7);
            context.SerializeWithChildContext<TRest>(_restSerializer, value.Rest);
            context.Writer.WriteEndArray();
        }
    }
}
