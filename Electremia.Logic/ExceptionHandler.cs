using System;

namespace Electremia.Logic
{
    public class ExceptionHandler : Exception
    {
        /// <summary>
        /// Exception title.
        /// </summary>
        public string Index { get; }

        /// <inheritdoc />
        /// <summary>
        /// Create the exception with description.
        /// </summary>
        /// <param name="message">Exception description</param>
        public ExceptionHandler(string message) : base(message) { }

        /// <summary>
        /// Create the exception with title and description.
        /// </summary>
        /// <param name="index">Exception title</param>
        /// <param name="message">Exception description</param>
        public ExceptionHandler(string index, string message) : base(message)
        {
            Index = index;
        }
    }
}
