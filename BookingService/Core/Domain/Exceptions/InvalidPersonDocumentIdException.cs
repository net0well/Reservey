namespace Domain.Exceptions
{
    public class InvalidPersonDocumentIdException : Exception
    {
        public InvalidPersonDocumentIdException()
            : base("Document is invalid.") { }
    }
}