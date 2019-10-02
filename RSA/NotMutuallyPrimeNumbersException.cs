using System;
using System.Runtime.Serialization;

namespace Crypto
{
    [Serializable]
    internal class NotMutuallyPrimeNumbersException : Exception
    {
        public NotMutuallyPrimeNumbersException()
        {
        }

        public NotMutuallyPrimeNumbersException(string message) : base(message)
        {
        }

        public NotMutuallyPrimeNumbersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotMutuallyPrimeNumbersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}