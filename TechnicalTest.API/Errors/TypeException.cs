namespace TechnicalTest.API.Errors
{
    public class TypeException: Exception
    {
        // Constructor sin parámetros.
        public TypeException()
        {
        }

        // Constructor que acepta solo un mensaje.
        public TypeException(string message)
            : base(message)
        {
        }

        // Constructor que acepta un mensaje y una excepción interna.
        public TypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Constructor para la deserialización.
        protected TypeException(System.Runtime.Serialization.SerializationInfo info,
                                 System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
