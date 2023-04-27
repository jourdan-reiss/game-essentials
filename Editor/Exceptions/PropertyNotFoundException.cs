using System;

namespace Editor.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException() { }

        public PropertyNotFoundException(string message) : base(message) { }

        public PropertyNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected PropertyNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}