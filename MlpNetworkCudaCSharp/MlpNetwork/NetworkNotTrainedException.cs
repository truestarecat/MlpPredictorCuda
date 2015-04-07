using System;

namespace MlpNetwork
{
    public class NetworkNotTrainedException : Exception
    {
        public NetworkNotTrainedException()
        {
        }

        public NetworkNotTrainedException(string message)
            : base(message)
        {
        }

        public NetworkNotTrainedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
