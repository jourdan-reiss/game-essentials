using System;

namespace Editor.Exceptions
{
    public class NumericTypeExpectedException : Exception
    {
        public NumericTypeExpectedException() { }

        public NumericTypeExpectedException(string message) : base(message) { }

        public NumericTypeExpectedException(string message, Exception inner) : base(message, inner) { }

        protected NumericTypeExpectedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}