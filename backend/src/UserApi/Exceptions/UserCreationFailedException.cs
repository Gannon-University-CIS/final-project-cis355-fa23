using System;

namespace UserApi.Exceptions
{
    public class UserCreationFailedException : Exception
    {
        public UserCreationFailedException(string message) : base(message)
        {
        }

        public UserCreationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

        public class RoomCreationFailedException : Exception
    {
        public RoomCreationFailedException(string message) : base(message)
        {
        }

        public RoomCreationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
