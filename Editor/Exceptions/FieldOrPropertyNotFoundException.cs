using System;

namespace Editor.Exceptions
{
    public class FieldOrPropertyNotFoundException : Exception
    {
        public FieldOrPropertyNotFoundException()
        {
        }

        public FieldOrPropertyNotFoundException(string message) : base(message)
        {
        }

        public FieldOrPropertyNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FieldOrPropertyNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}