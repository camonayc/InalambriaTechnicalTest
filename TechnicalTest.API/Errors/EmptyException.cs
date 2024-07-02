namespace TechnicalTest.API.Errors
{
    public class EmptyException : Exception
    {
        // Constructor sin parámetros.
        public EmptyException()
        {
        }

        // Constructor que acepta solo un mensaje.
        public EmptyException(string message)
            : base(message)
        {
        }

        // Constructor que acepta un mensaje y una excepción interna.
        public EmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Constructor para la deserialización.
        protected EmptyException(System.Runtime.Serialization.SerializationInfo info,
                                 System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
