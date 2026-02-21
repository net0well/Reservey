namespace Domain.Exceptions
{
    public class InvalidPersonDocumentIdException : Exception
    {
        public InvalidPersonDocumentIdException()
            : base("Documento de identificação inválido.") { }
    }
}